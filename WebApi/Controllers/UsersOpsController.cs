using Dataaccess.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersOpsController : ControllerBase
    {
        // MVC --> View
        // API --> Status Code


        public readonly IUsers _iuser;
        public UsersOpsController(IUsers iuser)
        {
            _iuser = iuser;
        }
        public async Task<IActionResult> Index()
        {
            // get all data 
            var res = await _iuser.GetUsers();
            return Ok(res); // 200 Which means data has been returned succfully
        }
    }
}
