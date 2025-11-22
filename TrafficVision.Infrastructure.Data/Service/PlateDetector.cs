using OpenCvSharp;
using Rect = OpenCvSharp.Rect;

namespace TrafficVision.Infrastructure.Data;

public static class PlateDetector
{
    public static Mat DetectPlate(string imagePath)
    {
        using var img = Cv2.ImRead(imagePath);
        if (img.Empty()) return null;

        using var gray = new Mat();
        Cv2.CvtColor(img, gray, ColorConversionCodes.BGR2GRAY);

        using var blur = new Mat();
        Cv2.BilateralFilter(gray, blur, 11, 17, 17); // remove ruído

        using var edged = new Mat();
        Cv2.Canny(blur, edged, 30, 200); // detecta borda
        using var dilated = new Mat();
        var element = Cv2.GetStructuringElement(MorphShapes.Rect, new Size(3, 3)); // engrossa as bordas para fechar retângulos falhados
        Cv2.Dilate(edged, dilated, element);

        // caso queira debugar
        //var debugPath = Path.Combine(AppContext.BaseDirectory, "debug_01_edged.png");
        //Cv2.ImWrite(debugPath, dilated);

        Cv2.FindContours(dilated, out Point[][] contours, out _, RetrievalModes.Tree, ContourApproximationModes.ApproxSimple);

        var sortedContours = contours.OrderByDescending(c => Cv2.ContourArea(c)).Take(15).ToList();

        Rect bestRect = new Rect();
        double bestScore = 0;

        foreach (var contour in sortedContours)
        {
            var perimeter = Cv2.ArcLength(contour, true);
            var approx = Cv2.ApproxPolyDP(contour, 0.02 * perimeter, true);

            var rect = Cv2.BoundingRect(approx);
            double area = rect.Width * rect.Height;

            if (area < 500) continue;

            double ratio = (double)rect.Width / rect.Height;

            if (ratio < 1.5 || ratio > 6.0) continue;

            if (area > bestScore)
            {
                bestScore = area;
                bestRect = rect;
            }
        }

        if (bestRect.Width == 0 || bestRect.Height == 0)
            return null;

        return new Mat(img, bestRect);
    }
}