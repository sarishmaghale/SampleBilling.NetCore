using System;
using System.Collections.Generic;

namespace SampleBilling.Data
{
    public partial class DailyReport
    {
        public int Id { get; set; }
        public string? Date { get; set; }
        public int? Income { get; set; }
        public int? Expense { get; set; }
    }
}
