using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace DBWeb
{
    public class ControlsUsers
    {

    }

    public interface IFillLstbxSearchType
    {
        void GetFillLstBxSearchTypeUser(DropDownList myddlst);

    }

    public interface IBuildGvTemplate
    {
        void GetGvTemplateUser(GridView mygridview);
        void AddUserColumns(GridView myUserGridView);
    }

    public class FillLstbsSearchType : IFillLstbxSearchType
    {
        public FillLstbsSearchType()
        {

        }

        //Fills DDL with Search Types
        public void GetFillLstBxSearchTypeUser(DropDownList myddlst)
        {
            // Listbox: SearchType
            DropDownList sendDropDownList = myddlst;
            
            List<string> searchType = new List<string>();
            string[] stringSearchType = { "Active Directory UserID", "First Name", "Last Name" };
            searchType.AddRange(stringSearchType);
            foreach (var i in searchType)
            {
                sendDropDownList.Items.Add(i);
            };
 

        }
    }

    public class BuildGvTemplateUser : IBuildGvTemplate
    {
        CommandField cmdUserSelect = new CommandField();
        BoundField userAdUid = new BoundField();
        BoundField userFname = new BoundField();
        BoundField userLname = new BoundField();
        BoundField userDept = new BoundField();
        BoundField userRole = new BoundField();
        BoundField userActive = new BoundField();

        public BuildGvTemplateUser()
        {

        }

        //Initates User GridView with Headers and Settings
        public void GetGvTemplateUser(GridView mygridview)
        {

            mygridview.AutoGenerateColumns = false;
            mygridview.AllowPaging = true;
            mygridview.DataKeyNames = new string[] { "uid" };
            mygridview.PageSize = 10;

            cmdUserSelect.HeaderText = "Choose";
            cmdUserSelect.ShowSelectButton = true;
            cmdUserSelect.Visible = true;
            userAdUid.HeaderText = "Active Directory ID";
            userAdUid.DataField = "ad_uid";
            userFname.HeaderText = "First Name";
            userFname.DataField = "fname";
            userLname.HeaderText = "Last Name";
            userLname.DataField = "lname";
            userDept.HeaderText = "Department Name";
            userDept.DataField = "department";
            userRole.HeaderText = "Role";
            userRole.DataField = "Role";
            userActive.HeaderText = "Active";
            userActive.DataField = "active";


        }

        //Adds Columns to User GridView
        public void AddUserColumns(GridView myUserGridView)
        {

            
            myUserGridView.Columns.Add(cmdUserSelect);
            myUserGridView.Columns.Add(userAdUid);
            myUserGridView.Columns.Add(userFname);
            myUserGridView.Columns.Add(userLname);
            myUserGridView.Columns.Add(userDept);
            myUserGridView.Columns.Add(userRole);
            myUserGridView.Columns.Add(userActive);

        }
    }

    public class FactoryControlUsers
    {
        public static IFillLstbxSearchType GetFillLstbxSearchTypeObj()
        {
            return new FillLstbsSearchType();
        }

        public static IBuildGvTemplate GetBuildGvTemplateObj()
        {
            return new BuildGvTemplateUser();
        }
    }
}