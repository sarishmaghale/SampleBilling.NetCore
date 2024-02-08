using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SampleBilling.Areas.Admin.Interface;
using SampleBilling.Areas.Admin.Models;

namespace SampleBilling.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CategoryController : Controller
    {
        private ICategoryRepo content;
        public CategoryController(ICategoryRepo _content)
        {
            content = _content;
        }


        public async Task<IActionResult> Index()
        {
            var data = await content.getCategories();
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryViewModel categoryData)
        {

                bool res = await content.addCategories(categoryData);
                if (res)
                {

                    return RedirectToAction("Index");
                }
                      
                return View();
        }
    }
}
