using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SampleBilling.Data
{
    public partial class Sale
    {

        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int? TotalSales { get; set; }
        public int? LeftStocks { get; set; }
        public string? UpdatedDate { get;set; }
        public int? ImportedStock { get; set; }
        public virtual Brand? Product { get; set; }
    }
}
