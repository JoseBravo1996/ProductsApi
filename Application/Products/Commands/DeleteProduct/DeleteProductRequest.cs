using Application.Commons.Interfaces.Repository;
using AutoMapper;
using Domain.Constants;
using Domain.Exceptions;
using MediatR;

namespace Application.Products.Commands.DeleteProduct;

public class DeleteProductRequest : IRequest<ProductResponse>
{
    public required string Id { get; set; }
}

public class DeleteProductRequestHandler(IProductRepository productRepository, IMapper mapper) : IRequestHandler<DeleteProductRequest, ProductResponse>
{
    private readonly IProductRepository _productRepository = productRepository;
    private readonly IMapper _mapper = mapper;
    public async Task<ProductResponse> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
    {
        if (await _productRepository.GetProductById(new Guid(request.Id)) is null)
            throw new NotFoundException(ProductMessage.ProductNotFound);

        return _mapper.Map<ProductResponse>(await _productRepository.DeleteProduct(new Guid(request.Id)));
    }
}
