using Microsoft.AspNetCore.Mvc;
using webapi.Models;

namespace webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoleController : ControllerBase
    {
        [HttpGet("[action]")]
        public IEnumerable<Role> Get()
        {
            return null;
        }
    }
}
