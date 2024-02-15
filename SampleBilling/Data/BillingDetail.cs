using System;
using System.Collections.Generic;

namespace SampleBilling.Data
{
    public partial class BillingDetail
    {
        public int Id { get; set; }
        public int BillId { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public int? Price { get; set; }
        public int? Quantity { get; set; }

        public virtual Billing Bill { get; set; } = null!;
        public virtual Brand Brand { get; set; } = null!;
        public virtual Category Category { get; set; } = null!;
    }
}
