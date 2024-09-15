using Application;
using Domain.Entities;
using FluentValidation.AspNetCore;
using Infrastructure;
using Infrastructure.Persistence;
using Microsoft.OpenApi.Models;
using System.Reflection;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation(v =>
{
    v.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(swagger =>
{
    swagger.EnableAnnotations();
    swagger.SupportNonNullableReferenceTypes();
    swagger.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Products ECommerce Web API",
        Description = "Products ECommerce Project"
    });
});


builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy("Politica", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseCors("Politica");

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<DataContext>();

    // Ensures the database is created
    context.Database.EnsureCreated();

    // Call the method to seed data
    SeedData(context);
}

app.UseAuthorization();

app.MapControllers();

app.Run();

void SeedData(DataContext context)
{
    if (!context.Category.Any())
    {
        context.Category.AddRange(
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

        context.SaveChanges();
    }
}