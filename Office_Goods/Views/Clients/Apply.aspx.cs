using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Office_Goods.Views.Clients
{
    public partial class Apply : System.Web.UI.Page
    {
        Models.Functions Con;
        int client = Login.User;
        string Cname = Login.UName;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();

            if (!IsPostBack)
            {
                ShowGoods();
                //GetCategories();
                //GetManufactors();
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[5]
                {
                    new DataColumn("序号"),
                    new DataColumn("商品名称"),
                    new DataColumn("价格"),
                    new DataColumn("数量"),
                    new DataColumn("总计"),
                });

                ViewState["领用申请清单"] = dt;
                this.BindGrid();
            }
        }

        protected void BindGrid()
        {
            ApplyList.DataSource = ViewState["领用申请清单"];
            ApplyList.DataBind();
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

        private void Close_Alart()
        {
            SuccessMsg1.Style["display"] = "none";
            ErreMsg.Style["display"] = "none";
        }

        int key = 0;
        int store = 0;
        protected void GoodList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Close_Alart();
            GnameTb.Value = GoodList.SelectedRow.Cells[2].Text;
            PriceTb.Value = GoodList.SelectedRow.Cells[6].Text;
            store = Convert.ToInt32(GoodList.SelectedRow.Cells[5].Text);
            if (GnameTb.Value == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(GoodList.SelectedRow.Cells[1].Text);
            }
        }


        private void UpdateStore()
        {

            Close_Alart();
            
            if (GoodList.SelectedRow != null)
            {
                int newNum = 0;
                newNum = Convert.ToInt32(GoodList.SelectedRow.Cells[5].Text) - Convert.ToInt32(NumTb.Value);
                if (newNum < 0)
                {
                    Close_Alart();
                    ErreMsg.Style["display"] = "block";
                    // 设置定时器
                    string script = "setTimeout(function() { $('#" + ErreMsg.ClientID + "').alert('close'); }, 1050);";
                    ClientScript.RegisterStartupScript(this.GetType(), "closeAlert", script, true);
                }
                else{
                    //newNum = Convert.ToInt32(GoodList.SelectedRow.Cells[5]) - Convert.ToInt32(NumTb.Value);
                    string Query = "update GoodsTbl set PQty='{0}' where PId={1}";
                    Query = string.Format(Query, newNum, GoodList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowGoods();
                }
            }
            
        }

        private void InsertApply()
        {

            Close_Alart();
            try
            {
                /*if (newNum < 0)
                {
                    Close_Alart();
                    Err.Style["display"] = "block";
                    // 设置定时器
                    string script = "setTimeout(function() { $('#" + ErreMsg.ClientID + "').alert('close'); }, 1000);";
                    ClientScript.RegisterStartupScript(this.GetType(), "closeAlert", script, true);
                }
                else
                {*/
                    string Query = "insert into ReportTbl values('{0}','{1}','{2}')";
                    Query = string.Format(Query, DateTime.Today.Date.ToString(), client, Convert.ToInt32(GrdTotalTb.Text));
                    Con.SetData(Query);
            }
            catch
            {

            }
        }


        int GrdTotal = 0;
        int Amount = 0;
        protected void AddApply_Click(object sender, EventArgs e)
        {
            Close_Alart();
            if (GnameTb.Value == "" || PriceTb.Value == "" || NumTb.Value == "")
            {
                
            }
            else
            {
                int newNum = 0;
                newNum = Convert.ToInt32(GoodList.SelectedRow.Cells[5].Text) - Convert.ToInt32(NumTb.Value);

                if(newNum >= 0)
                {
                    int total = Convert.ToInt32(PriceTb.Value) * Convert.ToInt32(NumTb.Value);
                    DataTable dt = (DataTable)ViewState["领用申请清单"];
                    dt.Rows.Add(ApplyList.Rows.Count + 1,
                        GnameTb.Value.Trim(),
                        PriceTb.Value.Trim(),
                        NumTb.Value.Trim(),
                        total);
                    ViewState["领用申请清单"] = dt;

                    this.BindGrid();
                    UpdateStore();
                    GrdTotal = 0;
                    for (int i = 0; i < ApplyList.Rows.Count; i++)
                    {
                        GrdTotal = GrdTotal + Convert.ToInt32(ApplyList.Rows[i].Cells[4].Text);

                    }
                    Amount = GrdTotal;
                    RMBLabel.Text = "￥";
                    GrdTotalTb.Text = Convert.ToString(GrdTotal);
                    GnameTb.Value = "";
                    PriceTb.Value = "";
                    NumTb.Value = "";
                }
                else
                {
                    Close_Alart();
                    ErreMsg.Style["display"] = "block";
                    // 设置定时器

                    string script = "setTimeout(function() { $('#" + ErreMsg.ClientID + "').alert('close'); }, 1050);";
                    ClientScript.RegisterStartupScript(this.GetType(), "closeAlert", script, true);
                }
            }
        }

        protected void PrintBtn_Click(object sender, EventArgs e)
        {
            InsertApply();
            Close_Alart();
            SuccessMsg1.Style["display"] = "block";
            // 设置定时器
            string script = "setTimeout(function() { $('#" + SuccessMsg1.ClientID + "').alert('close'); }, 1200);";
            ClientScript.RegisterStartupScript(this.GetType(), "closeAlert", script, true);
        }

        
    }
}