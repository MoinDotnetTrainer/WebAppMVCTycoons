using Microsoft.AspNetCore.Mvc;
using WebAppMVCTycoons.Models;

namespace WebAppMVCTycoons.Controllers
{
    public class OrdersController : Controller
    {

        private AppDb db;   
        public OrdersController()
        {
            db = new AppDb();
        }   
        [HttpGet]
        public IActionResult InsertOrders()
        {
            return View();
        }

        [HttpPost]
        public IActionResult InsertOrders(OrdersModel data)
        {

            db.orders.Add(data);
            db.SaveChanges();
            return View();
        }

    }
}
