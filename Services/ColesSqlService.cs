using Microsoft.EntityFrameworkCore;
using MyTraceLib.Tables;

namespace MyTraceLib.Services
{
    public static class ColesSqlService
    {

        public static ColesProduct? GetProductByStockCode(string stockCode)
        {
            using (var db = new DatabaseContext())
                return db.ColesProducts.Where(p => p.StockCode == stockCode).FirstOrDefault();
        }
        public static async Task SaveProductsAsync(List<ColesProduct> colesProducts)
        {
            try
            {
                using (var db = new DatabaseContext())
                {
                    db.ColesProducts.AddRange(colesProducts);
                    await db.SaveChangesAsync();
                }
            }
            catch (DbUpdateException dbEx)
            {
                PrintService.PrintDbError(dbEx);
            }
            catch (Exception ex)
            {
                PrintService.PrintError(ex);
            }
        }
        public static async Task SaveBrandsAsync(List<ColesBrand> colesBrands)
        {
            try
            {
                using (var db = new DatabaseContext())
                {
                    db.ColesBrands.AddRange(colesBrands);
                    await db.SaveChangesAsync();
                }
            }
            catch (DbUpdateException dbEx)
            {
                PrintService.PrintDbError(dbEx);
            }
            catch (Exception ex)
            {
                PrintService.PrintError(ex);
            }
        }
    }
}
