using System;
using System.Collections.Generic;

namespace SampleBilling.Data
{
    public partial class Brand
    {
        public Brand()
        {
            BillingDetails = new HashSet<BillingDetail>();
            SalesAndStocks = new HashSet<SalesAndStock>();
        }

        public int BrandId { get; set; }
        public string? BrandName { get; set; }
        public int? CategoryId { get; set; }
        public int? Price { get; set; }
        public int? TotalStocks { get; set; }
        public string? UpdatedDate { get; set; }

        public virtual Category? Category { get; set; }
        public virtual ICollection<BillingDetail> BillingDetails { get; set; }
        public virtual ICollection<SalesAndStock> SalesAndStocks { get; set; }
    }
}
