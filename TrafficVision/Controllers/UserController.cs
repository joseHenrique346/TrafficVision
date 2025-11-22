using MediatR;
using Microsoft.AspNetCore.Mvc;
using TrafficVision.Application.Features.Commands;
using TrafficVision.Domain.Entities;
using TrafficVision.Domain.Interfaces.Repository;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TrafficVision.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public UserController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllAsync()
        {
            throw new NotImplementedException();
            //var users = await _readRepository.GetAll();
            //return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
            //var user = await _readRepository.GetByIdAsync(id);
            //return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] CreateUserCommand command)
        {
            var result = await _mediatr.Send(command);

            if (!result.IsSuccess)
                return BadRequest(result.ListMessageErrors);

            return Ok(result.Content);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] User user)
        {
            throw new NotImplementedException();
            //await _writeRepository.UpdateAsync(user);
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
