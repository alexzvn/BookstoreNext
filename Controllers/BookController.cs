using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookstoreNext.Data;
using BookstoreNext.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookstoreNext.Controllers
{
    public class BookController : Controller
    {
        protected ApplicationDbContext db;

        public BookController(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }


        public IActionResult Index()
        {
            var books = db.Books.ToList();

            return View(books);
        }

        public IActionResult Show(int id)
        {
            var book = db.Books.Find(id);

            return View(book);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Delete(int id)
        {
            var book = db.Books.Find(id);

            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Store(BookModel book)
        {
            if (!ModelState.IsValid) return View("Create", book);

            db.Books.Add(book);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Destroy(int id)
        {
            var book = db.Books.Find(id);

            if (book != null) {
                db.Books.Remove(book);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var book = db.Books.Find(id);

            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(BookModel book)
        {
            if (!ModelState.IsValid) return View("Edit", book);

            db.Books.Update(book);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}

