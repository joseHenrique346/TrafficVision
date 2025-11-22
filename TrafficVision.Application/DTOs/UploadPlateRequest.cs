using Microsoft.AspNetCore.Http;

namespace TrafficVision.Application;

public class UploadPlateRequest
{
    public IFormFile File { get; set; }
}