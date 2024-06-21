using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyTraceTrawler.Migrations
{
    /// <inheritdoc />
    public partial class AU : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ColesBrands",
                columns: table => new
                {
                    ColesBrandId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InternalId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColesBrands", x => x.ColesBrandId);
                });

            migrationBuilder.CreateTable(
                name: "ColesProducts",
                columns: table => new
                {
                    ColesProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    table.PrimaryKey("PK_ColesProducts", x => x.ColesProductId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ColesBrands");

            migrationBuilder.DropTable(
                name: "ColesProducts");
        }
    }
}
