using Microsoft.AspNetCore.Mvc;
using System.Text;
using ReadEase.Application.Features.BookFeatures.Queries.GetAllBook;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using EntityFrameworkCorePagination.Nuget.Pagination;
using MediatR;
using ReadEase.Domain.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;

namespace ReadEase.WebApp.Controllers
{
    public class BookController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BookController(IHttpClientFactory httpClient)
        {
            _httpClientFactory = httpClient;
        }

        public IActionResult Index()
        {
            return View();
        } 
        public async Task<IActionResult> GetBookList(GetAllBookQuery bookQuery)
        {
            try
            {
                var apiUrl = "https://localhost:7020/api/BookControler/GetAllBook";

                //var jsonData = "{\"pageNumber\": 1, \"pageSize\": 10, \"search\": \"\"}";
                var jsonData = JsonConvert.SerializeObject(bookQuery);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                using(var httpClient = new HttpClient())
                {
                    var response = await httpClient.PostAsync(apiUrl, content);
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
