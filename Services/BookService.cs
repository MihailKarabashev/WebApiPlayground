namespace WebApiPlayground.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using WebApiPlayground.Data;
    using WebApiPlayground.Models;
    using static Common.ErrorMessages.Book;

    public class BookService : IBookService
    {
        private readonly ApplicationDbContext _context;

        public BookService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Book book)
        {
            if(_context.Books.Any(x => x.Name == book.Name)){
                throw new ArgumentException(BookAlreadyExist);
            }

            if (book == null)
            {
                throw new NullReferenceException(nameof(book));
            }

            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Book> GetAll() => _context.Books.ToList();

        public Book GetById(string id) => _context.Books.FirstOrDefault(x => x.Id == id);

        public Task RemoveAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(string id, Book book)
        {
            throw new System.NotImplementedException();
        }
    }
}
