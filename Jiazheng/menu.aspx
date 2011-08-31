<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="menu.aspx.cs" Inherits="Jiazheng.menu" %>
<%@ Import Namespace="Voodoo" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>menu</title>
    <link rel="stylesheet" href="skin/css/base.css" type="text/css" />
    <link rel="stylesheet" href="skin/css/menu.css" type="text/css" />

    <script language='javascript'>        var curopenItem = '1';</script>

    <script language="javascript" type="text/javascript" src="skin/js/frame/menu.js"></script>

    <base target="main" />
</head>
<body target="main">
    <form id="form1" runat="server">
    <table width='99%' height="100%" border='0' cellspacing='0' cellpadding='0'>
        <tr>
            <td style='padding-left: 3px; padding-top: 8px' valign="top">
                <asp:Repeater ID="list" runat="server" onitemcreated="list_ItemCreated">
                    <ItemTemplate>
                        <!-- Item <%#Eval("key") %> Strat -->
                        <dl class='bitem'>
                            <dt onclick='showHide("items_<%#Eval("key") %>")'><b><%#Eval("key") %></b></dt>
                            <dd style='display: block' class='sitem' id='items_<%#Eval("key") %>'>
                                <ul class='sitemu'>
                                    <asp:Repeater ID="subList" runat="server">
                                        <ItemTemplate>
                                        <li><a href='<%#Eval("Url") %>' target='main'><%#Eval("MenuTitle") %></a></div> </li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                            </dd>
                        </dl>
                        <!-- Item <%#Eval("key") %> End -->
                    </ItemTemplate>
                </asp:Repeater>

            </td>
        </tr>
    </table>
    </form>
</body>
</html>
