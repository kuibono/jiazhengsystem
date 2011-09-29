<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZPayLogEdit.aspx.cs" Inherits="Jiazheng.PayLog.ZPayLogEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>新增支付记录</title>
    <link rel="stylesheet" type="text/css" href="../skin/css/base.css" />
    <link rel="stylesheet" type="text/css" href="../skin/css/main.css" />

    <script type="text/javascript" src="../skin/js/jquery-1.3.2.min.js"></script>

    <script type="text/javascript" src="../skin/js/validate.js"></script>

    <script type="text/javascript" src="../skin/js/My97DatePicker/WdatePicker.js"></script>

    <script type="text/javascript">
        $(function() {
            $("#txt_PayMoney").isDouble();
            $("#txt_PayHour").isInt();
            $("#txt_CardNo").cannotnull();
            $("#form1").checkForm();

        })
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div class="tip">
        <img height="14" src="../skin/images/frame/book1.gif" width="20" />
        &nbsp; 这里填写页面说明。。。。。。。。。。
    </div>
    <table align="center" border="0" cellpadding="4" cellspacing="1" class="edittable">
        <tr>
            <td colspan="2" class='editheader'>
                <span>支付记录编辑</span>
            </td>
        </tr>
        <tr class="itemrow">
            <td width="12%">
                客户:
            </td>
            <td width="88%">
                <asp:DropDownList ID="ddl_Cus" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr class="itemrow">
            <td width="12%">
                售卡人:
            </td>
            <td width="88%">
                <asp:DropDownList ID="ddl_Saler" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr class="itemrow">
            <td>
                卡号:
            </td>
            <td>
                <asp:TextBox ID="txt_CardNo" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr class="itemrow">
            <td>
                有效期:
            </td>
            <td>
                <asp:TextBox ID="txt_VTime" runat="server" onFocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
            </td>
        </tr>
        <tr class="itemrow">
            <td>
                支付金额:
            </td>
            <td>
                <asp:TextBox ID="txt_PayMoney" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr class="itemrow">
            <td>
                充值工时:
            </td>
            <td>
                <asp:TextBox ID="txt_PayHour" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr class="itemrow">
            <td colspan="2">
                <asp:Button ID="btn_Save" runat="server" Text="保存" OnClick="btn_Save_Click" />
                &nbsp;
                <asp:Button ID="btn_Return" runat="server" Text="返回" OnClientClick="location.href='ZPayLogList.aspx';return false;" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
