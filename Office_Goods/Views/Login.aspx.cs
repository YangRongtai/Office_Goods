using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Office_Goods.Views
{
    public partial class Login : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
        }


        public static string UName = "";
        public static int User;
        
        protected void LoginBtn_Click1(object sender, EventArgs e)
        {
            //string selectedValue = Request.Form["optionsRadios1"];
            if (UnameTb.Value == "" || PasswordTb.Value == "")
            {
                ErrMsg.Text = "请输入用户名和密码！";
            }
            else if(AdminRd1.Checked && UnameTb.Value == "Admin@admin.com" && PasswordTb.Value == "0000")
            {
                    Response.Redirect("Admin/Clients.aspx");
            }
            
            else if (!AdminRd1.Checked && UnameTb.Value == "Admin@admin.com" && PasswordTb.Value == "0000")
            {
                ErrMsg.Text = "请您确认您的【管理员】用户身份！";
            }
            else if (AdminRd1.Checked && (UnameTb.Value == "Admin@admin.com" || PasswordTb.Value == "0000"))
            {
                ErrMsg.Text = "用户名或密码错误！";
            }
            else if (ClientRd1.Checked && UnameTb.Value != "Admin@admin.com" && PasswordTb.Value != "0000")
            {
                string Query = "select * from ClientsTbl where ClientEmail='{0}' and ClientPwd='{1}'";
                Query = string.Format(Query, UnameTb.Value, PasswordTb.Value);
                DataTable dt = Con.GetData(Query);
                if (dt.Rows.Count == 0)
                {
                        ErrMsg.Text = "用户名或密码错误！";
                }
                else
                {
                        UName = UnameTb.Value;
                        User = Convert.ToInt32(dt.Rows[0][0].ToString());
                        Response.Redirect("index.aspx");
                }
            }
            else if (!ClientRd1.Checked && UnameTb.Value != "Admin@admin.com" && PasswordTb.Value != "0000")
            {
                ErrMsg.Text = "请您确认您的【普通用户】身份";
            }
        }
    }
}