using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//NOT CURRENTLY USED
namespace DBWeb
{
    public class UserAppPermissionAppMember
    {
        public string ad_uid { set; get; }
        public string fname { set; get; }
        public string lname { set; get; }
        public int app_id { set; get; }
        public string cloud_id { set; get; }
        public string appname { set; get; }
    }
    class UserAppPermissionAppData
    {
        public void GetUserAppPermissionAppMembers()
        {
            List<UserAppPermissionAppMember> memberlist = new List<UserAppPermissionAppMember>();
            using (UserAccessEntities db = new UserAccessEntities())
            {
                var memberlst = from app in db.Apps
                                join app_p in db.App_Permission on app.app_id equals app_p.app_id
                                from user in app_p.Users
                                select new UserAppPermissionAppMember()
                                {
                                    ad_uid = user.ad_uid,
                                    fname = user.fname,
                                    lname = user.lname,
                                    app_id = app.app_id,
                                    cloud_id = app_p.cloud_uid,
                                    appname = app.name
                                };
                memberlist.AddRange(memberlst);
            }

            foreach (var mem in memberlist)
            {
                Console.WriteLine(mem.ad_uid + " " + mem.fname + " " + mem.lname + " " + mem.appname + " " + mem.cloud_id);
                //Console.WriteLine(mem.ad_uid + " " + mem.fname);
            }
        }


    }
}