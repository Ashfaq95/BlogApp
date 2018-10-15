using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminBGRepository;
using AdminEntity;

namespace BlogApp.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        private AdminRepository repo = new AdminRepository();
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
        public ActionResult Create(Admin a)
        {
            this.repo.Insert(a);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            Admin b = this.repo.Get(id);
            return View(b);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Admin b = this.repo.Get(id);
            return View(b);
        }

        [HttpPost]
        public ActionResult Edit(Admin a)
        {
            this.repo.Update(a);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Admin b = this.repo.Get(id);
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
