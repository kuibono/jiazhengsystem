<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Jiazheng._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>家政信息管理系统</title>
    <style>
        body
        {
            scrollbar-base-color: #C0D586;
            scrollbar-arrow-color: #FFFFFF;
            scrollbar-shadow-color: DEEFC6;
        }
    </style>
</head>
<frameset rows="60,*" cols="*" frameborder="no" border="0" framespacing="0">
  <frame src="top.aspx" name="topFrame" scrolling="no">
  <frameset cols="180,*" name="btFrame" frameborder="NO" border="0" framespacing="0">
    <frame src="menu.aspx" noresize name="menu" scrolling="yes">
    <frame src="welcome.htm" noresize name="main" scrolling="yes">
  </frameset>
</frameset>
<noframes>
    <body>
        您的浏览器不支持框架！</body>
</noframes>
</html>
