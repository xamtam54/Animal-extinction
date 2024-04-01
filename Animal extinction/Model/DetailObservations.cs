using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Animal_extinction.Model
{
    public class DetailObservations
    {
        [Key]
        public int DetailObservationsId { get; set; }
        public required int ObservationId { get; set; }
        public Observations? Observations { get; set; }
        public required DateOnly ObservationDate { get; set; }
        public required string ObservationType { get; set; }
        public required string Ubication { get; set; }
        public required string Behaviors { get; set; }
        

    }
}
