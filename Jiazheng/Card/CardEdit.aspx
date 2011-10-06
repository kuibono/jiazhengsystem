<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CardEdit.aspx.cs" Inherits="Jiazheng.Card.CardEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>家政卡编辑</title>
    <link rel="stylesheet" type="text/css" href="../skin/css/base.css" />
    <link rel="stylesheet" type="text/css" href="../skin/css/main.css" />

    <script type="text/javascript" src="../skin/js/jquery-1.3.2.min.js"></script>

    <script type="text/javascript" src="../skin/js/validate.js"></script>
    <script type="text/javascript" src="../skin/js/My97DatePicker/WdatePicker.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div class="tip">
        <img height="14" src="../skin/images/frame/book1.gif" width="20" />
        &nbsp; 增加、修改家政卡
    </div>
    <table align="center" border="0" cellpadding="4" cellspacing="1" class="edittable">
        <tr>
            <td colspan="2" class='editheader'>
                <span>家政卡编辑</span>
            </td>
        </tr>
        <tr class="itemrow">
            <td>
                卡号:
            </td>
            <td>
                <asp:TextBox ID="txt_CardNumber" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr class="itemrow">
            <td>
                总工时:
            </td>
            <td>
                <asp:TextBox ID="txt_HourSum" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr class="itemrow">
            <td>
                剩余工时:
            </td>
            <td>
                <asp:TextBox ID="txt_HourLeft" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr class="itemrow">
            <td>
                过期时间:
            </td>
            <td>
                <asp:TextBox ID="txt_VTime" runat="server" onFocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
            </td>
        </tr>
        <tr class="itemrow">
            <td>
                状态:
            </td>
            <td>
             <%--   <asp:TextBox ID="txt_Status" runat="server"></asp:TextBox>--%>
                <asp:DropDownList ID="ddl_Status" runat="server">
                    <asp:ListItem Text="未开通" Value="未开通"></asp:ListItem>
                    <asp:ListItem Text="已开通" Value="已开通"></asp:ListItem>
                    <asp:ListItem Text="已停用" Value="已停用"></asp:ListItem>
                    <asp:ListItem Text="已过期" Value="已过期"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr class="itemrow">
            <td colspan="2">
                <asp:Button ID="btn_Save" runat="server" Text="保存" OnClick="btn_Save_Click" />
                &nbsp;
                <asp:Button ID="btn_Return" runat="server" Text="返回" OnClientClick="location.href='CardList.aspx';return false;" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
