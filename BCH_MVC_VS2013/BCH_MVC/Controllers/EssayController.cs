using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BCH_MVC.Models;

namespace BCH_MVC.Controllers
{
    public class EssayController : Controller
    {
        // GET: Essay

        public ActionResult Create_Essay()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create_Essay(Essay model,AccountLogin user)
        {

            DBHelper tmpDBHelper = new DBHelper();
            var title   = model.Title;
            var content = model.Content;
            var userID = Session["UserId"].ToString();

            tmpDBHelper.SqlExcute("insert into Essay(UserId,EssayTitle,EssayContent) values('"+userID+"','"+title+"','"+content+"')");

            return Redirect("../Home/Index");
        }
        public ActionResult Update_Essay()
        {
            return View();
        }
        public ActionResult Delete_Essay()
        {
            return View();
        }
        public ActionResult Essay_List()
        {
            return View();
        }

    }
}