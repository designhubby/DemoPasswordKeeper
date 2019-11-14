<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsersToApps.aspx.cs" Inherits="DBWeb.UsersToApps" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <link rel="stylesheet" type ="text/css" href="StyleSheet1.css" />
    <title></title>
</head>
<body>
    <div id="mySidenav" class="sidenav">
      <a href="javascript:void(0)" class="closebtn" onclick="closeNav()">&times;</a>
      <a href="\UsersToApps.aspx">Users To Apps</a>
      <a href="\AppsToUsers.aspx">Apps To Users</a>
      <a href ="UserAdd.aspx">Add Users</a>
                <a href ="ApAdd.aspx">Add App or App Permissions</a>
        <a href ="EditUserPermissions.aspx">Edit Users and Permissions</a>

    </div>
    <span style="font-size:30px;cursor:pointer" onclick="openNav()">&#9776; open</span>
    <script>
function openNav() {
  document.getElementById("mySidenav").style.width = "250px";
}

function closeNav() {
  document.getElementById("mySidenav").style.width = "0";
}
</script>
    <form id="form1" runat="server">
        <div>
            Other Pages:&nbsp;
            <asp:HyperLink ID="HyperLink1" runat="server">Apps To Users</asp:HyperLink>
        </div>
        <asp:Menu ID="Menu1" runat="server">
        </asp:Menu>
        <h1>Users To Apps</h1>

        <asp:Label ID="lblSearchUser" runat="server" Text="Search User:"></asp:Label>
        <asp:TextBox ID="txtSearchString" runat="server"></asp:TextBox>
        <asp:DropDownList ID="ddlSearchUser" runat="server">
        </asp:DropDownList>
        <asp:Button ID="btnSearchUser" runat="server" Text="Search" />
        <br />
        <asp:GridView ID="gvUsers" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
        <br />
        <asp:GridView ID="gvAppsPermission" runat="server">
        </asp:GridView>

    </form>
</body>
</html>
