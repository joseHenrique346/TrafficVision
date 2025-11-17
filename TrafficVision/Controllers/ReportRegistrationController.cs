using Microsoft.AspNetCore.Mvc;
using TrafficVision.Domain.Entities;
using TrafficVision.Domain.Interfaces.Repository;

namespace TrafficVision.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportRegistrationController : ControllerBase
    {
        private readonly IReadReportRegistrationRepository _readRepository;
        private readonly IWriteReportRegistrationRepository _writeRepository;

        public ReportRegistrationController(
            IReadReportRegistrationRepository readRepository,
            IWriteReportRegistrationRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
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
        public async Task<ActionResult> CreateAsync([FromBody] ReportRegistration entity)
        {
            throw new NotImplementedException();
            //await _writeRepository.AddAsync(entity);
            //return Ok();
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
