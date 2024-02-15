using SampleBilling.Data;
using System.ComponentModel.DataAnnotations;

namespace SampleBilling.Areas.Admin.Models
{
    public class BillingViewModel
    {
      
        public int BillId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; } = null!;
        public int? Discount { get; set; }
        [Required(ErrorMessage = "Mobile Number is required.")]
        [RegularExpression("^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string? Phone { get; set; }
        public int Total { get; set; }
        public int? PayableAmt { get; set; }
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
