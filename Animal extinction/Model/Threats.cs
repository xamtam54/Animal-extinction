namespace Animal_extinction.Model
{
    public class Threats
    {
        public int ThreatsId { get; set; }
        public required string NameThreats { get; set; }
        public required string DescriptionThreats { get; set; }
        public required string ThreatsLevel  { get; set; }
        public required int ViabilityId { get; set; }
        public Viability? Viability { get; set; }
    }
}
