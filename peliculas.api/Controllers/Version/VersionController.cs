using Microsoft.AspNetCore.Mvc;

namespace peliculas.api.Controllers.Version
{
    [Route("api/[controller]")]
    [ApiController]
    public class VersionController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("V1.0.0");
        }

    }
}
