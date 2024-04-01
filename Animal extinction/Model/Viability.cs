namespace Animal_extinction.Model
{
    public class Viability
    {
        public int ViabilityId { get; set; }
        public required decimal GeneticDiversity { get; set; }
        public required decimal ReproductionRate { get; set; }
        public required string GeneralViability { get; set; }

    }
}
