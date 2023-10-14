using eShop.Application.Commands;
using eShop.Application.Queries;
using eShop.Models.eShopDbModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eShop.API.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class CatalogBrandController : ControllerBase
{
    private readonly IMediator _mediator;
    public CatalogBrandController(IMediator mediator)
    {
        _mediator = mediator;            
    }

    /// <summary>
    /// Gets all the catalogBrand.
    /// </summary>    
    /// <returns>Returns all the catalogBrand</returns>
    /// <response code="200">Success</response>    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CatalogBrand>))]
    public async Task<ActionResult> Get(CancellationToken cancel = default)
    {
        var query = new GetAllCatalogBrandQuery();
        return Ok(await _mediator.Send(query, cancel));
    }

    /// <summary>
    /// Gets a catalogBrand item.
    /// </summary>    
    /// <returns>A catalogBrand item filtered by id</returns>
    /// <response code="200">Success</response>  
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CatalogBrand))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> Get(int id, CancellationToken cancel = default)
    {
        var query = new GetCatalogBrandByIdQuery(){ Id = id };
        return Ok(await _mediator.Send(query, cancel));
    }

    /// <summary>
    /// Creates a catalogBrand item.
    /// </summary>
    /// <param name="catalogBrand"></param>
    /// <returns>Ok Response</returns>
    /// <response code="200">Success</response>
    /// <response code="400">If the request is not correct</response>
    [Authorize]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CatalogBrand))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Post(CreateCatalogBrandCommand catalogBrand, CancellationToken cancel = default)
    {
        return Created("",await _mediator.Send(catalogBrand, cancel));
    }

    /// <summary>
    /// Creates a catalogBrand item.
    /// </summary>
    /// <param name="id">Id</param>
    /// <param name="catalogBrand">CatalogBrand Item</param>
    /// <returns>A newly created catalogBrand item</returns>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the request is not correct</response>
    [Authorize]
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult> Put(int id, [FromBody] UpdateCatalogBrandCommand catalogBrand)
    {
        var updated = await _mediator.Send(catalogBrand);

        if (updated)
        {
            return Ok();
        }
        else 
        {
            return Conflict();
        }
    }

    /// <summary>
    /// Delete a catalogBrand item.
    /// </summary>
    /// <param name="id">Id</param>
    /// <returns>A newly created catalogBrand item</returns>
    /// <response code="200">Success</response>
    /// <response code="404">If the item is not found</response>
    [Authorize]
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteCatalogBrandCommand(id);
        var deleted = await _mediator.Send(command);
        return deleted ? Ok() : NotFound();
    }
}
