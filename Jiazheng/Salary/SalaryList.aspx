<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SalaryList.aspx.cs" Inherits="Jiazheng.Salary.SalaryList" %>
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
            <td height="24" colspan="7">
                &nbsp;用户列表&nbsp;
            </td>
        </tr>
        <tr align="center" bgcolor="#FAFAF1" class="Header">
            <td width="18%">
                员工
            </td>
            <td width="18%">
                月份
            </td>
            <td width="18%">
                提成
            </td>
            <td width="18%">
                借款
            </td>
            <td width="18%">
                最终工资
            </td>
        </tr>
        <asp:Repeater ID="list" runat="server">
            <ItemTemplate>
                <tr align='center'>
                    <td>
                        <%#Eval("UserName")%>
                    </td>
                    <td>
                        <%#Eval("月份")%>
                    </td>
                    <td>
                        <%#Eval("提成")%>
                    </td>
                    <td>
                        <%#Eval("借款")%>
                    </td>
                    <td>
                        <%#Eval("应发")%>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>

        <tr align="right" bgcolor="#EEF4EA">
            <td height="36" colspan="7" align="center">
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
