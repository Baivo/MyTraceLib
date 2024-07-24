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
        public DbSet<CostcoBrand> CostcoBrands { get; set; }
        public DbSet<CostcoProduct> CostcoProducts { get; set; }
        public DbSet<IngredientBreakdown> IngredientBreakdowns { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                Environment.GetEnvironmentVariable("SQL_CONNECTION_STRING"),
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
