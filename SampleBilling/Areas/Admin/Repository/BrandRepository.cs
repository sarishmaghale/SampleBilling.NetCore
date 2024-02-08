using Microsoft.EntityFrameworkCore;
using SampleBilling.Data;
using SampleBilling.Areas.Admin.Interface;
using SampleBilling.Areas.Admin.Models;

namespace SampleBilling.Areas.Admin.Repository
{
    public class BrandRepository : IBrandRepo
    {

        private BillingDbContext db;
        public BrandRepository(BillingDbContext _db)
        {
            db = _db;
        }
        public async Task<bool> addBrands(ProductViewModel brands)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    Brand brandData = new Brand()
                    {
                        BrandName = brands.BrandName,
                        CategoryId = brands.CategoryId,
                        Price = brands.Price,
                        TotalStocks = brands.TotalStocks,
                        UpdatedDate = brands.UpdatedDate
                    };
                    await db.Brands.AddAsync(brandData);
                    await db.SaveChangesAsync();
                    Sale sales = new Sale()
                    {
                        ProductId = brandData.BrandId,
                        TotalSales = 0,
                        UpdatedDate=brandData.UpdatedDate,
                        LeftStocks=brandData.TotalStocks,
                        ImportedStock=brandData.TotalStocks,
                    };
                    await db.Sales.AddAsync(sales);
                    await db.SaveChangesAsync();
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return false;
                }
            };
          
        }

        public async Task<IEnumerable<ProductViewModel>> getBrands()
        {
            var data = await db.Brands.Select(x => new ProductViewModel()
            {
                BrandId = x.BrandId,
                Price = x.Price,
                CategoryId = x.CategoryId,
                BrandName = x.BrandName,
                TotalStocks=x.TotalStocks,
                LeftStock=db.Sales.Where(a=> a.ProductId==x.BrandId).Select(a=>a.LeftStocks).FirstOrDefault()??0,
               
                UpdatedDate=x.UpdatedDate
            }).ToListAsync();
            return data;
        }
        public async Task<ProductViewModel> getBrandsByid(int id)
        {
            var data = await db.Brands.Where(x => x.BrandId == id).Select(m => new ProductViewModel() { 
                BrandId=m.BrandId,
                BrandName=m.BrandName,
                Price=m.Price,
                TotalStocks=m.TotalStocks,
                LeftStock=db.Sales.Where(a=> a.ProductId==id).Select(a=> a.LeftStocks).FirstOrDefault()??0,
                UpdatedDate=m.UpdatedDate,
                CategoryId=m.CategoryId,
                ImportedStock= db.Sales.Where(a => a.ProductId == id).Select(a => a.ImportedStock).FirstOrDefault() ?? 0
            }).FirstOrDefaultAsync();
            return data;
        }
        public async Task<bool> EditBrands(ProductViewModel model)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                   //update Brand Table
                    var OldData =await db.Brands.Where(x => x.BrandId == model.BrandId).FirstOrDefaultAsync();
                    OldData.BrandName = model.BrandName;
                    OldData.Price = model.Price;
                    OldData.UpdatedDate= DateTime.Now.ToShortDateString();
                    db.Entry(OldData).State = EntityState.Modified;
                    await db.SaveChangesAsync();

                    //update left stocks & date
                    var OldStock = await db.Sales.Where(a => a.ProductId == model.BrandId).FirstOrDefaultAsync();
                    OldStock.ImportedStock = model.ImportedStock;
                    OldStock.UpdatedDate = DateTime.Now.ToShortDateString();
                    OldStock.LeftStocks += model.ImportedStock;
                    db.Entry(OldStock).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    //update total stocks of products based on recent import
                    OldData.TotalStocks = (OldStock.LeftStocks + model.ImportedStock)??OldData.TotalStocks;
                    db.Entry(OldData).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    transaction.Commit();
                    return true;
                        
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public async Task<ProductViewModel> getProductDetails(int id)
        {
            var data = await db.Brands.Where(x => x.BrandId == id).Select(m => new ProductViewModel()
            {
                BrandId=m.BrandId,
                BrandName=m.BrandName,
                CategoryId=m.CategoryId,
                Price=m.Price,
                TotalStocks=m.TotalStocks,
                ImportedStock=db.Sales.Where(y=> y.ProductId==id).Select(y=> y.ImportedStock).FirstOrDefault(),
                LeftStock= db.Sales.Where(a=> a.ProductId==id).Select(a=> a.LeftStocks).FirstOrDefault()??0,
                UpdatedDate=m.UpdatedDate,
                TotalSales= db.Sales.Where(b=> b.ProductId==id).Select(b=> b.TotalSales).FirstOrDefault(),
            }).FirstOrDefaultAsync();
            return data;
        }
    }
}
