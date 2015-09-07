using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BCH_MVC.Models;

namespace BCH_MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Essay> EssayList = GetEssayList();
            //foreach?显示EssayList中的内容
            ViewBag.list = EssayList;
            return View();
            
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public List<Essay> GetEssayList()
        {
            DBHelper db = new DBHelper();
            return db.GetEssayList();
        }
    }
}