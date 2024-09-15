using Application.Commons.Interfaces.Repository;
using FluentValidation;

namespace Application.Products.Commands.CreateProduct;

public class ProductRequestValidator : AbstractValidator<ProductRequest>
{
    private readonly ICategoryRepository _categoryRepository;
    public ProductRequestValidator(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;

        RuleFor(request => request.Name).NotEmpty().WithMessage("El nombre del producto es obligatorio.");
        RuleFor(request => request.Description).NotEmpty().WithMessage("La descripción del producto es obligatoria.");
        RuleFor(request => request.Price).GreaterThan(0).WithMessage("El precio del producto debe ser mayor que cero.");
        RuleFor(request => request.Discount).GreaterThanOrEqualTo(0).WithMessage("El descuento del producto debe ser mayor o igual a cero.");
        RuleFor(request => request.ImageUrl).NotEmpty().WithMessage("La URL de la imagen del producto es obligatoria.");
        RuleFor(request => request.Category).GreaterThan(0).WithMessage("El ID de la categoría del producto debe ser mayor que cero.");
        RuleFor(x => x.Category).MustAsync(async (category, cancellation) =>
        {
            return await _categoryRepository.GetExistCategory(category);
        }).WithMessage("La categoria no existe.");
    }
}