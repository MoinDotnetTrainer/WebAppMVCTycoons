using Dataaccess.IService;
using Dataaccess.Models;
using Microsoft.AspNetCore.Mvc;
using WebAppMVCRepos.Models;

namespace WebAppMVCRepos.Controllers
{
    [Route("[controller]/[action]")] // as it is
    public class UsersTaskController : Controller
    {
        public readonly IUsers _iusers;
        public UsersTaskController(IUsers iusers)
        {
            _iusers = iusers;
        }

    //  [ExecuteBeforeActionRuns]
        public async Task<IActionResult> Index()
        {
            // get all data

            var res = await _iusers.GetUsers();

            var mydata = res.Select(x => new UsersDto
            {
                ID = x.ID,
                Name = x.Name,
                Email = x.Email,
                Dob = x.Dob,
                Age = x.Age,
                Gender = x.Gender
            }).ToList();

            return View(mydata);



        }


        [HttpGet]
        public IActionResult Create()
        {
            // add users
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(UsersDto data)
        {
            // add users

            var mydata = new Users
            {
                Name = data.Name,
                Email = data.Email,
                Password = data.Password,
                Dob = data.Dob,
                Age = data.Age,
                Gender = data.Gender

            };


            var res = await _iusers.AddUsers(mydata);
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
                var user = await _iusers.GetUserByID(id);

                if (user == null)
                {
                    return NotFound("User not found.");
                }

                var mydata = new UsersDto
                {
                    ID = user.ID,
                    Name = user.Name,
                    Email = user.Email,
                    Dob = user.Dob,
                    Age = user.Age,
                    Gender = user.Gender
                };

                return View(mydata);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UsersDto data)
        {
            // update users
            await _iusers.UpdateUsers(new Users
            {
                ID = data.ID,
                Name = data.Name,
                Email = data.Email,
                Password = data.Password,
                Dob = data.Dob,
                Age = data.Age,
                Gender = data.Gender
            });
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            // update users
            try
            {
                var user = await _iusers.GetUserByID(id);

                if (user == null)
                {
                    return NotFound("User not found.");
                }

                var mydata = new UsersDto
                {
                    ID = user.ID,
                    Name = user.Name,
                    Email = user.Email,
                    Dob = user.Dob,
                    Age = user.Age,
                    Gender = user.Gender
                };

                return View(mydata);
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
            await _iusers.DeleteUsers(id);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Login()
        {
            // validate
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto data)
        {
            // validate

            var loginData = new Login
            {
                Email = data.Email,
                Password = data.Password
            };
            var res = await _iusers.ValidateUser(loginData);

            if (res)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
