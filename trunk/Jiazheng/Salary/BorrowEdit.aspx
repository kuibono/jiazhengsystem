<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BorrowEdit.aspx.cs" Inherits="Jiazheng.Salary.BorrowEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>借款编辑</title>
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
        &nbsp; 这里填写页面说明。。。。。。。。。。
    </div>
    <table align="center" border="0" cellpadding="4" cellspacing="1" class="edittable">
        <tr>
            <td colspan="2" class='editheader'>
                <span>新增借款</span>
            </td>
        </tr>
                <tr class="itemrow">
            <td>
                员工类型:
            </td>
            <td>
                <asp:DropDownList ID="ddl_UserType" runat="server" 
                    onselectedindexchanged="ddl_UserType_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Text="宣传" Value="宣传"></asp:ListItem>
                    <asp:ListItem Text="保洁" Value="保洁"></asp:ListItem>
                    <asp:ListItem Text="办公室" Value="办公室"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>

        <tr class="itemrow">
            <td>
                员工:
            </td>
            <td>
                
                <asp:DropDownList ID="ddl_User" runat="server">
                
                </asp:DropDownList>
            </td>
        </tr>
        <tr class="itemrow">
            <td width="100">
                借款时间:
            </td>
            <td>
                <asp:TextBox ID="txt_BorrowTime" runat="server" onFocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
            </td>
        </tr>
        <tr class="itemrow">
            <td>
                借款金额:
            </td>
            <td>
                <asp:TextBox ID="txt_BorrowMoney" runat="server"></asp:TextBox>
            </td>
        </tr>

        
        <tr class="itemrow">
            <td colspan="2">
                <asp:Button ID="btn_Save" runat="server" Text="保存" OnClick="btn_Save_Click" />
                &nbsp;
                <asp:Button ID="btn_Return" runat="server" Text="返回" OnClientClick="location.href='ZBorrowSalaryList.aspx';return false;" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
