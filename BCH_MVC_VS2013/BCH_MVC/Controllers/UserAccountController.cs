using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Web.Mvc;
using BCH_MVC.Models;

namespace BCH_MVC.Controllers
{
    public class UserAccountController : Controller
    {
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(AccountRegister model)
        {
            DBHelper db = new DBHelper();
            var UserId = model.UserId;
            var Pwd = model.Pwd;
            //判断用户名是否存在
            if (!db.UserExist(UserId))
            {
                var cmd = "Insert into UserAccount(UserId,Pwd) values('"+UserId+"','"+Pwd+"')";
                db.SqlExcute(cmd);
                return Redirect("Login");
            }
            else
            {
                Response.Write("<script>alert('账号已存在~~~ ')</script>");
                return View();
            }
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login(AccountLogin model)
        {
            DBHelper db = new DBHelper();
            var uid = model.UserId;
            var pwd = model.Pwd;
            Session["UserId"] = uid;
            if (db.UserCorrect(uid,pwd))
            {
                return Redirect("~/Home/Index");
            }
            else
            {
                Response.Write("<script>alert('用户名或密码不正确~~~ ')</script>");
                return View();
            }

        }
    }
}