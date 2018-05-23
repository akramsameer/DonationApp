using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChairtyApplication.Models;

namespace ChairtyApplication.Services
{
    public static class Navigation
    {

        public static User GetTheNearstSubAdmin(ChairtyDbEntities db, double lan, double lon)
        {
            var subAdmins = db.Users.Where(x => x.RuleId == 2).ToList();
            double min = double.MaxValue;
            User res= null;
            foreach (var subAdmin in subAdmins)
            {
                if (subAdmin.Magnitude == null || subAdmin.Landitude == null)
                    continue;

                var dis = Math.Sqrt((subAdmin.Landitude.Value - lan) * (subAdmin.Landitude.Value - lan) +
                                    (subAdmin.Magnitude.Value - lon) * (subAdmin.Magnitude.Value - lon));
                if (dis < min)
                {
                    min = dis;
                    res = subAdmin;
                }
            }

            return res;
        }
    }
}