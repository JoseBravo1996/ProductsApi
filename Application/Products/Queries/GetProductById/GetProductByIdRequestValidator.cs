using FluentValidation;

namespace Application.Products.Queries.GetProductById;

public class GetProductByIdRequestValidator : AbstractValidator<GetProductByIdRequest>
{
    public GetProductByIdRequestValidator()
    {
        RuleFor(request => request.Id).Must(BeGuid).WithMessage("El ID debe ser un GUID válido.");
    }

    private bool BeGuid(string id) => Guid.TryParse(id, out _);
}