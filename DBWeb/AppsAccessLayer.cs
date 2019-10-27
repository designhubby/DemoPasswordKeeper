using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBWeb
{


    public class AppMember
    {
        public int app_id { set; get; }
        public string name { set; get; }
        public string details { set; get; }

    }

    public class AppPMember
    {
        public int      app_permission_id   { set; get; }
        public int      app_id              { set; get; }
        public string   cloud_uid           { set; get; }
        public string   cloud_pwd           { set; get; }
        public string   Permission_N        { set; get; }
        public int      admin               { set; get; }
    }

    public class AppsAccessLayer
    {
        public List<AppMember> GetAppMembers(string searchappname)
        {
            string search_app_name = searchappname;
            List<AppMember> listOfApps = new List<AppMember>();
            using(UserAccessEntities db = new UserAccessEntities())
            {
                var appmem = from App in db.Apps
                             where (App.name.Contains(search_app_name))
                             orderby App.name
                             select new AppMember
                             {
                                 app_id = App.app_id,
                                 name = App.name,
                                 details = App.details
                             };
                listOfApps.AddRange(appmem);
            }
            return listOfApps;
        }

        public List<AppMember> GetAppMembers(int searchappid)
        {
            int search_app_name = searchappid;
            List<AppMember> listOfApps = new List<AppMember>();
            using (UserAccessEntities db = new UserAccessEntities())
            {
                var appmem = from App in db.Apps
                             where (App.app_id.Equals(searchappid))
                             orderby App.name
                             select new AppMember
                             {
                                 app_id = App.app_id,
                                 name = App.name,
                                 details = App.details
                             };
                listOfApps.AddRange(appmem);
            }
            return listOfApps;
        }

        public List<AppPMember> GetAppPermissions(int my_app_id)
        {
            List<AppPMember> listOfPermissions = new List<AppPMember>();
            int app_id_search = my_app_id;
            using(UserAccessEntities db = new UserAccessEntities())
            {
                var apP_mem = from apP in db.App_Permission
                              where apP.app_id == app_id_search
                              orderby apP.cloud_uid
                              select new AppPMember
                              {
                                  app_permission_id = apP.app_permission_id,
                                  app_id            = apP.app_id,
                                  cloud_uid         = apP.cloud_uid,
                                  cloud_pwd         = apP.cloud_pwd,
                                  Permission_N      = apP.Permission_N,
                                  admin             = (apP.admin != null ? (int)apP.admin:3) //notice if null then 3
                              };
                listOfPermissions.AddRange(apP_mem);

            }
            return listOfPermissions;
        }

        public List<AppPMember> GetAppPermissionsSingle(int my_apPermission_id)
        {
            List<AppPMember> listOfPermissions = new List<AppPMember>();
            int app_permission_search = my_apPermission_id;
            using (UserAccessEntities db = new UserAccessEntities())
            {
                var apP_mem = from apP in db.App_Permission
                              where apP.app_permission_id == app_permission_search
                              select new AppPMember
                              {
                                  app_permission_id = apP.app_permission_id,
                                  app_id = apP.app_id,
                                  cloud_uid = apP.cloud_uid,
                                  cloud_pwd = apP.cloud_pwd,
                                  Permission_N = apP.Permission_N,
                                  admin = (apP.admin != null ? (int)apP.admin : 3) //notice if null then 3
                              };
                listOfPermissions.AddRange(apP_mem);

            }
            return listOfPermissions;
        }

        public void SetAp(int my_ap_id, string my_ap_name, string my_ap_detail)
        {

            using(UserAccessEntities dbAp = new UserAccessEntities())
            {
                var ap_mem = (from ap in dbAp.Apps
                             where ap.app_id == my_ap_id
                             select ap).FirstOrDefault();

                ap_mem.name = my_ap_name;
                ap_mem.details = my_ap_detail;
                dbAp.SaveChanges();
            }
        }
        public int SetApNew(string my_ap_name, string my_ap_detail)
        {

            using (UserAccessEntities dbAp = new UserAccessEntities())
            {

                App ap_mem = new App();
                ap_mem.name = my_ap_name;
                ap_mem.details = my_ap_detail;
                dbAp.Apps.Add(ap_mem);
                dbAp.SaveChanges();
                return ap_mem.app_id;
            }
        }
        
        public void SetApP(int apP_id, int my_ap_id, string my_cloudid, string my_cloudpwd, string my_pnotes, int my_admin)
        {
            using (UserAccessEntities db = new UserAccessEntities())
            {
                var ApP_mem = (from apP in db.App_Permission
                               where apP.app_permission_id == apP_id
                               select apP).FirstOrDefault();

                ApP_mem.app_id = my_ap_id;
                ApP_mem.cloud_uid = my_cloudid;
                ApP_mem.cloud_pwd = my_cloudpwd;
                ApP_mem.Permission_N = my_pnotes;
                ApP_mem.admin = my_admin;

                db.SaveChanges();
                
            }

        }

        public int SetApPNew(int my_ap_id, string my_cloudid, string my_cloudpwd, string my_pnotes, int my_admin)
        {
            using (UserAccessEntities db = new UserAccessEntities())
            {
                App_Permission apP = new App_Permission();
                apP.app_id = my_ap_id;
                apP.cloud_uid = my_cloudid;
                apP.cloud_pwd = my_cloudpwd;
                apP.Permission_N = my_pnotes;
                apP.admin = my_admin;

                db.App_Permission.Add(apP);
                db.SaveChanges();

                return apP.app_permission_id;
            }
        }


    }
}