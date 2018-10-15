using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminBGRepository;
using AdminEntity;
using UserBGEntity;
using UserBGRepository;

namespace BlogApp.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        private AdminRepository repo = new AdminRepository();
        private UserRepository repoo = new UserRepository();


        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index( User user1)
        {
            
            bool valid1 = repoo.Validate(user1);
            if (valid1)
            {
                Session["USERNAME"] = user1.Username;
                return RedirectToAction("Index", "Home");
            }

            else
            {
                return Content("Invalid username or password");
            }
        }

        [HttpGet]
        public ActionResult Admin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Admin(Admin user)
        {

            bool valid1 = repo.Validate(user);
            if (valid1)
            {
                Session["USERNAME"] = "Admin";
                return RedirectToAction("Index", "Home");
            }
                
            else
            {
                return Content("Invalid username or password");
            }


        }

        public ActionResult Logout()
        {
            Session["USERNAME"] = null;
            return RedirectToAction("Index", "Home");
        }




    }
}
