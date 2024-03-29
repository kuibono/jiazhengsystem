﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Top.aspx.cs" Inherits="Jiazheng.Top" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>top</title>
    <link href="skin/css/base.css" rel="stylesheet" type="text/css">

    <script language='javascript'>
        var preFrameW = '206,*';
        var FrameHide = 0;
        var curStyle = 1;
        var totalItem = 9;
        function ChangeMenu(way) {
            var addwidth = 10;
            var fcol = top.document.all.btFrame.cols;
            if (way == 1) addwidth = 10;
            else if (way == -1) addwidth = -10;
            else if (way == 0) {
                if (FrameHide == 0) {
                    preFrameW = top.document.all.btFrame.cols;
                    top.document.all.btFrame.cols = '0,*';
                    FrameHide = 1;
                    return;
                } else {
                    top.document.all.btFrame.cols = preFrameW;
                    FrameHide = 0;
                    return;
                }
            }
            fcols = fcol.split(',');
            fcols[0] = parseInt(fcols[0]) + addwidth;
            top.document.all.btFrame.cols = fcols[0] + ',*';
        }


        function mv(selobj, moveout, itemnum) {
            if (itemnum == curStyle) return false;
            if (moveout == 'm') selobj.className = 'itemsel';
            if (moveout == 'o') selobj.className = 'item';
            return true;
        }

        function changeSel(itemnum) {
            curStyle = itemnum;
            for (i = 1; i <= totalItem; i++) {
                if (document.getElementById('item' + i)) document.getElementById('item' + i).className = 'item';
            }
            document.getElementById('item' + itemnum).className = 'itemsel';
        }

    </script>

    <style>
        body
        {
            padding: 0px;
            margin: 0px;
        }
        #tpa
        {
            color: #009933;
            margin: 0px;
            padding: 0px;
            float: right;
            padding-right: 10px;
        }
        #tpa dd
        {
            margin: 0px;
            padding: 0px;
            float: left;
            margin-right: 2px;
        }
        #tpa dd.ditem
        {
            margin-right: 8px;
        }
        #tpa dd.img
        {
            padding-top: 6px;
        }
        div.item
        {
            text-align: center;
            background: url(skin/images/frame/topitembg.gif) 0px 3px no-repeat;
            width: 82px;
            height: 26px;
            line-height: 28px;
        }
        .itemsel
        {
            width: 80px;
            text-align: center;
            background: #226411;
            border-left: 1px solid #c5f097;
            border-right: 1px solid #c5f097;
            border-top: 1px solid #c5f097;
            height: 26px;
            line-height: 28px;
        }
        *html .itemsel
        {
            height: 26px;
            line-height: 26px;
        }
        a:link, a:visited
        {
            text-decoration: underline;
        }
        .item a:link, .item a:visited
        {
            font-size: 12px;
            color: #ffffff;
            text-decoration: none;
            font-weight: bold;
        }
        .itemsel a:hover
        {
            color: #ffffff;
            font-weight: bold;
            border-bottom: 2px solid #E9FC65;
        }
        .itemsel a:link, .itemsel a:visited
        {
            font-size: 12px;
            color: #ffffff;
            text-decoration: none;
            font-weight: bold;
        }
        .itemsel a:hover
        {
            color: #ffffff;
            border-bottom: 2px solid #E9FC65;
        }
        .rmain
        {
            padding-left: 10px; /* background:url(skin/images/frame/toprightbg.gif) no-repeat; */
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0" background="skin/images/frame/topbg.gif">
        <tr>
            <td width='20%' height="60">
                <img src="skin/images/frame/logo.png" />
            </td>
            <td width='80%' align="right" valign="bottom">
                <table width="750" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td align="right" height="26" style="padding-right: 10px; line-height: 26px;">
                            您好：<span class="username"><%= Opuser.UserName%></span>，欢迎使用本系统！ [<a href="welcome.htm"
                                target="main">网站主页</a>] [<a href="javascript:parent.location.href='Tools/Exit.ashx'" target="_top">注销退出</a>]&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="right" height="34" class="rmain">
                            <dl id="tpa">
                                <dd class='img'>
                                    <a href="javascript:ChangeMenu(-1);">
                                        <img vspace="5" src="skin/images/frame/arrl.gif" border="0" width="5" height="8"
                                            alt="缩小左框架" title="缩小左框架" /></a></dd>
                                <dd class='img'>
                                    <a href="javascript:ChangeMenu(0);">
                                        <img vspace="3" src="skin/images/frame/arrfc.gif" border="0" width="12" height="12"
                                            alt="显示/隐藏左框架" title="显示/隐藏左框架" /></a></dd>
                                <dd class='img' style="margin-right: 10px;">
                                    <a href="javascript:ChangeMenu(1);">
                                        <img vspace="5" src="skin/images/frame/arrr.gif" border="0" width="5" height="8"
                                            alt="增大左框架" title="增大左框架" /></a></dd>
                                
                                <asp:Repeater ID="list" runat="server">
                                    <ItemTemplate>
                                        <dd>
                                            <div class='itemsel' id='item<%#Eval("id") %>' onmousemove="mv(this,'move',<%#Eval("id") %>);" onmouseout="mv(this,'o',<%#Eval("id") %>);">
                                                <a href="menu.aspx?id=<%#Eval("id") %>" onclick="changeSel(<%#Eval("id") %>)" target="menu"><%#Eval("MenuTitle")%></a>
                                            </div>
                                        </dd>
                                    </ItemTemplate>
                                </asp:Repeater>
<%--                                
                                <dd>
                                    <div class='item' id='item1' onmousemove="mv(this,'m',2);" onmouseout="mv(this,'o',2);">
                                        <a href="menu.html" onclick="changeSel(2)" target="menu">内容发布</a></div>
                                </dd>
                                <dd>
                                    <div class='item' id='item8' onmousemove="mv(this,'m',8);" onmouseout="mv(this,'o',8);">
                                        <a href="menu.html" onclick="changeSel(8)" target="menu">插件模块</a></div>
                                </dd>
                                <dd>
                                    <div class='item' id='item4' onmousemove="mv(this,'m',4);" onmouseout="mv(this,'o',4);">
                                        <a href="menu.html" onclick="changeSel(4)" target="menu">HTML更新</a></div>
                                </dd>
                                <dd>
                                    <div class='item' id='item5' onmousemove="mv(this,'m',5);" onmouseout="mv(this,'o',5);">
                                        <a href="menu.html" onclick="changeSel(5)" target="menu">系统设置</a></div>
                                </dd>
                                <dd>
                                    <div class='item' id='item9' onmousemove="mv(this,'m',9);" onmouseout="mv(this,'o',9);">
                                        <a href="main.html" onclick="changeSel(9)" target="main">后台主页</a></div>
                                </dd>--%>
                            </dl>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
