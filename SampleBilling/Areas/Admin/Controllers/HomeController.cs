using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SampleBilling.Areas.Admin.Interface;
using SampleBilling.Areas.Admin.Models;
using SampleBilling.Utility;

namespace SampleBilling.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {       
        private CommonUtility util;
        private IReportRepository content;
        public HomeController(CommonUtility _util, IReportRepository _content)
        {
            util = _util;
            content = _content;
        }
        public async Task<IActionResult> Index()
        {
            var model = new DailyReportViewModel();
            model.Date = util.TodayDate();
            model.Income = await util.getDailySales(util.TodayDate());
            await content.AddDailyRecord(model);
            return View();
        }
        public async Task<IActionResult> DailyEarnings()
        {
            return View(await util.getDailyReportList());
        }
        [HttpPost]
        public List<object> GetSalesData()
        {
            var data = util.GetSalesData();
            return data;
        }
    }
}
