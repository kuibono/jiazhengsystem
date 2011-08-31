<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GropEdit.aspx.cs" Inherits="Jiazheng.Sys.GropEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>群组名称编辑</title>
    <link rel="stylesheet" type="text/css" href="../skin/css/base.css" />
    <link rel="stylesheet" type="text/css" href="../skin/css/main.css" />
    <script type="text/javascript" src="../skin/js/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="../skin/js/validate.js"></script>
    <script type="text/javascript">
        $(function() {
            $("#txt_Name").blur(function() { $(this).cannotnull() });
            $("#form1").checkForm();
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
<div class="tip">
    <img height="14" src="../skin/images/frame/book1.gif" width="20" />
    &nbsp;
    新增或设置群组名称
</div>
<table align="center" border="0" cellpadding="4" cellspacing="1" class="edittable" >
  <tr>
    <td colspan="2" class='editheader'><span>群组编辑</span></td>
  </tr>
  <tr class="itemrow">
    <td width="25%">群组名称：</td>
    <td width="75%"> 
        <asp:TextBox ID="txt_Name" runat="server" Width="200px"></asp:TextBox>
      </td>
  </tr>

    <tr class="itemrow">
    <td colspan="2">
        <asp:Button ID="btn_Save" runat="server" Text="保存" onclick="btn_Save_Click" />
        &nbsp;
        <asp:Button ID="btn_Return" runat="server" Text="返回" OnClientClick="location.href='GropList.aspx';return false;" />
     </td>
  </tr>

</table>
    </form>
</body>
</html>
