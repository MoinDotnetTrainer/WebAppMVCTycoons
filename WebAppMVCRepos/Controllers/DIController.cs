using Dataaccess.IService;
using Microsoft.AspNetCore.Mvc;

namespace WebAppMVCRepos.Controllers
{
    public class DIController : Controller
    {
        public readonly ITransient _transient1; // ID
        public readonly ITransient _transient2; // ID
        public readonly Iscoped _scoped1;
        public readonly Iscoped _scoped2;
        public readonly Isingleton _singleton1;
        public readonly Isingleton _singleton2;
        public DIController(ITransient transient1, ITransient transient2,
            Iscoped scoped1, Iscoped scoped2,
            Isingleton singleton1, Isingleton singleton2)
        {
            _transient1 = transient1; _transient2 = transient2;
            _scoped1 = scoped1; _scoped2 = scoped2;
            _singleton1 = singleton1; _singleton2 = singleton2;
        }
        public IActionResult Index()
        {
            ViewBag.Transient1 = _transient1.GetGuid().ToString();
            ViewBag.Transient2 = _transient2.GetGuid().ToString();
            ViewBag.Scoped1 = _scoped1.GetGuid().ToString();
            ViewBag.Scoped2 = _scoped2.GetGuid().ToString();
            ViewBag.Singleton1 = _singleton1.GetGuid().ToString();
            ViewBag.Singleton2 = _singleton2.GetGuid().ToString();
            return View();
        }

    }
}
