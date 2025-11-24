using FluentValidation;
using MediatR;
using QuestPDF.Infrastructure;
using TrafficVision.Api.Service;
using TrafficVision.Application.Features.Behaviour;
using TrafficVision.Application.Features.Commands;
using TrafficVision.Application.Interface;
using TrafficVision.Infrastructure.Data;
using TrafficVision.Infrastructure.Data.Persistence.DependencyInjection;
using VehicleAPI.Grpc;

QuestPDF.Settings.License = LicenseType.Community;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services.AddControllers();
// Postgre
builder.Services.AddInfrastructureInjection(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IReportRegistrationService, ReportRegistrationService>();
builder.Services.AddScoped<IDynamicReportExporter>(sp =>
{
    var env = sp.GetRequiredService<IWebHostEnvironment>();
    var config = sp.GetRequiredService<IConfiguration>();

    var relativePath = config["Assets:LogoPath"];
    var absolutePath = Path.Combine(env.WebRootPath, relativePath);

    return new DynamicReportExporterService(absolutePath);
});

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(CreateReportRegistrationCommand).Assembly));

builder.Services.AddValidatorsFromAssembly(typeof(CreateReportRegistrationCommandValidator).Assembly);

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

// Simulação Detran com gRPC :P

builder.Services.AddGrpcClient<VehicleService.VehicleServiceClient>(options =>
{
    options.Address = new Uri("https://localhost:7022");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
