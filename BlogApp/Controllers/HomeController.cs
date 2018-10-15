using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BGRepository;
using BlogEntity;

namespace BlogApp.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        private BlogRepository repo = new BlogRepository();
        public ActionResult Index()
        {
            if (Session["USERNAME"] == "Admin") { return View("Admin",this.repo.GetAll()); }
            else if (Session["USERNAME"] != null)
            {
                return View(this.repo.GetAll());
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            if (Session["USERNAME"] != null)
            {
                Blog b = this.repo.Get(id);
                return View(b);
            }
            else {
                return RedirectToAction("Index", "Login");
            
            }
        }
        [HttpGet]
        public ActionResult Admin() {
            return View(this.repo.GetAll());
        }
        

    }
}
