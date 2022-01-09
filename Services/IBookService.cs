namespace WebApiPlayground.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using WebApiPlayground.Models;

    public interface IBookService
    {
        Task CreateAsync(Book book);

        Task RemoveAsync(string id);

        Task UpdateAsync(Book bookToUpdate);

        Task<IEnumerable<Book>> GetAllAsync();

        Task<Book> GetByIdAsync(string id);
    }
}
