<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="Office_Goods.Views.Admin.Categories" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyContent" runat="server">

    <div class="container-fluid">
        <div class="row">
            <img src="../../Assets/images/1.jpg" id="logo" style="height:80px; width:1372px"/>

            <div class="col">
                <h3 class="text-center">类目管理</h3>
            </div>        
        </div>
        <div class="row">
            <div class="col-md-4">
                <div class="mb-3">
                    <label for="" class="form-label text-success">类目名称</label>
                    <input type="text" placeholder="" autocomplete="off" class="form-control" runat="server" id="CatNameTb"/>
                </div>
                <div class="mb-3">
                    <label for="" class="form-label text-success">详细信息</label>
                    <input type="text" placeholder="" autocomplete="off" class="form-control" runat="server" id="DetailTb"/>
                </div>

                <div class="row">
                     <div id="SuccessMsg1" class="alert alert-success alert-dismissible fade show" runat="server" style="display:none">
                            <a href="#" class="close" data-dismiss="alert">
		                        &times;
	                        </a>
                        <strong>成功!</strong> 操作成功！
                    </div>

                    <div id="InforMsg" class="alert alert-info alert-dismissible fade show" runat="server" style="display:none">
                            <a href="#" class="close" data-dismiss="alert">
		                        &times;
	                        </a>
                        <strong>提示!</strong>您未选中有效数据！请选择一条数据！
                    </div>

                    <div id="ErreMsg" class="alert alert-danger alert-dismissible fade show" runat="server" style="display:none">
                            <a href="#" class="close" data-dismiss="alert">
		                        &times;
	                        </a>
                        <strong>错误!</strong> 信息缺失，请补充完整！
                    </div>

                    <div class="col-md-4"><asp:Button Text="编辑" runat="server" id="EditBtn" CssClass="btn-success btn-block btn" width="90px" OnClick="EditBtn_Click" /></div>
                    <div class="col-md-4"><asp:Button Text="保存" runat="server" id="SaveBtn" CssClass="btn-primary btn-block btn" width="90px" OnClick="SaveBtn_Click" /></div>
                    <div class="col-md-4"><asp:Button Text="删除" runat="server" id="DeleteBtn" CssClass="btn-danger btn-block btn" width="90px" OnClick="DeleteBtn_Click" /></div>
                </div>
            </div>
            <div class="col-md-8">
                <asp:GridView ID="CategoryList" runat="server" class="table table-bordered table-striped" AutoGenerateSelectButton="True" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" Font-Bold="True" GridLines="None"  Width="794px" CellSpacing="1" OnSelectedIndexChanged="CategoryList_SelectedIndexChanged" >
                    <EditRowStyle BorderStyle="Solid" Width="56px" />
                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                    <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                    <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#594B9C" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#33276A" />
                </asp:GridView>
            </div>

        </div>
    </div>
</asp:Content>
