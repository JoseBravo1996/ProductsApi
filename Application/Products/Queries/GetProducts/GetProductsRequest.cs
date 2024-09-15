using Application.Commons.Interfaces.Repository;
using Application.Commons.ValidationHelpers;
using AutoMapper;
using MediatR;

namespace Application.Products.Queries.GetProducts;

public class GetProductsRequest : IRequest<List<ProductGetResponse>>
{
    public List<int>? Categories { get; set; }
    public string? Name { get; set; }
    public int Limit { get; set; }
    public int Offset { get; set; }
}

public class GetProductsRequestHandler(IProductRepository productRepository, IMapper mapper) : IRequestHandler<GetProductsRequest, List<ProductGetResponse>>
{
    private readonly IProductRepository _productRepository = productRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<List<ProductGetResponse>> Handle(GetProductsRequest request, CancellationToken cancellationToken)
    {
        var validator = new GetProductsRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        ValidationUtils.ValidateAndThrow(validationResult);

        var products = await _productRepository.GetProducts(request.Categories, request.Name, request.Limit, request.Offset);

        return _mapper.Map<List<ProductGetResponse>>(products);
    }
}
