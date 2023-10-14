using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace eShop.API.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class ClaimsController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public string GetNameIdentifier()
        {
            var principal = HttpContext.User.Identity as ClaimsIdentity;

            var login = principal?.Claims.SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            return login;
        }
    }
}
