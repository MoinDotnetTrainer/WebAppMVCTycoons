using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

namespace WebAppMVCRepos.Controllers
{

    //  [Route("[controller]/[action]")] // will be as it 

    //  [Route("[Controller]")] //

    //  [Route("Emp/[action]")]

    [Route("Emp")]
    public class MyTaskController : Controller
    {

        [Route("UsersList")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("AddUsers")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("GetData/{id}")]// id 

        // part of URL
        // ?id=34
        public IActionResult getDataByID(int x)
        {
            return View();
        }

        [Route("MyData")]
        //?
        public IActionResult getmydata(int x)
        {
            return View();
        }


    }
}
