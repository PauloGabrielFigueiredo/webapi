using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers.appuser
{
    public class UtilitisController :BaseApiController
    {
    [Authorize]
    [HttpGet,Route("Version")]
    
    public ActionResult<string> Version(string username)
    {
        return Ok("Version 1.0");

        
    }
    }
}