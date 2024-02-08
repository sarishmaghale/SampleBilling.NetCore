using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration;
using SampleBilling.Areas.Admin.Interface;
using SampleBilling.Areas.Admin.Models;
using SampleBilling.Utility;

namespace SampleBilling.Areas.Admin.Controllers
{
    public class DailyReportController : Controller
    {
        private CommonUtility util;
        private IReportRepository content;
        public DailyReportController(CommonUtility _util,IReportRepository _content)
        {
            util = _util;
            content = _content;
        }
        [HttpPost]
        public async Task<IActionResult> DailyReportUpdate()
        {
            var model = new DailyReportViewModel();
            model.Date = util.TodayDate();
            model.Income =await util.getDailySales(util.TodayDate());
            bool res = await content.AddDailyRecord(model);
            return RedirectToAction("Index","Home");
        }
    }
}
