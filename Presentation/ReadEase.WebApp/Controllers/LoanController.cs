using Microsoft.AspNetCore.Mvc;

namespace ReadEase.WebApp.Controllers
{
    public class LoanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
