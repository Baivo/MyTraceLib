using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyTraceTrawler.Migrations
{
    /// <inheritdoc />
    public partial class IngredientBreakdown : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            


            migrationBuilder.CreateTable(
                name: "IngredientBreakdowns",
                columns: table => new
                {
                    IngredientBreakdownId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IngredientName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Purpose = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Toxicity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarcinogenicProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HealthierAlternatives = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommonUses = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegulatoryStatusInAustralia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnvironmentalImpact = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientBreakdowns", x => x.IngredientBreakdownId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientBreakdowns");
        }
    }
}
