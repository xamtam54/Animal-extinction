using Animal_extinction.Model;
using Animal_extinction.Repository;

namespace Animal_extinction.Services
{
    public interface IDetailObservationsService
    {
        Task<List<DetailObservations>> GetAll();
        Task<DetailObservations?> GetDetailObservation(int DetailObservationsId);
        Task<DetailObservations> CreateDetailObservation(int ObservationId, DateOnly ObservationDate, string ObservationType, string Ubication, string Behaviors);
        Task<DetailObservations?> UpdateDetailObservation(int DetailObservationsId, int ObservationId, DateOnly ObservationDate, string ObservationType, string Ubication, string Behaviors);
        Task<DetailObservations?> DeleteDetailObservation(int DetailObservationsId);
    }

    public class DetailObservationsService : IDetailObservationsService
    {
        public readonly IDetailObservationsRepository _detailObservationsRepository;
        public DetailObservationsService(IDetailObservationsRepository detailObservationsRepository)
        {
            _detailObservationsRepository = detailObservationsRepository;
        }

        public async Task<DetailObservations> CreateDetailObservation(int ObservationId, DateOnly ObservationDate, string ObservationType, string Ubication, string Behaviors)
        {
            return await _detailObservationsRepository.CreateDetailObservation(ObservationId, ObservationDate, ObservationType, Ubication, Behaviors);
        }

        public async Task<DetailObservations?> DeleteDetailObservation(int DetailObservationsId)
        {
            return await _detailObservationsRepository.DeleteDetailObservation(DetailObservationsId);
        }

        public async Task<List<DetailObservations>> GetAll()
        {
            return await _detailObservationsRepository.GetAll();
        }

        public async Task<DetailObservations?> GetDetailObservation(int DetailObservationsId)
        {
            return await _detailObservationsRepository.GetDetailObservation(DetailObservationsId);
        }

        public async Task<DetailObservations?> UpdateDetailObservation(int DetailObservationsId, int ObservationId, DateOnly ObservationDate = default, string? ObservationType = null, string? Ubication = null, string? Behaviors = null)
        {
            DetailObservations? detailObservationToUpdate = await _detailObservationsRepository.GetDetailObservation(DetailObservationsId);

            if (detailObservationToUpdate != null)
            {
                if (ObservationId != -1) { detailObservationToUpdate.ObservationId = ObservationId; }
                if (ObservationDate != default) { detailObservationToUpdate.ObservationDate = ObservationDate; }
                if (ObservationType != null) { detailObservationToUpdate.ObservationType = ObservationType; }
                if (Ubication != null) { detailObservationToUpdate.Ubication = Ubication; }
                if (Behaviors != null) { detailObservationToUpdate.Behaviors = Behaviors; }

                await _detailObservationsRepository.UpdateDetailObservation(DetailObservationsId, detailObservationToUpdate.ObservationId, detailObservationToUpdate.ObservationDate, detailObservationToUpdate.ObservationType, detailObservationToUpdate.Ubication, detailObservationToUpdate.Behaviors);

            }

            return null; 
        }
        /*
        public async Task<List<User>> DeleteUser(int id)
        {
            User user = await _detailObservationsRepository.GetUser(int);
            //user.IsDeleted = true;
            //user.date = DateTime.Now;

            return await _repo.DeleteUserAsync(user);
        }*/
    }
}
