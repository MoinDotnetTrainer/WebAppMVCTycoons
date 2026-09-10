using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace WebAppMVCRepos.Controllers
{

    public class Std
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
    public class FirstController : Controller
    {
        public IActionResult Index()
        {

            List<Std> stds = new List<Std>() {
               new Std{ID=1,Name="A",Age=23},
               new Std{ID=2,Name="B",Age=34},
               new Std{ID=3,Name="C",Age=32},
            };

            //   ViewBag.complexdata = stds;  // dynamic prop
            ViewData["complexdata"] = stds;


            // Controller Action Method to View
            //ViewBag.vbdata = "hello from Viewbag";// within the corr action, view
            //ViewData["vddata"] = "hello from ViewData"; // same
            //TempData["tddata"] = "hello from TempData";
            //return RedirectToAction("Index1", "Second");


            HttpContext.Session.SetString("Sampledata",System.DateTime.Now.ToLongTimeString());
            return View();
        }

        public IActionResult Index1()
        {
            // string data = ViewBag.vbdata;
            // string data = ViewData["vddata"].ToString();
           // string data = TempData["tddata"].ToString();
          //  ViewBag.actualdata = data;

            ViewBag.data1 = HttpContext.Session.GetString("Sampledata"); 
            return View();
        }
        public IActionResult Index2()
        {
            ViewBag.data = HttpContext.Session.GetString("Sampledata");
            return View();
        }

    }
}
