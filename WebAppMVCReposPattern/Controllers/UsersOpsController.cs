using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Irepo;

namespace WebAppMVCReposPattern.Controllers
{
    public class UsersOpsController : Controller
    {

        private readonly IUser _iuser;
        public UsersOpsController(IUser iuser)
        {
            _iuser = iuser;
        }

        [HttpGet]
        public IActionResult AddUsers()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> AddUsers(Users data)
        {
            bool res = await _iuser.AddUsers(data);
            if (res)
            {
                return RedirectToAction("GetUsers");
            }
            // inseted 
            return View();
        }
        [HttpGet]
        public IActionResult GetUsers()
        {
            return View();
        }


    }
}
