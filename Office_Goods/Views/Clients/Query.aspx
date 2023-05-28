<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Clients/ClientsMaster.Master" AutoEventWireup="true" CodeBehind="Query.aspx.cs" Inherits="Office_Goods.Views.Clients.Query" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyContent" runat="server">

     <div class="container-fluid">
        <div class="row">
            <img src="../../Assets/images/1.jpg" id="logo" style="height:80px; width:1372px"/>

            <div class="col">
                <h3 class="text-center">物品信息</h3>
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

                
            </div>
            <div class="col-md-8">
                <asp:GridView ID="GoodList" runat="server" class="table table-bordered table-striped" AutoGenerateSelectButton="True" CellPadding="4" Font-Bold="True" GridLines="None"  Width="794px"  ForeColor="#333333" >
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
