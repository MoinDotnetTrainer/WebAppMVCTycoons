using Microsoft.AspNetCore.Mvc;

namespace WebAppMVCRepos.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult AccessDenied()
        {
            return View();
        }

        public IActionResult  Page404() {
            return View();
        }
    }
}
