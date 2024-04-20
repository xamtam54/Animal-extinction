using Animal_extinction.Model;
using Animal_extinction.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Animal_extinction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailObController : ControllerBase
    {
        private readonly IDetailObservationsService _detailObservationsService;

        public DetailObController(IDetailObservationsService detailObservationsService)
        {
            _detailObservationsService = detailObservationsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<DetailObservations>>> GetAll()
        {
            return Ok(await _detailObservationsService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DetailObservations>> GetGame(int id)
        {
            var user = await _detailObservationsService.GetDetailObservation(id);
            if (user == null)
            {
                return BadRequest("Game not found");
            }

            return Ok(user);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<DetailObservations>> UpdateGame(int id, int ObservationId, DateOnly ObservationDate, string ObservationType, string Ubication, string Behaviors)
        {
            var user = await _detailObservationsService.GetDetailObservation(id);
            if (user == null)
            {
                return BadRequest("Game not found");
            }

            return Ok(await _detailObservationsService.UpdateDetailObservation(id, ObservationId, ObservationDate,  ObservationType,  Ubication,  Behaviors));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DetailObservations>> DeleteGame(int id)
        {
            var user = await _detailObservationsService.GetDetailObservation(id);
            if (user == null)
            {
                return BadRequest("Game not found");
            }
            return Ok(await _detailObservationsService.DeleteDetailObservation(id));
        }

        [HttpPost]
        public async Task<ActionResult<DetailObservations>> CreateDetailObservation(int ObservationId, DateOnly ObservationDate, string ObservationType, string Ubication, string Behaviors)
        {
            return await _detailObservationsService.CreateDetailObservation(ObservationId,  ObservationDate,  ObservationType,  Ubication,  Behaviors);
        }
    }
}
