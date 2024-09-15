using Application.Commons.Interfaces.Repository;
using Application.Commons.ValidationHelpers;
using AutoMapper;
using MediatR;

namespace Application.Products.Commands.CreateProduct;

public class ProductRequest : IRequest<ProductResponse>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Discount { get; set; }
    public string ImageUrl { get; set; }
    public int Category { get; set; }
}

public class ProductRequestHandler(IProductRepository productRepository, ICategoryRepository categoryRepository, IMapper mapper) : IRequestHandler<ProductRequest, ProductResponse>
{
    private readonly IProductRepository _productRepository = productRepository;
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<ProductResponse> Handle(ProductRequest request, CancellationToken cancellationToken)
    {
        var validator = new ProductRequestValidator(_categoryRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        ValidationUtils.ValidateAndThrow(validationResult);

        var product = await _productRepository.CreateProduct(request);

        return _mapper.Map<ProductResponse>(product);
    }
}