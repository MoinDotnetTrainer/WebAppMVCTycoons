using Dataaccess.IService;
using Dataaccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PutExController : ControllerBase
    {
        private readonly IUsers _iuser;

        public PutExController(IUsers iuser)
        {
            _iuser = iuser;
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
    }
}
