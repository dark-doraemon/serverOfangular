using Microsoft.AspNetCore.Mvc;
using webapi.DataAccess;
using webapi.Models;

namespace webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IRepository repo;
        public UserController(IRepository repo)
        {
            this.repo = repo;
        }
        [HttpGet("[action]")]
        public IEnumerable<User> Get()
        {
            return repo.getUsers;
        }

        [HttpPost("[action]")]
        public void Post([FromBody] User user)
        {
            repo.addUser(user); 
        }
    }
}
