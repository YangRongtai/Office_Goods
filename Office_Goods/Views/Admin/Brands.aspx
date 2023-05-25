<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Brands.aspx.cs" Inherits="Office_Goods.Views.Admin.Brands" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyContent" runat="server">


    <div class="container-fluid">
        <div class="row">
            <img src="../../Assets/images/1.jpg" id="logo" style="height:80px; width:1372px"/>

            <div class="col">
                <h3 class="text-center">生产商管理</h3>
            </div>        
        </div>
        <div class="row">
            <div class="col-md-4">
                <div class="mb-3">
                    <label for="" class="form-label text-success">生产商名称</label>
                    <input type="text" placeholder="" autocomplete="off" class="form-control" runat="server" id="BNameTb" />
                </div>
                <div class="mb-3">
                    <label for="" class="form-label text-success">生产许可证</label>
                    <input type="text" placeholder="" autocomplete="off" class="form-control" runat="server" id="PermNumTb" />
                </div>
                <div class="mb-3">
                    <label for="" class="form-label text-success">产地</label>
                    <asp:DropDownList ID="PlaceCb" runat="server" class="form-control">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>江苏</asp:ListItem>
                        <asp:ListItem>山东</asp:ListItem>
                        <asp:ListItem>北京</asp:ListItem>
                        <asp:ListItem>重庆</asp:ListItem>
                        <asp:ListItem>四川</asp:ListItem>
                        
                    </asp:DropDownList>
                </div>
                <div class="row">
                    <!--<div id="successMsg" class="alert alert-info" runat="server" style="display:none">
                        <strong>成功!</strong>
                    </div>
                    <div id="InfoMsg" class="alert alert-info" runat="server" style="display:none" >
                        <strong>提示!</strong>
                    </div>
                    <div id="ErrrMsg" class="alert alert-danger" runat="server" style="display:none" >
                        <strong>错误!</strong>
                    </div>-->


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
                <asp:GridView ID="BrandList" runat="server" class="table table-bordered table-striped" AutoGenerateSelectButton="True" CellPadding="4" Font-Bold="True" GridLines="None"  Width="794px" OnSelectedIndexChanged="BrandList_SelectedIndexChanged1" ForeColor="#333333">
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
