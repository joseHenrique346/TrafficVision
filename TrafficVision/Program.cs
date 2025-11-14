using TrafficVision.Infrastructure.Data.Persistence.DependencyInjection;
using VehicleAPI.Grpc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddInfrastructureInjection(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Simulação Detran com gRPC :P

builder.Services.AddGrpcClient<VehicleService.VehicleServiceClient>(o =>
{
    o.Address = new Uri("https://localhost:44392");
});

// Postgre

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
