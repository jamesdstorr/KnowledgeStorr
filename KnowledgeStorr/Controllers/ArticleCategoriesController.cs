using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KnowledgeStorr.Data_Access;
using KnowledgeStorr.Models;

namespace KnowledgeStorr.Controllers
{
    public class ArticleCategoriesController : Controller
    {
        private DataAccess db = new DataAccess();

        // GET: ArticleCategories
        public ActionResult Index()
        {
            if (this.Session["User"] == null)
            {
                return RedirectToAction("Login", "Users");
            }
            return View(db.Categories.Where(c=>c.CategoryId != 1).ToList());
        }

        // GET: ArticleCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleCategory articleCategory = db.Categories.Find(id);
            if (articleCategory == null)
            {
                return HttpNotFound();
            }
            return View(articleCategory);
        }

        // GET: ArticleCategories/Create
        public ActionResult Create()
        {
            if (this.Session["User"] == null)
            {
                return RedirectToAction("Login", "Users");
            }
            return View();
        }

        // POST: ArticleCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryId,CategoryName")] ArticleCategory articleCategory)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(articleCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(articleCategory);
        }

        // GET: ArticleCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (this.Session["User"] == null)
            {
                return RedirectToAction("Login", "Users");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleCategory articleCategory = db.Categories.Find(id);
            if (articleCategory == null)
            {
                return HttpNotFound();
            }
            return View(articleCategory);
        }

        // POST: ArticleCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryId,CategoryName")] ArticleCategory articleCategory)
        {

            if (ModelState.IsValid)
            {
                db.Entry(articleCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(articleCategory);
        }

        // GET: ArticleCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (this.Session["User"] == null)
            {
                return RedirectToAction("Login", "Users");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleCategory articleCategory = db.Categories.Find(id);
            if (articleCategory == null)
            {
                return HttpNotFound();
            }
            return View(articleCategory);
        }

        // POST: ArticleCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArticleCategory articleCategory = db.Categories.Find(id);
            db.Categories.Remove(articleCategory);
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
