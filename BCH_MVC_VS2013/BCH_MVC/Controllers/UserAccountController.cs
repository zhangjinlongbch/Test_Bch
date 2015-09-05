using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Web.Mvc;
using BCH_MVC.Models;
using System.Data.SqlClient;
using System.Data;

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
        public async Task<ActionResult> Register(AccountRegister model)
        {
            var UserId = model.UserId;
            var Pwd = model.Pwd;
            var PwdCon = model.Pwd_Confirm;
            //判断用户名是否存在
            if (!UserExist(UserId))
            {
                var constr = System.Configuration.ConfigurationManager.ConnectionStrings["BCH_MVC_SQL"].ConnectionString;
                var cmd = "Insert into UserAccount(UserId,Phone,Pwd) values('"+UserId+"','"+Pwd+"')";
                SqlExcute(constr,cmd);
                Response.Write("<script>alert('注册成功~~~ ')</script>");
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
        //public async Task<ActionResult> Register(RegisterViewModel model)
        public async Task<ActionResult> Login(AccountLogin model)
        {
            var uid = model.UserId;
            var pwd = model.Pwd;
            //FindUserAccount(uid,pwd)?Login : ReWrite
            if (UserExist(uid, pwd))
            {
                Response.Write("<script>alert('登陆成功~~~ ')</script>");
                return Redirect("../Home/Index");
            }
            else
            {
                Response.Write("<script>alert('账号不存在~~~ ')</script>");
                return View();
            }

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
        public void SqlExcute(string ConStr , string SqlCmd)
        {
            SqlConnection con = new SqlConnection(ConStr);
            con.Open();
            SqlCommand cmd = new SqlCommand(SqlCmd,con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataSet SqlDataSet(string ConStr, string SqlCmd, string SrcTable)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(ConStr);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(SqlCmd, con);
            da.Fill(ds, SrcTable);
            con.Close();
            return ds;
        }
        //登录时判断是否存在ACCOUNT
        public bool UserExist(string uid , string pwd)
        {
            bool IsExist = false;
            int n = 0;
            var ConStr = System.Configuration.ConfigurationManager.ConnectionStrings["BCH_MVC_SQL"].ConnectionString;
            SqlConnection con = new SqlConnection(ConStr);
            con.Open();
            string CmdStr = "select * from dbo.UserAccount where UserId = '"+uid+"' and Pwd = '"+pwd+"'";
            SqlCommand cmd = new SqlCommand(CmdStr, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                n++;
            }
            con.Close();
            IsExist =(n>0)?true:false;
            return IsExist;
        }
        //注册时判断是否存在用户名
        public bool UserExist(string uid)
        {
            bool IsExist = false;
            int n = 0;
            var ConStr = System.Configuration.ConfigurationManager.ConnectionStrings["BCH_MVC_SQL"].ConnectionString;
            SqlConnection con = new SqlConnection(ConStr);
            con.Open();
            string CmdStr = "select * from dbo.UserAccount where UserId = '" + uid + "'";
            SqlCommand cmd = new SqlCommand(CmdStr, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                n++;
            }
            con.Close();
            IsExist = (n > 0) ? true : false;
            return IsExist;
        }
    }
}