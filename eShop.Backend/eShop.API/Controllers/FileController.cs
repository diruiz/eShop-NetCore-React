using eShop.Infrastructure.S3;
using eShop.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eShop.API.Controllers
{
    [Route("v1/[controller]")]
    [Authorize]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IS3Bucket _s3Bucket;
        public FileController(IS3Bucket s3Bucket)
        {
            _s3Bucket = s3Bucket;            
        }
       
        [HttpGet("{fileName}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FileStreamResult))]        
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Get(string fileName)
        {
            var (stream, contentType) = await _s3Bucket.GetFileAsync(fileName);
            return File(stream, contentType);
        }

        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UploadedFileDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Post(IFormFile file)
        {
            if (file.Length == 0)
            {
                return BadRequest("Empty file");
            }

            return Ok(await _s3Bucket.UploadFileAsync(file.OpenReadStream(), file.FileName));            
        }
        
    }
}
