using Microsoft.AspNetCore.Http;
using OpenCvSharp;
using Tesseract;
using TrafficVision.Domain.Interfaces;
using TrafficVision.Infrastructure.Data;
using Rect = OpenCvSharp.Rect;

public class PlateProcessor : IPlateProcessor
{
    private readonly string _tessdataPath;

    public PlateProcessor()
    {
        _tessdataPath = Path.Combine(AppContext.BaseDirectory, "tessdata");
    }

    public async Task<string> RecognizePlateAsync(IFormFile file)
    {
        var tempPath = Path.GetTempFileName();

        try
        {
            using (var stream = new FileStream(tempPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            using var plateFull = PlateDetector.DetectPlate(tempPath);

            if (plateFull == null || plateFull.Empty())
                return null; // Detector falhou

            using var plateBody = CropHeader(plateFull); // corta cabeçalho

            // caso queira debugar
            Cv2.ImWrite(Path.Combine(AppContext.BaseDirectory, "debug_02_body.png"), plateBody);

            string rawText = PerformOcr(plateBody);

            return ExtractLicensePlate(rawText); // limpa e valida
        }
        finally
        {
            if (File.Exists(tempPath)) File.Delete(tempPath);
        }
    }

    private Mat CropHeader(Mat fullPlate)
    {
        // Corta os 25% superiores da imagem para remover a tarja azul/cidade
        int cropTop = (int)(fullPlate.Height * 0.25);
        int height = fullPlate.Height - cropTop;

        // Verifica se sobrou imagem
        if (height <= 0) return fullPlate;

        var roi = new Rect(0, cropTop, fullPlate.Width, height);
        return new Mat(fullPlate, roi);
    }

    private string PerformOcr(Mat plateMat)
    {
        using var gray = new Mat();
        Cv2.CvtColor(plateMat, gray, ColorConversionCodes.BGR2GRAY);

        using var scaled = new Mat();
        Cv2.Resize(gray, scaled, new Size(0, 0), 2.0, 2.0, InterpolationFlags.Cubic);

        using var denoised = new Mat();
        Cv2.GaussianBlur(scaled, denoised, new Size(3, 3), 0);

        using var thresh = new Mat();
        Cv2.Threshold(denoised, thresh, 0, 255, ThresholdTypes.Otsu | ThresholdTypes.Binary);

        byte[] imgBytes = thresh.ToBytes(".png");

        using var engine = new TesseractEngine(_tessdataPath, "eng", EngineMode.Default);

        engine.SetVariable("tessedit_char_whitelist", "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789");

        using var pix = Pix.LoadFromMemory(imgBytes);
        using var page = engine.Process(pix, PageSegMode.SingleLine);

        return page.GetText();
    }

    private string ExtractLicensePlate(string ocrText)
    {
        if (string.IsNullOrWhiteSpace(ocrText)) return "";

        string clean = ocrText.Replace(" ", "").Replace("-", "")
                              .Replace("\n", "").Replace("\r", "")
                              .Replace(".", "").Replace(":", "")
                              .Replace("_", "")
                              .ToUpper();

        if (clean.Length > 7)
            clean = clean.Substring(clean.Length - 7);

        if (clean.Length != 7)
            return clean;

        char[] chars = clean.ToCharArray();

        for (int i = 0; i < 3; i++)
        {
            chars[i] = FixLetter(chars[i]);
        }

        chars[3] = FixNumber(chars[3]);

        chars[5] = FixNumber(chars[5]);
        chars[6] = FixNumber(chars[6]);

        return new string(chars);
    }

    // Converte números parecidos com letras em letras
    private char FixLetter(char c)
    {
        return c switch
        {
            '0' => 'O',
            '1' => 'I',
            '2' => 'Z',
            '4' => 'A',
            '5' => 'S',
            '8' => 'B',
            _ => c
        };
    }

    // Converte letras parecidas com números em números
    private char FixNumber(char c)
    {
        return c switch
        {
            'O' => '0',
            'Q' => '0',
            'D' => '0',
            'G' => '0',
            'U' => '0',
            'I' => '1',
            'L' => '1',
            'Z' => '2',
            'A' => '4',
            'S' => '5',
            'B' => '8',
            _ => c
        };
    }
}