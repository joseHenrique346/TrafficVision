using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using TrafficVision.Application.Interface;
using TrafficVision.Domain.Entities;

namespace TrafficVision.Infrastructure.Data;

public class DynamicReportExporterService : IDynamicReportExporter
{
    private readonly string _logoPath;

    public DynamicReportExporterService(string logoPath)
    {
        _logoPath = logoPath;
    }

    public async Task<byte[]> ExportToPdfAsync(DynamicReport report, IEnumerable<Vehicle> vehicles)
    {
        var model = new ReportDocument(report, vehicles, _logoPath);
        var pdf = model.GeneratePdf();
        return await Task.FromResult(pdf);
    }

    private class ReportDocument : IDocument
    {
        private readonly DynamicReport _report;
        private readonly IEnumerable<Vehicle> _vehicles;
        private readonly string _logoPath;

        public ReportDocument(DynamicReport report, IEnumerable<Vehicle> vehicles, string logoPath)
        {
            _report = report;
            _vehicles = vehicles;
            _logoPath = logoPath;
        }

        public DocumentMetadata GetMetadata() => new DocumentMetadata();

        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Margin(20);
                page.Size(PageSizes.A4.Landscape());
                page.PageColor(Colors.White);

                page.Header()
                    .Background("#222") 
                    .Padding(15)      
                    .Row(row =>
                    {
                        row.RelativeItem(1).AlignMiddle().Column(col =>
                        {
                            col.Item()
                                .Height(50) 
                                .AlignLeft()
                                .Image(_logoPath, ImageScaling.FitHeight);
                        });

                        row.RelativeItem(3).AlignMiddle().Column(col =>
                        {
                            col.Item().AlignRight()
                                .Text("Relatório Dinâmico de Veículos")
                                .FontSize(20)
                                .SemiBold()
                                .FontColor("#f5c542"); // Dourado TrafficVision

                            col.Item().AlignRight()
                                .Text($"Período: {_report.InitialDate:dd/MM/yyyy} → {_report.FinalDate?.ToString("dd/MM/yyyy") ?? "Hoje"}")
                                .FontSize(10)
                                .FontColor(Colors.White);

                            col.Item().AlignRight()
                                .Text($"Total encontrado: {_vehicles.Count()} veículos")
                                .FontSize(10)
                                .FontColor(Colors.White);
                        });
                    });

                page.Content().PaddingVertical(10).Table(table =>
                {
                    table.ColumnsDefinition(cols =>
                    {
                        cols.RelativeColumn(1.2f);
                        cols.RelativeColumn(1.2f);
                        cols.ConstantColumn(35);
                        cols.RelativeColumn(0.8f);
                        cols.RelativeColumn(1.3f);
                        cols.RelativeColumn(1.5f);
                        cols.RelativeColumn(1.5f);
                        cols.RelativeColumn(1.2f);
                        cols.RelativeColumn(1.8f);
                    });

                    static IContainer CellHeader(IContainer container) =>
                        container.Background("#333").Padding(4).BorderBottom(1).BorderColor(Colors.Black); 

                    table.Header(header =>
                    {
                        header.Cell().Element(CellHeader).Text("Modelo").FontColor("#FFF").Bold().FontSize(9);
                        header.Cell().Element(CellHeader).Text("Marca").FontColor("#FFF").Bold().FontSize(9);
                        header.Cell().Element(CellHeader).Text("Ano").FontColor("#FFF").Bold().FontSize(9);
                        header.Cell().Element(CellHeader).Text("Cor").FontColor("#FFF").Bold().FontSize(9);
                        header.Cell().Element(CellHeader).Text("Placa").FontColor("#FFF").Bold().FontSize(9);
                        header.Cell().Element(CellHeader).Text("Município").FontColor("#FFF").Bold().FontSize(9);
                        header.Cell().Element(CellHeader).Text("Registrado em").FontColor("#FFF").Bold().FontSize(9);
                        header.Cell().Element(CellHeader).Text("Status").FontColor("#FFF").Bold().FontSize(9);
                        header.Cell().Element(CellHeader).Text("Restrições").FontColor("#FFF").Bold().FontSize(9);
                    });

                    static IContainer CellData(IContainer container) =>
                        container.BorderBottom(1).BorderColor(Colors.Grey.Lighten2).PaddingVertical(4).PaddingHorizontal(2);

                    foreach (var v in _vehicles)
                    {
                        var theftCondition = v.VehicleSpec.VehicleRestriction.TheftVehicleCondition.ToString() ?? "";
                        bool isRobbed = !string.IsNullOrEmpty(theftCondition) &&
                                        (theftCondition.Contains("Roubado") || theftCondition.Contains("Furto"));

                        var listRestrictions = new List<string>();
                        if (v.VehicleSpec.VehicleRestriction.Wrecked) listRestrictions.Add("Sinistrado");
                        if (v.VehicleSpec.VehicleRestriction.JudicialRestriction) listRestrictions.Add("Judicial");
                        if (v.VehicleSpec.VehicleRestriction.Auction) listRestrictions.Add("Leilão");

                        var textRestrictions = listRestrictions.Any() ? string.Join(" • ", listRestrictions) : "-";

                        table.Cell().Element(CellData).Text(v.Model).FontSize(8);
                        table.Cell().Element(CellData).Text(v.Brand).FontSize(8);
                        table.Cell().Element(CellData).Text(v.Year.ToString()).FontSize(8).AlignCenter();
                        table.Cell().Element(CellData).Text(v.Color).FontSize(8);
                        table.Cell().Element(CellData).Text(v.VehicleSpec.Plate).FontSize(8).SemiBold();
                        table.Cell().Element(CellData).Text($"{v.VehicleSpec.Municipality}/{v.VehicleSpec.State}").FontSize(8);
                        table.Cell().Element(CellData).Text(v.CreatedAt.ToString("dd/MM/yyyy HH:mm")).FontSize(8);

                        table.Cell().Element(CellData).Text(text =>
                        {
                            if (isRobbed)
                                text.Span(theftCondition).Bold().FontColor(Colors.Red.Medium);
                            else
                                text.Span("Sem Queixa").FontColor(Colors.Green.Darken2);
                        });

                        table.Cell().Element(CellData).Text(textRestrictions).FontSize(8).FontColor(Colors.Grey.Darken3);
                    }
                });

                page.Footer().PaddingTop(5).Row(row =>
                {
                    row.RelativeItem().Text($"Gerado em: {DateTime.Now:dd/MM/yyyy HH:mm:ss}")
                        .FontSize(8).FontColor(Colors.Grey.Darken2);

                    row.RelativeItem().AlignRight().Text(x =>
                    {
                        x.Span("Página ").FontSize(8);
                        x.CurrentPageNumber().FontSize(8);
                        x.Span(" de ").FontSize(8);
                        x.TotalPages().FontSize(8);
                    });
                });
            });
        }
    }
}