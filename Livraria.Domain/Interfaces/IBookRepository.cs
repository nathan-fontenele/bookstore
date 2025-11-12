using Livraria.Domain.Entities;

namespace Livraria.Domain.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Books>> GetAllBooksAsync();
        Task<Books?> GetBookByIdAsync(Guid id);
        Task<Books> AddBookAsync(Books book);
        Task UpdateBookAsync(Books book);
        Task DeleteBookAsync(Guid id);
    }
}
