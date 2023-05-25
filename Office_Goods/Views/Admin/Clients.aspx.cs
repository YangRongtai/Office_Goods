using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Office_Goods.Views.Admin
{
    public partial class Manufactors : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            ShowClients();
        }

        private void Close_Alart()
        {
            SuccessMsg1.Style["display"] = "none";
            InforMsg.Style["display"] = "none";
            ErreMsg.Style["display"] = "none";
        }

        private void ShowClients()
        {
            string Query = "Select * from ClientsTbl";
            ClientList.DataSource = Con.GetData(Query);
            ClientList.DataBind();
            ClientList.HeaderRow.Cells[1].Text = "ID";
            ClientList.HeaderRow.Cells[2].Text = "姓名";
            ClientList.HeaderRow.Cells[3].Text = "性别";
            ClientList.HeaderRow.Cells[4].Text = "邮箱";
            ClientList.HeaderRow.Cells[5].Text = "电话";
            ClientList.HeaderRow.Cells[6].Text = "密码";
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CnameTb.Value == "" || EmailTb.Value == "" || PhoneTb.Value == "" || PwdTb.Value == "" || Csex.SelectedIndex == -1)
                {
                    // ErrMsg.Text = "信息缺失，请补充完整";
                    Close_Alart();
                    ErreMsg.Style["display"] = "block";
                    // 设置定时器
                    string script = "setTimeout(function() { $('#" + ErreMsg.ClientID + "').alert('close'); }, 900);";
                    ClientScript.RegisterStartupScript(this.GetType(), "closeAlert", script, true);
                }
                else
                {
                    string CName = CnameTb.Value;
                    string Email = EmailTb.Value;
                    string Phone = PhoneTb.Value;
                    string Pwd = PwdTb.Value;
                    string Sex = Csex.SelectedItem.ToString();

                    string Query = "update ClientsTbl set ClientName='{0}',ClientSex='{1}',ClientEmail='{2}',ClientPhone='{3}',ClientPwd='{4}' where ClientId = {5}";
                    Query = string.Format(Query, CName, Sex, Email, Phone, Pwd, ClientList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowClients();
                    //ErrMsg.Text = "用户信息已更新！";
                    Close_Alart();
                    SuccessMsg1.Style["display"] = "block";
                    // 设置定时器
                    string script = "setTimeout(function() { $('#" + SuccessMsg1.ClientID + "').alert('close'); }, 900);";
                    ClientScript.RegisterStartupScript(this.GetType(), "closeAlert", script, true);

                    CnameTb.Value = "";
                    EmailTb.Value = "";
                    PhoneTb.Value = "";
                    PwdTb.Value = "";
                    Csex.SelectedIndex = -1;

                }
            }
            catch (Exception Ex)
            {
                //ErrMsg.Text = Ex.Message;
            }
        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CnameTb.Value == "" || EmailTb.Value == "" || PhoneTb.Value == "" || PwdTb.Value == "" || Csex.SelectedIndex == -1)
                {
                    //ErrMsg.Text = "信息缺失，请补充完整";
                    Close_Alart();
                    ErreMsg.Style["display"] = "block";
                    // 设置定时器
                    string script = "setTimeout(function() { $('#" + ErreMsg.ClientID + "').alert('close'); }, 900);";
                    ClientScript.RegisterStartupScript(this.GetType(), "closeAlert", script, true);
                }
                else
                {
                    string CName = CnameTb.Value;
                    string Sex = Csex.SelectedItem.ToString();
                    string Email = EmailTb.Value;
                    string Phone = PhoneTb.Value;
                    string Pwd = PwdTb.Value;

                    string Query = "insert into ClientsTbl values('{0}','{1}','{2}','{3}','{4}')";
                    Query = string.Format(Query, CName, Sex, Email, Phone, Pwd);
                    Con.SetData(Query);
                    ShowClients();
                    //ErrMsg.Text = "用户信息添加成功！";
                    Close_Alart();
                    SuccessMsg1.Style["display"] = "block";
                    // 设置定时器
                    string script = "setTimeout(function() { $('#" + SuccessMsg1.ClientID + "').alert('close'); }, 900);";
                    ClientScript.RegisterStartupScript(this.GetType(), "closeAlert", script, true);

                    CnameTb.Value = "";
                    Csex.SelectedIndex = -1;
                    EmailTb.Value = "";
                    PhoneTb.Value = "";
                    PwdTb.Value = "";
                }
            }
            catch (Exception Ex)
            {
                //ErrMsg.Text = Ex.Message;
            }
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CnameTb.Value == "" || EmailTb.Value == "" || PhoneTb.Value == "" || PwdTb.Value == "" || Csex.SelectedIndex == -1)
                {
                    //ErrMsg.Text = "您未选中有效数据！请选择一条数据";
                    Close_Alart();
                    InforMsg.Style["display"] = "block";
                    // 设置定时器
                    string script = "setTimeout(function() { $('#" + InforMsg.ClientID + "').alert('close'); },900);";
                    ClientScript.RegisterStartupScript(this.GetType(), "closeAlert", script, true);
                }
                else
                {
                    string CName = CnameTb.Value;
                    string Email = EmailTb.Value;
                    string Phone = PhoneTb.Value;
                    string Pwd = PwdTb.Value;
                    string Sex = Csex.SelectedItem.ToString();

                    string Query = "delete from ClientsTbl where ClientId = {0}";
                    Query = string.Format(Query, ClientList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowClients();
                    //ErrMsg.Text = "用户信息已删除！";
                    Close_Alart();
                    SuccessMsg1.Style["display"] = "block";
                    // 设置定时器
                    string script = "setTimeout(function() { $('#" + SuccessMsg1.ClientID + "').alert('close'); }, 900);";
                    ClientScript.RegisterStartupScript(this.GetType(), "closeAlert", script, true);

                    CnameTb.Value = "";
                    EmailTb.Value = "";
                    PhoneTb.Value = "";
                    PwdTb.Value = "";
                    Csex.SelectedIndex = -1;

                }
            }
            catch (Exception Ex)
            {
                //ErrMsg.Text = Ex.Message;
            }
        }

        int key = 0;
        protected void ClientList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Close_Alart();
            CnameTb.Value = ClientList.SelectedRow.Cells[2].Text;
            Csex.SelectedItem.Value = ClientList.SelectedRow.Cells[3].Text;
            EmailTb.Value = ClientList.SelectedRow.Cells[4].Text;
            PhoneTb.Value = ClientList.SelectedRow.Cells[5].Text;
            PwdTb.Value = ClientList.SelectedRow.Cells[6].Text;
            if (CnameTb.Value == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(ClientList.SelectedRow.Cells[1].Text);
            }
        }
    }
}