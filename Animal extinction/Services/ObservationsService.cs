using Animal_extinction.Model;
using Animal_extinction.Repository;

namespace Animal_extinction.Services
{
    public interface IObservationsService
    {
        Task<List<Observations>> GetAll();
        Task<Observations?> GetObservation(int ObservationsId);
        Task<Observations> CreateObservation(int SpecieId);
        Task<Observations?> UpdateObservation(int ObservationsId, int SpecieId);
        Task<Observations?> DeleteObservation(int ObservationsId);
    }

    public class ObservationsService : IObservationsService
    {
        private readonly IObservationsRepository _observationsRepository;
        public ObservationsService(ObservationsRepository observationsRepository)
        {
            _observationsRepository = observationsRepository;
        }

        public async Task<Observations> CreateObservation(int SpecieId)
        {
            return await _observationsRepository.CreateObservation(SpecieId);
        }

        public async Task<Observations?> DeleteObservation(int ObservationsId)
        {
            return await _observationsRepository.DeleteObservation(ObservationsId);
        }

        public async Task<List<Observations>> GetAll()
        {
            return await _observationsRepository.GetAll();
        }

        public async Task<Observations?> GetObservation(int ObservationsId)
        {
            return await _observationsRepository.GetObservation(ObservationsId);
        }

        public async Task<Observations?> UpdateObservation(int ObservationsId, int SpecieId = -1)
        {
            var observationToUpdate = await _observationsRepository.GetObservation(ObservationsId);

            if (observationToUpdate != null)
            {
                if (SpecieId != -1)
                {
                    observationToUpdate.SpecieId = SpecieId;
                }

                 await _observationsRepository.UpdateObservation(ObservationsId, observationToUpdate.SpecieId);
            }

            return observationToUpdate;
        }
    }

}