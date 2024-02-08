using Microsoft.AspNetCore.Mvc.Rendering;
using SampleBilling.Areas.Admin.Models;

namespace SampleBilling.Areas.Admin.Interface
{
    public interface IBillingRepo
    {

        public Task<int> AddBilling(BillingViewModel billings);
        public Task<IEnumerable<BillingViewModel>> getBillings();
        public Task<BillingViewModel> getBillingDetails(int id);
        public Task<bool> deleteBilling(int id);
       
    }
}
