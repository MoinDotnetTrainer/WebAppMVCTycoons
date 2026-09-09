using Microsoft.AspNetCore.Mvc;

namespace WebAppMVCRepos.Controllers
{
    public class SecondController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Index1()
        {
            //var data = TempData["tddata"];
            //TempData.Keep("tddata");
            //ViewBag.mydata = data;

            ViewBag.mydata = TempData.Peek("tddata");
            return View();
        }

    }
}
