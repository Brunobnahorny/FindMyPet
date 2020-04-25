using Microsoft.EntityFrameworkCore.Migrations;

namespace findmypet.Migrations
{
    public partial class GeoLocationAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PetId",
                table: "GeoLocations",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GeoLocations_PetId",
                table: "GeoLocations",
                column: "PetId");

            migrationBuilder.AddForeignKey(
                name: "FK_GeoLocations_Pets_PetId",
                table: "GeoLocations",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "PetId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeoLocations_Pets_PetId",
                table: "GeoLocations");

            migrationBuilder.DropIndex(
                name: "IX_GeoLocations_PetId",
                table: "GeoLocations");

            migrationBuilder.DropColumn(
                name: "PetId",
                table: "GeoLocations");
        }
    }
}
