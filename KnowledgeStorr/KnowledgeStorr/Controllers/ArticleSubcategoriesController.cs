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
    public class ArticleSubcategoriesController : Controller
    {
        private DataAccess db = new DataAccess();

        // GET: ArticleSubcategories
        public ActionResult Index()
        {
            if (this.Session["User"] == null)
            {
                return RedirectToAction("Login", "Users");
            }
            var subcategories = db.Subcategories.Where(a=>a.CategoryId!=1).Include(a => a.ArticleCategory);
            return View(subcategories.ToList());
        }

        // GET: ArticleSubcategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleSubcategory articleSubcategory = db.Subcategories.Find(id);
            if (articleSubcategory == null)
            {
                return HttpNotFound();
            }
            return View(articleSubcategory);
        }

        // GET: ArticleSubcategories/Create
        public ActionResult Create()
        {
            if (this.Session["User"] == null)
            {
                return RedirectToAction("Login", "Users");
            }
            ViewBag.CategoryId = new SelectList(db.Categories.Where(a=>a.CategoryId !=1 ), "CategoryId", "CategoryName");
            return View();
        }

        // POST: ArticleSubcategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubcategoryId,SubcategoryName,CategoryId")] ArticleSubcategory articleSubcategory)
        {
            if (ModelState.IsValid)
            {
                db.Subcategories.Add(articleSubcategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", articleSubcategory.CategoryId);
            return View(articleSubcategory);
        }

        // GET: ArticleSubcategories/Edit/5
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
            ArticleSubcategory articleSubcategory = db.Subcategories.Find(id);
            if (articleSubcategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", articleSubcategory.CategoryId);
            return View(articleSubcategory);
        }

        // POST: ArticleSubcategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubcategoryId,SubcategoryName,CategoryId")] ArticleSubcategory articleSubcategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(articleSubcategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", articleSubcategory.CategoryId);
            return View(articleSubcategory);
        }

        // GET: ArticleSubcategories/Delete/5
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
            ArticleSubcategory articleSubcategory = db.Subcategories.Find(id);
            if (articleSubcategory == null)
            {
                return HttpNotFound();
            }
            return View(articleSubcategory);
        }

        // POST: ArticleSubcategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArticleSubcategory articleSubcategory = db.Subcategories.Find(id);
            db.Subcategories.Remove(articleSubcategory);
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
