using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DBWeb
{

    public partial class UsersToApps : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillLstbxSearchType();
            }
            runEvents();
        }

        public static int webState = 0;

        protected void runEvents()
        {
            if (webState == 0)
            {
                WebShowUsers(null); // on first page load, show all users
            }
            else
            {
                DdlSearchUser();
                SearchUser();
                WebShowUsers(umem); //on subsequent page load, show filtered users
            }
            webState = 1;
        }

        protected void WebShowUsers(List<UserMembers> listofusers) //For plotting List of user info to GridView
        {
            ddlSearchUser.EnableViewState = true;
            ddlSearchUser.SelectedIndexChanged += DdlSearchUser_SelectedIndexChanged; // subscribe to DropDown Box Changes (Filter Type Options: by UID, Firstname, Lastname)
            btnSearchUser.Click += btnSearchUser_Click;// subscribe to Search button click Changes

            UserAccessLayer userAccessLayer = new UserAccessLayer();
            gvUsers.DataSource = (listofusers != null ? listofusers : userAccessLayer.getUsers());
            //gvUsers.DataSource = userAccessLayer.getUsers();
            gvUsers.AutoGenerateColumns = false;
            gvUsers.DataKeyNames = new string[] { "ad_uid" };
            //gvUsers.Columns.Clear(); //alt use to clear existing columns before generating gv
            if (gvUsers.Columns.Count == 0)
            {
                BoundField bfUserID = new BoundField();
                bfUserID.HeaderText = "User ID";
                bfUserID.DataField = "ad_uid";
                gvUsers.Columns.Add(bfUserID);
                CommandField cmdSelect = new CommandField();
                cmdSelect.HeaderText = "Choose";
                cmdSelect.ShowSelectButton = true;
                cmdSelect.Visible = true;
                gvUsers.Columns.Add(cmdSelect);
            }

            gvUsers.AllowPaging = true;
            gvUsers.PageSize = 4;
            gvUsers.EnableViewState = true;
            gvUsers.DataBind();



            gvUsers.SelectedIndexChanged += GvUsers_SelectedIndexChanged; //subscribe to Change in selected User in GridView 
            gvUsers.PageIndexChanging += new GridViewPageEventHandler(GvUsers_PageIndexChanging); //subscribe to page changes to change page

        }

        public int SearchTypeSet { set; get; } // field to store the selected filter type

        private void DdlSearchUser()
        {
            DropDownList ddlist = (DropDownList) ddlSearchUser;
            int ddlist_index = ddlist.SelectedIndex;
            SearchTypeSet = ddlist_index;
        }

        private void DdlSearchUser_SelectedIndexChanged(object sender, EventArgs e)
        {

            DropDownList ddlist = sender as DropDownList;
            int ddlist_index = ddlist.SelectedIndex;
            SearchTypeSet = ddlist_index;
            // Filter Options Index: 1 = AD | 2 = First Name | 3 = Last Name

        }

        //Below: Drill Down of User --> Shows Access Permission for Selected User
        protected void WebShowPermissions(string aduid)
        {

            UserAppPermission user_app_permission_class = new UserAppPermission();
            gvAppsPermission.DataSource = user_app_permission_class.GetUserAppPermission(aduid);
            gvAppsPermission.AutoGenerateColumns = true;
            gvAppsPermission.DataBind();


        }
        //Below: When User is selected, runs WebShowPermissions method on User
        private void GvUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView gv = sender as GridView;
            string aduid = gv.SelectedDataKey.Value.ToString();
            WebShowPermissions(aduid);
        }

        //Below: Paging method
        private void GvUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (sender != null)
            {
                GridView gvUsers = sender as GridView;
                gvUsers.PageIndex = e.NewPageIndex;

                gvUsers.DataBind();


            }
        }

        //Below: Method to fill listbox with Filter Options 
        protected void FillLstbxSearchType()
        {
            // Listbox: SearchType
            List<string> searchType = new List<string>();
            string[] stringSearchType = { "Active Directory UserID", "First Name", "Last Name" };
            searchType.AddRange(stringSearchType);
            foreach (var i in searchType)
            {
                ddlSearchUser.Items.Add(i);
            };



        }
        public static List<UserMembers> umem; //static List to store the list of users to be displayed in Gridview

        //Below: button to take Filter type and Search string as parameters for retrieving list from DB
        public void SearchUser()
        {
            string text_string = txtSearchString.Text.ToString();
            //string text_fnameuser = txtSearchUser_fname.Text.ToString();

            UserAccessLayer userAccessLayer = new UserAccessLayer();
            umem = userAccessLayer.getUsers(SearchTypeSet, text_string);
        }
        protected void btnSearchUser_Click(object sender, EventArgs e)
        {
            string text_string = txtSearchString.Text.ToString();
            //string text_fnameuser = txtSearchUser_fname.Text.ToString();

            UserAccessLayer userAccessLayer = new UserAccessLayer();
            umem = userAccessLayer.getUsers(SearchTypeSet, text_string);
            //WebShowUsers(userAccessLayer.getUsers(SearchTypeSet, text_string));

        }

    }
}