﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditUserPermissions.aspx.cs" Inherits="DBWeb.EditUserPermissions" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
      <form id="form1" runat="server">
    <asp:MultiView ID="mvUserData" runat="server">
        <asp:View ID="vwUserSearch" runat="server">
            <asp:Table ID="tblUserSearch" runat="server">
                <asp:TableHeaderRow>
                    <asp:TableCell ColumnSpan ="3">
                        <asp:Label ID="lblSearchUser_Title" runat="server" Text ="Type in your search term"></asp:Label>
                    </asp:TableCell>
                </asp:TableHeaderRow>
                <asp:TableRow>
                
                    <asp:TableCell>
                        <asp:Label ID="lblSearchUser" runat="server" Text="Search User:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtSearchString" runat="server"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList ID="ddlSearchType" runat="server"></asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="3" HorizontalAlign="Right">
                        <asp:Button ID="btnUserSearchSubmit" runat="server" Text="Search" OnClick="btnUserSearchSubmit_Click" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>

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

        </asp:View>
        <asp:View ID="vwPermissionList" runat="server">
                <asp:Table ID="tblPermissionList" runat="server">
                    <asp:TableHeaderRow>
                        <asp:TableCell ColumnSpan="2">
                            <asp:Label ID="lblPermissionListHeader" runat="server" Text ="List of Permissions Associated with the User"></asp:Label>
                        </asp:TableCell>
                    </asp:TableHeaderRow>
                        <asp:TableHeaderRow>
                        <asp:TableCell ColumnSpan="2">
                            
                        </asp:TableCell>
                    </asp:TableHeaderRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="lblPermissionListUserNameKey" runat="server" Text="User  Name: "></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="txtPermissionListUserNameValue" ReadOnly="true" runat="server" Text=""></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="lblFirstName" runat="server" Text="First Name: "></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="txtFirstName" ReadOnly="true" runat="server" Text=""></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="lblLastName" runat="server" Text="Last Name: "></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="txtLastName" ReadOnly="true" runat="server" Text=""></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                <asp:GridView ID="gvPermissionList" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
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
                <div></div>
                <asp:Button ID="btnNewPermission" runat="server" OnClick="btnNewPermission_Click" Text="New Permission" />
        </asp:View>
        <asp:View ID="vwEditApP" runat="server">
                <asp:Table ID="tblEditApP" runat="server">
                    <asp:TableHeaderRow>
                        <asp:TableCell ColumnSpan="2">
                            <asp:Label ID="lblEditApP_Title" runat="server" Text="Edit Application Permission Details"></asp:Label>
                        </asp:TableCell>
                    </asp:TableHeaderRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="lblApName_P" runat="server" Text="Application Name"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="txtApName_P" ReadOnly="true" runat="server"></asp:TextBox>
                            <asp:DropDownList ID="ddlApNames_P" runat="server"></asp:DropDownList>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="lblCloudUid" runat="server" Text="Log In ID"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="txtCloudUid" runat="server"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="lblCloudPwd" runat="server" Text="Log In Password"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="txtCloudPwd" runat="server"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="lblPermissionNotes" runat="server" Text="Permission Notes"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="txtPermissionNotes" runat="server"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="lblIsAdmin" runat="server" Text="Administrator Access"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="txtIsAdmin" runat="server"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>

                </asp:Table>
                <asp:Button ID="btnSavePermission" runat="server" OnClick="btnSavePermission_Click" Text="Save" />
            </asp:View>
             <asp:View ID="vwConfirm_Save" runat="server">
                <asp:GridView ID="gvConfirmResults" runat="server"></asp:GridView>
                <asp:Button ID="btnRestart" runat="server" Text ="Home" OnClick="btnRestart_Click" />
            </asp:View>
           

    </asp:MultiView>
        </form>
</body>
</html>
