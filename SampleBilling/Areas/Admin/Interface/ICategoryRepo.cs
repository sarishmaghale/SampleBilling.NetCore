using SampleBilling.Areas.Admin.Models;

namespace SampleBilling.Areas.Admin.Interface
{
    public interface ICategoryRepo
    {
        public Task<bool> addCategories(CategoryViewModel categories);
        public Task<IEnumerable<CategoryViewModel>> getCategories();
 
    }
}
