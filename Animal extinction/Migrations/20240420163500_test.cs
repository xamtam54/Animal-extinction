using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Animal_extinction.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_detailObservations_observations_ObservationsId",
                table: "detailObservations");

            migrationBuilder.AlterColumn<int>(
                name: "ObservationsId",
                table: "detailObservations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_detailObservations_observations_ObservationsId",
                table: "detailObservations",
                column: "ObservationsId",
                principalTable: "observations",
                principalColumn: "ObservationsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_detailObservations_observations_ObservationsId",
                table: "detailObservations");

            migrationBuilder.AlterColumn<int>(
                name: "ObservationsId",
                table: "detailObservations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_detailObservations_observations_ObservationsId",
                table: "detailObservations",
                column: "ObservationsId",
                principalTable: "observations",
                principalColumn: "ObservationsId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
