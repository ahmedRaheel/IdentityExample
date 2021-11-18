using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        // GET: api/Books
        [HttpGet]
        public IActionResult GetUsers()
        {
            return  new JsonResult(from c in User.Claims select new { c.Type, c.Value});
        }
    }
}
