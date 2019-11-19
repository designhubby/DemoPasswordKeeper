<%@ Page Language="C#"  AutoEventWireup="true" CodeBehind="ApAdd.aspx.cs" Inherits="DBWeb.ApAdd" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type ="text/css" href="StyleSheet1.css" />
    <title>OCOT: Appi</title>
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
        <asp:MultiView ID="mvApAdd" runat="server">
            <asp:View ID="vwSearch_Ap" runat="server">
                
                <asp:Table ID="Table1" runat="server" Height="131px" Width="600px">
                    <asp:TableHeaderRow> 
                        <asp:TableCell ColumnSpan="2">Step 1: Search Application</asp:TableCell>
                        
                    </asp:TableHeaderRow>
                    <asp:TableRow>
                        <asp:TableCell ColumnSpan="2">Type in a Search Term and select Filter Type</asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="lblSearchTerm" runat="server" Text="Search Term"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="txtSearchTerm" runat="server"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="lblSearchType" runat="server" Text="Filter Type"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:DropDownList ID="ddlSearchType" runat="server"></asp:DropDownList>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell ColumnSpan="2">
                            <asp:Button ID="btnSearchSubmit" runat="server" OnClick="btnSearchSubmit_Click" Text ="Search"/>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
      
            </asp:View>
            <asp:View ID="vwSearchResultsAp" runat="server">
                <asp:Table ID="tblSearchResults" runat="server">
                    <asp:TableRow>
                        <asp:TableCell ColumnSpan="2">
                            <asp:GridView ID="gvSearchApResults" runat="server">
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
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Button ID="btnNewApp" runat="server" Text="New Application" OnClick="btnNewApp_Click" />
                        </asp:TableCell>
                        <asp:TableCell>

                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </asp:View>
            <asp:View ID="vwEditAp" runat="server">
                <asp:Table ID="tblEditApDetails" runat="server">
                    <asp:TableHeaderRow>
                        <asp:TableCell ColumnSpan ="2">
                            <asp:Label ID="lblEditApDetailTitle" runat="server" Text="Type in details of the Application"></asp:Label>

                        </asp:TableCell>
                    </asp:TableHeaderRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="lblApName" runat="server" Text="Application Name"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="txtApName" runat="server"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="lblApDetails" runat="server" Text="Application Details"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="txtApDetails" runat="server"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Button ID="btnAppSave" runat="server" OnClick="btnAppSave_Click" Text="Save Application Info" />
                        </asp:TableCell>
                    </asp:TableRow>

                </asp:Table>
                <asp:DetailsView ID="dvApplicationDetails" runat="server" >
                </asp:DetailsView>
            </asp:View>
            <asp:View ID="vwPermissionList" runat="server">
                <asp:Table ID="tblPermissionList" runat="server">
                    <asp:TableHeaderRow>
                        <asp:TableCell ColumnSpan="2">
                            <asp:Label ID="lblPermissionListHeader" runat="server" Text ="List of Permissions Associated with the Application"></asp:Label>
                        </asp:TableCell>
                    </asp:TableHeaderRow>
                        <asp:TableHeaderRow>
                        <asp:TableCell ColumnSpan="2">
                            
                        </asp:TableCell>
                    </asp:TableHeaderRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="lblPermissionListAppNameKey" runat="server" Text="Application  Name: "></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="lblPermissionListAppNameValue" runat="server"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                <asp:GridView ID="gvPermissionList" runat="server">
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
                <asp:GridView ID="gvConfirmResults" runat="server">
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
                <asp:Button ID="btnRestart" runat="server" Text ="Home" OnClick="btnRestart_Click" />
            </asp:View>
        </asp:MultiView>

  
        </form>
     </body> 
    </html>