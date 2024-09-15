using Application.Commons.Interfaces.Repository;
using Application.Commons.ValidationHelpers;
using AutoMapper;
using Domain.Constants;
using Domain.Exceptions;
using MediatR;

namespace Application.Products.Commands.UpdateProduct;

public class UpdateProductRequest : IRequest<ProductResponse>
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public int? Discount { get; set; }
    public string ImageUrl { get; set; }
}

public class UpdateProductRequestHandler(IProductRepository productRepository, IMapper mapper, ICategoryRepository categoryRepository) : IRequestHandler<UpdateProductRequest, ProductResponse>
{
    private readonly IProductRepository _productRepository = productRepository;
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<ProductResponse> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
    {
        var validator = new UpdateProductRequestValidator(_categoryRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        ValidationUtils.ValidateAndThrow(validationResult);

        if (await _productRepository.GetProductById(new Guid(request.Id)) is null)
            throw new NotFoundException(ProductMessage.ProductNotFound);

        return _mapper.Map<ProductResponse>(await _productRepository.UpdateProduct(new Guid(request.Id), request));
    }
}