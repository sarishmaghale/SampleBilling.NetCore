using System.ComponentModel.DataAnnotations;

namespace SampleBilling.Data
{
    public class DailyReport
    {
        [Key]
        public int Id { get; set; }
        public string? Date { get; set; }
        public int? Income { get; set; }
        public int? Expense { get; set; }

    }
}
