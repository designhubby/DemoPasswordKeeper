<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DBWeb._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <header runat="server">

    </header>
<asp:Image ID="logoImage" runat="server" ImageUrl="~/graphics/lock.svg" Width="200" Height="100" CssClass="clickable-image" />
    <asp:Label Text="Password Keeper" runat="server" Font-Size="24pt" />
    
</asp:Content>
