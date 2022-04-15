using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseApiController : ControllerBase
{        
    
    [HttpGet,Route("Version")]
    public ActionResult<string> Version(string username)
    {
        return Ok("Version 1.0");

        
    }
}
