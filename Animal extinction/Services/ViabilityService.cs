using Animal_extinction.Model;
using Animal_extinction.Repository;

namespace Animal_extinction.Services
{
    public interface IViabilityService
    {
        Task<List<Viability>> GetAll();
        Task<Viability?> GetViability(int viabilityId);
        Task<Viability> CreateViability(decimal geneticDiversity, decimal reproductionRate, string generalViability);
        Task<Viability?> UpdateViability(int viabilityId, decimal geneticDiversity, decimal reproductionRate, string generalViability);
        Task<Viability?> DeleteViability(int viabilityId);
    }

    public class ViabilityService : IViabilityService
    {
        private readonly IViabilityRepository _viabilityRepository;

        public ViabilityService(IViabilityRepository viabilityRepository)
        {
            _viabilityRepository = viabilityRepository;
        }

        public async Task<Viability> CreateViability(decimal geneticDiversity, decimal reproductionRate, string generalViability)
        {
            return await _viabilityRepository.CreateViability(geneticDiversity, reproductionRate, generalViability);
        }

        public async Task<Viability?> DeleteViability(int viabilityId)
        {
            return await _viabilityRepository.DeleteViability(viabilityId);
        }

        public async Task<List<Viability>> GetAll()
        {
            return await _viabilityRepository.GetAll();
        }

        public async Task<Viability?> GetViability(int viabilityId)
        {
            return await _viabilityRepository.GetViability(viabilityId);
        }
        public async Task<Viability?> UpdateViability(int viabilityId, decimal geneticDiversity = -1, decimal reproductionRate = -1, string? generalViability = null)
        {
            Viability? viabilityToUpdate = await _viabilityRepository.GetViability(viabilityId);

            if (viabilityToUpdate != null)
            {
                if (geneticDiversity != -1) viabilityToUpdate.GeneticDiversity = geneticDiversity;
                if (reproductionRate != -1) viabilityToUpdate.ReproductionRate = reproductionRate;
                if (generalViability != null) viabilityToUpdate.GeneralViability = generalViability;

                await _viabilityRepository.UpdateViability(viabilityId, viabilityToUpdate.GeneticDiversity, viabilityToUpdate.ReproductionRate, viabilityToUpdate.GeneralViability);
            }

            return viabilityToUpdate;
        }
    }
}