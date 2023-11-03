using Microsoft.AspNetCore.Mvc;
using webapi.DataAccess;
using webapi.Models;

namespace webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private IRepository repo;
        public CategoryController(IRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet("[action]")]
        public IEnumerable<Category> Get()
        {
            return repo.getCategories;
        }

        [HttpGet("[action]/{type}")]
        public IEnumerable<Category> Get([FromRoute] string type)
        {
            return repo.GetCategoriesByType(type);
        }

        [HttpPost("[action]")]
        public void Post([FromBody] Category category)
        {
            repo.addCategory(category);
        }
    }
}
