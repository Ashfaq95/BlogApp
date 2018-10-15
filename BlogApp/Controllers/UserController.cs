using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserBGEntity;
using UserBGRepository;



namespace BlogApp.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        private UserRepository repo = new UserRepository();

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
        public ActionResult Create(User user)
        {
            if (Session["USERNAME"] == null) {
                this.repo.Insert(user);
                return RedirectToAction("Index", "Login"); 
            }
            this.repo.Insert(user);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            User b = this.repo.Get(id);
            return View(b);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            User b = this.repo.Get(id);
            return View(b);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            this.repo.Update(user);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            User b = this.repo.Get(id);
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
