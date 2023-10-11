using eShop.Application.Commands;
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
    // GET: api/<CatalogController>
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    // GET api/<CatalogController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<CatalogController>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Post(CreateCatalogCommand catalog, CancellationToken cancel = default)
    {
        return Created("",await _mediator.Send(catalog, cancel));
    }

    // PUT api/<CatalogController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<CatalogController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
