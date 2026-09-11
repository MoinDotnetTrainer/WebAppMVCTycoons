using Dataaccess.IService;
using Dataaccess.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebAppMVCRepos.Models;

namespace WebAppMVCRepos.Controllers
{
    

    public class UsersOpsController : Controller
    {
        public readonly IUsers _iusers;
        public UsersOpsController(IUsers iusers)
        {
            _iusers = iusers;
        }


        public IActionResult AccessDenied()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            string IsloggedIn = HttpContext.Session.GetString("useremail");
            if (IsloggedIn == null)
            {
                return RedirectToAction("Login");
            }
            // get all data

            var res = await _iusers.GetUsers();

            var mydata = res.Select(x => new UsersDto
            {
                ID = x.ID,
                Name = x.Name,
                Email = x.Email,
                Dob = x.Dob,
                Age = x.Age,
                Gender = x.Gender,
                Role = x.Role,
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
                Name = data.Name.ToUpper(),
                Email = data.Email,
                Password = data.Password,
                Dob = data.Dob,
                Age = data.Age,
                Gender = data.Gender,
                Role = data.Role,

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
            string IsloggedIn = HttpContext.Session.GetString("useremail");
            if (IsloggedIn == null)
            {
                return RedirectToAction("Login");
            }
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
                    Gender = user.Gender,
                    Role = user.Role,
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
                Gender = data.Gender,
                Role = data.Role,
            });
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            string IsloggedIn = HttpContext.Session.GetString("useremail");
            if (IsloggedIn == null)
            {
                return RedirectToAction("Login");
            }
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
                    Gender = user.Gender,
                    Role = user.Role,
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

            ClaimsIdentity identity = null;
            bool Isautheticated = false;
            // validate

            var loginData = new Login
            {
                Email = data.Email,
                Password = data.Password
            };
            var res = await _iusers.ValidateUser(loginData);

            // TF

            var userdata = await _iusers.GetUserByEmail(data.Email);

            // auth and authorization

            // identtiy by its role and claims

            HttpContext.Session.SetString("username", userdata.Name);
            HttpContext.Session.SetString("useremail", userdata.Email);

            // when useremail is null
            if (res)
            {
                identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name,userdata.Name),
                    new Claim(ClaimTypes.Email,userdata.Email),
                    new Claim(ClaimTypes.Role,userdata.Role),
                }, CookieAuthenticationDefaults.AuthenticationScheme);
                Isautheticated = true;

                if (Isautheticated)
                {
                    var princiapl = new ClaimsPrincipal(identity);
                    var redirect = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, princiapl);
                    return RedirectToAction("Index", "UsersOps", redirect);


                }
                else
                {
                    return View();
                }
            }

            return View();
        }

        public IActionResult Logout()
        {
            // validate

            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }



        public IActionResult Sample()
        {
            string str = null;
            ViewBag.data = str.Length;

            ViewBag.error = "unable to find len";
            return View();
        }
    }
}
