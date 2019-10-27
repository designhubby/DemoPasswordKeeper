using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DBWeb
{
    public partial class ApAdd : System.Web.UI.Page
    {
        //Retrieve Factory : Controls
        ISetupDropDownList _ISetupDropDownList = FactoryControlApp.SetupDropDownListObj();
        ISetupGridView _ISetupGridView = FactoryControlApp.SetupGridViewObj();



        protected void Page_Load(object sender, EventArgs e)
        {
            //gvSearchApResults.SelectedIndexChanged += GvSearchApResults_SelectedIndexChanged;
            gvSearchApResults.RowCommand += GvSearchApResults_RowCommand;
            gvPermissionList.SelectedIndexChanged += GvPermissionList_SelectedIndexChanged;
            dvApplicationDetails.ModeChanging += DvApplicationDetails_ModeChanging;
            dvApplicationDetails.ItemUpdating += DvApplicationDetails_ItemUpdating;
            //load initial conditions: Ap
            LoadApInitialConditions(gvSearchApResults);

            //load initial conditions: ApP
            LoadApPIntitialConditions(gvPermissionList);

            //load initial conditions: ApDv

            
            

            if (!IsPostBack)
            {
                mvApAdd.ActiveViewIndex = 0;
                //load Filter Type
                LoadFilterTypeAp(ddlSearchType);

                //load columns: Ap
                LoadApColumns(gvSearchApResults);


                //load columns: ApP
                LoadApPColumns(gvPermissionList);




            }
        }

        //Button: Permission Row Selected Actions
        private void GvPermissionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView gvApP = (GridView)sender;

            //copy over Application Name to vwPermissionList
            string appName = ViewState["apName"].ToString();
            txtApName_P.Text = appName;
            ViewState["apName"] = null; //clear ViewState store

            //Get DatakeyIDs (Ap ID and ApP ID)
            int currentRowIndex = gvApP.SelectedRow.RowIndex;
            int datakeyApPId = Int32.Parse(gvApP.DataKeys[currentRowIndex].Values[0].ToString());
            int datakeyApId = Int32.Parse(gvApP.DataKeys[currentRowIndex].Values[1].ToString());
            ViewState["datakeyApPId"] = datakeyApPId;
            ViewState["datakeyApId"] = datakeyApId;

            //Get CurrentRow
            GridViewRow currentRow = gvApP.Rows[currentRowIndex];



            //Load GridView Row into TextBox
            txtCloudUid.Text = currentRow.Cells[1].Text;
            txtCloudPwd.Text = currentRow.Cells[2].Text;
            txtPermissionNotes.Text = currentRow.Cells[3].Text;
            txtIsAdmin.Text = currentRow.Cells[4].Text;

            //Switch MultView to vwEditApP
            mvApAdd.ActiveViewIndex = 4;
        }

        //DetailsView Change Mode to Edit [Control No Longer Used]
        private void DvApplicationDetails_ModeChanging(object sender, DetailsViewModeEventArgs e)
        {
            DetailsView appDv = (DetailsView)sender;
            appDv.ChangeMode(e.NewMode);
            if(e.NewMode != DetailsViewMode.Insert)
            {
                AppsAccessLayer db = new AppsAccessLayer();
                appDv.DataSource = db.GetAppMembers((int)ViewState["datakeyApID"]);
                appDv.DataBind();

            }
        }

        //DetailsView Update Application Record [Control No Longer Used]
        private void DvApplicationDetails_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            DetailsView dvAp = (DetailsView)sender;
            int txtap_id = Int32.Parse(dvAp.DataKey.Value.ToString());
            
            string txtAppName = ((TextBox)dvAp.Rows[0].Cells[1].Controls[0]).Text;
            string txtAppDetails = ((TextBox)dvAp.Rows[1].Cells[1].Controls[0]).Text;
            AppsAccessLayer db = new AppsAccessLayer();
            db.SetAp(txtap_id, txtAppName, txtAppDetails);
            //switch back to view mode
        }

        //GridView Edit Application OR Edit Application Permissions Buttons
        private void GvSearchApResults_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "cmdEditApP") //Button: Edit Permission
            {
                mvApAdd.ActiveViewIndex = 3;
                GridView gvtemp = (GridView)sender;
                int currentRow = Convert.ToInt32(e.CommandArgument);
                int datakeyApID = Int32.Parse(gvtemp.DataKeys[0].Value.ToString());
                AppsAccessLayer db = new AppsAccessLayer();
                gvPermissionList.DataSource = db.GetAppPermissions(datakeyApID);
                gvPermissionList.DataBind();
                GridViewRow selectedRow = gvSearchApResults.Rows[currentRow];
                //Below: Show Ap Name on Next Page
                string apName = selectedRow.Cells[2].Text;
                lblPermissionListAppNameValue.Text = apName;
                ViewState["apName"] = apName;
                ViewState["apPId"] = datakeyApID;
                ViewState["NewPermission"] = "false";
                //Below: Show Ap Name on Next Page\\
            }
            else
            {   //Button: Edit Application
                //e.CommandName == cmdEditAp
                mvApAdd.ActiveViewIndex = 2;
                GridView gvtemp = (GridView)sender;
                int currentRow = Convert.ToInt32(e.CommandArgument);
                int datakeyApID = Int32.Parse(gvtemp.DataKeys[0].Value.ToString());
                ViewState["datakeyApID"] = datakeyApID;
                GridViewRow gvSelectedRow = gvtemp.Rows[currentRow];
                string appName = gvSelectedRow.Cells[2].Text;
                string appDetails = gvSelectedRow.Cells[3].Text;
                txtApName.Text = appName;
                txtApDetails.Text = appDetails;

                //DetailsView DataBinding
                AppsAccessLayer db = new AppsAccessLayer();
                dvApplicationDetails.DataSource = db.GetAppMembers(datakeyApID);
                dvApplicationDetails.DataBind();
                //DetailsView DataBinding\\
            }



        }

        private void GvSearchApResults_SelectedIndexChanged(object sender, EventArgs e) //No LONGER USED
        {
            GridView gvApResults = (GridView)sender;
            GridViewRow gvrApResults = gvApResults.SelectedRow;
            string apName = gvrApResults.Cells[2].Text;
            string apDetails = gvrApResults.Cells[3].Text;

            txtApName.Text = apName;
            txtApDetails.Text = apDetails;
        }

        //DropDown Filter: Load Options
        private void LoadFilterTypeAp(DropDownList myDropDownList)
        {
            _ISetupDropDownList.LoadSearchFilterAp(myDropDownList);
        }
        
    //Application Grid
        private void LoadApInitialConditions(GridView gvSearchApResults)
        {
            _ISetupGridView.LoadGridViewInitialConditionsAp(gvSearchApResults);
            _ISetupGridView.LoadDetailsViewInitialConditionsAp(dvApplicationDetails); //DetailView
        }

        private void LoadApColumns(GridView gvSearchApResults)
        {
            _ISetupGridView.LoadGridViewColumnsAp(gvSearchApResults);
            _ISetupGridView.LoadDetailsViewColumnsAp(dvApplicationDetails); //DetailView
        }//Application Grid\\


        //Permission Grid
        private void LoadApPIntitialConditions(GridView gvPermissionList)
        {
            _ISetupGridView.LoadGridViewInitialConditionsApP(gvPermissionList);
        }

        private void LoadApPColumns(GridView gvPermissionList)
        {
            _ISetupGridView.LoadGridViewColumnsApP(gvPermissionList);
        }
        //Permission Grid\\

        //Button: Find Applications by Name
        protected void btnSearchSubmit_Click(object sender, EventArgs e)
        {
            mvApAdd.ActiveViewIndex = 1;
            string searchTerm = txtSearchTerm.Text.ToString();
            AppsAccessLayer dbap = new AppsAccessLayer();
            gvSearchApResults.DataSource = dbap.GetAppMembers(searchTerm);
            gvSearchApResults.DataBind();

        }

        //Button: Page Index set to Application Form
        protected void btnNewApp_Click(object sender, EventArgs e)
        {
            //Change multiView
            mvApAdd.ActiveViewIndex = 2;

        }

        //Button: Save Application Fields into DB (Insert or Update)
        protected void btnAppSave_Click(object sender, EventArgs e)
        {
            //Retrieve db obj
            AppsAccessLayer db = new AppsAccessLayer();

            //Collect Information into memory
            string ApName = txtApName.Text.ToString();
            string ApDetails = txtApDetails.Text.ToString();

            //Set Information into DB
            if (ViewState["datakeyApID"] != null) //Update//Update//Update//Update//Update//Update//Update
            {
                int ApId = (int)ViewState["datakeyApID"];
                //save to DB
                db.SetAp(ApId, ApName, ApDetails);

                //Retrieve Saved Info From DB
                gvConfirmResults.DataSource = db.GetAppMembers(ApId);
                gvConfirmResults.DataBind();
                ViewState["datakeyApID"] = null;
            }
            else
            {                                   //Insert//Insert//Insert//Insert//Insert//Insert//Insert
                int newApID = db.SetApNew(ApName, ApDetails);

                //Retrieve Saved Info From DB
                gvConfirmResults.DataSource = db.GetAppMembers(newApID);
                gvConfirmResults.DataBind();
            }
            //Change multiView
            mvApAdd.ActiveViewIndex = 5;
            
        }

        protected void btnNewPermission_Click(object sender, EventArgs e)
        {
            //load ap_id Viewstate into memory
            int ap_id = Int32.Parse(ViewState["apPId"].ToString());

            //Switch MultiView to 4
            mvApAdd.ActiveViewIndex = 4;

            //Fill Field Application Name with Application Name
            string appName = ViewState["apName"].ToString();
            txtApName_P.Text = appName;
            ViewState["apName"] = null; //clear ViewState store

            //set ViewState New Permission to True
            ViewState["NewPermission"] = "true";




        }

        protected void btnSavePermission_Click(object sender, EventArgs e)
        {
            int apP_id = 0;
            //load textbox data into memory
            string cloud_uid = txtCloudUid.Text.ToString();
            string cloud_pwd = txtCloudPwd.Text.ToString();
            string cloud_notes = txtPermissionNotes.Text.ToString();
            int admin_access = (txtIsAdmin.Text != null ? Int32.Parse(txtIsAdmin.Text.ToString()) : 3);

            AppsAccessLayer apDb = new AppsAccessLayer();

            bool newPermission = Boolean.Parse(ViewState["NewPermission"].ToString());
            if (newPermission)
            {
                int ap_id = Int32.Parse(ViewState["apPId"].ToString());
                apP_id = apDb.SetApPNew(ap_id, cloud_uid, cloud_pwd, cloud_notes, admin_access);
            }
            else
            {
                //load Ap ID and ApP ID DataKeys in memory
                apP_id = Int32.Parse(ViewState["datakeyApPId"].ToString());
                int ap_id = Int32.Parse(ViewState["datakeyApId"].ToString());
                apDb.SetApP(apP_id, ap_id, cloud_uid, cloud_pwd, cloud_notes, admin_access);


            }






            //Retrieve DB and Insert Record



            //Retrieve Newly Updated Record
            gvConfirmResults.DataSource = apDb.GetAppPermissionsSingle(apP_id);
            gvConfirmResults.DataBind();

            //Switch MultiView to 5
            mvApAdd.ActiveViewIndex = 5;
        }

        protected void btnRestart_Click(object sender, EventArgs e)
        {
            mvApAdd.ActiveViewIndex = 0;
        }
    }
}