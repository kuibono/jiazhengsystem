<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HandBillEdit.aspx.cs" Inherits="Jiazheng.HandBill.HandBillEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
        &nbsp; 宣传记录的增加和修改
    </div>
    <table align="center" border="0" cellpadding="4" cellspacing="1" class="edittable">
        <tr>
            <td colspan="2" class='editheader'>
                <span>宣传记录</span>
            </td>
        </tr>
        <tr class="itemrow">
            <td width="100">
                宣传人:
            </td>
            <td>
                <asp:DropDownList ID="ddl_User" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
 
        <tr class="itemrow">
            <td>
                派发数量:
            </td>
            <td>
                <asp:TextBox ID="txt_DiliverCount" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr class="itemrow">
            <td>
                查卡数量:
            </td>
            <td>
                <asp:TextBox ID="txt_ViewCount" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr class="itemrow">
            <td>
                回收数量:
            </td>
            <td>
                <asp:TextBox ID="txt_BackCount" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr class="itemrow">
            <td>
                日期:
            </td>
            <td>
                <asp:TextBox ID="txt_WorkTime" runat="server" onFocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
            </td>
        </tr>
        <tr class="itemrow">
            <td colspan="2">
                <asp:Button ID="btn_Save" runat="server" Text="保存" OnClick="btn_Save_Click" />
                &nbsp;
                <asp:Button ID="btn_Return" runat="server" Text="返回" OnClientClick="location.href='HandBillList.aspx';return false;" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
