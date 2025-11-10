namespace TrafficVision.Application.Features.Commands;

public record UpdateReportRegistrationCommand(long id, long userId, string plate) { }
