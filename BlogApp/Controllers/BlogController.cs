using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BGRepository;
using BlogEntity;


namespace BlogApp.Controllers
{
    public class BlogController : Controller
    {
        //
        // GET: /Blog/
        private BlogRepository repo = new BlogRepository();
        public ActionResult Index()
        {
            
                return View(this.repo.GetAll());
          
            
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Blog blog)
        {
            this.repo.Insert(blog);
            if (Session["USERNAME"] != "Admin") { return RedirectToAction("Index", "Home"); }
            else { return RedirectToAction("Index"); }
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            Blog b = this.repo.Get(id);
            return View(b);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Blog b = this.repo.Get(id);
            return View(b);
        }

        [HttpPost]
        public ActionResult Edit(Blog blog)
        {
            this.repo.Update(blog);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Blog b = this.repo.Get(id);
            return View(b);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            this.repo.Delete(id);
            return RedirectToAction("Index");
        }


    }
}
