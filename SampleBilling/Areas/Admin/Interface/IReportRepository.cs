using SampleBilling.Areas.Admin.Models;

namespace SampleBilling.Areas.Admin.Interface
{
    public interface IReportRepository
    {
        public Task<bool> AddDailyRecord(DailyReportViewModel model);
    }
}
