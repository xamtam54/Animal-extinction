using Animal_extinction.Model;
using Animal_extinction.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Animal_extinction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IObservationsRepository _observationsRepository;
        public ValuesController(IObservationsRepository observationsRepository)
        {
            _observationsRepository = observationsRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Observations>>> GetAll()
        {
           return Ok(await _observationsRepository.GetAll());
        }

        [HttpGet("{observationsId}")]
        public async Task<ActionResult<List<Observations>>> GetObservation(int observationsId)
        {
            var Observations = await _observationsRepository.GetObservation(observationsId);
            if (Observations == null)
            {
                return BadRequest("User not found");
            }

            return Ok(Observations);
        }

    }
}
