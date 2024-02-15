using Microsoft.EntityFrameworkCore;
using SampleBilling.Areas.Admin.Interface;
using SampleBilling.Areas.Admin.Models;
using SampleBilling.Data;

namespace SampleBilling.Areas.Admin.Repository
{
    public class ReportsRepository: IReportRepository
    {
        private BillingDbContext db;
        public ReportsRepository(BillingDbContext _db)
        {
            db = _db;
        }
        public async Task<bool> AddDailyRecord(DailyReportViewModel model)
        {
            bool result= db.DailyReports.Any(x => x.Date == model.Date);
            if (!result)
            {
                DailyReport records = new DailyReport()
                {
                    Date = model.Date,
                    Income = model.Income,
                };
                await db.DailyReports.AddAsync(records);
                int a = await db.SaveChangesAsync();
            }
            var record =await db.DailyReports.Where(y=> y.Date==model.Date).FirstOrDefaultAsync();
            record.Income = model.Income;
            db.Entry(record).State = EntityState.Modified;
            await db.SaveChangesAsync();          
            return true;
        }
    }
}
