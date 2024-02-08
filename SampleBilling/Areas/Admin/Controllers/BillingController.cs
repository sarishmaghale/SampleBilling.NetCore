using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SampleBilling.Areas.Admin.Interface;
using SampleBilling.Areas.Admin.Models;
using SampleBilling.Utility;

namespace SampleBilling.Areas.Admin.Controllers
{
    [Area("Admin")]

    [Authorize]   
    public class BillingController : Controller
    {
        private IBillingRepo content;
        private CommonUtility util;
        public BillingController(IBillingRepo _content, CommonUtility _util)
        {
            content = _content;
            util = _util;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetViews()
        {
            return PartialView("_BillingPartial");
        }
        

        //pass brands data through ajax call
        public async Task<IActionResult> GetBrandValue(int CategoryId)
        {
            var result =await util.getBrandsByCatId(CategoryId);
            return Json(result);
        }

        //pass price value through ajax call
        public async Task<IActionResult> GetPriceValue(int BrandId)
        {
           int val= await util.getPriceByBrandId(BrandId);
            return Json(val);
        }

        [HttpPost]
        public async Task<IActionResult> AddBilling(BillingViewModel billingData)
        {
            int result= await content.AddBilling(billingData);
            if (result!=0)
            {
                TempData["Msg"] = "Successfully Added";
                return RedirectToAction("ViewDetails", new {id=result});
            }
            else
            {
                TempData["Msg"] = "Failed to Add";
                return RedirectToAction("Index","Billing");
            }
        }

        public async Task< IActionResult> History()
        {

            return View(await content.getBillings());
        }

        public async Task<IActionResult> ViewDetails(int id)
        {
           
            return View("BillingDetails", await content.getBillingDetails(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int BillId)
        {
            await content.deleteBilling(BillId);
            return RedirectToAction("History", "Billing");
        }
    }
}
