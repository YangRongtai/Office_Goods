<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Office_Goods.Views.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Konchok</title>
    <!-- <link rel="stylesheet" type="text/css" href="css/style.css" /> -->
    <style>
        *{
            padding: 0;
            margin: 0;
            font-family: "楷体";
        }
        header{
            background-image:linear-gradient(rgba(0,0,0,0.5),rgba(0,0,0,0.5)), url(../../Assets/Images/index1.png);
            height: 100vh;
            background-size: cover;
            background-position: center;
        }
    
        ul{
            float: right;
            list-style-type: none;
            margin: 15px;
        }
        ul li{
            display: inline-block;
        }
    
        ul li a{
            text-decoration: none;
            color: #fff;
            padding: 5px 20px;
            border: 1px solid transparent;
            transition: .6s ease;
            border-radius: 20px;
        }
    
        ul li a:hover{
            background-color: #fff;
            color: #000;
        }
        ul li.active a{
            background-color: #fff;
            color: #000;
        }
        .title{
            position: absolute;
            top:50%;
            left:50%;
            transform: translate(-50%,-50%);
        }
        .title h1{
            color: #fff;
            font-size: 70px;
            font-family: Century Gothic;
        }
    </style>
</head>
<body>
    <header>
        <div class="main">
            <ul>
                <li class="active"><a href="#">主页</a></li>
                <li><a href="Admin/Goods.aspx" target="_blank">库存查询</a></li>
                <li><a href="Clients/Apply.aspx" target="_blank">领用申请</a></li>
                <li><a href="Login.aspx" target="_blank">退出</a></li>
                
            </ul>
        </div>
        <div class="title">
            <h1 align="center">欢迎使用</h1>
            <h1><span style="color:	#FFE1FF">办公物品管理系统</span></h1>
        </div>
    </header>
</body>
</html>
