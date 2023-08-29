using Microsoft.AspNetCore.Mvc;

namespace Web
{
    public class Services : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
