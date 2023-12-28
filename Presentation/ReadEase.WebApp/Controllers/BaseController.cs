using Microsoft.AspNetCore.Mvc;

namespace ReadEase.WebApp.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IHttpClientFactory _httpClientFactory;
        protected readonly string baseApiUrl = "https://localhost:7020/api/";
        public BaseController(IHttpClientFactory httpClient)
        {
            _httpClientFactory = httpClient;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
