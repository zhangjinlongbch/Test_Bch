using System;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BCH_MVC.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UserList()
        {
            ViewBag.content = "嗬嗬嗬嗬嗬嗬嗬";
            return View();
        }
    }
}