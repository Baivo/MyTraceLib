using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyTraceTrawler.Migrations
{
    /// <inheritdoc />
    public partial class BarcodeFixColesCostcode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EANs",
                table: "CostcoProducts");

            migrationBuilder.RenameColumn(
                name: "UPCs",
                table: "CostcoProducts",
                newName: "Barcode");

            migrationBuilder.AddColumn<string>(
                name: "Barcode",
                table: "ColesProducts",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Barcode",
                table: "ColesProducts");

            migrationBuilder.RenameColumn(
                name: "Barcode",
                table: "CostcoProducts",
                newName: "UPCs");

            migrationBuilder.AddColumn<string>(
                name: "EANs",
                table: "CostcoProducts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
