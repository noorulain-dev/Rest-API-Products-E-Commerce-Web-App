using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp0.data;

namespace WebApp0.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupportController : ControllerBase
    {
        private readonly DBService _db;
        public SupportController(DBService db)
        {
            _db = db;
        }

        [HttpGet()]
        public async Task<List<Support>> GetSupport()
        {
            return await _db.GetSupports();
        }

        [HttpPost()]
        public void CreateSupport(Support support)
        {
            support.Id = ObjectId.GenerateNewId();
            support.Type = Support.DBType;
            _db.CreateSupport(support);
        }

        [HttpDelete("{id}")]
        public void DeleteSupport(int id)
        {
            _db.DeleteSupport(id);
        }

    }
}