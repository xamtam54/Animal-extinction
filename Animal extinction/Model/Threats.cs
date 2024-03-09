namespace Animal_extinction.Model
{
    public class Threats
    {
        public required int ThreatsId { get; set; }
        public required string NameThreats { get; set; }
        public required string DescriptionThreats { get; set; }
        public required string ThreatsLevel  { get; set; }
        public required int ViabilityId { get; set; }
        public required Viability Viability { get; set; }
    }
}
