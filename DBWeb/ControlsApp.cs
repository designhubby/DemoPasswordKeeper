using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace DBWeb
{
    public class ControlsApp
    {
    }

    public interface ISetupDropDownList
    {
        void LoadSearchFilterAp(DropDownList myDropDownList);
    }

    public interface ISetupGridView
    {
        void LoadGridViewInitialConditionsAp(GridView mygridview);
        void LoadGridViewColumnsAp(GridView mygridview);
        void LoadGridViewInitialConditionsApP(GridView mygridView);
        void LoadGridViewInitialConditionsApPwithApName(GridView mygridView);
        void LoadGridViewColumnsApP(GridView mygridview);
        void LoadGridViewColumnsApPwithApName(GridView mygridview);
        void LoadDetailsViewInitialConditionsAp(DetailsView mydetailsview);
        void LoadDetailsViewColumnsAp(DetailsView mydetailsview);
    }

    public class FactoryControlApp
    {
        public static ISetupDropDownList SetupDropDownListObj()
        {
            return new SetupDropDownList();
        }

        public static ISetupGridView SetupGridViewObj()
        {
            return new SetupGridView();
        }
    }
    // Implementation Section:          // Implementation Section:          // Implementation Section:          // Implementation Section:          
    public class SetupDropDownList : ISetupDropDownList
    {
        public SetupDropDownList()
        { }//constructor
        

        public void LoadSearchFilterAp(DropDownList myDropDownList)
        {
            DropDownList ddlSearch = myDropDownList;

            List<String> option_list = new List<string>();
            string[] array_my_list_items = { "Application Name" };
            option_list.AddRange(array_my_list_items);
            foreach(var i in option_list)
            {
                ddlSearch.Items.Add(i);
            }

        }
    }

    public class SetupGridView : ISetupGridView
    {
        ButtonField     btnApEdit_Ap_Select  = new ButtonField();
        ButtonField     btnApEdit_P_Select   = new ButtonField();
        BoundField      apName               = new BoundField();
        BoundField      apDetails            = new BoundField();

        CommandField cmdApPSelect         = new CommandField();
        BoundField   apP_CloudUid         = new BoundField();
        BoundField   apP_CloudPwd         = new BoundField();
        BoundField   apP_PermissionNotes  = new BoundField();
        BoundField   apP_admin            = new BoundField();

        //BoundField ApName              = new TemplateField();
        //TemplateField tfApDetails           = new TemplateField();

        public SetupGridView()
        { }//constructor


        public void LoadGridViewInitialConditionsAp(GridView mygridview)
        {
            mygridview.AutoGenerateColumns = false;
            mygridview.AllowPaging = true;
            mygridview.DataKeyNames = new string[] { "app_id" };
            mygridview.PageSize = 10;
            btnApEdit_Ap_Select.HeaderText = "Edit Application";
            btnApEdit_Ap_Select.Text = "Edit Application";
            btnApEdit_Ap_Select.ButtonType = ButtonType.Button;
            btnApEdit_Ap_Select.CommandName = "cmdEditAp";
            btnApEdit_Ap_Select.Visible = true;
            btnApEdit_P_Select.CommandName = "cmdEditApP";
            btnApEdit_P_Select.ButtonType = ButtonType.Button;
            btnApEdit_P_Select.HeaderText = "Edit Permission";
            btnApEdit_P_Select.Text = "Edit Permission";
            btnApEdit_P_Select.Visible = true;
            apName.HeaderText = "Application Name";
            apName.DataField = "name";
            apDetails.HeaderText = "Application Details";
            apDetails.DataField = "details";


        }

        public void LoadGridViewColumnsAp(GridView mygridview)
        {
            mygridview.Columns.Add(btnApEdit_Ap_Select);
            mygridview.Columns.Add(btnApEdit_P_Select);
            mygridview.Columns.Add(apName);
            mygridview.Columns.Add(apDetails);
        }

        public void LoadGridViewInitialConditionsApP(GridView mygridView)
        {
            mygridView.AutoGenerateColumns = false;
            mygridView.AllowPaging = true;
            mygridView.DataKeyNames = new string[] { "app_permission_id", "app_id"};
            mygridView.PageSize = 10;
            cmdApPSelect.HeaderText = "Choose";
            cmdApPSelect.ShowSelectButton = true;
            cmdApPSelect.Visible = true;
            apP_CloudUid.HeaderText = "Cloud User ID";
            apP_CloudUid.DataField = "cloud_uid";
            apP_CloudPwd.HeaderText = "Cloud Password";
            apP_CloudPwd.DataField = "cloud_pwd";
            apP_PermissionNotes.HeaderText = "Permission Notes";
            apP_PermissionNotes.DataField = "Permission_N";
            apP_admin.HeaderText = "Administrator Access";
            apP_admin.DataField = "admin";

        }

        public void LoadGridViewColumnsApP(GridView mygridview)
        {
            mygridview.Columns.Add(cmdApPSelect);
            mygridview.Columns.Add(apP_CloudUid);
            mygridview.Columns.Add(apP_CloudPwd);
            mygridview.Columns.Add(apP_PermissionNotes);
            mygridview.Columns.Add(apP_admin);
            
        }

        public void LoadGridViewInitialConditionsApPwithApName(GridView mygridView)
        {
            mygridView.AutoGenerateColumns = false;
            mygridView.AllowPaging = true;
            mygridView.DataKeyNames = new string[] { "app_permission_id", "app_id", "uid" };
            mygridView.PageSize = 10;
            cmdApPSelect.HeaderText = "Choose";
            cmdApPSelect.ShowSelectButton = true;
            cmdApPSelect.Visible = true;
            apP_CloudUid.HeaderText = "Cloud User ID";
            apP_CloudUid.DataField = "cloud_uid";
            apP_CloudPwd.HeaderText = "Cloud Password";
            apP_CloudPwd.DataField = "cloud_pwd";
            apP_PermissionNotes.HeaderText = "Permission Notes";
            apP_PermissionNotes.DataField = "Permission_N";
            apP_admin.HeaderText = "Administrator Access";
            apP_admin.DataField = "admin";
            apName.HeaderText = "Application Name";
            apName.DataField = "appname";

        }

        public void LoadGridViewColumnsApPwithApName(GridView mygridview)
        {
            mygridview.Columns.Add(cmdApPSelect);
            mygridview.Columns.Add(apName);
            mygridview.Columns.Add(apP_CloudUid);
            mygridview.Columns.Add(apP_CloudPwd);
            mygridview.Columns.Add(apP_PermissionNotes);
            mygridview.Columns.Add(apP_admin);
            

        }

        public void LoadDetailsViewInitialConditionsAp(DetailsView mydetailsview)
        {
            mydetailsview.AutoGenerateRows = false;
            mydetailsview.AutoGenerateEditButton = true;
            mydetailsview.Visible = false; // Hidden Detail View (no longer used)
            

            mydetailsview.DataKeyNames = new string[] { "app_id" };
            apName.HeaderText = "Application Name";
            apName.DataField = "name";
            apDetails.HeaderText = "Application Details";
            apDetails.DataField = "details";

        }

        public void LoadDetailsViewColumnsAp(DetailsView mydetailsview)
        {
            mydetailsview.Fields.Add(apName);
            mydetailsview.Fields.Add(apDetails);
        }
    }
}