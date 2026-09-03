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
            int res = db.SaveChanges(); // commit changes to db , exe insert query

            if (res > 0)
            {
                return RedirectToAction("GetBooks");
            }
            return View();
        }


        [HttpGet]
        public IActionResult GetBooks()
        {

            // get the data from db
            // ef core is also uses linq syntax's
            // LINQ --> Get the data
            IEnumerable<BooksModel> data = from s in db.books select s;
            return View(data);
        }

        [HttpGet]
        public IActionResult EditBooks(int BookID)
        {
            // we in db , get here and binds to model

            BooksModel data = (from s in db.books where s.BookID == BookID select s).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        public IActionResult EditBooks(BooksModel data)
        {
            db.books.Update(data);
            int res = db.SaveChanges();
            if (res > 0)
            {
                return RedirectToAction("GetBooks");
            }
            return View();
        }
        

        [HttpGet]
        public IActionResult BookDetails(int BookID)
        {
            // we in db , get here and binds to model

            BooksModel data = (from s in db.books where s.BookID == BookID select s).FirstOrDefault();
            return View(data);
        }


        [HttpGet]
        public IActionResult DeleteBook(int BookID)
        {
            // we in db , get here and binds to model

            BooksModel data = (from s in db.books where s.BookID == BookID select s).FirstOrDefault();
            return View(data);
        }

        [HttpPost,ActionName("DeleteBook")]
        public IActionResult DeleteConfirm(int BookID)
        {
            var find = db.books.Find(BookID);
            if (find != null)
            {
                db.books.Remove(find);
                int res = db.SaveChanges();
                if (res > 0)
                {
                    return RedirectToAction("GetBooks");
                }
            }
            return View();
        }
    }
}
