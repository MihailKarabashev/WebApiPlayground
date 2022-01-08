namespace WebApiPlayground.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using WebApiPlayground.Models;

    public interface IBookService
    {
        Task CreateAsync(Book book);

        Task RemoveAsync(string id);

        Task UpdateAsync(string id ,Book bookToUpdate);

        IEnumerable<Book> GetAll();

        Book GetById(string id);
    }
}
