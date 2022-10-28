using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp0.data;

namespace WebApp0.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly DBService _db;
        public ProductController(DBService db)
        {
            _db = db;
        }

        [HttpGet()]
        public async Task<List<Product>> GetProducts()
        {
            return await _db.GetProducts();
        }

        [HttpPost()]
        public void CreateProduct(Product product)
        {
            product.Id = ObjectId.GenerateNewId();
            product.Type = Product.DBType;
            _db.CreateProduct(product);
        }

        [HttpDelete("{id}")]
        public void DeleteProduct(int id)
        {
            _db.DeleteProduct(id);
        }

    }
}