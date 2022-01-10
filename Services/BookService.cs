namespace WebApiPlayground.Services
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using WebApiPlayground.Data;
    using WebApiPlayground.Models;
    using static Common.ErrorMessages.Book;
    using static WebApiPlayground.Common.CustomExceptions;

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

        public async Task<IEnumerable<Book>> GetAllAsync() => await _context.Books.ToListAsync();

        public PagedList<Book> GetAllPaginatedBooks(BookParameters parameters)
            => PagedList<Book>.ToPagedList( _context.Books.OrderBy(x => x.Name), parameters.PageNumber, parameters.PageSize);

        public  async Task<Book> GetByIdAsync(string id) 
            => await _context.Books.FirstOrDefaultAsync(x => x.Id == id);

        public async Task RemoveAsync(string id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);

            if (book == null)
            {
                throw new NotFoundException(BookDoestNotExist);
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Book bookToUpdate)
        {
            _context.Books.Update(bookToUpdate);
            await _context.SaveChangesAsync();
        }
    }
}
