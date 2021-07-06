using Microsoft.AspNetCore.Mvc;

namespace SoftToyShop.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
