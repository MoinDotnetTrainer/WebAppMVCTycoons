using Dataaccess.IService;
using Dataaccess.Models;
using Microsoft.AspNetCore.Mvc;
using WebAppMVCRepos.Models;

namespace WebAppMVCRepos.Controllers
{
    public class UsersOpsSpController : Controller
    {
        public readonly IUsersSp _Iuser;
        public UsersOpsSpController(IUsersSp Iuser)
        {
            _Iuser = Iuser;
        }
        public async Task<IActionResult> Index()
        {

            return View(await _Iuser.GetUsers());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Users data)
        {
            // add users

            var res = await _Iuser.AddUsers(data);

            if (res)
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            // update users
            try
            {
                var user = await _Iuser.GetUserByID(id);
                if (user == null)
                {
                    return NotFound("User not found.");
                }
                return View(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Users data)
        {
            // update users

            var res = await _Iuser.UpdateUsers(data);
            if (res)
            {
                return RedirectToAction("Index");
            }
            else return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            // update users
            try
            {
                var user = await _Iuser.GetUserByID(id);
                if (user == null)
                {
                    return NotFound("User not found.");
                }



                return View(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            // update users
            var res = await _Iuser.DeleteUsers(id);
            if (res)
                return RedirectToAction("Index");
            else return View();
        }


        [HttpGet]
        public IActionResult Login()
        {
            // validate
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login data)
        {
            // validate

            var loginData = new Login
            {
                Email = data.Email,
                Password = data.Password
            };
            var res = await _Iuser.ValidateUser(data);

            if (res)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
