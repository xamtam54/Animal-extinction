using Animal_extinction.Model;
using Animal_extinction.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Animal_extinction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeciesController : ControllerBase
    {
        private readonly ISpeciesService _speciesService;

        public SpeciesController(ISpeciesService speciesService)
        {
            _speciesService = speciesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Species>>> GetAll()
        {
            return Ok(await _speciesService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Species>> GetSpecies(int id)
        {
            var species = await _speciesService.GetSpecies(id);
            if (species == null)
            {
                return BadRequest("Species not found");
            }
            return Ok(species);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Species>> UpdateSpecies(int id, string nameSpecies, string description, string conservationState, int viabilityId)
        {
            var species = await _speciesService.UpdateSpecies(id, nameSpecies, description, conservationState, viabilityId);
            if (species == null)
            {
                return BadRequest("Species not found");
            }
            return Ok(species);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Species>> DeleteSpecies(int id)
        {
            var species = await _speciesService.DeleteSpecies(id);
            if (species == null)
            {
                return BadRequest("Species not found");
            }
            return Ok(species);
        }

        [HttpPost]
        public async Task<ActionResult<Species>> CreateSpecies(string nameSpecies, string description, string conservationState, int viabilityId)
        {
            return await _speciesService.CreateSpecies(nameSpecies, description, conservationState, viabilityId);
        }
    }
}
