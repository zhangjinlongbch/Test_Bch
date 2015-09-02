using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BCH_MVC.Models;

namespace BCH_MVC.Controllers
{
    public class UserAccountController : Controller
    {
        // GET: UserAccount
        public ActionResult Index()
        {
            return View();
        }
        
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(AccountRegister model)
        {
            var UserId = model.UserId;
            var Pwd = model.Pwd;
            Response.Write("<script>alert('注册成功！！')</script>");
            return Redirect("../Home/Index");
        }
        [HttpPost]
        public ActionResult Login()
        {
            return View();
        }
    }
}