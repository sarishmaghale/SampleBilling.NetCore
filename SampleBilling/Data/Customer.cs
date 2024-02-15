using System.ComponentModel.DataAnnotations;

namespace SampleBilling.Data
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerPhone { get; set; }
        public int? Points { get; set; }
    }
}
