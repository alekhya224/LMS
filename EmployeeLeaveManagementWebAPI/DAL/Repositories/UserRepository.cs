using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
 public class UserRepository
    {
        public bool GetUser(string emailId, string password)
        {
            using (var ctx = new LeaveManagementSystemEntities())
            {
                var userData = (from c in ctx.UserAccounts
                                where c.UserName == emailId && c.Password == password
                                select c).SingleOrDefault();
                if (userData != null)
                {
                    var EmpData = (from c in ctx.EmployeeDetails
                                   where c.Id == userData.RefEmployeeId
                                   select c).SingleOrDefault();
                }
                else
                    return false;
            }
        }
    }
}
