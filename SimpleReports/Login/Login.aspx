<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SimpleReports.Login.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="login">
        <h1>登 录</h1>
        <fieldset id="inputs">
            <input id="username" type="text" placeholder="请输入用户名" autofocus="autofocus" required="required" />
            <input id="password" type="password" placeholder="请输入密码" required="required" />
        </fieldset>
        <fieldset id="actions">
            <input type="submit" id="submit" value="登录" />
            <%--<a href="">Forgot your password?</a>--%><a href="">注册</a>
        </fieldset>
    </form>
    <link href="../assets/css/login.css" rel="stylesheet" />
</body>
</html>
