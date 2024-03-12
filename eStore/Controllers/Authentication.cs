using Microsoft.AspNetCore.Mvc;

namespace eStore.Controllers
{
    public class Authentication : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
