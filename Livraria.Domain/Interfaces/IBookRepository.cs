namespace Livraria.Domain.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Entities.Books>> GetAllBooksAsync();
        Task<Entities.Books?> GetBookByIdAsync(Guid id);
        Task AddBookAsync(Entities.Books book);
        Task UpdateBookAsync(Entities.Books book);
        Task DeleteBookAsync(Guid id);
    }
}
