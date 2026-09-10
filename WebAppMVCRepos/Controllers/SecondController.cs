using Microsoft.AspNetCore.Mvc;

namespace WebAppMVCRepos.Controllers
{
    public class SecondController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.data = HttpContext.Session.GetString("Sampledata");
            return View();
        }
        public IActionResult Index1()
        {
            //var data = TempData["tddata"];
            //TempData.Keep("tddata");
            //ViewBag.mydata = data;

            // ViewBag.mydata = TempData.Peek("tddata");
            ViewBag.data = HttpContext.Session.GetString("Sampledata");
            return View();
        }

        public IActionResult Index2()
        {
            ViewBag.data = HttpContext.Session.GetString("Sampledata");
            return View();
        }

    }
}
