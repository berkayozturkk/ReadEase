using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReadEase.Application.Features.LoanFeatures.Command.BorrowBook;
using System.Text;

namespace ReadEase.WebApp.Controllers
{
    public class LoanController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        public LoanController(IHttpClientFactory httpClient) : base(httpClient) { }

        public async Task<IActionResult> BorrowBook(BorrowBookCommand borrowCommand)
        {
            try
            {
                var requestUrl = baseApiUrl + "LoanController/BorrowBookAsync";

                var jsonData = JsonConvert.SerializeObject(borrowCommand);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.PostAsync(requestUrl, content);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = await response.Content.ReadAsStringAsync();
                        return Ok(responseData);
                    }
                    else
                    {
                        var errorMessage = await response.Content.ReadAsStringAsync();
                        return BadRequest(errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
