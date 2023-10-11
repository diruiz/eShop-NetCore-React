﻿using eShop.Application.Commands;
using eShop.Application.Queries;
using eShop.Models.eShopDbModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eShop.API.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class CatalogController : ControllerBase
{
    private readonly IMediator _mediator;
    public CatalogController(IMediator mediator)
    {
        _mediator = mediator;            
    }

    /// <summary>
    /// Gets all the catalog.
    /// </summary>    
    /// <returns>Returns all the catalog</returns>
    /// <response code="200">Success</response>    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Catalog>))]
    public async Task<ActionResult> Get(CancellationToken cancel = default)
    {
        var query = new GetAllCatalogQuery();
        return Ok(await _mediator.Send(query, cancel));
    }

    /// <summary>
    /// Gets a catalog item.
    /// </summary>    
    /// <returns>A catalog item filtered by id</returns>
    /// <response code="200">Success</response>  
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Catalog))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> Get(int id, CancellationToken cancel = default)
    {
        var query = new GetCatalogByIdQuery(){ Id = id };
        return Ok(await _mediator.Send(query, cancel));
    }

    /// <summary>
    /// Creates a catalog item.
    /// </summary>
    /// <param name="catalog"></param>
    /// <returns>A newly created catalog item</returns>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the request is not correct</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Catalog))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Post(CreateCatalogCommand catalog, CancellationToken cancel = default)
    {
        return Created("",await _mediator.Send(catalog, cancel));
    }

    /// <summary>
    /// Creates a catalog item.
    /// </summary>
    /// <param name="id">Id</param>
    /// <param name="catalog">Catalog Item</param>
    /// <returns>A newly created catalog item</returns>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the request is not correct</response>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult> Put(int id, [FromBody] UpdateCatalogCommand catalog)
    {
        var updated = await _mediator.Send(catalog);

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
    /// Delete a catalog item.
    /// </summary>
    /// <param name="id">Id</param>
    /// <returns>A newly created catalog item</returns>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the request is not correct</response>
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
