using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Office_Goods.Views.Admin
{
    public partial class Brands : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            ShowManufactors();
        }

        private void ShowManufactors()
        {
            string Query = "Select * from ManufactorTbl";
            BrandList.DataSource = Con.GetData(Query);
            BrandList.DataBind();
            BrandList.HeaderRow.Cells[1].Text = "序号";
            BrandList.HeaderRow.Cells[2].Text = "生产商名称";
            BrandList.HeaderRow.Cells[3].Text = "生产许可号";
            BrandList.HeaderRow.Cells[4].Text = "物品产地";
        }

        private void Close_Alart()
        {
            SuccessMsg1.Style["display"] = "none";
            InforMsg.Style["display"] = "none";
            ErreMsg.Style["display"] = "none";
        }
        protected void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (BNameTb.Value == "" || PermNumTb.Value == "" || PlaceCb.SelectedIndex == -1)
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
                    string BName = BNameTb.Value;
                    string PermNum = PermNumTb.Value;
                    string Place = PlaceCb.SelectedItem.ToString();

                    string Query = "update ManufactorTbl set ManufactName='{0}',ManufactPermNum='{1}',ManufactPlace='{2}' where ManufactId = {3}";
                    Query = string.Format(Query, BName, PermNum, Place, BrandList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowManufactors();
                    //SuccessMsg.Text = "供应商信息已更新！";
                    Close_Alart();
                    SuccessMsg1.Style["display"] = "block";
                    // 设置定时器
                    string script = "setTimeout(function() { $('#" + SuccessMsg1.ClientID + "').alert('close'); }, 900);";
                    ClientScript.RegisterStartupScript(this.GetType(), "closeAlert", script, true);


                    BNameTb.Value = "";
                    PermNumTb.Value = "";
                    PlaceCb.SelectedIndex = -1;

                }
            }
            catch (Exception Ex)
            {
            }
        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (BNameTb.Value == "" || PermNumTb.Value == "" || PlaceCb.SelectedIndex == -1)
                {
                    //InfoMsg.Text = "信息缺失，请补充完整";
                    Close_Alart();
                    ErreMsg.Style["display"] = "block";
                    // 设置定时器
                    string script = "setTimeout(function() { $('#" + ErreMsg.ClientID + "').alert('close'); }, 900);";
                    ClientScript.RegisterStartupScript(this.GetType(), "closeAlert", script, true);
                }
                else
                {
                    string BName = BNameTb.Value;
                    string PermNum = PermNumTb.Value;
                    string Place = PlaceCb.SelectedItem.ToString();

                    string Query = "insert into ManufactorTbl values('{0}','{1}','{2}')";
                    Query = string.Format(Query, BName, PermNum, Place);
                    Con.SetData(Query);
                    ShowManufactors();
                    //SuccessMsg.Text = "供应商信息添加成功！";
                    Close_Alart();
                    SuccessMsg1.Style["display"] = "block";
                    // 设置定时器
                    string script = "setTimeout(function() { $('#" + SuccessMsg1.ClientID + "').alert('close'); }, 900)";
                    ClientScript.RegisterStartupScript(this.GetType(), "closeAlert", script, true);

                    BNameTb.Value = "";
                    PermNumTb.Value = "";
                    PlaceCb.SelectedIndex = -1;
                }
            }
            catch (Exception Ex)
            {
            }
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (BNameTb.Value == "" || PermNumTb.Value == "" || PlaceCb.SelectedIndex == -1)
                {
                    //InfoMsg.Text = "您未选中有效数据！请选择一条数据";
                    Close_Alart();
                    InforMsg.Style["display"] = "block";
                    // 设置定时器
                    string script = "setTimeout(function() { $('#" + InforMsg.ClientID + "').alert('close'); },900);";
                    ClientScript.RegisterStartupScript(this.GetType(), "closeAlert", script, true);
                }
                else
                {
                    string BName = BNameTb.Value;
                    string PermNum = PermNumTb.Value;
                    string Place = PlaceCb.SelectedItem.ToString();

                    string Query = "delete from ManufactorTbl where ManufactId = {0}";
                    Query = string.Format(Query, BrandList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowManufactors();
                    //SuccessMsg.Text = "供应商信息已删除！";
                    Close_Alart();
                    SuccessMsg1.Style["display"] = "block";
                    // 设置定时器
                    string script = "setTimeout(function() { $('#" + SuccessMsg1.ClientID + "').alert('close'); }, 900);";
                    ClientScript.RegisterStartupScript(this.GetType(), "closeAlert", script, true);

                    BNameTb.Value = "";
                    PermNumTb.Value = "";
                    PlaceCb.SelectedIndex = -1;

                }
            }
            catch (Exception Ex)
            {
            }
        }


        int key = 0;
        protected void BrandList_SelectedIndexChanged1(object sender, EventArgs e)
        {
            Close_Alart();
            BNameTb.Value = BrandList.SelectedRow.Cells[2].Text;
            PermNumTb.Value = BrandList.SelectedRow.Cells[3].Text;
            PlaceCb.SelectedItem.Value = BrandList.SelectedRow.Cells[4].Text;
            if (BNameTb.Value == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(BrandList.SelectedRow.Cells[1].Text);
            }
        }
    }
}