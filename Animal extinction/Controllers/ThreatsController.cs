using Animal_extinction.Model;
using Animal_extinction.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Animal_extinction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThreatsController : ControllerBase
    {
        private readonly IThreatsService _threatsService;

        public ThreatsController(IThreatsService threatsService)
        {
            _threatsService = threatsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Threats>>> GetAll()
        {
            return Ok(await _threatsService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Threats>> GetThreat(int id)
        {
            var threat = await _threatsService.GetThreat(id);
            if (threat == null)
            {
                return BadRequest("Threat not found");
            }
            return Ok(threat);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Threats>> UpdateThreat(int id, string nameThreats, string descriptionThreats, string threatsLevel, int viabilityId)
        {
            var threat = await _threatsService.UpdateThreat(id, nameThreats, descriptionThreats, threatsLevel, viabilityId);
            if (threat == null)
            {
                return BadRequest("Threat not found");
            }
            return Ok(threat);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Threats>> DeleteThreat(int id)
        {
            var threat = await _threatsService.DeleteThreat(id);
            if (threat == null)
            {
                return BadRequest("Threat not found");
            }
            return Ok(threat);
        }

        [HttpPost]
        public async Task<ActionResult<Threats>> CreateThreat(string nameThreats, string descriptionThreats, string threatsLevel, int viabilityId)
        {
            return await _threatsService.CreateThreat(nameThreats, descriptionThreats, threatsLevel, viabilityId);
        }
    }
}
