using eShop.Application.Commands;
using eShop.Application.Queries;
using eShop.Models.eShopDbModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Channels;


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
    // GET: api/<CatalogController>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Catalog>))]
    public async Task<ActionResult> Get(CancellationToken cancel = default)
    {
        var query = new GetAllCatalogQuery();
        return Ok(await _mediator.Send(query, cancel));
    }

    // GET api/<CatalogController>/5
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Catalog))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> Get(int id, CancellationToken cancel = default)
    {
        var query = new GetCatalogByIdQuery(){ Id = id };
        return Ok(await _mediator.Send(query, cancel));
    }

    // POST api/<CatalogController>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Catalog))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Post(CreateCatalogCommand catalog, CancellationToken cancel = default)
    {
        return Created("",await _mediator.Send(catalog, cancel));
    }

    // PUT api/<CatalogController>/5
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

    // DELETE api/<CatalogController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
