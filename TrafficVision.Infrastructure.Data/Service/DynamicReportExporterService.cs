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
                page.Margin(25);
                page.Size(PageSizes.A4);
                page.PageColor(Colors.White);

                page.Header().Row(row =>
                {
                    row.RelativeItem(1).Column(col =>
                    {
                        col.Item().AlignLeft().Image(_logoPath, ImageScaling.FitWidth);
                    });

                    row.RelativeItem(3).Column(col =>
                    {
                        col.Item().AlignRight()
                            .Text("Relatório Dinâmico de Veículos")
                            .FontSize(22)
                            .SemiBold()
                            .FontColor("#f5c542"); // Dourado TrafficVision

                        col.Item().AlignRight().Text($"Período: {_report.InitialDate:dd/MM/yyyy} → {_report.FinalDate?.ToString("dd/MM/yyyy") ?? "Hoje"}");
                        col.Item().AlignRight().Text($"Total encontrado: {_vehicles.Count()} veículos");
                    });
                });

                page.Content().PaddingVertical(15).Table(table =>
                {
                    table.ColumnsDefinition(cols =>
                    {
                        cols.RelativeColumn(2); // Modelo
                        cols.RelativeColumn(2); // Marca
                        cols.RelativeColumn(1); // Ano
                        cols.RelativeColumn(1); // Cor
                        cols.RelativeColumn(2); // Cidade
                        cols.RelativeColumn(2); // Situação
                    });

                    table.Header(header =>
                    {
                        header.Cell().Background("#222").Padding(4).Text("Modelo").FontColor("#FFF");
                        header.Cell().Background("#222").Padding(4).Text("Marca").FontColor("#FFF");
                        header.Cell().Background("#222").Padding(4).Text("Ano").FontColor("#FFF");
                        header.Cell().Background("#222").Padding(4).Text("Cor").FontColor("#FFF");
                        header.Cell().Background("#222").Padding(4).Text("Município").FontColor("#FFF");
                        header.Cell().Background("#222").Padding(4).Text("Situação").FontColor("#FFF");
                    });

                    foreach (var v in _vehicles)
                    {
                        table.Cell().Padding(3).Text(v.Model);
                        table.Cell().Padding(3).Text(v.Brand);
                        table.Cell().Padding(3).Text(v.Year.ToString());
                        table.Cell().Padding(3).Text(v.Color);
                        table.Cell().Padding(3).Text($"{v.VehicleSpec.Municipality}/{v.VehicleSpec.State}");

                        var status = $"{v.VehicleSpec.VehicleRestriction.TheftVehicleCondition}";
                        if (v.VehicleSpec.VehicleRestriction.Wrecked) status += " • Sinistrado";
                        if (v.VehicleSpec.VehicleRestriction.JudicialRestriction) status += " • Judicial";
                        if (v.VehicleSpec.VehicleRestriction.Auction) status += " • Leilão";

                        table.Cell().Padding(3).Text(status);
                    }
                });

                page.Footer().Column(col =>
                {
                    col.Item().AlignCenter().Text(x =>
                    {
                        x.Span("Página ").FontSize(10);
                        x.CurrentPageNumber().FontSize(10);
                        x.Span(" de ").FontSize(10);
                        x.TotalPages().FontSize(10);
                    });

                    col.Item().AlignCenter().Text($"Gerado em: {DateTime.Now:dd/MM/yyyy HH:mm:ss}")
                        .FontSize(9)
                        .FontColor(Colors.Grey.Darken2);
                });
            });
        }
    }
}
