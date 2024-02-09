﻿namespace SampleBilling.Data
{
    public class SalesAndStock
    {
        public int Id { get; set; }
        public int? BrandId { get; set; }
        public int? TotalSales { get; set; }
        public int? LeftStocks { get; set; }
        public string? UpdatedDate { get; set; }
        public int? ImportedStock { get; set; }
        public virtual Brand? Brand { get; set; }
    }
}
