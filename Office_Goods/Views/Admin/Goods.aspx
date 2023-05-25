<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Goods.aspx.cs" Inherits="Office_Goods.Views.Admin.Goods" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyContent" runat="server">

    <div class="container-fluid">
        <div class="row">
            <img src="../../Assets/images/1.jpg" id="logo" style="height:80px; width:1372px"/>

            <div class="col">
                <h3 class="text-center">物品管理</h3>
            </div>        
        </div>
        <div class="row">
            <div class="col-md-4">
                <div class="mb-3">
                    <label for="" class="form-label text-success">商品名称</label>
                    <input type="text" placeholder="" autocomplete="off" runat="server" id="GNameTb" class="form-control" />
                </div>
                <div class="mb-3">
                    <label for="" class="form-label text-success">生产商</label>
                    <asp:DropDownList ID="PManufactCb" runat="server" class="form-control"></asp:DropDownList>
                </div>
                <div class="mb-3">
                    <label for="" class="form-label text-success">类目</label>
                    <asp:DropDownList ID="PCategoryCb" runat="server" class="form-control"></asp:DropDownList>
                </div>
                <div class="mb-3">
                    <label for="" class="form-label text-success">价格</label>
                    <input type="text" placeholder="" autocomplete="off" runat="server" id="GPriceTb" class="form-control" />
                </div>
                <div class="mb-3">
                    <label for="" class="form-label text-success">数量</label>
                    <input type="text" placeholder="" autocomplete="off" runat="server" id="GNumTb" class="form-control" />
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

                    <div class="col-md-4"><asp:Button Text="编辑" id="EditBtn" runat="server" CssClass="btn-success btn-block btn" width="90px" OnClick="EditBtn_Click" /></div>
                    <div class="col-md-4"><asp:Button Text="保存" id="SaveBtn" runat="server" CssClass="btn-primary btn-block btn" width="90px" OnClick="SaveBtn_Click" /></div>
                    <div class="col-md-4"><asp:Button Text="删除" id="DeleteBtn" runat="server" CssClass="btn-danger btn-block btn" width="90px" OnClick="DeleteBtn_Click" /></div>
                </div>
            </div>
            <div class="col-md-8">
                <asp:GridView ID="GoodList" runat="server" class="table table-bordered table-striped" AutoGenerateSelectButton="True" CellPadding="4" Font-Bold="True" GridLines="None"  Width="794px"  ForeColor="#333333" OnSelectedIndexChanged="GoodList_SelectedIndexChanged" >
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BorderStyle="Solid" Width="56px" BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
            </div>

        </div>
    </div>
</asp:Content>
