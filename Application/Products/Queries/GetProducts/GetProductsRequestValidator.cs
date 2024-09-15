using FluentValidation;

namespace Application.Products.Queries.GetProducts;

public class GetProductsRequestValidator : AbstractValidator<GetProductsRequest>
{
    public GetProductsRequestValidator()
    {
        RuleFor(request => request.Limit)
            .GreaterThanOrEqualTo(0)
            .WithMessage("El parámetro 'limit' debe ser mayor o igual a cero.");

        RuleFor(request => request.Offset)
            .GreaterThanOrEqualTo(0)
            .WithMessage("El parámetro 'offset' debe ser mayor o igual a cero.");
    }
}