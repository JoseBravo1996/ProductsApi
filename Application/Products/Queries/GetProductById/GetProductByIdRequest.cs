using Application.Commons.Interfaces.Repository;
using Application.Commons.ValidationHelpers;
using AutoMapper;
using Domain.Exceptions;
using MediatR;

namespace Application.Products.Queries.GetProductById;

public class GetProductByIdRequest : IRequest<ProductGetResponse>
{
    public string Id { get; set; }
}

public class GetProductByIdRequestHandler(IProductRepository productRepository, IMapper mapper) : IRequestHandler<GetProductByIdRequest, ProductGetResponse>
{
    private readonly IProductRepository _productRepository = productRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<ProductGetResponse> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
    {
        var validator = new GetProductByIdRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        ValidationUtils.ValidateAndThrow(validationResult);

        var product = _mapper.Map<ProductGetResponse>(await _productRepository.GetProductById(new Guid(request.Id)));

        return product == null ? 
            throw new NotFoundException($"Producto no encontrada con ID {request.Id}") 
            : _mapper.Map<ProductGetResponse>(product);
    }
}
