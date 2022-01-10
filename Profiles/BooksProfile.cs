namespace WebApiPlayground.Profiles
{
    using AutoMapper;
    using WebApiPlayground.Dtos.Books;
    using WebApiPlayground.Models;
    using WebApiPlayground.Services;

    public class BooksProfile : Profile
    {
        public BooksProfile()
        {
            CreateMap<Book, BookCreateDto>().ReverseMap();
            CreateMap<Book, BookReadDto>().ReverseMap();
            CreateMap<Book, BookUpdateDto>().ReverseMap();
        }
    }
}
