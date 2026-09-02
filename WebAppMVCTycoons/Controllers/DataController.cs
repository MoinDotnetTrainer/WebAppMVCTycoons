using Microsoft.AspNetCore.Mvc;
using WebAppMVCTycoons.Models;

namespace WebAppMVCTycoons.Controllers
{
    public class DataController : Controller
    {
        public IActionResult Getdata() {
            // when is fun is not 

            TempData["date"]= System.DateTime.Now.ToString();
            return View();
        }

        public IActionResult Addition() {
            int x = 45, y = 234, z;
            z = x + y;
            TempData["add"] = z;
            return View();
        }


        [HttpGet] // Exe on page load
        public IActionResult Sub() {
            TempData["msg"] = "No result On httpget";
            return View();
        }

        [HttpPost]
        public IActionResult Sub(int x, int y)
        {
            int z = x - y;
            TempData["msg"] = "Result on Submit:"+z;
            return View();
        }


        [HttpGet]
        public IActionResult Mul()
        {
            TempData["msg"] = "No result On httpget";
            return View();
        }


        [HttpPost]
        public IActionResult Mul(Values obj)
        {
            int z = obj.x * obj.y;
            TempData["msg"] = "Res:"+z;
            return View();
        }
        [HttpGet]
        public IActionResult Div()
        {
            TempData["msg"] = "No result On httpget";
            return View();
        }


        [HttpPost]
        public IActionResult Div(Values obj)
        {
            int z = obj.x / obj.y;
            TempData["msg"] = "Res:" + z;
            return View();
        }



    }
}
