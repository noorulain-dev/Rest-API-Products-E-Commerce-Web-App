using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp0.data;

namespace WebApp0.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly DBService _db;
        public BasketController(DBService db)
        {
            _db = db;
        }

        [HttpGet()]
        public async Task<List<Basket>> GetBasket()
        {
            return await _db.GetBaskets();
        }

        [HttpPost()]
        public void CreateBasket(Basket basket)
        {
            basket.Id = ObjectId.GenerateNewId();
            basket.Type = Basket.DBType;
            _db.CreateBasket(basket);
        }

        [HttpDelete("{id}")]
        public void DeleteBasket(int id)
        {
            _db.DeleteBasket(id);
        }

    }
}