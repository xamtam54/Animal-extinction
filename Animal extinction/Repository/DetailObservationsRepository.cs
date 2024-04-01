using Animal_extinction.Context;
using Animal_extinction.Model;
using Microsoft.EntityFrameworkCore;

namespace Animal_extinction.Repository
{
    public interface IDetailObservationsRepository
    {
        Task<List<DetailObservations>> GetAll();
        Task<DetailObservations?> GetDetailObservation(int DetailObservationsId);
        Task<DetailObservations> CreateDetailObservation(int ObservationId, DateOnly ObservationDate, string ObservationType, string Ubication, string Behaviors);
        Task<DetailObservations?> UpdateDetailObservation(int DetailObservationsId, int ObservationId, DateOnly ObservationDate, string ObservationType, string Ubication, string Behaviors);
        Task<DetailObservations?> DeleteDetailObservation(int DetailObservationsId);
    }

    public class DetailObservationsRepository : IDetailObservationsRepository
    {
        private readonly TodoDBContext _db;
        public DetailObservationsRepository(TodoDBContext db)
        {
            _db = db;
        }

        public async Task<List<DetailObservations>> GetAll()
        {
            return await _db.detailObservations.ToListAsync();
        }

        public async Task<DetailObservations?> GetDetailObservation(int DetailObservationsId)
        {
            return await _db.detailObservations.FindAsync(DetailObservationsId);
        }

        public async Task<DetailObservations> CreateDetailObservation(int ObservationId, DateOnly ObservationDate, string ObservationType, string Ubication, string Behaviors)
        {
            DetailObservations newDetailObservation = new DetailObservations
            {
                ObservationId = ObservationId,
                ObservationDate = ObservationDate,
                ObservationType = ObservationType,
                Ubication = Ubication,
                Behaviors = Behaviors
            };

            await _db.detailObservations.AddAsync(newDetailObservation);
            _db.SaveChanges();
            return newDetailObservation;
        }

        public async Task<DetailObservations?> UpdateDetailObservation(int DetailObservationsId, int ObservationId, DateOnly ObservationDate, string ObservationType, string Ubication, string Behaviors)
        {
            DetailObservations? detailObservationToUpdate = await GetDetailObservation(DetailObservationsId);

            if (detailObservationToUpdate != null)
            {
                detailObservationToUpdate.ObservationId = ObservationId;
                detailObservationToUpdate.ObservationDate = ObservationDate;
                detailObservationToUpdate.ObservationType = ObservationType;
                detailObservationToUpdate.Ubication = Ubication;
                detailObservationToUpdate.Behaviors = Behaviors;

                await _db.SaveChangesAsync();
            }

            return detailObservationToUpdate;
        }

        public async Task<DetailObservations?> DeleteDetailObservation(int DetailObservationsId)
        {
            DetailObservations? detailObservationToDelete = await GetDetailObservation(DetailObservationsId);

            if (detailObservationToDelete != null)
            {
                _db.detailObservations.Remove(detailObservationToDelete);
                await _db.SaveChangesAsync();
            }

            return detailObservationToDelete;
        }
    }
}
