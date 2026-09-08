using Dataaccess.IService;
using Dataaccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAppMVCRepos.Controllers
{
    public class ValidateOpsController : Controller
    {
        public readonly IValidate _ivalidate;
        public ValidateOpsController(IValidate ivalidate)
        {
            _ivalidate = ivalidate;
        }

        [HttpGet]
        public IActionResult Validate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Validate(Validate data)
        {
            if (data==null)
            {

            }
            if (ModelState.IsValid)  // T F
            {
                //  _ivalidate.Validate(data);
                return View();
            }

            return View();
        }
    }
}
