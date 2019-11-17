using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBWeb
{
    public class UserAppPermissionData
    {
    }

    public class UserAppPermissionMember
    {
        public int app_permission_id { set; get; }
        public int app_id { set; get; }
        public int uid { set; get; }
        public string aduid { set; get; }
        public string appname { set; get; }
        public string cloud_uid { set; get; }
        public string cloud_pwd { set; get; }
        public string Permission_N { set; get; }
        public int admin { set; get; }
    }

    public class UserAppPermission
    {
        public List<UserAppPermissionMember> GetUserAppPermissionSpecific(int myuid, int myapP_id)
        {
            List<UserAppPermissionMember> listuserapps = new List<UserAppPermissionMember>();
            int uid = myuid; // <---- Input
            int apP_id = myapP_id;
            using (UserAccessEntities db = new UserAccessEntities())
            {
                var userapp_mem = from user in db.Users

                                  from app in user.App_Permission
                                  join ap in db.Apps on app.app_id equals ap.app_id

                                  where user.uid == uid && app.app_permission_id == apP_id
                                  select new UserAppPermissionMember
                                  {
                                      uid = user.uid,
                                      app_id = ap.app_id,
                                      app_permission_id = app.app_permission_id, //newly added
                                      aduid = user.ad_uid,
                                      appname = ap.name,
                                      cloud_uid = app.cloud_uid,
                                      cloud_pwd = app.cloud_pwd,
                                      Permission_N = app.Permission_N,
                                      admin = (app.admin != null ? (int)app.admin : 0)

                                  };
               
                //foreach (var mem in userapp_mem)
                //{
                //    Console.WriteLine($"AD_UID:{mem.aduid} // App UID: {mem.apuid} // App Pwd: {mem.appwd} // AppNote: {mem.appnote} // Ap_Admin: {mem.apadmin}");
                //}

                listuserapps.AddRange(userapp_mem);
                return listuserapps;

            }


        }
        public List<UserAppPermissionMember> GetUserAppPermission(string activediruid)
        {
            List<UserAppPermissionMember> listuserapps = new List<UserAppPermissionMember>();
            string aduid = activediruid; // <---- Input
            using (UserAccessEntities db = new UserAccessEntities())
            {
                var userapp_mem = from user in db.Users

                                  from app in user.App_Permission
                                  join ap in db.Apps on app.app_id equals ap.app_id

                                  where user.ad_uid == aduid
                                  select new UserAppPermissionMember
                                  {
                                      uid = user.uid,
                                      app_id = ap.app_id,
                                      app_permission_id = app.app_permission_id, //newly added
                                      aduid = user.ad_uid,
                                      appname = ap.name,
                                      cloud_uid = app.cloud_uid,
                                      cloud_pwd = app.cloud_pwd,
                                      Permission_N = app.Permission_N,
                                      admin = (app.admin != null ? (int)app.admin : 0)

                                  };
                //foreach (var mem in userapp_mem)
                //{
                //    Console.WriteLine($"AD_UID:{mem.aduid} // App UID: {mem.apuid} // App Pwd: {mem.appwd} // AppNote: {mem.appnote} // Ap_Admin: {mem.apadmin}");
                //}

                listuserapps.AddRange(userapp_mem);
                return listuserapps;

            }
        }



        //public void SetUserAppPermission(int app_id, string aduid, string clouduid, string cloudpwd, string perm, int adm)
        //{
        //    using (UserAccessEntities db = new UserAccessEntities())
        //    {
        //        var usermem = (from user in db.Users
        //                       where user.ad_uid == aduid
        //                       select user).FirstOrDefault();
        //        App_Permission app_Permission = new App_Permission();
        //        app_Permission.app_id = app_id;
        //        app_Permission.cloud_uid = clouduid;
        //        app_Permission.cloud_pwd = cloudpwd;
        //        app_Permission.Permission_N = perm;
        //        app_Permission.admin = adm;

        //        usermem.App_Permission.Add(app_Permission);
        //        db.SaveChanges();
        //    }
        //}
        public int SetUserAppPermission(int app_id, int uid, string clouduid, string cloudpwd, string perm, int adm)
        {
            using (UserAccessEntities db = new UserAccessEntities())
            {
                var usermem = (from user in db.Users
                               where user.uid == uid
                               select user).FirstOrDefault();
                App_Permission app_Permission = new App_Permission();
                app_Permission.app_id = app_id;
                app_Permission.cloud_uid = clouduid;
                app_Permission.cloud_pwd = cloudpwd;
                app_Permission.Permission_N = perm;
                app_Permission.admin = adm;

                usermem.App_Permission.Add(app_Permission);
                db.SaveChanges();

                return Int32.Parse(app_Permission.app_permission_id.ToString());
            }
        }

        //Associate UID with Existing ApP
        public void SetUserAppPermission_input_ad_uid(int app_id, string ad_uid)
        {
            using (UserAccessEntities db = new UserAccessEntities())
            {
                var usermem = (from user in db.Users
                               where user.ad_uid == ad_uid
                               select user).FirstOrDefault();
                var appmem = (from app in db.App_Permission
                              where app.app_permission_id == app_id
                              select app).FirstOrDefault();

                usermem.App_Permission.Add(appmem);
                db.SaveChanges();
            }
        }


        //Remove association of UID with Existing ApP
        public void DelUserAppPermission(int my_apP_id, int my_uid)
        {
            using(UserAccessEntities db = new UserAccessEntities())
            {
                var usermem = (from user in db.Users
                               where user.uid == my_uid
                               select user).FirstOrDefault();
                var apPmem = (from apP in db.App_Permission
                           where apP.app_permission_id == my_apP_id
                           select apP).FirstOrDefault();

                usermem.App_Permission.Remove(apPmem);
                db.SaveChanges();
            }
        }



    }
}