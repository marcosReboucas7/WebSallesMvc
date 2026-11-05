using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebSallesMvc.Models;
using WebSallesMvc.Services;

namespace WebSallesMvc.Controllers
{
    public class SellersController : Controller
    {

        private readonly SellerService _sellerService;

        private readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }
        public IActionResult Index()
        {
            var list = _sellerService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            ViewBag.Departments = new SelectList(_departmentService.FindAll(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            if (seller.DepartmentId == 0)
            {
                ModelState.AddModelError(nameof(Seller.DepartmentId), "Select a department.");
                ViewBag.Departments = new SelectList(_departmentService.FindAll(), "Id", "Name");
                return View(seller);
            }

            _sellerService.Intert(seller);
            return RedirectToAction(nameof(Index));
        }
    }
}
