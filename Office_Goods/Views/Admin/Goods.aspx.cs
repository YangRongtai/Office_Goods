using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Office_Goods.Views.Admin
{
    public partial class Goods : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();

            if (!IsPostBack)
            {
                ShowGoods();
                GetCategories();
                GetManufactors();
            }
        }

        private void Close_Alart()
        {
            SuccessMsg1.Style["display"] = "none";
            InforMsg.Style["display"] = "none";
            ErreMsg.Style["display"] = "none";
        }
        private void ShowGoods()
        {
            string Query = "Select G.PId,G.PName,M.ManufactName,C.CategoryName,G.PQty,G.PPrice from GoodsTbl as G,CategoryTbl as C,ManufactorTbl as M where G.PManufact = M.ManufactId and G.PCategory = C.CategoryId";
            GoodList.DataSource = Con.GetData(Query);
            GoodList.DataBind();
            GoodList.HeaderRow.Cells[1].Text = "物品编号";
            GoodList.HeaderRow.Cells[2].Text = "名称";
            GoodList.HeaderRow.Cells[3].Text = "产地";
            GoodList.HeaderRow.Cells[4].Text = "类别";
            GoodList.HeaderRow.Cells[5].Text = "库存数量";
            GoodList.HeaderRow.Cells[6].Text = "单价/￥";
            //GoodList.HeaderRow.Cells[7].Text = "物品产地";
            //GoodList.HeaderRow.Cells[8].Text = "物品产地";
        }

        private void GetCategories()
        {
            string Query = "select * from CategoryTbl";
            PCategoryCb.DataTextField = Con.GetData(Query).Columns["CategoryName"].ToString();
            PCategoryCb.DataValueField = Con.GetData(Query).Columns["CategoryId"].ToString();
            PCategoryCb.DataSource = Con.GetData(Query);
            PCategoryCb.DataBind();
        }

        private void GetManufactors()
        {
            string Query = "select * from ManufactorTbl";
            PManufactCb.DataTextField = Con.GetData(Query).Columns["ManufactName"].ToString();
            PManufactCb.DataValueField = Con.GetData(Query).Columns["ManufactId"].ToString();
            PManufactCb.DataSource = Con.GetData(Query);
            PManufactCb.DataBind();
        }
        protected void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (GNameTb.Value == "" || PCategoryCb.SelectedIndex == -1 || PCategoryCb.SelectedIndex == -1 || GPriceTb.Value == "" || GNumTb.Value == "")
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
                    string GName = GNameTb.Value;
                    string PManufact = PManufactCb.SelectedValue.ToString();
                    string PCategory = PCategoryCb.SelectedValue.ToString();
                    int GNum = Convert.ToInt32(GNumTb.Value);
                    int GPrice = Convert.ToInt32(GPriceTb.Value);

                    string Query = "update GoodsTbl set PName='{0}',PManufact='{1}',PCategory='{2}',PQty='{3}',PPrice='{4}' where PId={5}";
                    Query = string.Format(Query, GName, PManufact, PCategory, GNum, GPrice, GoodList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowGoods();
                    //ErrMsg.Text = "物品信息已更新！";
                    Close_Alart();
                    SuccessMsg1.Style["display"] = "block";
                    // 设置定时器
                    string script = "setTimeout(function() { $('#" + SuccessMsg1.ClientID + "').alert('close'); }, 900);";
                    ClientScript.RegisterStartupScript(this.GetType(), "closeAlert", script, true);

                    GNameTb.Value = "";
                    PManufactCb.SelectedIndex = -1;
                    PCategoryCb.SelectedIndex = -1;
                    GNumTb.Value = "";
                    GPriceTb.Value = "";
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
                if (GNameTb.Value == "" || PCategoryCb.SelectedIndex == -1 || PCategoryCb.SelectedIndex == -1 || GPriceTb.Value == "" || GNumTb.Value == "")
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
                    string GName = GNameTb.Value;
                    string PManufact = PManufactCb.SelectedValue.ToString();
                    string PCategory = PCategoryCb.SelectedValue.ToString();
                    int GNum = Convert.ToInt32(GNumTb.Value);
                    int GPrice = Convert.ToInt32(GPriceTb.Value);

                    string Query = "insert into GoodsTbl values('{0}','{1}','{2}','{3}','{4}')";
                    Query = string.Format(Query, GName, PManufact, PCategory, GNum, GPrice);
                    Con.SetData(Query);
                    ShowGoods();
                    //ErrMsg.Text = "物品信息添加成功！";
                    Close_Alart();
                    SuccessMsg1.Style["display"] = "block";
                    // 设置定时器
                    string script = "setTimeout(function() { $('#" + SuccessMsg1.ClientID + "').alert('close'); }, 900);";
                    ClientScript.RegisterStartupScript(this.GetType(), "closeAlert", script, true);

                    GNameTb.Value = "";
                    PManufactCb.SelectedIndex = -1;
                    PCategoryCb.SelectedIndex = -1;
                    GNumTb.Value = "";
                    GPriceTb.Value = "";
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
                if (GNameTb.Value == "" || PCategoryCb.SelectedIndex == -1 || PCategoryCb.SelectedIndex == -1 || GPriceTb.Value == "" || GNumTb.Value == "")
                {
                    Close_Alart();
                    InforMsg.Style["display"] = "block";
                    // 设置定时器
                    string script = "setTimeout(function() { $('#" + InforMsg.ClientID + "').alert('close'); },900);";
                    ClientScript.RegisterStartupScript(this.GetType(), "closeAlert", script, true);
                }
                else
                {
                    string GName = GNameTb.Value;
                    string PManufact = PManufactCb.SelectedValue.ToString();
                    string PCategory = PCategoryCb.SelectedValue.ToString();
                    int GNum = Convert.ToInt32(GNumTb.Value);
                    int GPrice = Convert.ToInt32(GPriceTb.Value);

                    string Query = "delete from GoodsTbl where PId={0}";
                    Query = string.Format(Query, GoodList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowGoods();
                    //ErrMsg.Text = "物品信息已删除！";
                    Close_Alart();
                    SuccessMsg1.Style["display"] = "block";
                    // 设置定时器
                    string script = "setTimeout(function() { $('#" + SuccessMsg1.ClientID + "').alert('close'); }, 900);";
                    ClientScript.RegisterStartupScript(this.GetType(), "closeAlert", script, true);

                    GNameTb.Value = "";
                    PManufactCb.SelectedIndex = -1;
                    PCategoryCb.SelectedIndex = -1;
                    GNumTb.Value = "";
                    GPriceTb.Value = "";
                }
            }
            catch (Exception Ex)
            {
                //ErrMsg.Text = Ex.Message;
            }
        }


        int key = 0;
        protected void GoodList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Close_Alart();
            GNameTb.Value = GoodList.SelectedRow.Cells[2].Text;
            PManufactCb.SelectedItem.Value = GoodList.SelectedRow.Cells[3].Text;
            PCategoryCb.SelectedItem.Value = GoodList.SelectedRow.Cells[4].Text;
            GNumTb.Value = GoodList.SelectedRow.Cells[5].Text;
            GPriceTb.Value = GoodList.SelectedRow.Cells[6].Text;

            if (GNameTb.Value == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(GoodList.SelectedRow.Cells[1].Text);
            }
        }
    }
}