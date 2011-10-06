<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CardConsumeList.aspx.cs" Inherits="Jiazheng.Card.CardConsumeList" %>
<%@ Import Namespace="Voodoo" %>
<%@ Register Assembly="Voodoo" Namespace="Voodoo.UI" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>减工时明细</title>
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
                        卡号：
                    </td>
                    <td style="width: 160px">
                        <asp:TextBox ID="txt_CardNo" runat="server"></asp:TextBox>
                    </td>

                    <td>
                        <asp:ImageButton ID="btn_Search" ImageUrl="../skin/images/frame/search.gif" runat="server"
                            CssClass="np" OnClick="btn_Search_Click" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<table width="98%" border="0" cellpadding="2" cellspacing="1" align="center" class="list">
    <tr bgcolor="#EEF4EA" class="Title">
        <td height="24" colspan="3">
            &nbsp;减工时明细&nbsp;
        </td>
    </tr>
<tr align="center" bgcolor="#FAFAF1" class="Header">

    <td width="18%">
	    卡号
	</td>

    <td width="18%">
	    消耗工时
	</td>

    <td width="18%">
	    消耗时间
	</td>
<tr>

<asp:Repeater ID="list" runat="server">
	<ItemTemplate>
	<tr>
		<td align="center">
			<%# Eval("CardNo")%>
		</td>
		
		
		<td align="center">
			<%# Eval("ConsumeHour")%>
		</td>
		
		
		<td align="center">
			<%# Eval("ConsumeTime")%>
		</td>
		
	</tr>
	</ItemTemplate>
</asp:Repeater>


<tr>
	<td colspan="3" align="center">
		<cc1:AspNetPager ID="pager" runat="server" PageSize="10" AlwaysShow="true" CustomInfoHTML="共%RecordCount%条记录，%CurrentPageIndex%/%PageCount%页"
            FirstPageText="[首页]" LastPageText="[尾页]" NextPageText="[后页]" PrevPageText="[前页]"
            ShowCustomInfoSection="Left" onpagechanged="pager_PageChanged" />
	</td>
</tr>
</table>
    </form>
</body>
</html>
