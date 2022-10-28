using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp0.data;

namespace WebApp0.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly DBService _db;
        public UserController(DBService db)
        {
            _db = db;
        }

        [HttpGet()]
        public async Task<List<User>> GetUsers()
        {
            return await _db.GetUsers();
        }

        [HttpPost()]
        public void CreateUser(User user)
        {
            user.Id = ObjectId.GenerateNewId();
            user.Type = WebApp0.data.User.DBType;
            _db.CreateUser(user);
        }

        [HttpDelete("{id}")]
        public void DeleteUser(int id)
        {
            _db.DeleteUser(id);
        }

    }
}