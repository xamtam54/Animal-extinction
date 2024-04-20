using Animal_extinction.Context;
using Animal_extinction.Model;
using Animal_extinction.Repository;
using Microsoft.EntityFrameworkCore;

namespace Animal_extinction.Services
{
    public interface IThreatsService
    {
        Task<List<Threats>> GetAll();
        Task<Threats?> GetThreat(int threatsId);
        Task<Threats> CreateThreat(string nameThreats, string descriptionThreats, string threatsLevel, int viabilityId);
        Task<Threats?> UpdateThreat(int threatsId, string nameThreats, string descriptionThreats, string threatsLevel, int viabilityId);
        Task<Threats?> DeleteThreat(int threatsId);
    }

    public class ThreatsService : IThreatsService
    {
        private readonly IThreatsRepository _threatsRepository;

        public ThreatsService(IThreatsRepository threatsRepository)
        {
            _threatsRepository = threatsRepository;
        }

        public async Task<Threats> CreateThreat(string nameThreats, string descriptionThreats, string threatsLevel, int viabilityId)
        {
            return await _threatsRepository.CreateThreat(nameThreats, descriptionThreats, threatsLevel, viabilityId);
        }

        public async Task<Threats?> DeleteThreat(int threatsId)
        {
            return await _threatsRepository.DeleteThreat(threatsId);
        }

        public async Task<List<Threats>> GetAll()
        {
            return await _threatsRepository.GetAll();
        }

        public async Task<Threats?> GetThreat(int threatsId)
        {
            return await _threatsRepository.GetThreat(threatsId);
        }

        public async Task<Threats?> UpdateThreat(int threatsId, string? nameThreats = null, string? descriptionThreats = null, string? threatsLevel = null, int viabilityId = -1)
        {
            Threats? threatToUpdate = await _threatsRepository.GetThreat(threatsId);

            if (threatToUpdate != null)
            {
                if (nameThreats != null) threatToUpdate.NameThreats = nameThreats;
                if (descriptionThreats != null) threatToUpdate.DescriptionThreats = descriptionThreats;
                if (threatsLevel != null) threatToUpdate.ThreatsLevel = threatsLevel;
                if (viabilityId != -1) threatToUpdate.ViabilityId = viabilityId;

                return await _threatsRepository.UpdateThreat(threatsId, threatToUpdate.NameThreats, threatToUpdate.DescriptionThreats, threatToUpdate.ThreatsLevel, threatToUpdate.ViabilityId);
            }

            return null;
        }
    }
}
