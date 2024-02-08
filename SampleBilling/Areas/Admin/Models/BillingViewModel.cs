using SampleBilling.Data;

namespace SampleBilling.Areas.Admin.Models
{
    public class BillingViewModel
    {
      
        public int BillId { get; set; }
        public string Name { get; set; } = null!;
        public int Total { get; set; }
        public List<BillingViewModel> Details { get; set; }

        //For Billings Detail
        public int Id { get; set; }
        public int? Quantity { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public int Price { get; set; }
        public string BillingDate { get; set; }
        public virtual Billing Bill { get; set; } = null!;
        public virtual Brand Brand { get; set; } = null!;
        public virtual Category Category { get; set; } = null!;
    }
 



}
