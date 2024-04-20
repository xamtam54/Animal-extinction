using Animal_extinction.Model;
using Animal_extinction.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Animal_extinction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViabilityController : ControllerBase
    {
        private readonly IViabilityService _viabilityService;

        public ViabilityController(IViabilityService viabilityService)
        {
            _viabilityService = viabilityService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Viability>>> GetAll()
        {
            return Ok(await _viabilityService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Viability>> GetViability(int id)
        {
            var viability = await _viabilityService.GetViability(id);
            if (viability == null)
            {
                return BadRequest("Viability not found");
            }
            return Ok(viability);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Viability>> UpdateViability(int id, decimal geneticDiversity, decimal reproductionRate, string generalViability)
        {
            var viability = await _viabilityService.UpdateViability(id, geneticDiversity, reproductionRate, generalViability);
            if (viability == null)
            {
                return BadRequest("Viability not found");
            }
            return Ok(viability);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Viability>> DeleteViability(int id)
        {
            var viability = await _viabilityService.DeleteViability(id);
            if (viability == null)
            {
                return BadRequest("Viability not found");
            }
            return Ok(viability);
        }

        [HttpPost]
        public async Task<ActionResult<Viability>> CreateViability(decimal geneticDiversity, decimal reproductionRate, string generalViability)
        {
            return await _viabilityService.CreateViability(geneticDiversity, reproductionRate, generalViability);
        }
    }
}
