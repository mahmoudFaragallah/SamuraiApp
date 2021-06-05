using Microsoft.EntityFrameworkCore.Migrations;

namespace SamuraiApp.Data.Migrations
{
    public partial class nullableHorseID : Migration
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
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Samurais_HorseId",
                table: "Samurais",
                column: "HorseId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Samurais_Horses_HorseId",
                table: "Samurais",
                column: "HorseId",
                principalTable: "Horses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
