using MediatR;
using Microsoft.AspNetCore.Mvc;
using TrafficVision.Application.Features.Commands;
using TrafficVision.Domain.Entities;

namespace TrafficVision.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportRegistrationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReportRegistrationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<ReportRegistration>>> GetAllAsync()
        {
            throw new NotImplementedException();
            //var list = await _readRepository.GetAll();
            //return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReportRegistration>> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
            //var result = await _readRepository.GetByIdAsync(id);
            //return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateReportRegistrationCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(result.ListMessageErrors);

            return Ok(result.Content);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] ReportRegistration entity)
        {
            throw new NotImplementedException();
            //await _writeRepository.UpdateAsync(entity);
            //return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(long id)
        {
            throw new NotImplementedException();
            //await _writeRepository.DeleteAsync(id);
            //return Ok();
        }
    }
}
