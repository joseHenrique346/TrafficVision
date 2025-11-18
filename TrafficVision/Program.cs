using FluentValidation;
using MediatR;
using TrafficVision.Api.Service;
using TrafficVision.Application.Features.Behaviour;
using TrafficVision.Application.Features.Commands;
using TrafficVision.Application.Interface;
using TrafficVision.Infrastructure.Data.Persistence.DependencyInjection;
using VehicleAPI.Grpc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Postgre
builder.Services.AddInfrastructureInjection(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IReportRegistrationService, ReportRegistrationService>();

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(CreateReportRegistrationCommand).Assembly));

builder.Services.AddValidatorsFromAssembly(typeof(CreateReportRegistrationCommandValidator).Assembly);

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

// Simulação Detran com gRPC :P

builder.Services.AddGrpcClient<VehicleService.VehicleServiceClient>(o =>
{
    o.Address = new Uri("https://localhost:44392");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
