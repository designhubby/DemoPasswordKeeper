<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AppsToUsers.aspx.cs" Inherits="DBWeb.AppsToUsers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type ="text/css" href="StyleSheet1.css" />
    <title></title>
</head>
<body>
   
    <form id="form1" runat="server">
        <asp:Table ID="tblTitle" runat="server">
            <asp:TableHeaderRow>
               <asp:TableCell>
                   <asp:ImageButton ImageUrl="~/graphics/ocot logo.JPG" ID="ibTitleBanner" runat="server" PostBackUrl="~/Default.aspx" />
               </asp:TableCell>
            </asp:TableHeaderRow>
        </asp:Table>
  
        <div id="mySidenav" class="sidenav">
            <a href="javascript:void(0)" class="closebtn" onclick="closeNav()">&times;</a>
        
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
        <div>
        </div>

        <asp:Label ID="lblAppSearch" runat="server" Text="App Name"></asp:Label>
        <asp:TextBox ID="txtAppSearch" runat="server"></asp:TextBox>
        <asp:Button ID="btnAppSearch" runat="server" Text="Search" OnClick="btnAppSearch_Click" />
        <asp:GridView ID="gvAppList" runat="server" CellPadding="4" ForeColor="#333333" GridLines="Both">
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
        <asp:GridView ID="gvUserList" runat="server" CellPadding="4" ForeColor="#333333" GridLines="Both">
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

    </form>
</body>
</html>
