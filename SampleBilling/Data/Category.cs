using System;
using System.Collections.Generic;

namespace SampleBilling.Data
{
    public partial class Category
    {
        public Category()
        {
            BillingDetails = new HashSet<BillingDetail>();
            Brands = new HashSet<Brand>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;

        public virtual ICollection<BillingDetail> BillingDetails { get; set; }
        public virtual ICollection<Brand> Brands { get; set; }
    }
}
