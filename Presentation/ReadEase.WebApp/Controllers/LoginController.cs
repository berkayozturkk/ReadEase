using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReadEase.Application.Features.UserFeatures.Command.UserLogin;
using System.Text;

namespace ReadEase.WebApp.Controllers
{
    public class LoginController : BaseController
    {
        public LoginController(IHttpClientFactory httpClient) : base(httpClient){}

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Authenticate(string username, string password)
        {
            UserLoginCommand user = new UserLoginCommand(username,password);

            var requestUrl = baseApiUrl + "User/UserLogin";

            var jsonData = JsonConvert.SerializeObject(user);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            using (var httpClient = new HttpClient())
            {
                var response =  await httpClient.PostAsync(requestUrl, content);
                string responseContent = await response.Content.ReadAsStringAsync();

                if (!string.IsNullOrEmpty(responseContent))
                    return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Login");
        }
    }
}
