using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBWeb
{
    public class UserMembers
    {
        public int uid { get; set; }
        public string ad_uid { set; get; }
        public string fname { set; get; }
        public string lname { set; get; }
        public string department { set; get; }
        public string role { set; get; }
        public int active { set; get; }
    }

    public class UserAccessLayer
    {
        public List<UserMembers> getUsers()
        {
            List<UserMembers> listusers = new List<UserMembers>();
            using (UserAccessEntities db = new UserAccessEntities())
            {
                var usermem = from u in db.Users
                              orderby u.ad_uid
                              select new UserMembers
                              {
                                  uid = u.uid,
                                  ad_uid = u.ad_uid,
                                  fname = u.fname,
                                  lname = u.lname,
                                  department = u.department,
                                  role = u.Role,
                                  active = (u.active != null ? (int)u.active : 0)
                              };


                listusers.AddRange(usermem);
            }
            return listusers;
        }

        public List<UserMembers> getUsers(int search_type, string search_term)
        {

            List<UserMembers> listofusers = new List<UserMembers>();
            using (UserAccessEntities db = new UserAccessEntities())
            {
                var usermem = from u in db.Users
                                  //where u.ad_uid == "aGolloher" //testing purpose
                                  //this where statement needs to switch btw fname, ad_uid, lname
                              where (search_type == 0 && u.ad_uid.Equals(search_term) ||
                                    search_type == 1 && u.fname.Contains(search_term) ||
                                    search_type == 2 && u.lname.Contains(search_term) )
                              orderby u.ad_uid

                              select new UserMembers
                              {
                                  uid = u.uid,
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

        public void SetUser(int myuid, string myad_uid, string myfname, string mylname, string mydepartment, string myrole, int myactive)
        {
            using(UserAccessEntities db = new UserAccessEntities())
            {
                var memuser = (from user in db.Users
                               where user.uid == myuid
                               select user).FirstOrDefault();

                memuser.ad_uid = myad_uid;
                memuser.fname = myfname;
                memuser.lname = mylname;
                memuser.department = mydepartment;
                memuser.Role = myrole;
                memuser.active = myactive;

                db.SaveChanges();
            }
        }
        public void SetUserNew(string myad_uid, string myfname, string mylname, string mydepartment, string myrole, int myactive)
        {
            using (UserAccessEntities db = new UserAccessEntities())
            {
                User memuser = new User();
                memuser.ad_uid = myad_uid;
                memuser.fname = myfname;
                memuser.lname = mylname;
                memuser.department = mydepartment;
                memuser.Role = myrole;
                memuser.active = myactive;
                db.Users.Add(memuser);
                db.SaveChanges();
            }
        }
    }


}