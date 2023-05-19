using AutoMapper;
using BooksApp.API.Models.DTOs;
using BooksApp.Business.Abstract;
using BooksApp.Business.Concrete;
using BooksApp.Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BooksApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookManager;
        private readonly ICategoryService _categoryManager;
        private readonly IMapper _mapper;
        public BooksController(IBookService bookManager, ICategoryService categoryManager, IMapper mapper)
        {
            _bookManager = bookManager;
            _categoryManager = categoryManager;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            #region ReturnBooks
            //List<Book> books = await _bookManager.GetAllBooksFullDataAsync(true);
            //List<BookDto> bookDtos = books.Select(x => new BookDto
            //{
            //    Id = x.Id,
            //    Name = x.Name,
            //    CreatedDate = x.CreatedDate,
            //    ModifiedDate = x.ModifiedDate,
            //    EditionNumber = x.EditionNumber,
            //    EditionYear = x.EditionYear,
            //    IsApproved = x.IsApproved,
            //    PageCount = x.PageCount,
            //    Price = x.Price,
            //    Stock = x.Stock,
            //    Url = x.Url,
            //    Summary = x.Summary,
            //    Authors = x.BookAuthors.Select(x => new AuthorDto
            //    {
            //        Id = x.AuthorId,
            //        About = x.Author.About,
            //        BirthDate = x.Author.BirthDate,
            //        CreatedDate = x.Author.CreatedDate,
            //        Gender = x.Author.Gender,
            //        ImageUrl = x.Author.ImageUrl,
            //        IsApproved = x.Author.IsApproved,
            //        ModifiedDate = x.Author.ModifiedDate,
            //        Name = x.Author.Name,
            //        Url = x.Author.Url,
            //    }).ToArray(),
            //    Categories = x.BookCategories.Select(x => new CategoryDto
            //    {
            //        Id = x.Category.Id,
            //        Name = x.Category.Name,
            //        Url = x.Category.Url,
            //        Description = x.Category.Description
            //    }).ToArray(),
            //    Images = x.Images.Select(x => new ImageDto
            //    {
            //        Id = x.Id,
            //        BookId = x.BookId,
            //        Url = x.Url
            //    }).ToArray()
            //}).ToList();
            //var options = new JsonSerializerOptions
            //{
            //    ReferenceHandler = ReferenceHandler.Preserve
            //};
            //var jsonResult = JsonSerializer.Serialize(bookDtos.ToArray(), options);
            //return Ok(jsonResult);
            #endregion
            #region Kategori listesi döndürme
            //List<Category> categories = await _categoryManager.GetAllAsync();
            //CategoryDto[] categoryDtos = _mapper.Map<List<Category>, List<CategoryDto>>(categories).ToArray();
            //var jsonResult = JsonSerializer.Serialize(categoryDtos);
            //return Ok(jsonResult);
            #endregion
            var books = await _bookManager.GetAllBooksFullDataAsync(true); 
            var bookDtos=_mapper.Map<List<Book>,List<BookDto>>(books).ToArray();
            var options =new JsonSerializerOptions{
                ReferenceHandler=ReferenceHandler.Preserve
            };
            var jsonString = JsonSerializer.Serialize(bookDtos, options);
            return Ok(jsonString);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var book = await _bookManager.GetBookFullDataAsync(id);
            var bookDto=_mapper.Map<Book,BookDto>(book);
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };
            var jsonString = JsonSerializer.Serialize(bookDto, options);
            return Ok(jsonString);
        }
    }
}
