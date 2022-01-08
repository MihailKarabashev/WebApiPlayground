namespace WebApiPlayground.Profiles
{
    using AutoMapper;
    using WebApiPlayground.Dtos.Books;
    using WebApiPlayground.Models;

    public class BooksProfile : Profile
    {
        public BooksProfile()
        {
            CreateMap<BookCreateDto, Book>();
            CreateMap<Book, BookCreateDto>();
            CreateMap<Book, BookReadDto>();
            CreateMap<BookReadDto, Book>();
        }
    }
}
