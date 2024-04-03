using System.ComponentModel.DataAnnotations;
using Api.Constants;
using Application.Domain.Products.Commands.CreateProduct;
using Application.Domain.Products.Commands.DeleteProduct;
using Application.Domain.Products.Commands.UpdateProduct;
using Application.Domain.Products.Queries.GetProductDetails;
using Application.Domain.Products.Queries.GetProducts;
using AutoMapper;
using Core.Exceptions;
using DataTransfer.Dtos.Products;
using DataTransfer.Dtos.Products.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PagesResponses;

namespace Api.Controllers;

[ApiController]
[Route(Routes.Products)]
public class ProductController(IMediator mediator, IMapper mapper) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(PageResponse<ProductDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10,
        CancellationToken cancellationToken = default)
    {
        var products = await mediator.Send(new GetProductsQuery(page, pageSize), cancellationToken);
        return Ok(products);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ProductDetailsDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(
        [FromRoute] [Required] Guid id,
        CancellationToken cancellationToken)
    {
        var query = new GetProductDetailsQuery(id);
        try
        {
            var product = await mediator.Send(query, cancellationToken);
            return Ok(product);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPost]
    [ProducesResponseType(typeof(ProductDto), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create(
        [FromBody] [Required] CreateProductRequest request,
        CancellationToken cancellationToken)
    {
        var command = mapper.Map<CreateProductCommand>(request);
        var productId = await mediator.Send(command, cancellationToken);
        return StatusCode(StatusCodes.Status201Created, productId);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(
        [FromBody] [Required] UpdateProductRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            var command = mapper.Map<UpdateProductCommand>(request);
            await mediator.Send(command, cancellationToken);
            return NoContent();
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(
        [FromQuery] [Required] IReadOnlyCollection<Guid> ids,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var command = new DeleteProductCommand(ids);
            await mediator.Send(command, cancellationToken);
            return NoContent();
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }
}