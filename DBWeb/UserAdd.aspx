<%@ Page Language="C#"  MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="UserAdd.aspx.cs" Inherits="DBWeb.UserAdd" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
    </div>
        <asp:MultiView ID="mvUserData" runat="server">
            <asp:View ID="Search" runat="server">
                <asp:Panel ID="pnSearch" runat="server" DefaultButton="btnSearchSubmit">
                    <asp:Table ID="Table1" runat="server" Height="131px" Width="600px">
                    <asp:TableHeaderRow> 
                        <asp:TableCell ColumnSpan="2">Step 1: Search User</asp:TableCell>
                        
                    </asp:TableHeaderRow>
                    <asp:TableRow>
                        <asp:TableCell ColumnSpan="2">Type in a Search Term and select Filter Type</asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="Label1" runat="server" Text="Search Term"></asp:Label>
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
                </asp:Panel>
                
      
            </asp:View>
            <asp:View ID="Results" runat="server">
                <asp:Button ID="btnBackToStep1" runat="server" Text="Back" OnClick="btnBackToStep1_Click" />
                <asp:GridView ID="gvUsers" runat="server" CellPadding="4" ForeColor="#333333" GridLines="Both">
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
                <asp:Button ID="btnCreateNew" OnClick="btnCreateNew_Click" runat="server" Text="Create New" />

            </asp:View>
            <asp:View ID="Add_Edit_User" runat="server">
                <asp:Button ID="btnBackToStep2" runat="server" Text="Back" OnClick="btnBackToStep2_Click" />
                <asp:Table ID="tblAddEditUser" runat="server">
                    <asp:TableHeaderRow>
                        <asp:TableCell ColumnSpan="2">
                            Please Fill in the details below:
                        </asp:TableCell>
                    </asp:TableHeaderRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="lblAdUid" runat="server" Text="Active Directory ID"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="txtAdUid" runat="server"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="lblFname" runat="server" Text="First Name"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="txtfname" runat="server"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="lblLname" runat="server" Text="Last Name"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="txtLname" runat="server"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="lblDept" runat="server" Text="Department"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="txtDept" runat="server"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="lblRole" runat="server" Text="Role"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="txtRole" runat="server"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="lblActive" runat="server" Text="Active"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="txtActive" runat="server"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
            </asp:View>
            <asp:View ID="Save_Confirm" runat="server">
                <asp:Button ID="btnBackToStep3" runat="server" Text="Back" OnClick="btnBackToStep3_Click" />
                <asp:Button ID="btnRestart" runat="server" Text ="Home" OnClick="btnRestart_Click" />
                <asp:Table ID="tblSave_Confirm" runat="server">
                    <asp:TableHeaderRow>
                        <asp:TableCell>
                            <asp:Label ID="lblInfo" runat="server" Text="Saved Information"></asp:Label>
                           
                        </asp:TableCell>
                    </asp:TableHeaderRow>
                    
                    <asp:TableRow>
                        <asp:TableCell ColumnSpan ="2">
                            <asp:GridView ID="gvSaveResults" runat="server">
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
                </asp:Table>
            </asp:View>
        </asp:MultiView>

    </asp:Content>

