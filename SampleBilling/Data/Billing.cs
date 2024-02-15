using System;
using System.Collections.Generic;

namespace SampleBilling.Data
{
    public partial class Billing
    {
        public Billing()
        {
            BillingDetails = new HashSet<BillingDetail>();
        }

        public int BillId { get; set; }
        public string Name { get; set; } = null!;
        public int Total { get; set; }
        public bool? Status { get; set; }
        public string BillingDate { get; set; } = null!;
        public int? Discount { get; set; }
        public string? Phone { get; set; }
        public int? PayableAmt { get; set; }

        public virtual ICollection<BillingDetail> BillingDetails { get; set; }
    }
}
