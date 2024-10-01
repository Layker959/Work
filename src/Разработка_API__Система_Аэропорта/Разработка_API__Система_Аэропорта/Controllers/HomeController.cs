using Microsoft.AspNetCore.Mvc;

namespace Разработка_API__Система_Аэропорта.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
