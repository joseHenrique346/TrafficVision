using TrafficVision.Domain.Entities;

namespace TrafficVision.Application.Interface;

public interface IDynamicReportExporter
{
    Task<byte[]> ExportToPdfAsync(DynamicReport report, IEnumerable<Vehicle> vehicles);
}