using Microsoft.AspNetCore.Mvc;
using WebAppMVCTycoons.Models;

namespace WebAppMVCTycoons.Controllers
{
    public class UsersOpsController : Controller
    {

        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(UsersModel data) // data ui model
        {

            // data --> db using Ef 
            return View();
        }
    }
}
