using AutoMapper;
using BooksApp.API.Models.DTOs;
using BooksApp.Entity.Concrete;

namespace BooksApp.API.Mapping
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Author,AuthorDto>().ReverseMap();
            CreateMap<Image,ImageDto>().ReverseMap();
            CreateMap<BookAuthor,AuthorDto>().ReverseMap();
            CreateMap<BookCategory,CategoryDto>().ReverseMap();
            CreateMap<Book, BookDto>()
                .ForMember(bdto => bdto.Authors, opt => opt.MapFrom(x => x.BookAuthors.Select(x => x.Author).ToArray()))
                .ForMember(bdto => bdto.Categories, opt => opt.MapFrom(x => x.BookCategories.Select(x => x.Category).ToArray()))
                .ReverseMap();
                }
    }
}
