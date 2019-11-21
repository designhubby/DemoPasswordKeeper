using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DBWeb
{
    public partial class UserAdd : System.Web.UI.Page
    {
        //Retrieve Factory : Controls
        IFillLstbxSearchType _fillLstbxSearchTypeUser = FactoryControlUsers.GetFillLstbxSearchTypeObj();
        IBuildGvTemplate _GvTemplateAccess = FactoryControlUsers.GetBuildGvTemplateObj();


        protected void Page_Load(object sender, EventArgs e)
        {
            
            LoadGvUsersTemplate(gvUsers);//setup gvUsers control with template

            gvUsers.PageIndexChanging += GvUserList_PageIndexChanged; //typo here?
            gvUsers.SelectedIndexChanged += GvUserList_SelectedIndexChanged;
            if (!IsPostBack)
            {
                mvUserData.ActiveViewIndex = 0;
                LoadFilterType(ddlSearchType);
                //LoadColumns;
                AddGvUserColumns(gvUsers);

                //LoadData;
                LoadGvUserData(gvUsers);

                //DataBind
                gvUsers.DataBind();
            }

        }

        private void LoadGvUserData(GridView mygridview)
        {
            
            int searchType = ddlSearchType.SelectedIndex;
            string searchTerm = txtSearchTerm.Text.ToString(); // will require entry validation function
            
            //retrieve database obj
            UserAccessLayer userdb = new UserAccessLayer();
            mygridview.DataSource = userdb.getUsers(searchType, searchTerm);
        }

        //load gvUser based on SearchType(AD_UID) and given search term
        private void LoadGvUserData(GridView mygridview, string mysearchterm)
        {
            UserAccessLayer userdb = new UserAccessLayer();
            int searchType = 0;
            string searchTerm = mysearchterm; // will require entry validation function
            mygridview.DataSource = userdb.getUsers(searchType, searchTerm);
        }


        private void AddGvUserColumns(GridView mygv)
        {
            _GvTemplateAccess.AddUserColumns(mygv);
        }

        private void LoadGvUsersTemplate(GridView mygridv)
        {
            _GvTemplateAccess.GetGvTemplateUser(mygridv);
        }

        private void LoadFilterType(DropDownList myddlst)
        {
            _fillLstbxSearchTypeUser.GetFillLstBxSearchTypeUser(myddlst);
        }

        private void GvUserList_SelectedIndexChanged(object sender, EventArgs e)
        {
            mvUserData.ActiveViewIndex = 2;
            //plotting the selected user info to MV_2 for editing 
            GridView tempgv = (GridView)sender;
            GridViewRow row = tempgv.SelectedRow;
            //txtAdUid.Text = tempgv.SelectedDataKey.Value.ToString();
            txtAdUid.Text = row.Cells[1].Text;
            txtfname.Text = row.Cells[2].Text;
            txtLname.Text = row.Cells[3].Text;
            txtDept.Text = row.Cells[4].Text;
            txtRole.Text = row.Cells[5].Text;
            txtActive.Text = row.Cells[6].Text;
            isNewRecord = false;
        }

        private void GvUserList_PageIndexChanged(object sender, GridViewPageEventArgs e)
        {
            GridView tempgv = (GridView)sender;
            tempgv.PageIndex = e.NewPageIndex;
            LoadGvUserData(tempgv);
            tempgv.DataBind();
        }

        protected void btnSearchSubmit_Click(object sender, EventArgs e)
        {
            mvUserData.ActiveViewIndex = 1;
            //LoadData;
            LoadGvUserData(gvUsers);

            //DataBind
            gvUsers.DataBind();
        }

        //private bool isNewRecord;
        public bool isNewRecord
        {
            get
            {
                return (bool)ViewState["vs_isNewRecord"];
            }
            set
            {
                ViewState["vs_isNewRecord"] = value;
            }
        }

        protected void btnCreateNew_Click(object sender, EventArgs e)
        {
            mvUserData.ActiveViewIndex = 2;
            txtAdUid.Text = null;
            txtfname.Text = null;
            txtLname.Text = null;
            txtDept.Text  = null;
            txtRole.Text  = null;
            txtActive.Text = null;
            isNewRecord = true;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //function to save / update record
            
            mvUserData.ActiveViewIndex = 3;
            
            //int myuid = Int32.Parse(gvUsers.SelectedDataKey.Value.ToString()); //need null case?
            string myAdUid = txtAdUid.Text.ToString(); //add function: check unique 
            string myFname = txtfname.Text.ToString();
            string myLname = txtLname.Text.ToString();
            string myDept = txtDept.Text.ToString();
            string myRole = txtRole.Text.ToString();
            int myActive = (txtActive.Text.ToString() != null ? Int32.Parse(txtActive.Text.ToString()) : 3);

            //txtInfo.Text = myDept;
            //txtInfo2.Text = myRole;

            UserAccessLayer dbuser = new UserAccessLayer();
            if(isNewRecord)
            {
                //when no datakey exists then it must be new record, so Insert Record
                dbuser.SetUserNew(myAdUid, myFname, myLname, myDept, myRole, myActive);
            }
            else
            {
                //when datakey exists then it must be existing record, so Update Record
                int myuid = Int32.Parse(gvUsers.SelectedDataKey.Value.ToString());
                dbuser.SetUser(myuid, myAdUid, myFname, myLname, myDept, myRole, myActive);
            }
            
            LoadGvUserData(gvSaveResults, myAdUid);
            gvSaveResults.DataBind();
            isNewRecord = false;
        }

        protected void btnBackToStep1_Click(object sender, EventArgs e)
        {
            mvUserData.ActiveViewIndex = 0;
        }

        protected void btnBackToStep2_Click(object sender, EventArgs e)
        {
            mvUserData.ActiveViewIndex = 1;
        }

        protected void btnBackToStep3_Click(object sender, EventArgs e)
        {
            mvUserData.ActiveViewIndex = 2;
        }
        protected void btnRestart_Click(object sender, EventArgs e)
        {
            mvUserData.ActiveViewIndex = 0;
        }
    }


}