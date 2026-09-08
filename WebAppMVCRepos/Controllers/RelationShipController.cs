using Dataaccess.IService;
using Microsoft.AspNetCore.Mvc;

namespace WebAppMVCRepos.Controllers
{
    public class RelationShipController : Controller
    {

        public readonly IRelation _Irela;

        public RelationShipController(IRelation Irela) { 
        _Irela = Irela;
        }
        public async Task< IActionResult> GetDept()
        {
            return View(await _Irela.GetAllDept());
        }

        public async Task<IActionResult> GetEmp()
        {
            return View(await _Irela.GetAllEmp());
        }
    }
}
