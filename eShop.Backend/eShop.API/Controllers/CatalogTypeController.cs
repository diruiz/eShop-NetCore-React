﻿using eShop.Application.Commands;
using eShop.Application.Queries;
using eShop.Models.eShopDbModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eShop.API.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class CatalogTypeController : ControllerBase
{
    private readonly IMediator _mediator;
    public CatalogTypeController(IMediator mediator)
    {
        _mediator = mediator;            
    }

    /// <summary>
    /// Gets all the catalogType.
    /// </summary>    
    /// <returns>Returns all the catalogType</returns>
    /// <response code="200">Success</response>    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CatalogType>))]
    public async Task<ActionResult> Get(CancellationToken cancel = default)
    {
        var query = new GetAllCatalogTypeQuery();
        return Ok(await _mediator.Send(query, cancel));
    }

    /// <summary>
    /// Gets a catalogType item.
    /// </summary>    
    /// <returns>A catalogType item filtered by id</returns>
    /// <response code="200">Success</response>  
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CatalogType))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> Get(int id, CancellationToken cancel = default)
    {
        var query = new GetCatalogTypeByIdQuery(){ Id = id };
        return Ok(await _mediator.Send(query, cancel));
    }

    /// <summary>
    /// Creates a catalogType item.
    /// </summary>
    /// <param name="catalogType"></param>
    /// <returns>Ok Response</returns>
    /// <response code="200">Success</response>
    /// <response code="400">If the request is not correct</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CatalogType))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Post(CreateCatalogTypeCommand catalogType, CancellationToken cancel = default)
    {
        return Created("",await _mediator.Send(catalogType, cancel));
    }

    /// <summary>
    /// Creates a catalogType item.
    /// </summary>
    /// <param name="id">Id</param>
    /// <param name="catalogType">CatalogType Item</param>
    /// <returns>A newly created catalogType item</returns>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the request is not correct</response>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult> Put(int id, [FromBody] UpdateCatalogTypeCommand catalogType)
    {
        var updated = await _mediator.Send(catalogType);

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
    /// Delete a catalogType item.
    /// </summary>
    /// <param name="id">Id</param>
    /// <returns>A newly created catalogType item</returns>
    /// <response code="200">Success</response>
    /// <response code="404">If the item is not found</response>
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteCatalogTypeCommand(id);
        var deleted = await _mediator.Send(command);
        return deleted ? Ok() : NotFound();
    }
}
