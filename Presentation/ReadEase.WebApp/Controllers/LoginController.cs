using Microsoft.AspNetCore.Mvc;

namespace ReadEase.WebApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Authenticate(string username, string password)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
