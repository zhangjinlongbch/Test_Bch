using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using BCH_MVC.Models;

namespace BCH_MVC
{
    public class DBHelper
    {
        private string ConStr;
        public DBHelper()
        {
            ConStr = System.Configuration.ConfigurationManager.ConnectionStrings["BCH_MVC_SQL"].ConnectionString;
        }
        //执行Excute操作并返回受影响的行数
        public int SqlExcute( string Cmd)
        {
            SqlConnection con = new SqlConnection(ConStr);
            var number = 0;
            con.Open();
            SqlCommand cmd = new SqlCommand(Cmd, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                number++;
            }
            con.Close();
            return number;
        }
        //查询是否存在用户
        public bool UserExist(string uid)
        {
            bool IsExist = false;
            string cmd = "select * from UserAccount where UserId = '"+uid+"'";
            IsExist = (SqlExcute(cmd) != 0) ? true : false;
            return IsExist;
        }
        //判断用户名密码
        public bool UserCorrect(string uid , string pwd)
        {
            bool IsCorrect = false;
            string cmd = "select * from UserAccount where UserId = '" + uid + "' and Pwd = '"+pwd+"'";
            IsCorrect = (SqlExcute(cmd) != 0) ? true : false;
            return IsCorrect;
        }
        //返回文章列表，以DATASET形式存储
        public DataSet EssaySet()
        {
            SqlConnection con = new SqlConnection(ConStr);
            con.Open();
            string cmd = "select * from Essay";
            SqlDataAdapter sda = new SqlDataAdapter(cmd, con);
            DataSet ds = new DataSet();
            sda.Fill(ds,"Essay");
            con.Close();
            return ds;
        }
        //返回评论列表，以DATASET形式存储
        public DataSet CommentSet()
        {
            SqlConnection con = new SqlConnection(ConStr);
            con.Open();
            string cmd = "select * from Comment";
            SqlDataAdapter sda = new SqlDataAdapter(cmd, con);
            DataSet ds = new DataSet();
            sda.Fill(ds, "Comment");
            con.Close();
            return ds;
        }
        //~~~~~~~~~~~~
    }
}