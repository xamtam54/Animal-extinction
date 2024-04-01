using Animal_extinction.Context;
using Animal_extinction.Model;
using Microsoft.EntityFrameworkCore;

namespace Animal_extinction.Repository
{
    public interface IViabilityRepository
    {
        Task<List<Viability>> GetAll();
        Task<Viability?> GetViability(int viabilityId);
        Task<Viability> CreateViability(decimal geneticDiversity, decimal reproductionRate, string generalViability);
        Task<Viability?> UpdateViability(int viabilityId, decimal geneticDiversity, decimal reproductionRate, string generalViability);
        Task<Viability?> DeleteViability(int viabilityId);
    }

    public class ViabilityRepository : IViabilityRepository
    {
        private readonly TodoDBContext _db;

        public ViabilityRepository(TodoDBContext db)
        {
            _db = db;
        }

        public async Task<List<Viability>> GetAll()
        {
            return await _db.viability.ToListAsync();
        }

        public async Task<Viability?> GetViability(int viabilityId)
        {
            return await _db.viability.FindAsync(viabilityId);
        }

        public async Task<Viability> CreateViability(decimal geneticDiversity, decimal reproductionRate, string generalViability)
        {
            Viability newViability = new Viability
            {
                GeneticDiversity = geneticDiversity,
                ReproductionRate = reproductionRate,
                GeneralViability = generalViability
            };

            await _db.viability.AddAsync(newViability);
            await _db.SaveChangesAsync();
            return newViability;
        }

        public async Task<Viability?> UpdateViability(int viabilityId, decimal geneticDiversity, decimal reproductionRate, string generalViability)
        {
            Viability? viabilityToUpdate = await GetViability(viabilityId);

            if (viabilityToUpdate != null)
            {
                viabilityToUpdate.GeneticDiversity = geneticDiversity;
                viabilityToUpdate.ReproductionRate = reproductionRate;
                viabilityToUpdate.GeneralViability = generalViability;

                await _db.SaveChangesAsync();
            }

            return viabilityToUpdate;
        }

        public async Task<Viability?> DeleteViability(int viabilityId)
        {
            Viability? viabilityToDelete = await GetViability(viabilityId);

            if (viabilityToDelete != null)
            {
                _db.viability.Remove(viabilityToDelete);
                await _db.SaveChangesAsync();
            }

            return viabilityToDelete;
        }
    }
}
