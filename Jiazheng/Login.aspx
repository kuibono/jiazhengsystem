<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Jiazheng.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>系统登录</title>
    <style type="text/css">
        body
        {
            font-size: 14px;
        }
        input
        {
            border: 1px solid #BDC7D8;
        }
        table
        {
            width: 330px;
            border-collapse: collapse;
            background-color: #F0F5F8;
            border: 1px solid #B8D4E8;
            padding: 20px;
        }
        td
        {
            height: 35px;
        }
        .header
        {
            margin-left: 15px;
            font-size: 14px;
            font-weight: bold;
            height: 50px;
        }
        .align_right
        {
            text-align: right;
        }
        .btn
        {
            color: #fff;
            background-color: #005EAC;
            border-color: #B8D4E8 #124680 #124680 #B8D4E8;
        }
        a
        {
            font-size: 12pxx;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <br />
        <br />
        <br />
        <br />
        <br />
        <table border="0" align="center">
            <tr>
                <td colspan="2" class="header">
                    &nbsp;&nbsp;登录系统
                </td>
            </tr>
            <tr>
                <td class="align_right" style="width: 50px;">
                    账号：
                </td>
                <td>
                    <asp:TextBox ID="txt_UserName" runat="server" Width="225px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="align_right" style="width: 50px;">
                    密码：
                </td>
                <td>
                    <asp:TextBox ID="txt_Password" runat="server" Width="225px" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="align_right">
                    <asp:Button ID="btn_Login" runat="server" Text="登录" CssClass="btn" 
                        onclick="btn_Login_Click" />
                </td>
                <td style="width: 228px; text-align: right">
                    <a href="javascript:void(0)">重置密码</a>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
