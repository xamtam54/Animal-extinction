using Animal_extinction.Context;
using Animal_extinction.Model;
using Microsoft.EntityFrameworkCore;

namespace Animal_extinction.Repository
{
    public interface ISpeciesRepository
    {
        Task<List<Species>> GetAll();
        Task<Species?> GetSpecies(int speciesId);
        Task<Species> CreateSpecies(string nameSpecies, string description, string conservationState, int viabilityId);
        Task<Species?> UpdateSpecies(int speciesId, string nameSpecies, string description, string conservationState, int viabilityId);
        Task<Species?> DeleteSpecies(int speciesId);
    }

    public class SpeciesRepository : ISpeciesRepository
    {
        private readonly TodoDBContext _db;

        public SpeciesRepository(TodoDBContext db)
        {
            _db = db;
        }

        public async Task<List<Species>> GetAll()
        {
            return await _db.species.ToListAsync();
        }

        public async Task<Species?> GetSpecies(int speciesId)
        {
            return await _db.species.FindAsync(speciesId);
        }

        public async Task<Species> CreateSpecies(string nameSpecies, string description, string conservationState, int viabilityId)
        {
            Species newSpecies = new Species
            {
                NameSpecies = nameSpecies,
                Description = description,
                ConservationState = conservationState,
                ViabilityId = viabilityId
            };

            await _db.species.AddAsync(newSpecies);
            await _db.SaveChangesAsync();
            return newSpecies;
        }

        public async Task<Species?> UpdateSpecies(int speciesId, string nameSpecies, string description, string conservationState, int viabilityId)
        {
            Species? speciesToUpdate = await GetSpecies(speciesId);

            if (speciesToUpdate != null)
            {
                speciesToUpdate.NameSpecies = nameSpecies;
                speciesToUpdate.Description = description;
                speciesToUpdate.ConservationState = conservationState;
                speciesToUpdate.ViabilityId = viabilityId;

                await _db.SaveChangesAsync();
            }

            return speciesToUpdate;
        }

        public async Task<Species?> DeleteSpecies(int speciesId)
        {
            Species? speciesToDelete = await GetSpecies(speciesId);

            if (speciesToDelete != null)
            {
                _db.species.Remove(speciesToDelete);
                await _db.SaveChangesAsync();
            }

            return speciesToDelete;
        }
    }
}
