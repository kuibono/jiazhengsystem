<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaySalary.aspx.cs" Inherits="Jiazheng.Salary.PaySalary" %>
<%@ Import Namespace="Voodoo" %>
<%@ Register Assembly="Voodoo" Namespace="Voodoo.UI" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../skin/css/base.css" />

    <script type="text/javascript" src="../skin/js/jquery-1.3.2.min.js"></script>

    <script type="text/javascript" src="../skin/js/validate.js"></script>

    <script type="text/javascript" src="../skin/js/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript" src="../skin/js/common.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="tip">
        <img height="14" src="../skin/images/frame/book1.gif" width="20" />
        &nbsp; 任何不谨慎的操作将造成不可恢复的损失，请谨慎操作！
    </div>
    <table width='98%' border='0' cellpadding='1' cellspacing='1' bgcolor='#CBD8AC' align="center"
        style="margin-top: 8px">
        <tr bgcolor='#EEF4EA'>
            <td background='../skin/images/wbg.gif' align='center'>
                <table border='0' cellpadding='0' cellspacing='0'>
                    <tr>
                        <td>
                            月份：
                        </td>
                        <td style="width: 160px">
                            <asp:TextBox ID="txt_Month" runat="server" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM'})"></asp:TextBox>
                        </td>

                        <td style="width: 70px">
                            <asp:ImageButton ID="ImageButton1" ImageUrl="../skin/images/frame/search.gif" runat="server"
                                CssClass="np" OnClick="ImageButton1_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btn_Export" runat="server" Text="导出" OnClick="btn_Export_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table width="98%" border="0" cellpadding="2" cellspacing="1" align="center" class="list">
        <tr bgcolor="#EEF4EA" class="Title">
            <td height="24" colspan="11">
                &nbsp;宣传工资结算&nbsp;
            </td>
        </tr>
        <tr align="center" bgcolor="#FAFAF1" class="Header">
            <td>
                员工
            </td>
            <td>
                月份
            </td>
            <td>
                发卡数量
            </td>
            <td>
                查卡数量
            </td>
            <td>
                回收数量
            </td>
            <td>
                发卡提成
            </td>
            <td>
                查卡提成
            </td>
            <td>
                回收提成
            </td>
            <td>
                总额
            </td>
            <td>
                类型
            </td>
            <td>
                备注
            </td>
        </tr>
        <asp:Repeater ID="list" runat="server">
            <ItemTemplate>
                <tr align='center'>
                    <td>
                        <%#Eval("宣传员")%>
                    </td>
                    <td>
                        <%#Eval("日期")%>
                    </td>
                    <td>
                        <%#Eval("发卡")%>
                    </td>
                    <td>
                        <%#Eval("查卡")%>
                    </td>
                    <td>
                        <%#Eval("回收")%>
                    </td>
                    <td>
                        <%#Eval("发卡提成")%>
                    </td>
                    <td>
                        <%#Eval("查卡提成")%>
                    </td>
                    <td>
                        <%#Eval("回收提成")%>
                    </td>
                    <td>
                        <%#Eval("总计")%>
                    </td>
                    <td>
                        <%#Eval("类型")%>
                    </td>
                    <td>
                        <%#Eval("备注")%>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>

        <tr align="right" bgcolor="#EEF4EA">
            <td height="36" colspan="11" align="center">
                <!--翻页代码 -->
                <cc1:AspNetPager ID="pager" runat="server" PageSize="10" AlwaysShow="true" CustomInfoHTML="共%RecordCount%条记录，%CurrentPageIndex%/%PageCount%页"
                    FirstPageText="[首页]" LastPageText="[尾页]" NextPageText="[后页]" PrevPageText="[前页]"
                    ShowCustomInfoSection="Left" onpagechanged="pager_PageChanged" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
