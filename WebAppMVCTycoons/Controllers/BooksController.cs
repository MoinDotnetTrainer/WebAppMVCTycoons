using Microsoft.AspNetCore.Mvc;
using WebAppMVCTycoons.Models;

namespace WebAppMVCTycoons.Controllers
{
    public class BooksController : Controller
    {

        private AppDb db;
        public BooksController()
        {
            db = new AppDb();
        }       
        [HttpGet]
        public IActionResult AddBooks()
        {
            return View();
        }

        [HttpPost] // on submit to want to insert data  into db
        public IActionResult AddBooks(BooksModel data)
        {
            // inseted into db
            // Entity Framework Core

            db.books.Add(data); // Add --> Insert ops
            db.SaveChanges(); // commit changes to db , exe insert query
            return View();
        }
    }
}
