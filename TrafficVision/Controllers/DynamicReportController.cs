using MediatR;
using Microsoft.AspNetCore.Mvc;
using TrafficVision.Application.Features.Commands;

namespace TrafficVision.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DynamicReportController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DynamicReportController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("generate")]
        public async Task<IActionResult> Generate([FromBody] CreateDynamicReportCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(result.ListMessageErrors);

            var pdfBytes = result.Content;

            return File(pdfBytes, "application/pdf", "relatorio-dinamico.pdf");
        }
    }
}