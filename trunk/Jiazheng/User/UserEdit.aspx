<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserEdit.aspx.cs" Inherits="Jiazheng.User.UserEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户信息编辑</title>
    <link rel="stylesheet" type="text/css" href="../skin/css/base.css" />
    <link rel="stylesheet" type="text/css" href="../skin/css/main.css" />

    <script type="text/javascript" src="../skin/js/jquery-1.3.2.min.js"></script>

    <script type="text/javascript" src="../skin/js/common.js"></script>

    <script type="text/javascript" src="../skin/js/validate.js"></script>

    <script type="text/javascript" src="../skin/js/My97DatePicker/WdatePicker.js"></script>

    <script type="text/javascript">
        $(function() {
        $("#txt_UserName").exist("User", "UserName");
            $("#form1").checkForm();
            $("#txt_Birthday").click(function() {
                WdatePicker();
            })

        })
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div class="tip">
        <img height="14" src="../skin/images/frame/book1.gif" width="20" />
        &nbsp; 编辑、新增用过户信息
    </div>
    <table align="center" border="0" cellpadding="4" cellspacing="1" class="edittable">
        <tr>
            <td colspan="2" class='editheader'>
                <span>用户编辑</span>
            </td>
        </tr>
        <tr class="itemrow">
            <td width="25%">
                帐号：
            </td>
            <td width="75%">
                <asp:TextBox ID="txt_UserName" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr class="itemrow">
            <td width="25%">
                密码：
            </td>
            <td width="75%">
                <asp:TextBox ID="txt_Pass" runat="server" Width="200px" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr class="itemrow">
            <td width="25%">
                性别：
            </td>
            <td width="75%">
                <asp:RadioButtonList ID="rbl_Sex" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Text="男" Value="男"></asp:ListItem>
                    <asp:ListItem Text="女" Value="女"></asp:ListItem>
                    <asp:ListItem Text="保密" Value="保密"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr class="itemrow">
            <td width="25%">
                生日：
            </td>
            <td width="75%">
                <asp:TextBox ID="txt_Birthday" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr class="itemrow">
            <td width="25%">
                底薪：
            </td>
            <td width="75%">
                <asp:TextBox ID="txt_Salary" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr class="itemrow">
            <td width="25%">
                用户状态：：
            </td>
            <td width="75%">
                <asp:RadioButtonList ID="rbl_Status" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Text="正常" Value="正常"></asp:ListItem>
                    <asp:ListItem Text="锁定" Value="锁定"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr class="itemrow">
            <td width="25%">
                群组：
            </td>
            <td width="75%">
                <asp:DropDownList ID="ddl_Group" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr class="itemrow">
            <td colspan="2">
                <asp:Button ID="btn_Save" runat="server" Text="保存" OnClick="btn_Save_Click" />
                &nbsp;
                <asp:Button ID="btn_Return" runat="server" Text="返回" OnClientClick="location.href='UserList.aspx';return false;" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
