using Microsoft.AspNetCore.Http;

namespace TrafficVision.Domain.Interfaces;

public interface IPlateProcessor
{
    Task<string> RecognizePlateAsync(IFormFile file);
}