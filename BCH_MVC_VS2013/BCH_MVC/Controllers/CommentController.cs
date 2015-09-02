using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BCH_MVC.Controllers
{
    public class CommentController : Controller
    {
        // GET: Comment
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create_Comment()
        {
            return View();
        }
        public ActionResult Delete_Comment()
        {
            return View();
        }
    }
}