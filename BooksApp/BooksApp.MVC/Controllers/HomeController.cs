using BooksApp.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BooksApp.MVC.Controllers
{
    public class HomeController : Controller
    {

        public async Task<IActionResult> Index()
        {
            var books = new List<Book>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5200/api/Books"))
                {
                    string contentResponse = await response.Content.ReadAsStringAsync();
                    books = JsonSerializer.Deserialize<List<Book>>(contentResponse);
                }
            }
            return View(books);
        }
        public async Task<IActionResult> Categories()
        {
            var categories = new List<Category>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5200/api/categories"))
                {
                    string contentResponse = await response.Content.ReadAsStringAsync();
                    categories = JsonSerializer.Deserialize<List<Category>>(contentResponse);
                }
            }
            return View(categories);
        }
        public async Task<IActionResult> GetById(int id)
        {
            var book = new Book();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"http://localhost:5200/api/Books/{id}"))
                {
                    string contentResponse = await response.Content.ReadAsStringAsync();
                    book = JsonSerializer.Deserialize<Book>(contentResponse);
                }
            }
            return View(book);
        }
    }
}