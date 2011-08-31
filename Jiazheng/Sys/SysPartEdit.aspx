<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SysPartEdit.aspx.cs" Inherits="Jiazheng.Sys.SysPartEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>模块编辑</title>
    <link rel="stylesheet" type="text/css" href="../skin/css/base.css" />
    <link rel="stylesheet" type="text/css" href="../skin/css/main.css" />

    <script type="text/javascript" src="../skin/js/jquery-1.3.2.min.js"></script>

    <script type="text/javascript" src="../skin/js/validate.js"></script>

    <script type="text/javascript">
        $(function() {
            $("#txt_PartName").blur(function() { $(this).cannotnull() });
            $("#txt_Url").blur(function() { $(this).cannotnull() });
            $("#form1").checkForm();
        })
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div class="tip">
        <img height="14" src="../skin/images/frame/book1.gif" width="20" />
        &nbsp; 任何不谨慎的操作将造成不可恢复的损失，请谨慎操作！
    </div>
    <table align="center" border="0" cellpadding="4" cellspacing="1" class="edittable">
        <tr>
            <td colspan="2" class='editheader'>
                <span>系统基本信息</span>
            </td>
        </tr>
        <tr class="itemrow">
            <td width="25%">
                模块名称：
            </td>
            <td width="75%">
                <asp:TextBox ID="txt_PartName" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr class="itemrow">
            <td>
                分组：
            </td>
            <td>
                <asp:TextBox ID="txt_Group" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr class="itemrow">
            <td>
                父菜单：
            </td>
            <td>
                <asp:DropDownList ID="ddl_Parent" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr class="itemrow">
            <td>
                地址：
            </td>
            <td>
                <asp:TextBox ID="txt_Url" runat="server" Width="200px" Visible="False"></asp:TextBox>
                <asp:DropDownList ID="DropDownList1" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr class="itemrow">
            <td>
                在菜单中显示：
            </td>
            <td>
                <asp:CheckBox ID="cb_Display" runat="server" />
            </td>
        </tr>
        <tr class="itemrow">
            <td colspan="2">
                <asp:Button ID="btn_Save" runat="server" Text="保存" OnClick="btn_Save_Click" />
                &nbsp;
                <asp:Button ID="btn_Return" runat="server" Text="返回" OnClientClick="location.href='SysPartList.aspx';return false;" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
