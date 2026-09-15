using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEBAPISQLITE.Models;

namespace WEBAPISQLITE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersOpsController : ControllerBase
    {
        public readonly appdb _db;
        public UsersOpsController(appdb db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var res = _db.users.ToList();
            return Ok(res);
        }

        [HttpPost]
        public IActionResult Create(Users data) {
            _db.users.Add(data);
            _db.SaveChanges();
            return Ok(new { msg="Successfuly"});
        }
    }
}
