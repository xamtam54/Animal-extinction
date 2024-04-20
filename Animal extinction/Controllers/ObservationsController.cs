using Animal_extinction.Model;
using Animal_extinction.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Animal_extinction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObservationsController : ControllerBase
    {
        private readonly IObservationsService _observationsService;

        public ObservationsController(IObservationsService observationsService)
        {
            _observationsService = observationsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Observations>>> GetAll()
        {
            return Ok(await _observationsService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Observations>> GetObservation(int id)
        {
            var observation = await _observationsService.GetObservation(id);
            if (observation == null)
            {
                return BadRequest("Observation not found");
            }
            return Ok(observation);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Observations>> UpdateObservation(int id, int SpecieId)
        {
            var observation = await _observationsService.UpdateObservation(id, SpecieId);
            if (observation == null)
            {
                return BadRequest("Observation not found");
            }
            return Ok(observation);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Observations>> DeleteObservation(int id)
        {
            var observation = await _observationsService.DeleteObservation(id);
            if (observation == null)
            {
                return BadRequest("Observation not found");
            }
            return Ok(observation);
        }

        [HttpPost]
        public async Task<ActionResult<Observations>> CreateObservation(int SpecieId)
        {
            return await _observationsService.CreateObservation(SpecieId);
        }
    }
}
