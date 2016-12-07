using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories
{
 public class UserRepository:IUser
    {
        public UserAccount GetUser(string emailId, string password)
        {
            using (var ctx = new LeaveManagementSystemEntities())
            {
                var userData = (from c in ctx.UserAccounts
                                where c.UserName == emailId && c.Password == password
                                select c).SingleOrDefault();
                if (userData != null)
                {
                    return userData;
                }
                else
                    return null;
            }
        }
    }
}
