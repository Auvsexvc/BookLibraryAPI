using Microsoft.AspNetCore.Mvc;

namespace BookLibraryAPI.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet("get-data")]
        public IActionResult GetData()
        {
            return Ok("v1 Controller");
        }
    }
}