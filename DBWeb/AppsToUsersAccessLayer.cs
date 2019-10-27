using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBWeb
{

    public class AppsToUsersAccessLayer
    {
        public List<UserMembers> getUsers(int search_type, int search_term)
        {

            List<UserMembers> listofusers = new List<UserMembers>();
            using (UserAccessEntities db = new UserAccessEntities())
            {
                var usermem = from u in db.Users
                                  //where u.ad_uid == "aGolloher" //testing purpose
                                  //this where statement needs to switch btw fname, ad_uid, lname
                              from app in u.App_Permission
                              join ap in db.Apps on app.app_id equals ap.app_id
                              where (search_type == 3 && ap.app_id == search_term)

                              select new UserMembers
                              {
                                  ad_uid = u.ad_uid,
                                  fname = u.fname,
                                  lname = u.lname,
                                  department = u.department,
                                  role = u.Role,
                                  active = (u.active != null ? (int)u.active : 0)
                              };
                listofusers.AddRange(usermem);
            }
            return listofusers;
        }
    }
}