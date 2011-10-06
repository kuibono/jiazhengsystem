<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeesEdit.aspx.cs"
    Inherits="Jiazheng.Employees.EmployeesEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>员工编辑</title>
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
            $("#txt_SalaryDegree").isDouble();

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
        &nbsp; 编辑、新增员工信息
    </div>
    <table align="center" border="0" cellpadding="4" cellspacing="1" class="edittable">
        <tr>
            <td colspan="2" class='editheader'>
                <span>员工编辑</span>
            </td>
        </tr>
        <tr class="itemrow">
            <td width="12%">
                员工类型：
            </td>
            <td width="88%">
                <asp:RadioButtonList ID="rbl_UserType" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Text="保洁" Value="保洁" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="宣传" Value="宣传"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr class="itemrow">
            <td width="12%">
                姓名：
            </td>
            <td width="88%">
                <asp:TextBox ID="txt_UserName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr class="itemrow">
            <td>
                工号：
            </td>
            <td>
                <asp:TextBox ID="txt_UserNo" runat="server" Width="200px"></asp:TextBox>
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
                生日：
            </td>
            <td>
                <asp:TextBox ID="txt_Birthday" runat="server" Width="180px" ></asp:TextBox>
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
                地址：
            </td>
            <td>
                <asp:TextBox ID="txt_Address" runat="server" Width="200px" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr class="itemrow">
            <td>
                入司时间：
            </td>
            <td>
                <asp:TextBox ID="txt_JoinTime" runat="server" Width="180px" onfocus="WdatePicker()"></asp:TextBox>
            </td>
        </tr>
        <tr class="itemrow">
            <td>
                可完成工作：
            </td>
            <td>
                &nbsp;<asp:CheckBoxList ID="cbl_Workable" runat="server"></asp:CheckBoxList>
            </td>
        </tr>
        <tr class="itemrow">
            <td>
                工资级别：
            </td>
            <td>
                <asp:TextBox ID="txt_SalaryDegree" runat="server"></asp:TextBox>元/小时
            </td>
        </tr>
        <tr class="itemrow">
            <td>
                现在在司：
            </td>
            <td>
                <asp:CheckBox ID="cb_IsFree" runat="server" />
            </td>
        </tr>
        <tr class="itemrow">
            <td>
                备注：
            </td>
            <td>
                <asp:TextBox ID="txt_Remark" runat="server" Width="200px" TextMode="MultiLine" Rows="4"></asp:TextBox>
            </td>
        </tr>
        <tr class="itemrow">
            <td colspan="2">
                <asp:Button ID="btn_Save" runat="server" Text="保存" OnClick="btn_Save_Click" />
                &nbsp;
                <asp:Button ID="btn_Return" runat="server" Text="返回" OnClientClick="location.href='EmployeesList.aspx';return false;" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
