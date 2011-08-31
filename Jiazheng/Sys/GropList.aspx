<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GropList.aspx.cs" Inherits="Jiazheng.Sys.GropList" %>
<%@ Import Namespace="Voodoo" %>
<%@ Register assembly="Voodoo" namespace="Voodoo.UI" tagprefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>群组管理</title>
    <link rel="stylesheet" type="text/css" href="../skin/css/base.css">
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
    &nbsp;
    任何不谨慎的操作将造成不可恢复的损失，请谨慎操作！
</div>
<table width="98%" border="0" cellpadding="2" cellspacing="1"  align="center" class="list">

<tr bgcolor="#E7E7E7" class="Title">

	<td height="24" colspan="5">&nbsp;群组列表&nbsp;</td>

</tr>

<tr align="center" bgcolor="#FAFAF1" class="Header">

	<td width="4%">选择</td>

	<td width="28%">群组名称</td>

	<td width="18%">操作</td>

</tr>

<asp:Repeater ID="list" runat="server">
    <ItemTemplate>

<tr align='center'>

	<td><input name="ids" type="checkbox" id="ids" value="<%#Eval("Id") %>" class="np"></td>

	<td><%#Eval("Name") %></td>


	<td>
	    <a href="RoleEdit.aspx?groupid=<%#Eval("id")%>">编辑权限</a> | 
	    <%if (SysPartRole.AllowEdit==true){ %>
	    <a href="GropEdit.aspx?id=<%#Eval("id")%>">编辑</a> | 
	    <%} %>
	    <%if (SysPartRole.AllowDelete==true){ %>
	    <a onclick="return confirm('删除群组后，组内的用户将全部不能访问页面，确定要删除吗？')" href="?action=delete&id=<%#Eval("id")%>">删除</a>
	    <%} %>
	</td>

</tr>
    
    </ItemTemplate>
</asp:Repeater>




<tr bgcolor="#FAFAF1">

<td height="28" colspan="5">

	&nbsp;
	
	<input id="Button1" type="button" value="新增" onclick="location.href='GropEdit.aspx'"  class="coolbg" />
	
    <input id="Button2" type="button" value="全选" onclick="selAll()"  class="coolbg" />
    
    <input id="Button3" type="button" value="反选" onclick="noSelAll()" class="coolbg"  />
    
    <asp:Button ID="btn_Del" runat="server" Text="删除"  CssClass="coolbg" onclick="btn_Del_Click"/>

</td>

</tr>

<tr align="right" bgcolor="#EEF4EA">

	<td height="36" colspan="5" align="center"><!--翻页代码 -->
        <cc1:AspNetPager ID="pager" runat="server" PageSize="10" AlwaysShow="true" 
            CustomInfoHTML="共%RecordCount%条记录，%CurrentPageIndex%/%PageCount%页" 
            FirstPageText="[首页]" LastPageText="[尾页]" NextPageText="[后页]" PrevPageText="[前页]" 
            ShowCustomInfoSection="Left" onpagechanged="pager_PageChanged"/>
    </td>

</tr>






</table>
    </form>
</body>
</html>
