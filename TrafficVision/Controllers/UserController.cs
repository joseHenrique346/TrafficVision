using Microsoft.AspNetCore.Mvc;
using TrafficVision.Domain.Entities;
using TrafficVision.Domain.Interfaces.Repository;

namespace TrafficVision.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IReadUserRepository _readRepository;
        private readonly IWriteUserRepository _writeRepository;

        public UserController(IReadUserRepository readRepository, IWriteUserRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
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
        public async Task<ActionResult> CreateAsync([FromBody] User user)
        {
            throw new NotImplementedException();
            //await _writeRepository.AddAsync(user);
            //return Ok();
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
