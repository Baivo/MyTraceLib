using Microsoft.EntityFrameworkCore;

namespace MyTraceLib.Tables
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Barcodes> Barcode { get; set; }
        public DbSet<VendorStockCode> StockCodes { get; set; }
        public DbSet<WoolworthsProduct> Products { get; set; }
        public DbSet<ColesProduct> ColesProducts { get; set; }
        public DbSet<ColesBrand> ColesBrands { get; set; }
        public DbSet<CostcoProduct> CostcoProducts { get; set; }
        public DbSet<CostcoBrand> CostcoBrands { get; set; }
        public DbSet<IngredientBreakdown> IngredientBreakdowns { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            string connectionString = Environment.GetEnvironmentVariable("SQL_CONNECTION_STRING") ?? "Server=tcp:mytraceau.database.windows.net,1433;Initial Catalog=MyTrace;Persist Security Info=False;User ID=mytrace;Password=John8:32;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=300;";
            optionsBuilder.UseSqlServer(
                connectionString,
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null);
                });
        }
    }
}
