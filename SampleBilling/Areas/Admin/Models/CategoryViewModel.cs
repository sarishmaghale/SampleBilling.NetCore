using SampleBilling.Data;

namespace SampleBilling.Areas.Admin.Models
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<Brand> Brands { get; set; }
    }
}
