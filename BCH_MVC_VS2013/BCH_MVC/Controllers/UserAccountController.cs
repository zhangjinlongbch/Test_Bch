using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BCH_MVC.Models;
using System.Data.SqlClient;

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
            //测试所用连接数据库函数
            Sqltest();
            //***********************
            Response.Write("<script>alert('注册成功！！')</script>");
            return Redirect("../Home/Index");
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public void Login(AccountLogin model)
        {
            var uid = model.UserId;
            var pwd = model.Pwd;
            //FindUserAccount(uid,pwd)?Login : ReWrite

        }
        //测试所用连接数据库函数
        public void Sqltest()
        {
            //创建数据库连接字符串
            var ConStr = System.Configuration.ConfigurationManager.ConnectionStrings["BCH_MVC_SQL"].ConnectionString;
            SqlConnection con = new SqlConnection(ConStr);
            con.Open();
            string CmdStr = "insert into UserAccount(UserId,Phone,Pwd) values('" + "123123" + "','" + "123321" + "','" + "11111" + "')";
            SqlCommand cmd = new SqlCommand(CmdStr, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}