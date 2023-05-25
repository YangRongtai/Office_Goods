using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Office_Goods.Views.Admin
{
    public partial class Categories : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            ShowCategories();
        }

        private void ShowCategories()
        {
            string Query = "Select * from CategoryTbl";
            CategoryList.DataSource = Con.GetData(Query);
            CategoryList.DataBind();
            CategoryList.HeaderRow.Cells[1].Text = "类目序号";
            CategoryList.HeaderRow.Cells[2].Text = "类目名称";
            CategoryList.HeaderRow.Cells[3].Text = "类目详情";
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
                if (CatNameTb.Value == "" || DetailTb.Value == "")
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
                    string CatName = CatNameTb.Value;
                    string Detail = DetailTb.Value;

                    string Query = "update CategoryTbl set CategoryName='{0}',CategoryDetail='{1}' where CategoryId={2}";
                    Query = string.Format(Query, CatName, Detail, CategoryList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowCategories();
                    //ErrMsg.Text = "物品类目信息已更新！";
                    Close_Alart();
                    SuccessMsg1.Style["display"] = "block";
                    // 设置定时器
                    string script = "setTimeout(function() { $('#" + SuccessMsg1.ClientID + "').alert('close'); }, 900);";
                    ClientScript.RegisterStartupScript(this.GetType(), "closeAlert", script, true);

                    CatNameTb.Value = "";
                    DetailTb.Value = "";
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
                if (CatNameTb.Value == "" || DetailTb.Value == "")
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
                    string CatName = CatNameTb.Value;
                    string Detail = DetailTb.Value;

                    string Query = "insert into CategoryTbl values('{0}','{1}')";
                    Query = string.Format(Query, CatName, Detail);
                    Con.SetData(Query);
                    ShowCategories();
                    //ErrMsg.Text = "物品类目信息添加成功！";
                    Close_Alart();
                    SuccessMsg1.Style["display"] = "block";
                    // 设置定时器
                    string script = "setTimeout(function() { $('#" + SuccessMsg1.ClientID + "').alert('close'); }, 900);";
                    ClientScript.RegisterStartupScript(this.GetType(), "closeAlert", script, true);

                    CatNameTb.Value = "";
                    DetailTb.Value = "";
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
                if (CatNameTb.Value == "" || DetailTb.Value == "")
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
                    string BName = CatNameTb.Value;
                    string PermNum = DetailTb.Value;

                    string Query = "delete from CategoryTbl where CategoryId = {0}";
                    Query = string.Format(Query, CategoryList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowCategories();
                    //ErrMsg.Text = "物品类目信息已删除！";
                    Close_Alart();
                    SuccessMsg1.Style["display"] = "block";
                    // 设置定时器
                    string script = "setTimeout(function() { $('#" + SuccessMsg1.ClientID + "').alert('close'); }, 900);";
                    ClientScript.RegisterStartupScript(this.GetType(), "closeAlert", script, true);

                    CatNameTb.Value = "";
                    DetailTb.Value = "";

                }
            }
            catch (Exception Ex)
            {
                //ErrMsg.Text = Ex.Message;
            }
        }

        int key = 0;
        protected void CategoryList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Close_Alart();
            CatNameTb.Value = CategoryList.SelectedRow.Cells[2].Text;
            DetailTb.Value = CategoryList.SelectedRow.Cells[3].Text;
            if (CatNameTb.Value == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(CategoryList.SelectedRow.Cells[1].Text);
            }
        }
    }
}