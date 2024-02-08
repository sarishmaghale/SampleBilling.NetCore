using SampleBilling.Areas.Admin.Models;

namespace SampleBilling.Areas.Admin.Interface
{
    public interface IBrandRepo
    {
        public Task<bool> addBrands(ProductViewModel brands);
        public Task<IEnumerable<ProductViewModel>> getBrands();
        public Task<ProductViewModel> getBrandsByid(int id);
        public Task<bool> EditBrands(ProductViewModel model);

        public Task<ProductViewModel> getProductDetails(int id);
   
    }

}
