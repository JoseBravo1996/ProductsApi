using Domain.Entities;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    public DbSet<Category> Category { get; set; }
    public DbSet<Product> Product { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        //ModelInitializer(builder);
        builder.Entity<Category>().HasData(
              new Category { CategoryId = 1, Name = "Electrodomésticos" },
              new Category { CategoryId = 2, Name = "Tecnología y Electrónica" },
              new Category { CategoryId = 3, Name = "Moda y Accesorios" },
              new Category { CategoryId = 4, Name = "Hogar y Decoración" },
              new Category { CategoryId = 5, Name = "Salud y Belleza" },
              new Category { CategoryId = 6, Name = "Deportes y Ocio" },
              new Category { CategoryId = 7, Name = "Juguetes y Juegos" },
              new Category { CategoryId = 8, Name = "Alimentos y Bebidas" },
              new Category { CategoryId = 9, Name = "Libros y Material Educativo" },
              new Category { CategoryId = 10, Name = "Jardinería y Bricolaje" }
          );
    }

    private static void ModelInitializer(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
    }
}
