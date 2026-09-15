using Dataaccess.IService;
using Dataaccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.VisualBasic;
using System.Reflection.Metadata;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersOpsController : ControllerBase
    {
        private readonly IUsers _iuser;

        public UsersOpsController(IUsers iuser)
        {
            _iuser = iuser;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var res = await _iuser.GetUsers();
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsersById(int id)
        {
            var res = await _iuser.GetUserByID(id);

            if (res == null)
            {
                return NotFound(new { msg = "Resource not found" });
            }

            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Users data)
        {
            if (data == null)
            {
                return BadRequest(new { msg = "Invalid data" });
            }

            var res = await _iuser.AddUsers(data);

            if (res)
            {
                return CreatedAtAction(
                    nameof(GetUsersById),
                    new { id = data.ID },
                    data
                );
            }

            return BadRequest(new { msg = "Unable to create user" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, Users data)
        {
            if (data == null)
            {
                return BadRequest(new { msg = "Please provide user data" });
            }

            if (id != data.ID)
            {
                return BadRequest(new { msg = "ID does not match" });
            }

            var existingUser = await _iuser.GetUserByID(id);

            if (existingUser == null)
            {
                return NotFound(new { msg = "Resource not found" });
            }

            await _iuser.UpdateUsers(data);

            

            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _iuser.GetUserByID(id);

            if (res == null)
            {
                return NotFound(new { msg = "Resource not found" });
            }

            await _iuser.DeleteUsers(res.ID);

            return Ok(new { msg = "Deleted Successfully" });
        }
    }

}
