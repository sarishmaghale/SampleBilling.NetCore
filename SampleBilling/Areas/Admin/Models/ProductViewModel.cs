using SampleBilling.Data;
using System.ComponentModel.DataAnnotations;

namespace SampleBilling.Areas.Admin.Models
{
    public class ProductViewModel
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; } = null!;
        public int? CategoryId { get; set; }
        public int? Price { get; set; }
        public int TotalStocks { get; set; }
        public int LeftStock { get; set; }
        public int? ImportDate { get; set; }
        public string UpdatedDate { get; set; }
        public int? ImportedStock { get; set; }
        public int? TotalSales { get; set; }
        public virtual Category? Category { get; set; }
    }
   
}
