using Microsoft.AspNetCore.Mvc;

namespace ProjectShopMVC.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
