using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
 
public string BillingDate { get; set; }


        public virtual ICollection<BillingDetail> BillingDetails { get; set; }

    }
}
