using Application.Commons.Models;
using Application.Products.Commands;
using Application.Products.Commands.CreateProduct;
using Application.Products.Commands.DeleteProduct;
using Application.Products.Commands.UpdateProduct;
using Application.Products.Queries;
using Application.Products.Queries.GetProductById;
using Application.Products.Queries.GetProducts;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel;

namespace ECommerce.Api.Controllers;

[Route("api/[controller]")]
public class ProductController : ApiControllerBase
{

    [HttpGet]
    [ProducesResponseType(typeof(List<ProductGetResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
    [SwaggerOperation(Summary = "Obtiene una lista de productos.", Description = "Recuperar una lista de productos disponibles, con opciones de filtrado.")]
    public async Task<IActionResult> GetProductsAsync([FromQuery]
    [SwaggerParameter("Filtrar productos por categorías. Es posible filtrar por 1 o más categorias. Filtro opcional")]
    List<int>? categories,
    [SwaggerParameter("Filtrar productos por nombre. Es posible filtrar por nombres incompletos")]
    string? name,
    [SwaggerParameter("Limita el número de productos devueltos.")]
    [DefaultValue(0)] int limit = 0,
    [SwaggerParameter("Número de productos a omitir antes de empezar a devolver los resultados.")]
    [DefaultValue(0)] int offset = 0)
    {
        try
        {
            var request = new GetProductsRequest
            {
                Categories = categories,
                Name = name,
                Limit = limit,
                Offset = offset
            };

            var response = await Mediator.Send(request);
            return Ok(response);
        }
        catch (BadRequestException ex)
        {
            return BadRequest(new ApiError { Message = ex.Message });
        }


    }

    [HttpPost]
    [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiError), StatusCodes.Status409Conflict)]
    [SwaggerOperation(Summary = "Crea un nuevo producto.", Description = "Permite la creación de un nuevo producto en el sistema.")]
    public async Task<IActionResult> CreateProduct([FromBody] ProductRequest productRequest)
    {
        try
        {
            var response = await Mediator.Send(productRequest);
            return CreatedAtAction(nameof(CreateProduct), response);
        }
        catch (BadRequestException ex)
        {
            return BadRequest(new ApiError { Message = ex.Message });
        }
        catch (ConflictException ex)
        {
            return Conflict(new ApiError { Message = ex.Message });
        }
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ProductGetResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
    [SwaggerOperation(Summary = "Obtiene detalles de un producto específico.", Description = "Recupera los detalles de un producto por su ID único.")]
    public async Task<IActionResult> GetProductByIdAsync(string id)
    {
        try
        {
            var request = new GetProductByIdRequest() { Id = id };
            var response = await Mediator.Send(request);

            return Ok(response);
        }
        catch (NotFoundException ex)
        {
            return NotFound(new ApiError { Message = ex.Message });
        }
        catch (BadRequestException ex)
        {
            return BadRequest(new ApiError { Message = ex.Message });
        }
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
    [SwaggerOperation(Summary = "Actualiza un producto existente.", Description = "Permite la actualización de los detalles de un producto específico.")]
    public async Task<IActionResult> UpdateProduct(string id, [FromBody] ProductRequest productRequest)
    {
        try
        {
            var request = new UpdateProductRequest()
            {
                Id = id,
                Name = productRequest.Name,
                Description = productRequest.Description,
                Price = productRequest.Price,
                CategoryId = productRequest.Category,
                Discount = productRequest.Discount,
                ImageUrl = productRequest.ImageUrl
            };
            return Ok(await Mediator.Send(request));
        }
        catch (BadRequestException ex)
        {
            return BadRequest(new ApiError { Message = ex.Message });
        }
        catch (NotFoundException ex)
        {
            return NotFound(new ApiError { Message = ex.Message });
        }

    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
    [SwaggerOperation(Summary = "Elimina un producto específico.", Description = "Permite la eliminación de un producto del sistema usando su ID.")]
    public async Task<IActionResult> DeleteProduct(string id)
    {
        try
        {
            return Ok(await Mediator.Send(new DeleteProductRequest { Id = id }));
        }
        catch (NotFoundException ex)
        {
            return NotFound(new ApiError { Message = ex.Message });
        }
    }
}
