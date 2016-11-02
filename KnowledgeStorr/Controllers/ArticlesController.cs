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
using System.Diagnostics;
using PagedList;

namespace KnowledgeStorr.Controllers
{
    public class ArticlesController : Controller
    {
        private DataAccess db = new DataAccess();

        // GET: Articles
        public ActionResult ArticlesFilter()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName");
            ViewModels.ArticleFilterViewModel viewModel = new ViewModels.ArticleFilterViewModel();
            viewModel.subcategories = db.Subcategories.Where(s => s.SubcategoryId == 1).ToList();
            viewModel.categories = db.Categories.ToList();
            return PartialView(viewModel);
        }

        public ActionResult ArticlesResults(int? Category_Id, int? Subcategory_Id, string searchString, int? page)
        {

            ViewBag.Category = Category_Id;
            ViewBag.SubCategory = Subcategory_Id;
            ViewBag.SearchString = searchString;
            
            if(Category_Id == null)
            {
                var articles = db.Articles.Where(a => a.ArticleDescription.Contains(searchString));
                int pageSize = 10;
                int pageNumber = (page ?? 1);
                return View(articles.ToList().ToPagedList(pageNumber, pageSize));
            }
            else

            if(Category_Id == 1)
            {
                var articles = from a in db.Articles                                                            
                               select a;
                if (!String.IsNullOrEmpty(searchString))
                {
                    articles = articles.Where(a => a.ArticleDescription.Contains(searchString) || a.ArticleContents.Contains(searchString) || a.ArticleName.Contains(searchString));
                }
                int pageSize = 10;
                int pageNumber = (page ?? 1);
                return View(articles.ToList().ToPagedList(pageNumber, pageSize));
            }

            if (Subcategory_Id != 0)
            {
                var articles = from a in db.Articles
                               orderby a.ArticleId
                               where a.CategoryId == Category_Id
                               where a.SubcategoryId == Subcategory_Id
                               select a;
                if(!String.IsNullOrEmpty(searchString))
                {
                    articles = articles.Where(a => a.ArticleDescription.Contains(searchString) || a.ArticleContents.Contains(searchString) || a.ArticleName.Contains(searchString));
                }
                int pageSize = 10;
                int pageNumber = (page ?? 1);
                return View(articles.ToList().ToPagedList(pageNumber, pageSize));
            }
            else
            {
                var articles = from a in db.Articles
                               orderby a.ArticleId
                               where a.CategoryId == Category_Id                               
                               select a;

                  if(!String.IsNullOrEmpty(searchString))
                {
                    articles = articles.Where(a => a.ArticleDescription.Contains(searchString) || a.ArticleContents.Contains(searchString) || a.ArticleName.Contains(searchString));
                }
                  int pageSize = 10;
                  int pageNumber = (page ?? 1);
                  return View(articles.ToList().ToPagedList(pageNumber, pageSize));
            }
        }

       
        // GET: Articles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // GET: Articles/Create
        public ActionResult Create()
        {
            if (this.Session["User"] == null)
            {
                return RedirectToAction("Login", "Users");
            }
            else
            {
                ViewBag.CategoryId = new SelectList(db.Categories.Where(a=>a.CategoryId!=1), "CategoryId", "CategoryName");
                ArticleCreateViewModel viewModel = new ArticleCreateViewModel();
                viewModel.subcategories = new List<ArticleSubcategory>();                
                return View(viewModel);
            }
        }

        public ActionResult SubCategoryFilter(int categoryID)
        {
            Debug.Write("Category ID is " + categoryID);
            var data = db.Subcategories.Where(s => s.CategoryId == categoryID).Select(s => new { s.SubcategoryId, s.SubcategoryName }).Distinct().ToList();
            List<ArticleSubcategory> subcategoryList = new List<ArticleSubcategory>();
            foreach(var item in data)
            {
                ArticleSubcategory obj = new ArticleSubcategory();
                obj.SubcategoryId = item.SubcategoryId;
                obj.SubcategoryName = item.SubcategoryName;
                subcategoryList.Add(obj);                
            }
            return Json(subcategoryList, JsonRequestBehavior.AllowGet);
        }

        // POST: Articles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(ArticleCreateViewModel form, int CategoryId, int SubcategoryId, string ArticleContents)
        {
            Models.User user = this.Session["User"] as Models.User;
            Article article = new Article();
            article.UserId = user.UserId;
            article.ArticleCreated = DateTime.Now;
            article.ArticleName = form.article.ArticleName;
            article.ArticleDescription = form.article.ArticleDescription;
            article.CategoryId = CategoryId;
            article.SubcategoryId = SubcategoryId;
            article.ArticleCreated = form.article.ArticleCreated;
            article.ArticleContents = ArticleContents;
            

            if (ModelState.IsValid)
            {
                db.Articles.Add(article);
                db.SaveChanges();
                return RedirectToAction("Details", "Articles", new { id = article.ArticleId });
                //return RedirectToAction("Index", "Home");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", article.CategoryId);
            ViewBag.SubcategoryId = new SelectList(db.Subcategories, "SubcategoryId", "SubcategoryName", article.SubcategoryId);
            ArticleCreateViewModel viewmodel = new ArticleCreateViewModel();
            return View(viewmodel);
        }

        // GET: Articles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if(this.Session["User"] ==  null)
            {
                return RedirectToAction("Login", "Users");
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories.Where(a=>a.CategoryId!=1), "CategoryId", "CategoryName", article.CategoryId);
            ViewBag.SubcategoryId = new SelectList(db.Subcategories.Where(a=>a.CategoryId == article.CategoryId), "SubcategoryId", "SubcategoryName", article.SubcategoryId);
            return View(article);
        }

        // POST: Articles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArticleId,ArticleName,ArticleDescription,ArticleCreated,ArticleContents,CategoryId,SubcategoryId,UserId")] Article article)
        {
            //Models.User user = this.Session["User"] as Models.User;
            //article.UserId = user.UserId;
            if (ModelState.IsValid)
            {
                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details","Articles", new { id = article.ArticleId });
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", article.CategoryId);
            ViewBag.SubcategoryId = new SelectList(db.Subcategories.Where(a=>a.CategoryId == article.CategoryId), "SubcategoryId", "SubcategoryName", article.SubcategoryId);
            return View(article);
        }

        // GET: Articles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Article article = db.Articles.Find(id);
            db.Articles.Remove(article);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult LatestArticles()
        {
            var results = db.Articles.OrderByDescending(a => a.ArticleCreated).Take(5).ToList();
            return PartialView(results);            
        }

    }
}
