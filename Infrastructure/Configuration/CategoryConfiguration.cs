using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> entityBuilder)
    {
        entityBuilder.HasKey(e => e.CategoryId).HasName("PK__Category__19093A0BC8BAD7F1");

        entityBuilder.ToTable("Category");

        entityBuilder.Property(e => e.Name).HasMaxLength(100);

        entityBuilder.HasData(GetInitialCategories());
    }

    private static readonly List<Category> _categories =
    [
        new() { CategoryId = 1, Name = "Electrodomésticos" },
        new() { CategoryId = 2, Name = "Tecnología y Electrónica" },
        new() { CategoryId = 3, Name = "Moda y Accesorios" },
        new() { CategoryId = 4, Name = "Hogar y Decoración" },
        new() { CategoryId = 5, Name = "Salud y Belleza" },
        new() { CategoryId = 6, Name = "Deportes y Ocio" },
        new() { CategoryId = 7, Name = "Juguetes y Juegos" },
        new() { CategoryId = 8, Name = "Alimentos y Bebidas" },
        new() { CategoryId = 9, Name = "Libros y Material Educativo" },
        new() { CategoryId = 10, Name = "Jardinería y Bricolaje" },
    ];

    private static IEnumerable<Category> GetInitialCategories() => _categories;

}
