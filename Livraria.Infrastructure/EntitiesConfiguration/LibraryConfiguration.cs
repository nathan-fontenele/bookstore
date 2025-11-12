using Livraria.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Livraria.Infrastructure.EntityConfiguration
{
    public class LibraryConfiguration : IEntityTypeConfiguration<Books>
    {
        public void Configure(EntityTypeBuilder<Books> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Title).HasMaxLength(100).IsRequired();
            builder.Property(b => b.Author).HasMaxLength(200).IsRequired();
            builder.Property(b => b.ReleaseDate).IsRequired();
            builder.Property(b => b.BookCover).HasMaxLength(200).IsRequired();
        }
    }
}