namespace Animal_extinction.Model
{
    public class Viability
    {
        public required int ViabilityId { get; set; }
        public required int SpeciesId { get; set; }
        public required int ThreatsId { get; set; }
        public required string ThreatsLevel { get; set; }
        public required decimal GeneticDiversity { get; set; }
        public required decimal ReproductionRate { get; set; }
        public required string GeneralViability { get; set; }
        public required Species  Species { get; set; }
        public required Threats Threats { get; set; }

    }
}
