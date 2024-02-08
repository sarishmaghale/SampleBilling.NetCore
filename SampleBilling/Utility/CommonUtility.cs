using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SampleBilling.Data;
using SampleBilling.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc.TagHelpers;

namespace SampleBilling.Utility
{
    public class CommonUtility
    {
        private BillingDbContext ent;
        public CommonUtility(BillingDbContext _ent)
        {
            ent = _ent;
        }

        public async Task<string> getCategoryName(int id)
        {
            var ctgy = await ent.Categories.Where(x => x.CategoryId == id).FirstOrDefaultAsync();
            return ctgy.CategoryName;
        }

       public async Task<string> getBrandName(int id)
        {
            var brnd = await ent.Brands.Where(x => x.BrandId == id).FirstOrDefaultAsync();
            return brnd.BrandName;
        }
        public SelectList getBrandId(IEnumerable<ProductViewModel> brands)
        {
            var brandId = new SelectList(brands, "BrandId", "BrandName");
            return brandId;
        }
        public async Task<IEnumerable<ProductViewModel>> getBrandsByCatId(int id)
        {
            var result = await ent.Brands.Where(x => x.CategoryId == id).Select(m => new ProductViewModel()
            {
                BrandId = m.BrandId,
                BrandName = m.BrandName,
                CategoryId = id,
            }).ToListAsync();
            return result;
        }
        public SelectList getCategoryId(IEnumerable<CategoryViewModel> categories)
        {
            var CategoryId = new SelectList(categories, "CategoryId", "CategoryName");
            return CategoryId;
        }

        public async Task<int> getPriceByBrandId(int BrandId)
        {
            var data = await ent.Brands.Where(x => x.BrandId == BrandId).FirstOrDefaultAsync();
            int val = (int)data.Price;
            return val;
        }

        public async Task<IEnumerable<CategoryViewModel>> getCategories()
        {
            var data = await ent.Categories.Select(x => new CategoryViewModel()
            {
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName,
            }).ToListAsync();
            return data;
        }
        public async Task<int> getDailySales(string Date)
        {
            var TotalSales = await ent.Billings.Where(x => x.BillingDate == Date).ToListAsync();
            int SalesAmt = 0;
            foreach (var item in TotalSales)
            {
                SalesAmt = SalesAmt + item.Total;
            }
            return SalesAmt;
        }
        public string TodayDate()
        {
            return DateTime.Now.ToShortDateString();
        }
        public async Task<IEnumerable<ProductViewModel>> bestSellers()
        {
          var data=  await ent.Brands.Select(m => new ProductViewModel()
            {
              BrandName=m.BrandName,
              TotalSales=ent.Sales.Where(x=> x.ProductId==m.BrandId).Select(x=> x.TotalSales).FirstOrDefault(),
              Price=m.Price,
            }).OrderByDescending(m => m.TotalSales).Take(3).ToListAsync();
            return data;
        }

        public async Task<int> TotalProducts()
        {
            return await ent.Brands.CountAsync();
        }
        public async Task<int> TotalCategories()
        {
            return await ent.Categories.CountAsync();
        }
    }
}
