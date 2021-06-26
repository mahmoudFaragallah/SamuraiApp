﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace SamuraiApp.Data.Migrations
{
    public partial class AddNavigationalPropertyToHorseEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Samurais_Horses_HorseId",
                table: "Samurais");

            migrationBuilder.DropIndex(
                name: "IX_Samurais_HorseId",
                table: "Samurais");

            migrationBuilder.DropColumn(
                name: "HorseId",
                table: "Samurais");

            migrationBuilder.AddColumn<int>(
                name: "SamuraiId",
                table: "Horses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Horses_SamuraiId",
                table: "Horses",
                column: "SamuraiId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Horses_Samurais_SamuraiId",
                table: "Horses",
                column: "SamuraiId",
                principalTable: "Samurais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Horses_Samurais_SamuraiId",
                table: "Horses");

            migrationBuilder.DropIndex(
                name: "IX_Horses_SamuraiId",
                table: "Horses");

            migrationBuilder.DropColumn(
                name: "SamuraiId",
                table: "Horses");

            migrationBuilder.AddColumn<int>(
                name: "HorseId",
                table: "Samurais",
                type: "int",
                nullable: true);

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
                onDelete: ReferentialAction.Restrict);
        }
    }
}
