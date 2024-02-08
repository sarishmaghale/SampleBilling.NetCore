using Microsoft.EntityFrameworkCore;
using SampleBilling.Data;
using SampleBilling.Areas.Admin.Interface;
using SampleBilling.Areas.Admin.Models;

namespace SampleBilling.Areas.Admin.Repository
{
    public class CategoryRepository : ICategoryRepo
    {
        private BillingDbContext db;
        public CategoryRepository(BillingDbContext _db)
        {
            db = _db;
        }
        public async Task<bool> addCategories(CategoryViewModel categories)
        {
            Category categoryData = new Category()
            {
                CategoryName = categories.CategoryName,
            };
            await db.Categories.AddAsync(categoryData);
            int a = await db.SaveChangesAsync();
            bool result = (a > 0) ? true : false;
            return result;
        }

        public async Task<IEnumerable<CategoryViewModel>> getCategories()
        {
            var data = await db.Categories.Select(x => new CategoryViewModel()
            {
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName,
            }).ToListAsync();
            return data;
        }

        public async Task<int> getPriceByBrandId(int BrandId)
        {
            var data = await db.Brands.Where(x => x.BrandId == BrandId).FirstOrDefaultAsync();
            int val = (int)data.Price;
            return val;
        }

    }
}
