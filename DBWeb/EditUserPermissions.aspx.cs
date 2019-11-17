using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DBWeb
{
    public partial class EditUserPermissions : System.Web.UI.Page
    {
        //Retrieve Factory : Controls
        IFillLstbxSearchType _fillLstbxSearchTypeUser = FactoryControlUsers.GetFillLstbxSearchTypeObj();
        IBuildGvTemplate _GvTemplateAccess = FactoryControlUsers.GetBuildGvTemplateObj();

        ISetupGridView _iSetupGridView = FactoryControlApp.SetupGridViewObj();



        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGvUsersTemplate(gvUsers);//setup gvUsers control with template
            LoadGvApPInitialConditions(gvPermissionList); //setup gvApP control with template
            LoadGvApPInitialConditions_WO_ApName(gvApP_Existing_Show);

            gvUsers.PageIndexChanging += GvUserList_PageIndexChanging;
            gvUsers.SelectedIndexChanged += GvUserList_SelectedIndexChanged;
            ddlApNames_P.SelectedIndexChanged += DdlApNames_P_SelectedIndexChanged;
            ddlApList.SelectedIndexChanged += DdlApList_SelectedIndexChanged;

            gvPermissionList.PageIndexChanging += GvPermissionList_PageIndexChanging;
            gvPermissionList.SelectedIndexChanged += GvPermissionList_SelectedIndexChanged;
            gvPermissionList.RowCommand += GvPermissionList_RowCommand;

            gvApP_Existing_Show.SelectedIndexChanged += GvApP_Existing_Show_SelectedIndexChanged;




            if (!IsPostBack)
            {
                mvUserData.ActiveViewIndex = 0;
                LoadFilterType(ddlSearchType);
                //LoadColumns;
                AddGvUserColumns(gvUsers);
                LoadGvApPAddColumnswithApName(gvPermissionList);
                LoadGvApPAddColumns_WO_ApName(gvApP_Existing_Show);

                //LoadData;
                
                LoadGvUserData(gvUsers);

                //DataBind
                gvUsers.DataBind();
            }
        }

        private void GvApP_Existing_Show_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Get Info:apP_ID
            GridView _gridView = (GridView)sender;
            GridViewRow _Selected_gridViewRow = _gridView.SelectedRow;
            int selected_row_index = _gridView.SelectedIndex;
            int apP_Id = Int32.Parse(_gridView.SelectedDataKey[0].ToString());
            string ad_uId = ViewState["ad_uid"].ToString();
            //Link apP_ID to User [ ViewState["ad_uid"]  ]
            UserAppPermission _userAppPermission = new UserAppPermission();
            _userAppPermission.SetUserAppPermission_input_ad_uid(apP_Id, ad_uId);
            mvUserData.ActiveViewIndex = 3;
            List<UserAppPermissionMember> _userApPMemTemp = new List<UserAppPermissionMember>();

            _userApPMemTemp = _userAppPermission.GetUserAppPermission(ad_uId);
            gvConfirmResults.DataSource = _userApPMemTemp;
            gvConfirmResults.DataBind();

            //Return to vwPermissionList to reflect newly linked permission
        }

        private void DdlApList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList DdlAp = (DropDownList)sender;
            //get Ap_ID
            int current_row_index = DdlAp.SelectedIndex; 
            int current_row_value = Int32.Parse(DdlAp.SelectedValue.ToString()); // = Ap_ID
            string current_row_text = DdlAp.SelectedItem.Text.ToString();
            // Query: All permissions(apP by apID) associated with that app
            List<AppPMember> _AppPMembers = new List<AppPMember>();
            AppsAccessLayer _AppsAccessLayer = new AppsAccessLayer();
            _AppPMembers = _AppsAccessLayer.GetAppPermissions(current_row_value);
            gvApP_Existing_Show.DataSource = _AppPMembers;
            gvApP_Existing_Show.DataBind();
                //varlist = GetApP(apID)
                //gvExistingApP.DataSource = varlist
                //gvExistingApP.Databind()
                            //Choose the permission record 
                                //Get Info:apID, apP_ID
                                //Link apP_ID to User [ ViewState["ad_uid"]  ]
                                //Return to vwPermissionList to reflect newly linked permission

        }

        private void GvPermissionList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridView gv_apP = (GridView)sender;
            string command_name = e.CommandName;
            string btn_name = "btnApP_Delete";
            if (command_name == btn_name)
            {
                int rowIndexCurrent = Convert.ToInt32(e.CommandArgument);
                //u id
                int rowDataKeyCurrent_UID = Int32.Parse(gv_apP.DataKeys[rowIndexCurrent].Values[2].ToString());
                //apP id
                int rowDataKeyCurrent_ApPID = Int32.Parse(gv_apP.DataKeys[rowIndexCurrent].Values[0].ToString());
                //delete apP association
                UserAppPermission uapp = new UserAppPermission();
                uapp.DelUserAppPermission(rowDataKeyCurrent_ApPID, rowDataKeyCurrent_UID);


                //update results
                UserAppPermission user_to_apP = new UserAppPermission();
                List<UserAppPermissionMember> temp_uaP = new List<UserAppPermissionMember>();
                string ad_uid = (string)ViewState["ad_uid"];
                temp_uaP = (List<UserAppPermissionMember>)user_to_apP.GetUserAppPermission(ad_uid);
                gvPermissionList.DataSource = temp_uaP;
                Session["temp_uaP"] = temp_uaP;
                gvPermissionList.DataBind();

                //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "UID: " + rowDataKeyCurrent_UID + "ApP_ID" + rowDataKeyCurrent_ApPID + "');", true);
            }
            else
            {

            }
        }

        private void DdlApNames_P_SelectedIndexChanged(object sender, EventArgs e)
        {
            //get UserID
            //datakey uid
            int datakey_current_row_uid = Int32.Parse(gvUsers.SelectedDataKey.Value.ToString());
            //get ApID
            DropDownList appddl = (DropDownList)sender;
            int current_row_index = appddl.SelectedIndex;
            int current_row_value = Int32.Parse(appddl.SelectedValue);

        }

        private void LoadGvUserData(GridView mygridview)
        {
          //retrieve database obj
            UserAccessLayer userdb = new UserAccessLayer();
            List<UserMembers> tempusermem = new List<UserMembers>();
            tempusermem  = userdb.getUsers();
            mygridview.DataSource = tempusermem;
            Session["ListofUserGvResults"] = tempusermem;


        }
        private void LoadGvUserData(GridView mygridview, int mysearchtype, string mysearchterm)
        {

            UserAccessLayer userdb = new UserAccessLayer();
            int searchType = mysearchtype;
            string searchTerm = mysearchterm; // will require entry validation function
            List<UserMembers> tempusermem = new List<UserMembers>();
            tempusermem = userdb.getUsers(searchType, searchTerm);
            mygridview.DataSource = tempusermem;
            Session["ListofUserGvResults"] = tempusermem;
            
        }



        // Index Changes and Page Changes// Index Changes and Page Changes// Index Changes and Page Changes// Index Changes and Page Changes// Index Changes and Page Changes// Index Changes and Page Changes
            //User Gv Index Change
        private void GvUserList_SelectedIndexChanged(object sender, EventArgs e)
        {
            mvUserData.ActiveViewIndex = 1;
            //plotting the selected user info to MV_2 for editing 
            GridView tempgv = (GridView)sender;
            GridViewRow row = tempgv.SelectedRow;
            //datakey uid
            int datakey_current_row_uid = Int32.Parse(tempgv.SelectedDataKey.Value.ToString());
            //Show Gridview of all permissions linked to selected UID
            string ad_uid = row.Cells[1].Text.ToString();
            string fname = row.Cells[2].Text.ToString();
            string lname = row.Cells[3].Text.ToString();
            txtPermissionListUserNameValue.Text = ad_uid;
            ViewState["ad_uid"] = ad_uid;
            txtFirstName.Text = fname;
            txtLastName.Text = lname;
            //Retrieve Permission DB obj
            UserAppPermission user_to_apP = new UserAppPermission();
            List<UserAppPermissionMember> temp_uaP = new List<UserAppPermissionMember>();
            temp_uaP  = (List<UserAppPermissionMember>) user_to_apP.GetUserAppPermission(ad_uid);
            gvPermissionList.DataSource = temp_uaP;
            Session["temp_uaP"] = temp_uaP;
            gvPermissionList.DataBind();


        }
        //User Gv Page Change
        private void GvUserList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView gvlist = (GridView)sender;
            gvlist.PageIndex = e.NewPageIndex;
            gvlist.DataSource = (List<UserMembers>) Session["ListofUserGvResults"];
            //Execute Search Function, Display to GridView:

            gvlist.DataBind();

        }

        //Permission Gv Index Change for Editing Permission
        private void GvPermissionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            //Input: ApID // ApPID // UID
            //Output: ApID // ApPID // UID
            //Display ApN // CloudID/PWD // PermN // Admin
            //Buttons: Save -Goto Confirm Page

            GridView mygvApP = (GridView)sender;
            int rowIndexCurrent = mygvApP.SelectedRow.RowIndex;
            GridViewRow gvrApP_Current = mygvApP.SelectedRow;
            int rowDataKeyCurrent_UID   = Int32.Parse(mygvApP.DataKeys[rowIndexCurrent].Values[2].ToString());
            int rowDataKeyCurrent_ApID  = Int32.Parse(mygvApP.DataKeys[rowIndexCurrent].Values[1].ToString());
            int rowDataKeyCurrent_ApPID = Int32.Parse(mygvApP.DataKeys[rowIndexCurrent].Values[0].ToString());
            txtApName_P.Text        = gvrApP_Current.Cells[1].Text.ToString();
            txtCloudUid.Text        = gvrApP_Current.Cells[2].Text.ToString();
            txtCloudPwd.Text        = gvrApP_Current.Cells[3].Text.ToString();
            txtPermissionNotes.Text = gvrApP_Current.Cells[4].Text.ToString();
            txtIsAdmin.Text         = gvrApP_Current.Cells[5].Text.ToString();

            //set ViewState Switch to isNewPerm = false
            ViewState["isNewPerm"] = false;

            mvUserData.ActiveViewIndex = 2;

        }
        //Permission Gv Page Change
        private void GvPermissionList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            throw new NotImplementedException();
        }

        //buttons //buttons //buttons //buttons //buttons //buttons //buttons //buttons //buttons //buttons //buttons 
            //User Search Submit Button
        protected void btnUserSearchSubmit_Click(object sender, EventArgs e)
        {

            int searchType = ddlSearchType.SelectedIndex;
            string searchTerm = txtSearchString.Text.ToString(); // will require entry validation function

            //Execute Search Function, Display to GridView:
            LoadGvUserData(gvUsers, searchType, searchTerm);
            gvUsers.DataBind();
        }

        //Load Application Names to DropDownBox:Application List:Permission Edit Page
        private void LoadDDB_ApList(DropDownList myddl)
        {
            AppsAccessLayer aalDB = new AppsAccessLayer();
            myddl.DataSource = aalDB.GetAppMembers("");
            myddl.DataValueField = "app_id";
            myddl.DataTextField = "name";
            myddl.DataBind();

            //foreach (var appMem in appList)
            //{
            //    ddlApNames_P.Items.Add(appMem.name);
            //    ddlApNames_P.
            //}
        }

        //Button Permission New
        protected void btnNewPermission_Click(object sender, EventArgs e)
        {
            //Set ViewState switch Is New Permission to True
            ViewState["isNewPerm"] = true;

            mvUserData.ActiveViewIndex = 2;
            //Make Textbox txtApName_P hidden
            txtApName_P.Visible = false;
            //load list of apps into ddlApNames_p
            LoadDDB_ApList(ddlApNames_P);



        }

        //Button Permission Save
        protected void btnSavePermission_Click(object sender, EventArgs e)
        {
            bool isNewPermission = Boolean.Parse(ViewState["isNewPerm"].ToString());
            AppsAccessLayer aalDB = new AppsAccessLayer();

            //Common variables between if statements
            int common_u_id = 0;
            int common_apP_id = 0;


            //Collect Textbox info
            string ap_name = txtApName_P.Text;
            string cloud_id = txtCloudUid.Text;
            string cloud_pwd = txtCloudPwd.Text;
            string perm_notes = txtPermissionNotes.Text;
            int isAdmin = Int32.Parse(txtIsAdmin.Text.ToString());


            if (isNewPermission)
            {
                //get UserID
                //datakey uid
                int datakey_current_row_uid = Int32.Parse(gvUsers.SelectedDataKey.Value.ToString());

                common_u_id = datakey_current_row_uid;

                //get ApID
                DropDownList appddl = (DropDownList)ddlApNames_P;
                int current_row_index = appddl.SelectedIndex;
                int current_row_value = Int32.Parse(appddl.SelectedValue); //Contains ApID
                

                //Set Existing User with new ApP
                UserAppPermission uapP_DB = new UserAppPermission();
                int newapP_ID = uapP_DB.SetUserAppPermission(current_row_value, datakey_current_row_uid, cloud_id, cloud_pwd, perm_notes, isAdmin);
                common_apP_id = newapP_ID;
            }
            else
            {
                //Collect ID info to mem
                GridView mygvApP = (GridView)gvPermissionList;
                int rowIndexCurrent = mygvApP.SelectedRow.RowIndex;
                GridViewRow gvrApP_Current = mygvApP.SelectedRow;
                int rowDataKeyCurrent_UID = Int32.Parse(mygvApP.DataKeys[rowIndexCurrent].Values[2].ToString());
                common_u_id= rowDataKeyCurrent_UID;
                int rowDataKeyCurrent_ApID = Int32.Parse(mygvApP.DataKeys[rowIndexCurrent].Values[1].ToString());
                
                //Collect apPID
                int rowDataKeyCurrent_ApPID = Int32.Parse(mygvApP.DataKeys[rowIndexCurrent].Values[0].ToString());
                common_apP_id = rowDataKeyCurrent_ApPID;
                //Set Existing ApP

                aalDB.SetApP(rowDataKeyCurrent_ApPID, rowDataKeyCurrent_ApID, cloud_id, cloud_pwd, perm_notes, isAdmin);

            }

            //show results on next page (save page)
            UserAppPermission apPDB = new UserAppPermission();
            gvConfirmResults.DataSource= apPDB.GetUserAppPermissionSpecific(common_u_id, common_apP_id);
            gvConfirmResults.DataBind();
            mvUserData.ActiveViewIndex = 3;
        }
        protected void btnSelectPermission_Click(object sender, EventArgs e)
        {
            //Load Application list into ddl
            LoadDDB_ApList(ddlApList);
            //switch to mv 4
            mvUserData.ActiveViewIndex = 4;
            //ddl:
            //add trigger for ddl
            //Select App Then
            //Query: All permissions (apP by apID) associated with that app
            //Choose the permission record 
            //Get Info:apID, apP_ID
            //Link apP_ID to User
            //Return to vwPermissionList to reflect newly linked permission



        }

        protected void btnRestart_Click(object sender, EventArgs e)
        {
            mvUserData.ActiveViewIndex = 0;
        }

        //Load Template Methods //Load Template Methods //Load Template Methods //Load Template Methods //Load Template Methods 

        private void LoadGvUsersTemplate(GridView mygridv)
        {
            _GvTemplateAccess.GetGvTemplateUser(mygridv);
        }

        private void AddGvUserColumns(GridView mygv)
        {
            _GvTemplateAccess.AddUserColumns(mygv);
        }


        private void LoadFilterType(DropDownList myddlst)
        {
            _fillLstbxSearchTypeUser.GetFillLstBxSearchTypeUser(myddlst);
        }

        private void LoadGvApPInitialConditions(GridView mygv)
        {
            _iSetupGridView.LoadGridViewInitialConditionsApPwithApName(mygv);
        }
        private void LoadGvApPInitialConditions_WO_ApName(GridView mygv)
        {
            _iSetupGridView.LoadGridViewInitialConditionsApP(mygv);
        }

        private void LoadGvApPAddColumnswithApName(GridView mygv)
        {
            _iSetupGridView.LoadGridViewColumnsApPwithApName(mygv);
        }
        private void LoadGvApPAddColumns_WO_ApName(GridView mygv)
        {
            _iSetupGridView.LoadGridViewColumnsApP(mygv);
        }


    }
}