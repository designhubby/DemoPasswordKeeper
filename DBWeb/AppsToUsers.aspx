<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AppsToUsers.aspx.cs" Inherits="DBWeb.AppsToUsers" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   

  

        <asp:Panel ID="pnAppSearch" runat="server" DefaultButton="btnAppSearch">
            <asp:Label ID="lblAppSearch" runat="server" Text="App Name"></asp:Label>
            <asp:TextBox ID="txtAppSearch" runat="server"></asp:TextBox>
            <asp:Button ID="btnAppSearch" runat="server" Text="Search" OnClick="btnAppSearch_Click" />
        </asp:Panel>
        
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

    
    </asp:Content>