using Animal_extinction.Model;
using Animal_extinction.Repository;

namespace Animal_extinction.Services
{
    public interface ISpeciesService
    {
        Task<List<Species>> GetAll();
        Task<Species?> GetSpecies(int speciesId);
        Task<Species> CreateSpecies(string nameSpecies, string description, string conservationState, int viabilityId);
        Task<Species?> UpdateSpecies(int speciesId, string nameSpecies, string description, string conservationState, int viabilityId);
        Task<Species?> DeleteSpecies(int speciesId);
    }

    public class SpeciesService : ISpeciesService
    {
        private readonly ISpeciesRepository _speciesRepository;

        public SpeciesService(ISpeciesRepository speciesRepository)
        {
            _speciesRepository = speciesRepository;
        }

        public async Task<Species> CreateSpecies(string nameSpecies, string description, string conservationState, int viabilityId)
        {
            return await _speciesRepository.CreateSpecies(nameSpecies, description, conservationState, viabilityId);
        }

        public async Task<Species?> DeleteSpecies(int speciesId)
        {
            return await _speciesRepository.DeleteSpecies(speciesId);
        }

        public async Task<List<Species>> GetAll()
        {
            return await _speciesRepository.GetAll();
        }

        public async Task<Species?> GetSpecies(int speciesId)
        {
            return await _speciesRepository.GetSpecies(speciesId);
        }

        public async Task<Species?> UpdateSpecies(int speciesId, string? nameSpecies = null, string? description = null, string? conservationState = null, int viabilityId = -1)
        {
            Species? speciesToUpdate = await _speciesRepository.GetSpecies(speciesId);

            if (speciesToUpdate != null)
            {
                if (nameSpecies != null) speciesToUpdate.NameSpecies = nameSpecies;
                if (description != null) speciesToUpdate.Description = description;
                if (conservationState != null) speciesToUpdate.ConservationState = conservationState;
                if (viabilityId != -1) speciesToUpdate.ViabilityId = viabilityId;

                return await _speciesRepository.UpdateSpecies(speciesId, speciesToUpdate.NameSpecies, speciesToUpdate.Description, speciesToUpdate.ConservationState, speciesToUpdate.ViabilityId);
            }

            return null;
        }
    }
}