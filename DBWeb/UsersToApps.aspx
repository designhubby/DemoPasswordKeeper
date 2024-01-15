<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsersToApps.aspx.cs" Inherits="DBWeb.UsersToApps" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

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

    </asp:Content>
