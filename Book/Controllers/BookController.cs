using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Book.Data;
using Book.Models;

namespace Book.Controllers
{
    public class BookController : Controller
    {
        private BookContext db = new BookContext();

        // GET: Book
       public ActionResult Index(string searchString) 
{           
    var books = from m in db.BookModels 
                 select m; 
 
    if (!String.IsNullOrEmpty(searchString)) 
    { 
        books = books.Where(s => s.Title.Contains(searchString)); 
    } 
 
    return View(books); 
}
        // GET: Book/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookModel bookModel = db.BookModels.Find(id);
            if (bookModel == null)
            {
                return HttpNotFound();
            }
            return View(bookModel);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Auther,publisher,Price")] BookModel bookModel)
        {
            if (ModelState.IsValid)
            {
                db.BookModels.Add(bookModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookModel);
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookModel bookModel = db.BookModels.Find(id);
            if (bookModel == null)
            {
                return HttpNotFound();
            }
            return View(bookModel);
        }

        // POST: Book/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Auther,publisher,Price")] BookModel bookModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookModel);
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookModel bookModel = db.BookModels.Find(id);
            if (bookModel == null)
            {
                return HttpNotFound();
            }
            return View(bookModel);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookModel bookModel = db.BookModels.Find(id);
            db.BookModels.Remove(bookModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
