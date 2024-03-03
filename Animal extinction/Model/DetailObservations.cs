namespace Animal_extinction.Model
{
    public class DetailObservations
    {
        public required int DetailObservationsId { get; set; }
        public required int ObservationId { get; set; }
        public required DateOnly ObservationDate { get; set; }
        public required string ObservationType { get; set; }
        public required string Ubication { get; set; }
        public required Observations Observations { get; set; }

    }
}
