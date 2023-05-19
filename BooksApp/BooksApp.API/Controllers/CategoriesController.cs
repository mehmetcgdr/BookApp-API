using AutoMapper;
using BooksApp.API.Models.DTOs;
using BooksApp.Business.Abstract;
using BooksApp.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace BooksApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryManager;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryManager, IMapper mapper)
        {
            _categoryManager = categoryManager;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _categoryManager.GetAllAsync();
            var categoriesDtos = _mapper.Map<List<Category>, List<CategoryDto>>(categories).ToArray();
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };
            var jsonString = JsonSerializer.Serialize(categoriesDtos, options);
            return Ok(jsonString);
        }
    }
}
