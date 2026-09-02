using Microsoft.AspNetCore.Mvc;

namespace WebAppMVCTycoons.Controllers
{
    public class AccountsController : Controller
    {
        // LoginPage
        // Behves like code behind BL is writtne
        public IActionResult Login() {
            return View();
        }

        public IActionResult Register() {
            return View();
        }
    }
}
