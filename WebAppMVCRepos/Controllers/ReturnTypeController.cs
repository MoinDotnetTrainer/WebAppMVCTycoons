using Dataaccess.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAppMVCRepos.Controllers
{
    public class ReturnTypeController : Controller
    {

        public readonly IUsers _iuser;
        public ReturnTypeController(IUsers iuser)
        {
            _iuser = iuser;
        }
        public async Task<IActionResult> Index()
        {
            //return View();

            //var user = await _iuser.GetUsers();

            //return Json(user);
            //// string str = "hi";
            // TempData["res"] = str;
            // return PartialView("Sample");

            return Content("Hello World");
        }

        //IActionResult return type --> any type of value
        // view 
        // redirecttoaction
        // json 
        // partial view
        // view result


        public PartialViewResult Index1() {
            return PartialView("");
        }

        public ActionResult GetData() {
            return View();
        }
    }
}
