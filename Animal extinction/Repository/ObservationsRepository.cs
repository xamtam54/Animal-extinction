using Animal_extinction.Context;
using Animal_extinction.Model;
using Microsoft.EntityFrameworkCore;

namespace Animal_extinction.Repository
{
    public interface IObservationsRepository
    {
        Task<List<Observations>> GetAll();
        Task<Observations?> GetObservation(int ObservationsId);
        Task<Observations> CreateObservation(int SpecieId);
        Task<Observations?> UpdateObservation(int ObservationsId, int SpecieId);
        Task<Observations?> DeleteObservation(int ObservationsId);
    }

    public class ObservationsRepository : IObservationsRepository
    {
        private readonly TodoDBContext _db;
        public ObservationsRepository(TodoDBContext db)
        {
            _db = db;
        }

        public async Task<List<Observations>> GetAll()
        {
            return await _db.observations.ToListAsync();
        }

        public async Task<Observations?> GetObservation(int ObservationsId)
        {
            return await _db.observations.FindAsync(ObservationsId);
        }

        public async Task<Observations> CreateObservation(int SpecieId)
        {
            Observations newObservation = new Observations
            {
                SpecieId = SpecieId
            };

            await _db.observations.AddAsync(newObservation);
            await _db.SaveChangesAsync();
            return newObservation;
        }

        public async Task<Observations?> UpdateObservation(int ObservationsId, int SpecieId)
        {
            Observations? observationToUpdate = await GetObservation(ObservationsId);

            if (observationToUpdate != null)
            {
                observationToUpdate.SpecieId = SpecieId;

                await _db.SaveChangesAsync();
            }

            return observationToUpdate;
        }

        public async Task<Observations?> DeleteObservation(int ObservationsId)
        {
            Observations? observationToDelete = await GetObservation(ObservationsId);

            if (observationToDelete != null)
            {
                _db.observations.Remove(observationToDelete);
                await _db.SaveChangesAsync();
            }

            return observationToDelete;
        }
    }
}
