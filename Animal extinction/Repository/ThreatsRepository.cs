using Animal_extinction.Context;
using Animal_extinction.Model;
using Microsoft.EntityFrameworkCore;

namespace Animal_extinction.Repository
{
    public interface IThreatsRepository
    {
        Task<List<Threats>> GetAll();
        Task<Threats?> GetThreat(int threatsId);
        Task<Threats> CreateThreat(string nameThreats, string descriptionThreats, string threatsLevel, int viabilityId);
        Task<Threats?> UpdateThreat(int threatsId, string nameThreats, string descriptionThreats, string threatsLevel, int viabilityId);
        Task<Threats?> DeleteThreat(int threatsId);
    }

    public class ThreatsRepository : IThreatsRepository
    {
        private readonly TodoDBContext _db;

        public ThreatsRepository(TodoDBContext db)
        {
            _db = db;
        }

        public async Task<List<Threats>> GetAll()
        {
            return await _db.threats.ToListAsync();
        }

        public async Task<Threats?> GetThreat(int threatsId)
        {
            return await _db.threats.FindAsync(threatsId);
        }

        public async Task<Threats> CreateThreat(string nameThreats, string descriptionThreats, string threatsLevel, int viabilityId)
        {
            Threats newThreat = new Threats
            {
                NameThreats = nameThreats,
                DescriptionThreats = descriptionThreats,
                ThreatsLevel = threatsLevel,
                ViabilityId = viabilityId
            };

            await _db.threats.AddAsync(newThreat);
            await _db.SaveChangesAsync();
            return newThreat;
        }

        public async Task<Threats?> UpdateThreat(int threatsId, string nameThreats, string descriptionThreats, string threatsLevel, int viabilityId)
        {
            Threats? threatToUpdate = await GetThreat(threatsId);

            if (threatToUpdate != null)
            {
                threatToUpdate.NameThreats = nameThreats;
                threatToUpdate.DescriptionThreats = descriptionThreats;
                threatToUpdate.ThreatsLevel = threatsLevel;
                threatToUpdate.ViabilityId = viabilityId;

                await _db.SaveChangesAsync();
            }

            return threatToUpdate;
        }

        public async Task<Threats?> DeleteThreat(int threatsId)
        {
            Threats? threatToDelete = await GetThreat(threatsId);

            if (threatToDelete != null)
            {
                _db.threats.Remove(threatToDelete);
                await _db.SaveChangesAsync();
            }

            return threatToDelete;
        }
    }
}
