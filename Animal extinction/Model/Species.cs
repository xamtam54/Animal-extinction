﻿namespace Animal_extinction.Model
{
    public class Species
    {
        public int SpeciesId { get; set; }
        public required string NameSpecies { get; set; }
        public required string Description { get; set; }
        public required string ConservationState { get; set; }
        public required int ViabilityId { get; set; }
        public Viability? Viability { get; set; }
    }

}
