using Microsoft.AspNetCore.Mvc;
using webapi.Models;

namespace webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BillController : ControllerBase
    {
        [HttpGet("[action]")]
        public IEnumerable<Bill> Get()
        {
            return null;
        }
    }
}
