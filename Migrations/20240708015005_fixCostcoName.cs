using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyTraceTrawler.Migrations
{
    /// <inheritdoc />
    public partial class fixCostcoName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_costcoBrands",
                table: "costcoBrands");

            migrationBuilder.RenameTable(
                name: "costcoBrands",
                newName: "CostcoBrands");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CostcoBrands",
                table: "CostcoBrands",
                column: "CostcoBrandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CostcoBrands",
                table: "CostcoBrands");

            migrationBuilder.RenameTable(
                name: "CostcoBrands",
                newName: "costcoBrands");

            migrationBuilder.AddPrimaryKey(
                name: "PK_costcoBrands",
                table: "costcoBrands",
                column: "CostcoBrandId");
        }
    }
}
