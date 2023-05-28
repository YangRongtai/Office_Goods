<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Office_Goods.Views.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <!-- css样式表 -->
    <style>
    body
        {
            /* 加载背景图 */
        background:url(../../Assets/Images/bg.png);
        /* 背景图垂直、水平均居中 */
        background-position: center center;
        /* 背景图不平铺 */
        background-repeat: no-repeat;
        /* 当内容高度大于图片高度时，背景图像的位置相对于viewport固定 */
        background-attachment: fixed;
        /* 让背景图基于容器大小伸缩 */
        background-size: cover;
        /* 设置背景颜色，背景图加载过程中会显示背景色 */
        background-color: #464646;
        }
    .loginform{
        /*上边界距离*/
        margin-top: 110px;
    }
    .radio-btn {
        margin-right: 50px;
    }
    .text-center {
        display: flex;
        justify-content: center;
        align-items: center;
        text-align: center;
    }
   
    </style>


    <!--<link rel="stylesheet" href="../Assets/Lib/css/bootstrap.min.css" />-->
    <!-- 新 Bootstrap 核心 CSS 文件 -->
    <link href="https://cdn.staticfile.org/twitter-bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet"/>
 
    <!-- jQuery文件。务必在bootstrap.min.js 之前引入 -->
    <script src="https://cdn.staticfile.org/jquery/2.1.1/jquery.min.js"></script>
 
    <!-- 最新的 Bootstrap 核心 JavaScript 文件 -->
    <script src="https://cdn.staticfile.org/twitter-bootstrap/3.3.7/js/bootstrap.min.js"></script>
</head>
<body>
 <div class="loginform">
    <h1 class="text-center">办公物品管理系统</h1>
    <div class="container-fluid">
        <div class="row bg">
            <div class="col-md-4 col-md-offset-4" style="border: #4d4d4d solid 1px;background-color: hsl(0, 0%, 98%);">
                <form class="form-container " role="form" runat="server">
                    <h3 class="text-center">用户登录</h3>
                    <div class="form-group">
                        <label for="username">用户名 </label>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                            <input type="email" class="form-control" autocomplete="off" runat="server" id="UnameTb" placeholder="请输入用户名"/>
                         </div>
                    </div>
 
                    <div class="form-group">
                        <label for="password">密码</label>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                            <input type="password" class="form-control" autocomplete="off" runat="server" id="PasswordTb" placeholder="请输入密码"/>
                        </div>
                    </div>
                    <div class="well well-sm" style="text-align:center;">
                        <!--<label class="radio-inline" runat="server" id="ClientRd">
                            <input type="radio" name="optionsRadios"  value="0" checked="checked" /> 普通用户
                        </label>
                        <label class="radio-inline" runat="server" id="AdminRd" >
                            <input type="radio"name="optionsRadios"  values="1"/>管理员
                        </label>-->

                        <asp:RadioButton ID="ClientRd1" class="radio-btn" runat="server" Text="普通用户" GroupName="UserType" Checked="True" />
                        <asp:RadioButton ID="AdminRd1" class="radio-btn" runat="server" Text="管理员" GroupName="UserType" />
                    </div>
                    
                    <div>
                        <!--<button class="btn btn-primary btn-block active" id="LoginBtn" type="submit">登录</button>-->
                        <asp:Label runat="server" ID="ErrMsg" class="text-danger text-center"></asp:Label>
                        <br>
                        <asp:Button type="submit" ID="LoginBtn" Text="登录" runat="server" class="btn btn-primary btn-block active" OnClick="LoginBtn_Click1" />
                    </div>

 
                    <div class="well well-sm" style="text-align:center;">
                    <button type="button" class="btn btn-link">注册用户</button>
                    <button type="button" class="btn btn-link">找回密码</button>
                    </div>
 
                </form>        
            </div>
        </div>
    </div>
</div>

</body>
</html>
