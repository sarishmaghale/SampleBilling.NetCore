using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SampleBilling.Areas.Admin.Interface;
using SampleBilling.Areas.Admin.Models;

namespace SampleBilling.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class BrandController : Controller
    {
        private IBrandRepo content;
        public BrandController(IBrandRepo _content)
        {
            content = _content;
        }

        public async Task<IActionResult> Index()
        {
           var data= await content.getBrands();
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel brandsData)
        {
            
                bool res = await content.addBrands(brandsData);
                if (res)
                {
                    return RedirectToAction("Index");
                }
                  
                return View();
        }
        public async Task<IActionResult> Edit(int id)
        {
            return View(await content.getBrandsByid(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductViewModel model)
        {
            bool res = await content.EditBrands(model);
            if (res)
            {
                TempData["Msg"] = "Successfully Updated";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Msg"] = "Failed to update";
                return View(model);
            }
        }
        public async Task<IActionResult> ViewDetails(int id)
        {
            var result = await content.getProductDetails(id);
            return View(result);
        }

    }
}
