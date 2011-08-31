<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerEdit.aspx.cs" Inherits="Jiazheng.Customer.CustomerEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../skin/css/base.css" />
    <link rel="stylesheet" type="text/css" href="../skin/css/main.css" />

    <script type="text/javascript" src="../skin/js/jquery-1.3.2.min.js"></script>

    <script type="text/javascript" src="../skin/js/validate.js"></script>

    <script type="text/javascript" src="../skin/js/My97DatePicker/WdatePicker.js"></script>

    <script type="text/javascript">
        $(function() {
            $("#txt_UserName").cannotnull();

            $("#txt_Tel").isTel();
            $("#txt_MobilePhone").isMobile();

            
            $("#form1").checkForm();
            $("#txt_Birthday").focus(function() { WdatePicker(); })
        })
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div class="tip">
        <img height="14" src="../skin/images/frame/book1.gif" width="20" />
        &nbsp; 编辑、新增客户信息
    </div>
    <table align="center" border="0" cellpadding="4" cellspacing="1" class="edittable">
        <tr>
            <td colspan="2" class='editheader'>
                <span>客户编辑</span>
            </td>
        </tr>
        
        <tr class="itemrow">
            <td width="12%">
                姓名：
            </td>
            <td width="88%">
                <asp:TextBox ID="txt_UserName" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr class="itemrow">
            <td>
                性别：
            </td>
            <td>
                <asp:RadioButtonList ID="rbl_Sex" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Text="男" Value="男"></asp:ListItem>
                    <asp:ListItem Text="女" Value="女"></asp:ListItem>
                    <asp:ListItem Text="保密" Value="保密"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>

        <tr class="itemrow">
            <td>
                电话：
            </td>
            <td>
                <asp:TextBox ID="txt_Tel" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr class="itemrow">
            <td>
                手机：
            </td>
            <td>
                <asp:TextBox ID="txt_MobilePhone" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr class="itemrow">
            <td>
                小区名称：
            </td>
            <td>
                <asp:TextBox ID="txt_HomeName" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr class="itemrow">
            <td>
                家庭地址：
            </td>
            <td>
                <asp:TextBox ID="txt_Address" runat="server" Width="200px" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr class="itemrow">
            <td>
                身份证号：
            </td>
            <td>
                <asp:TextBox ID="txt_IDCard" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr class="itemrow">
            <td>
                会员卡号：
            </td>
            <td>
                <asp:TextBox ID="txt_CardNo" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr class="itemrow">
            <td>
                已用工时：
            </td>
            <td>
                <asp:TextBox ID="txt_UsedHour" runat="server">0</asp:TextBox>
            </td>
        </tr>
        <tr class="itemrow">
            <td>
                剩余工时：
            </td>
            <td>
                <asp:TextBox ID="txt_LeftHour" runat="server">0</asp:TextBox>
            </td>
        </tr>
        <tr class="itemrow">
            <td>
                注册用户：
            </td>
            <td>
                <asp:Checkbox ID="cb_IsReg" runat="server" />
            </td>
        </tr>
        <tr class="itemrow">
            <td colspan="2">
                <asp:Button ID="btn_Save" runat="server" Text="保存" OnClick="btn_Save_Click" />
                &nbsp;
                <asp:Button ID="btn_Return" runat="server" Text="返回" OnClientClick="location.href='CustomerList.aspx';return false;" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
