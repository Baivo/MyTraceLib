using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyTraceTrawler.Migrations
{
    /// <inheritdoc />
    public partial class CostCo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "costcoBrands",
                columns: table => new
                {
                    CostcoBrandId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InternalId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_costcoBrands", x => x.CostcoBrandId);
                });

            migrationBuilder.CreateTable(
                name: "CostcoProducts",
                columns: table => new
                {
                    CostcoProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    StockCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandExternalId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EANs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManufacturerPartNumbers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UPCs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductPageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostcoProducts", x => x.CostcoProductId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "costcoBrands");

            migrationBuilder.DropTable(
                name: "CostcoProducts");
        }
    }
}
