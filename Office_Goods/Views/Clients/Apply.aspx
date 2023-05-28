<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Clients/ClientsMaster.Master" AutoEventWireup="true" CodeBehind="Apply.aspx.cs" Inherits="Office_Goods.Views.Clients.Apply" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        function PrintApply() {
            var PGrid = document.getElementById('<%=ApplyList.ClientID%>');
            PGrid.bordr = 0;
            var PWin = window.open('', 'PrintApply', 'left=100,top=100,width=1024,height=768,tollvar=0,scrollbars=1,status=0,resizable=1');
            PWin.document.write(PGrid.outerHTML);
            Pwin.document.close();
            PWin.focus();
            PWin.print();
            PWin.close();
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyContent" runat="server">

    <div class="container-fluid">

        
        <div class="row">
            <h2 style="color:navy" class="text-center my-2">办公物品申请</h2>
        </div>

        <div class="row">
            <div class="col-md-5">

                <div class="row">
                    <div class="col">
                        <div class="mt-3">
                            <label for="" style="font-weight: bold;" class="col-form-label text-info ">物品名称</label>
                            <input type="text" placeholder="" autocomplete="off" class="form-control" runat="server" id="GnameTb" />
                        </div>
                    </div>

                    <div class="col">
                        <div class="mt-3">
                            <label for="" style="font-weight: bold;" class="col-form-label text-info">价格</label>
                            <input type="text" placeholder="" autocomplete="off" class="form-control" runat="server" id="PriceTb" />
                        </div>
                    </div>

                    <div class="col">
                        <div class="mt-3">
                            <label for="" style="font-weight: bold;" class="col-form-label text-info">数量</label>
                            <input type="text" placeholder="" autocomplete="off" class="form-control" runat="server" id="NumTb" />
                        </div>
                    </div>

                    <div class="row mb-3 mt-3">
                        <div class="col d-grid">
                            <asp:Button Text="加入申请列表" runat="server" id="AddApply" CssClass="btn-success btn-block btn" OnClick="AddApply_Click" />
                        </div>

                    </div>


                </div>

                <div class="row mt-4">
                    <h3 style="color:darkorange" class="my-2">商品列表</h3>
                    <div class="col">
                        <asp:GridView ID="GoodList" runat="server" class="table table-bordered table-striped" AutoGenerateSelectButton="True" CellPadding="4" Font-Bold="True" GridLines="None"  Width="794px"  ForeColor="#333333" OnSelectedIndexChanged="GoodList_SelectedIndexChanged"  >
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
            <div class="col-md-7">

                <h3 style="color:darkorange" class="text-center my-2">领用申请</h3>
                    <div class="col">
                        <asp:GridView ID="ApplyList" runat="server" class="table table-bordered table-striped" CellPadding="4" Font-Bold="True" GridLines="None"  Width="794px"  ForeColor="#333333" >
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

                    <div class="row">
                        <div class="row">
                            <div class="col-md-5">

                            </div>
                            <div class="col-md-1">
                                <asp:Label runat="server" ID="RMBLabel" class="text-danger text-center"></asp:Label><br>
                            </div>
                            <div class="col-md-6">
                                <asp:Label runat="server" ID="GrdTotalTb" class="text-danger text-center"></asp:Label><br>
                            </div>
                        </div>

                        <div class="row">
                        <div id="SuccessMsg1" class="alert alert-success alert-dismissible fade show" runat="server" style="display:none">
                            <a href="#" class="close" data-dismiss="alert">
		                        &times;
	                        </a>
                            <strong>申请成功!</strong> <span style="color:crimson">请等待审核！</span>
                        </div>

                        <div id="ErreMsg" class="alert alert-danger alert-dismissible fade show" runat="server" style="display:none">
                            <a href="#" class="close" data-dismiss="alert">
		                        &times;
	                        </a>
                            <strong>错误!</strong> 申请数量不能超过库存数量！
                        </div>
                        </div>
                        </div class="btn-group">
                                <asp:Button style="width: 700px;margin-left: 27px;" Text="提交申请" runat="server" id="SubmitTb" CssClass="btn-success btn-block btn" OnClick="PrintBtn_Click" />
                                <asp:Button style="width: 700px;margin-left: 27px;" Text="打印清单" runat="server" id="PrintTb" OnClientClick="PrintApply()" CssClass="btn-primary btn-block btn" />
                        </div>
                    </div>
            </div>

</asp:Content>
