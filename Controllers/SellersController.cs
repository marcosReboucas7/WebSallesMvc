using Microsoft.AspNetCore.Mvc;

namespace WebSallesMvc.Controllers
{
    public class SellersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
