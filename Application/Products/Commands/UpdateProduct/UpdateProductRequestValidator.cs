using Application.Commons.Interfaces.Repository;
using Application.Commons.ValidationHelpers;
using FluentValidation;

namespace Application.Products.Commands.UpdateProduct;

public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
{
    private readonly ICategoryRepository _categoryRepository;
    public UpdateProductRequestValidator(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;

        RuleFor(request => request.Id).NotEmpty().WithMessage("El ID del producto es obligatorio.")
            .Must(ValidationHelpers.BeGuid).WithMessage("El ID debe ser un GUID válido.");
        RuleFor(request => request.Name).NotEmpty().WithMessage("El nombre del producto es obligatorio.");
        RuleFor(request => request.Description).NotEmpty().WithMessage("La descripción del producto es obligatoria.");
        RuleFor(request => request.Price).GreaterThan(0).WithMessage("El precio del producto debe ser mayor que cero.");
        RuleFor(request => request.CategoryId).GreaterThan(0).WithMessage("El ID de la categoría del producto debe ser mayor que cero.");
        RuleFor(x => x.CategoryId).MustAsync(async (category, cancellation) =>
        {
            return await _categoryRepository.GetExistCategory(category);
        }).WithMessage("La categoria no existe.");
        RuleFor(request => request.Discount).InclusiveBetween(0, 100).When(request => request.Discount.HasValue).WithMessage("El descuento del producto debe estar entre 0 y 100.");
        RuleFor(request => request.ImageUrl).NotEmpty().WithMessage("La URL de la imagen del producto es obligatoria.");
        
    }
}