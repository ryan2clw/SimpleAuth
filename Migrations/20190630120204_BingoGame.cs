using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class BingoGame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BingoGameId",
                table: "BingoNumbers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BingoGames",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StartTime = table.Column<DateTime>(nullable: true),
                    EndTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BingoGames", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BingoNumbers_BingoGameId",
                table: "BingoNumbers",
                column: "BingoGameId");

            migrationBuilder.AddForeignKey(
                name: "FK_BingoNumbers_BingoGames_BingoGameId",
                table: "BingoNumbers",
                column: "BingoGameId",
                principalTable: "BingoGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BingoNumbers_BingoGames_BingoGameId",
                table: "BingoNumbers");

            migrationBuilder.DropTable(
                name: "BingoGames");

            migrationBuilder.DropIndex(
                name: "IX_BingoNumbers_BingoGameId",
                table: "BingoNumbers");

            migrationBuilder.DropColumn(
                name: "BingoGameId",
                table: "BingoNumbers");
        }
    }
}
