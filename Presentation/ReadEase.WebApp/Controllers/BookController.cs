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
using ReadEase.Application.Features.BookFeatures.Queries.GetAllBookGenre;
using ReadEase.Application.Features.BookFeatures.Command.CreateBook;
using ReadEase.Application.Features.BookFeatures.Queries.GetAllBookByStatus;

namespace ReadEase.WebApp.Controllers
{
    public class BookController : BaseController
    {
        public BookController(IHttpClientFactory httpClient) : base(httpClient){}

        //private readonly IHttpClientFactory _httpClientFactory;
        //public BookController(IHttpClientFactory httpClient)
        //{
        //    _httpClientFactory = httpClient;
        //}

        public IActionResult Index()
        {
            return View();
        } 

        public async Task<IActionResult> GetBookList(GetAllBookQuery bookQuery)
        {
            try
            {
                var requestUrl = baseApiUrl + "BookControler/GetAllBook";

                var jsonData = JsonConvert.SerializeObject(bookQuery);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                using(var httpClient = new HttpClient())
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

        public async Task<IActionResult> GetAllBookByStatus(GetAllBookByStatusQuery bookQuery)
        {
            try
            {
                var requestUrl = baseApiUrl + "BookControler/GetAllBookByStatus";

                var jsonData = JsonConvert.SerializeObject(bookQuery);
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

        public async Task<IActionResult> GetBookGenreList()
        {
            try
            {
                var requestUrl = baseApiUrl + "BookControler/GetAllBookGenre";
                var jsonData = JsonConvert.SerializeObject(new GetAllBookGenreQuery());
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
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        public async Task<IActionResult> AddBook(CreateBookCommand book)
        {
            try
            {
                var requestUrl = baseApiUrl + "BookControler/CreateBook";

                var jsonData = JsonConvert.SerializeObject(book);
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
