using Microsoft.AspNetCore.Mvc;
using webapi.DataAccess;
using webapi.Models;

namespace webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private IRepository repo;
        public ProductController(IRepository repo)
        {
            this.repo = repo;
        }
        [HttpGet("[action]")]
        public IEnumerable<Product> Get()
        {
            return repo.getProducts.ToList();
        }

        [HttpGet("[action]/{categoryId}")]
        public IEnumerable<Product> Get(string categoryId)
        {
            return repo.getProductsByCategory(categoryId);
        }

        [HttpPost("[action]")]
        public void Post([FromBody] Product product)
        {
            repo.addProduct(product);
        }

        
    }
}
