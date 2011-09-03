<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SystemSetting.aspx.cs" Inherits="Jiazheng.Sys.SystemSetting" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>系统设置</title>
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
    系统信息设置，请慎重填写
</div>
<table align="center" border="0" cellpadding="4" cellspacing="1" class="edittable" >
  <tr>
    <td colspan="2" class='editheader'><span>系统信息</span></td>
  </tr>
<%--  <tr class="itemrow">
    <td width="25%">系统名称：</td>
    <td width="75%"> 
        <asp:TextBox ID="txt_SysTitle" runat="server" Width="200px"></asp:TextBox>
      </td>
  </tr>--%>
  <tr class="itemrow">
    <td width="25%">版权信息：</td>
    <td width="75%"> 
        <asp:TextBox ID="txt_Copyright" runat="server" Width="200px"></asp:TextBox>
      </td>
  </tr>
  <tr class="itemrow">
    <td width="25%">宣传提成百分比：</td>
    <td width="75%"> 
        <asp:TextBox ID="txt_SalerSalaryPercent" runat="server" Width="50px"></asp:TextBox>%
      </td>
  </tr>      <tr class="itemrow">
    <td colspan="2">
        <asp:Button ID="btn_Save" runat="server" Text="保存" onclick="btn_Save_Click" />
     </td>
  </tr>

</table>
    </form>
</body>
</html>
