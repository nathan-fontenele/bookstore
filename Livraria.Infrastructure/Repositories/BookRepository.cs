using Livraria.Domain.Entities;
using Livraria.Domain.Interfaces;
using Livraria.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Books> AddBookAsync(Books book)
        {
            if (book is not null && _context is not null && _context.Books is not null)
            {
                _context.Books.Add(book);
                await _context.SaveChangesAsync();
                return book;
            }
            else
            {
                throw new ArgumentNullException(nameof(book), "Book or context cannot be null");
            }
        }

        public Task DeleteBookAsync(Guid id)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);
            if (book is not null)
            {
                _context.Books.Remove(book);
                return _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException($"Book id not found.");
            }
        }

        public async Task<IEnumerable<Books>> GetAllBooksAsync()
        {
            if (_context is not null && _context.Books is not null)
            {
                var books = await _context.Books.ToListAsync();
                return books;
            }
            else
            {
                return Enumerable.Empty<Books>();
            }
        }

        public async Task<Books?> GetBookByIdAsync(Guid id)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);
            if (book is null)
                throw new InvalidOperationException($"Book id not found.");        
            return book;            
        }

        public async Task UpdateBookAsync(Books book)
        {
            if (book is not null)
            {
                _context.Entry(book).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentNullException(nameof(book), "Book fields is invalid");
            }
        }
    }
}