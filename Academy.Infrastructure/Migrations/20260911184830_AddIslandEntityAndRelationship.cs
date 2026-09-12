using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Academy.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddIslandEntityAndRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IslandId",
                table: "Subjects",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Islands",
                columns: table => new
                {
                    IslandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Islands", x => x.IslandId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_IslandId",
                table: "Subjects",
                column: "IslandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Islands_IslandId",
                table: "Subjects",
                column: "IslandId",
                principalTable: "Islands",
                principalColumn: "IslandId",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Islands_IslandId",
                table: "Subjects");

            migrationBuilder.DropTable(
                name: "Islands");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_IslandId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "IslandId",
                table: "Subjects");
        }
    }
}
