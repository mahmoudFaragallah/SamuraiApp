using Microsoft.EntityFrameworkCore.Migrations;

namespace SamuraiApp.Data.Migrations
{
    public partial class optionalHorseNavigationForSamurai : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Samurais_Horses_HorseId",
                table: "Samurais");

            migrationBuilder.DropIndex(
                name: "IX_Samurais_HorseId",
                table: "Samurais");

            migrationBuilder.AlterColumn<int>(
                name: "HorseId",
                table: "Samurais",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Samurais_HorseId",
                table: "Samurais",
                column: "HorseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Samurais_Horses_HorseId",
                table: "Samurais",
                column: "HorseId",
                principalTable: "Horses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Samurais_Horses_HorseId",
                table: "Samurais");

            migrationBuilder.DropIndex(
                name: "IX_Samurais_HorseId",
                table: "Samurais");

            migrationBuilder.AlterColumn<int>(
                name: "HorseId",
                table: "Samurais",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Samurais_HorseId",
                table: "Samurais",
                column: "HorseId",
                unique: true,
                filter: "[HorseId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Samurais_Horses_HorseId",
                table: "Samurais",
                column: "HorseId",
                principalTable: "Horses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
