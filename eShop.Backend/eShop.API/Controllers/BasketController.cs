using eShop.Infrastructure.Redis;
using eShop.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Security.Claims;

namespace eShop.API.Controllers
{
    [Route("v1/[controller]")]
    [Authorize]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IDistributedCache _cache;
        public BasketController(IDistributedCache cache)
        {
            _cache = cache;            
        }
        
        [HttpGet]
        public async Task<ActionResult> GetUserBasket()
        {
            var principal = HttpContext.User.Identity as ClaimsIdentity;
            var userIdentifier = principal?.Claims.SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            var basket = await _cache.GetRecordAsync<List<BasketItem>>($"basket-{userIdentifier}");

            return Ok(basket);
        }

        [HttpPost]
        public async Task<ActionResult> SetUserBasket(List<BasketItem> basket)
        {
            var principal = HttpContext.User.Identity as ClaimsIdentity;
            var userIdentifier = principal?.Claims.SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            await _cache.SetRecordAsync($"basket-{userIdentifier}", basket, TimeSpan.FromDays(7)); //records stored for a week

            return Ok();
        }
    }
}
