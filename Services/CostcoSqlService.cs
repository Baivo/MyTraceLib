using Microsoft.EntityFrameworkCore;
using MyTraceLib.Tables;

namespace MyTraceLib.Services
{
    public static class CostcoSqlService 
    {

        public static CostcoProduct? GetProductByStockCode(string stockCode)
        {
            using (var db = new DatabaseContext())
                return db.CostcoProducts.Where(p => p.StockCode == stockCode).FirstOrDefault();
        }
        public static async Task SaveProductsAsync(List<CostcoProduct> CostcoProducts)
        {
            try
            {
                using (var db = new DatabaseContext())
                {
                    db.CostcoProducts.AddRange(CostcoProducts);
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
        public static async Task SaveBrandsAsync(List<CostcoBrand> CostcoBrands)
        {
            try
            {
                using (var db = new DatabaseContext())
                {
                    db.CostcoBrands.AddRange(CostcoBrands);
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
