using Livraria.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Livraria.Domain.Entities
{
    public class Books
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Título é obrigatório")]
        [StringLength(100)]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Autor é obrigatório")]
        [StringLength(200)]
        public string? Author { get; set; }

        [Required(ErrorMessage = "Capa do livro é obrigatória")]
        [StringLength(200)]
        public string? BookCover { get; set; }

        [Required(ErrorMessage = "Data de lançamento é obrigatória")]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "Editora é obrigatória")]
        [EnumDataType(typeof(Publisher), ErrorMessage = "Editora é obrigatória")]
        public Publisher Publisher { get; set; }

        [Required(ErrorMessage = "Categoria é obrigatória")]
        [EnumDataType(typeof(Category), ErrorMessage = "Categoria é obrigatória")]
        public Category Category { get; set; }

        public Books(Guid id, string? title, string? author, string? bookCover, DateTime releaseDate, Publisher publisher, Category category)
        {
            Id = id;
            Title = title;
            Author = author;
            BookCover = bookCover;
            ReleaseDate = releaseDate;
            Publisher = publisher;
            Category = category;
        }
    }
}
