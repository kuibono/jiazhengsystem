<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="Jiazheng.User.UserList" %>

<%@ Import Namespace="Voodoo" %>
<%@ Register Assembly="Voodoo" Namespace="Voodoo.UI" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户管理</title>
    <link rel="stylesheet" type="text/css" href="../skin/css/base.css" />

    <script type="text/javascript" src="../skin/js/jquery-1.3.2.min.js"></script>

    <script type="text/javascript" src="../skin/js/common.js"></script>

    <script type="text/javascript">
        $(function() {
            $("#btn_Del").click(function() {
                if ($(".list input:checked").size() == 0) {
                    alert("您没有选中任何项，将不执行任何操作！");
                    return false;
                }

                return confirm("模块数据删除后不可恢复，并且将造成所删模块不能访问的问题，是否继续操作？");
            })
        })
    </script>

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
                            帐号：
                        </td>
                        <td style="width: 160px">
                            <asp:TextBox ID="txt_Name" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            性别：
                        </td>
                        <td style="width: 160px">
                            <asp:RadioButtonList ID="rbl_Sex" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Text="不限" Value="" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="男" Value="男"></asp:ListItem>
                                <asp:ListItem Text="女" Value="女"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td>
                            群组：
                        </td>
                        <td>
                            <asp:DropDownList ID="ddl_Group" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            状态：
                        </td>
                        <td style="width: 160px">
                            <asp:RadioButtonList ID="rbl_Status" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Text="不限" Value="" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="正常" Value="正常"></asp:ListItem>
                                <asp:ListItem Text="锁定" Value="锁定"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td>
                            生日：
                        </td>
                        <td style="width: 160px">
                            <asp:TextBox ID="txt_Birth" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            
                        </td>
                        <td>
                            <asp:ImageButton ID="ImageButton1" ImageUrl="../skin/images/frame/search.gif" runat="server"
                                CssClass="np" OnClick="ImageButton1_Click" />
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
            <td width="4%">
                选择
            </td>
            <td width="18%">
                帐号
            </td>
            <td width="18%">
                性别
            </td>
            <td width="18%">
                状态
            </td>
            <td width="18%">
                群组
            </td>
            <td width="18%">
                生日
            </td>
            <td width="18%">
                操作
            </td>
        </tr>
        <asp:Repeater ID="list" runat="server">
            <ItemTemplate>
                <tr align='center'>
                    <td>
                        <input name="ids" type="checkbox" id="ids" value="<%#Eval("Id") %>" class="np">
                    </td>
                    <td>
                        <%#Eval("UserName")%>
                    </td>
                    <td>
                        <%#Eval("Sex")%>
                    </td>
                    <td>
                        <%#Eval("Status")%>
                    </td>
                    <td>
                        <%#Eval("GroupName")%>
                    </td>
                    <td>
                        <%#Eval("Birthday")%>
                    </td>
                    <td>
                        <%if (SysPartRole.AllowEdit == true)
                          { %>
                        <a href="UserEdit.aspx?id=<%#Eval("id")%>">编辑</a> |
                        <%} %>
                        <%if (SysPartRole.AllowDelete == true)
                          { %>
                        <a onclick="return confirm('删除群组后，组内的用户将全部不能访问页面，确定要删除吗？')" href="?action=delete&id=<%#Eval("id")%>">
                            删除</a>
                        <%} %>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <tr bgcolor="#FAFAF1">
            <td height="28" colspan="7">
                &nbsp;
                <input id="Button1" type="button" value="新增" onclick="location.href='UserEdit.aspx'"
                    class="coolbg" />
                <input id="Button2" type="button" value="全选" onclick="selAll()" class="coolbg" />
                <input id="Button3" type="button" value="反选" onclick="noSelAll()" class="coolbg" />
                <asp:Button ID="btn_Del" runat="server" Text="删除" CssClass="coolbg" OnClick="btn_Del_Click" />
            </td>
        </tr>
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
