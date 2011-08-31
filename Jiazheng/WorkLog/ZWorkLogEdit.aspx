<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZWorkLogEdit.aspx.cs" Inherits="Jiazheng.WorkLog.ZWorkLogEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>工作记录增加</title>
    <link rel="stylesheet" type="text/css" href="../skin/css/base.css" />
    <link rel="stylesheet" type="text/css" href="../skin/css/main.css" />

    <script type="text/javascript" src="../skin/js/jquery-1.3.2.min.js"></script>

    <script type="text/javascript" src="../skin/js/jquery.autocomplete.js"></script>

    <script type="text/javascript" src="../skin/js/validate.js"></script>

    <script type="text/javascript" src="../skin/js/My97DatePicker/WdatePicker.js"></script>

    <script type="text/javascript">
        $(function() {
            //$("#txt_Name").blur(function() { $(this).cannotnull() });
            $("#txt_CustomerName").cannotnull();
            $("#txt_Tel").isTel();
            $("#txt_MobilePhone").isMobile();
            $("#txt_WorkHour").isInt();
            $("#txt_PayMoney").isDouble();
            $("#form1").checkForm();

            $("#txt_HomeName").suggestTable("ZCustomer", "HomeName");

        })
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div class="tip">
        <img height="14" src="../skin/images/frame/book1.gif" width="20" />
        &nbsp; 曾经受过本司服务的客户请直接选择。 表单中的各内容请仔细填写！
    </div>
    <table align="center" border="0" cellpadding="4" cellspacing="1" class="edittable">
        <tr>
            <td colspan="2" class='editheader'>
                <span>服务编辑</span>
            </td>
        </tr>
        <tr class="itemrow">
            <td width="12%">
                老客户:
            </td>
            <td width="88%">
                <%--<asp:TextBox ID="txt_CustomerId" runat="server"></asp:TextBox>--%>
                <asp:DropDownList ID="ddl_CustomerId" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_CustomerId_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr class="itemrow">
            <td>
                客户姓名:
            </td>
            <td>
                <asp:TextBox ID="txt_CustomerName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr class="itemrow">
            <td>
                性别:
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
                电话:
            </td>
            <td>
                <asp:TextBox ID="txt_Tel" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr class="itemrow">
            <td>
                手机:
            </td>
            <td>
                <asp:TextBox ID="txt_MobilePhone" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr class="itemrow">
            <td>
                服务时间:
            </td>
            <td>
                <asp:TextBox ID="txt_WorkTime" runat="server" onFocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"></asp:TextBox>
            </td>
        </tr>
        <tr class="itemrow">
            <td>
                工作内容:
            </td>
            <td>
                <asp:TextBox ID="txt_WorkContent" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr class="itemrow">
            <td>
                小区名称:
            </td>
            <td>
                <asp:TextBox ID="txt_HomeName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr class="itemrow">
            <td>
                地址:
            </td>
            <td>
                <asp:TextBox ID="txt_Address" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr class="itemrow">
            <td>
                工时:
            </td>
            <td>
                <asp:TextBox ID="txt_WorkHour" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr class="itemrow">
            <td>
                服务员工:
            </td>
            <td>
                <asp:CheckBoxList ID="cbl_EmployeesNames" runat="server" RepeatColumns="4" RepeatDirection="Horizontal"
                    RepeatLayout="Flow">
                </asp:CheckBoxList>
                <table border="1" style="border:solid 1px gray;">
                    <tr>
                        <td>保洁员工</td>
                        <td>提成工资</td>
                    </tr>
                    <asp:Repeater ID="list" runat="server">
                        <ItemTemplate>
                        <tr>
                            <td>
                                <input class="user" type="checkbox" name="users" id="em_<%#Eval("id") %>" value="<%#Eval("id") %>" /><label for="em_<%#Eval("id") %>"><%#Eval("UserName") %></label>
                            </td>
                            <td>
                                <input class="salary" type="text" name="salary" ID="salary_<%#Eval("id") %>" value="" />
                            </td>
                        </tr>
                        </ItemTemplate>
                        
                    </asp:Repeater>
                </table>
            </td>
        </tr>
        <tr class="itemrow">
            <td>
                所带工具:
            </td>
            <td>
                <asp:CheckBoxList ID="cbl_ToolIds" runat="server" RepeatColumns="4" RepeatDirection="Horizontal"
                    RepeatLayout="Flow">
                </asp:CheckBoxList>
            </td>
        </tr>
        <tr class="itemrow">
            <td>
                佣金:
            </td>
            <td>
                <asp:TextBox ID="txt_PayMoney" runat="server" Text="0"></asp:TextBox>
            </td>
        </tr>
        <tr class="itemrow">
            <td>
                已经删除:
            </td>
            <td>
                <asp:CheckBox ID="cb_IsDelete" runat="server" />
            </td>
        </tr>
        <tr class="itemrow">
            <td>
                已经完工:
            </td>
            <td>
                <asp:CheckBox ID="cb_IsFinished" runat="server" />
            </td>
        </tr>
        <tr class="itemrow">
            <td>
                客户评分:
            </td>
            <td>
                <asp:TextBox ID="txt_Customerappraise" runat="server" Text="0"></asp:TextBox>
            </td>
        </tr>
        <tr class="itemrow">
            <td>
                备注:
            </td>
            <td>
                <asp:TextBox ID="txt_Remark" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr class="itemrow">
            <td colspan="2">
                <asp:Button ID="btn_Save" runat="server" Text="保存" OnClick="btn_Save_Click" />
                &nbsp;
                <asp:Button ID="btn_Return" runat="server" Text="返回" OnClientClick="location.href='ZWorkLogList.aspx';return false;" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
