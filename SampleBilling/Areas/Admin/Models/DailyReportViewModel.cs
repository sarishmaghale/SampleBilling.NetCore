namespace SampleBilling.Areas.Admin.Models
{
    public class DailyReportViewModel
    {
        public int Id { get; set; }
        public string? Date { get; set; }
        public int? Income { get; set; }
        public int? Expense { get; set; }
    }
}
