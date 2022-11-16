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
 


[HttpGet, Route("content/{category}")]
    public ActionResult<(ContentResult, string)> ConfirmVerify(string category)
    {   
        var html="";
        try{
        html = System.IO.File.ReadAllText(@"./assests/html/" + category + ".html");
    } 
    catch(SystemException){ return NotFound("File not found");
    } 
        return Ok((base.Content(html, "text/html"), category));
    }}
    



}