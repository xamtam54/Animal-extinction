using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Animal_extinction.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "viability",
                columns: table => new
                {
                    ViabilityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GeneticDiversity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReproductionRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GeneralViability = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_viability", x => x.ViabilityId);
                });

            migrationBuilder.CreateTable(
                name: "species",
                columns: table => new
                {
                    SpeciesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameSpecies = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConservationState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ViabilityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_species", x => x.SpeciesId);
                    table.ForeignKey(
                        name: "FK_species_viability_ViabilityId",
                        column: x => x.ViabilityId,
                        principalTable: "viability",
                        principalColumn: "ViabilityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "threats",
                columns: table => new
                {
                    ThreatsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameThreats = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionThreats = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThreatsLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ViabilityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_threats", x => x.ThreatsId);
                    table.ForeignKey(
                        name: "FK_threats_viability_ViabilityId",
                        column: x => x.ViabilityId,
                        principalTable: "viability",
                        principalColumn: "ViabilityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "observations",
                columns: table => new
                {
                    ObservationsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_observations", x => x.ObservationsId);
                    table.ForeignKey(
                        name: "FK_observations_species_SpecieId",
                        column: x => x.SpecieId,
                        principalTable: "species",
                        principalColumn: "SpeciesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "detailObservations",
                columns: table => new
                {
                    DetailObservationsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ObservationId = table.Column<int>(type: "int", nullable: false),
                    ObservationDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ObservationType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ubication = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Behaviors = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ObservationsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detailObservations", x => x.DetailObservationsId);
                    table.ForeignKey(
                        name: "FK_detailObservations_observations_ObservationsId",
                        column: x => x.ObservationsId,
                        principalTable: "observations",
                        principalColumn: "ObservationsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_detailObservations_ObservationsId",
                table: "detailObservations",
                column: "ObservationsId");

            migrationBuilder.CreateIndex(
                name: "IX_observations_SpecieId",
                table: "observations",
                column: "SpecieId");

            migrationBuilder.CreateIndex(
                name: "IX_species_ViabilityId",
                table: "species",
                column: "ViabilityId");

            migrationBuilder.CreateIndex(
                name: "IX_threats_ViabilityId",
                table: "threats",
                column: "ViabilityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detailObservations");

            migrationBuilder.DropTable(
                name: "threats");

            migrationBuilder.DropTable(
                name: "observations");

            migrationBuilder.DropTable(
                name: "species");

            migrationBuilder.DropTable(
                name: "viability");
        }
    }
}
