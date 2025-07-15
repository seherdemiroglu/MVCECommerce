using Microsoft.AspNetCore.Mvc;

namespace MVCECommerce.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
