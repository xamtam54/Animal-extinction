namespace Animal_extinction.Model
{
    public class Observations
    {
        public required int ObservationsId { get; set; }
        public required int SpecieId { get; set; }
        public required string Behaviors { get; set; }
        public required Species Specie {get; set;} 
    }
}