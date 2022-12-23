using BookstoreNext.Data;
using BookstoreNext.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookstoreNext.Controllers
{
    public class HomeController : Controller
    {

        protected ApplicationDbContext db;

        public HomeController(ApplicationDbContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View(db.Books.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            var book = db.Books.Find(id);

            if (book == null) {
                return NotFound();
            }

            return View(book);
        }

        [HttpGet]
        public IActionResult Checkout(RequestOrderModel request) {
            var book = db.Books.Find(request.Id);

            if (book == null) {
                return NotFound();
            }

            var order = new OrderModel {
                Book = book,
                BookId = book.Id,
                Quantity = request.Quantity
            };

            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Order(OrderModel order) {
            var book = db.Books.Find(order.BookId);

            if (book == null) {
                return NotFound();
            }

            order.Book = book;
            order.BookId = book.Id;

            if (ModelState.IsValid) {
                db.Orders.Add(order);
                db.SaveChanges();
                return View(order);
            }

            return View("Checkout", order);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
