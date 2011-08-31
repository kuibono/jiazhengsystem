<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleEdit.aspx.cs" Inherits="Jiazheng.Sys.RoleEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>权限管理</title>
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

	<td height="24" colspan="6">&nbsp;群组列表&nbsp;</td>

</tr>

<tr align="center" bgcolor="#FAFAF1" class="Header">

	<td width="14%">角色</td>

	<td width="18%">模块</td>

	<td width="18%">允许访问</td>
	<td width="18%">允许删除</td>
	<td width="18%">允许修改</td>
	<td width="18%">允许新增</td>

</tr>

<asp:Repeater ID="list" runat="server">
    <ItemTemplate>

<tr align='center'>
	<td>
	    <%#Eval("GroupName")%>
	</td>
	<td>
	    <%#Eval("SyspartName")%>
	</td>
	<td>
        <asp:CheckBox ID="chk_View" runat="server" />
	</td>
	<td>
	    <asp:CheckBox ID="chk_Del" runat="server" />
	</td>
	<td>
	    <asp:CheckBox ID="chk_Edit" runat="server" />
	</td>
	<td>
	    <asp:CheckBox ID="chk_Add" runat="server" />
	</td>
</tr>
    
    </ItemTemplate>
</asp:Repeater>




<tr bgcolor="#FAFAF1">

<td height="28" colspan="6">

	&nbsp;
	
    <asp:Button ID="btn_Save" runat="server" Text="保存" onclick="btn_Save_Click" />
    

</td>

</tr>







</table>
    </form>
</body>
</html>
