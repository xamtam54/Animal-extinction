namespace Animal_extinction.Model
{
    public class Observations
    {
        public int ObservationsId { get; set; }
        public required int SpecieId { get; set; }
        public Species? Specie {get; set;} 
    }
}