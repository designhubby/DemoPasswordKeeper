using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DBWeb
{
    public partial class AppsToUsers : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {


        }

        protected void Page_Init(object sender, EventArgs e)
        {



        }

        protected void Page_PreLoad(object sender, EventArgs e)
        {

        }

        private void GvAppList_PageIndexChanged(object sender, GridViewPageEventArgs e)
        {
            GridView gval = (GridView)sender;
            gval.PageIndex = e.NewPageIndex;
            LoadGvShowApps("");
            gval.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            BuildGridTemplate();
            

        }

        private void BuildGridTemplate()
        {
            if (!IsPostBack)
            {
                LoadGvShowApps("");
                BuildGridViewTemplateUsers();


            }
            gvAppList.AutoGenerateColumns = false;
            gvAppList.AllowPaging = true;
            gvAppList.PageIndexChanging += GvAppList_PageIndexChanged;
            gvAppList.SelectedIndexChanged += GvAppList_SelectedIndexChanged;
            gvAppList.PageSize = 10;
            CommandField cmdAppSelect = new CommandField();
            BoundField appname = new BoundField();
            BoundField appdetails = new BoundField();
            cmdAppSelect.HeaderText = "Choose";
            cmdAppSelect.ShowSelectButton = true;
            cmdAppSelect.Visible = true;
            appname.HeaderText = "App Name";
            appname.DataField = "name";
            appdetails.HeaderText = "App Details";
            appdetails.DataField = "details";
            if (!IsPostBack)
            {
                gvAppList.Columns.Add(cmdAppSelect);
                gvAppList.Columns.Add(appname);
                gvAppList.Columns.Add(appdetails);
                gvAppList.DataBind();
            }
            
        }

        protected void BuildGridViewTemplateUsers()
        {
            gvUserList.AutoGenerateColumns = false;
            gvUserList.AllowPaging = true;
            gvUserList.PageSize = 10;
            gvUserList.PageIndexChanging += GvUserList_PageIndexChanging;

            BoundField bfUid = new BoundField();
            BoundField bfFname = new BoundField();
            BoundField bfLname = new BoundField();
            BoundField bfDepartment = new BoundField();
            BoundField bfRole = new BoundField();
            BoundField bfActive = new BoundField();
            bfUid.HeaderText = "Active Directory UID";
            bfUid.DataField = "ad_uid";
            bfFname.HeaderText = "First Name";
            bfFname.DataField = "fname";
            bfLname.HeaderText = "Last Name";
            bfLname.DataField = "lname";
            bfRole.HeaderText = "Role";
            bfRole.DataField = "Role";
            bfActive.HeaderText = "Is Employee Active?";
            bfActive.DataField = "active";

            gvUserList.Columns.Add(bfUid);
            gvUserList.Columns.Add(bfFname);
            gvUserList.Columns.Add(bfLname);
            gvUserList.Columns.Add(bfRole);
            gvUserList.Columns.Add(bfActive);


        }

        private void GvUserList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void GvAppList_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView gv = (GridView)sender;
            int appid = Int32.Parse(gv.SelectedDataKey.Value.ToString());
            LoadGvShowUsers(appid);

        }

        protected void btnAppSearch_Click(object sender, EventArgs e)
        {
            
            LoadGvShowApps(txtAppSearch.Text);
            gvAppList.DataBind();
        }

        private void LoadGvShowUsers(int appid)
        {
            AppsToUsersAccessLayer appdb = new AppsToUsersAccessLayer();
            gvUserList.DataSource = appdb.getUsers(3, appid);
            gvUserList.DataBind();

        }

        private void LoadGvShowApps(string appSearchName)
        {
            AppsAccessLayer appdb = new AppsAccessLayer();

            gvAppList.DataSource = appdb.GetAppMembers(appSearchName);
            gvAppList.DataKeyNames = new string[] { "app_id" };
        }
    }
}