using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Contexts;
using WebApplication2.Middleware;

namespace WebApplication2.Controllers
{
    [AuthorizeRole(1)]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            return Ok(new {Message = "Welcome admin to the dashboard!"});
        }
    }
}
