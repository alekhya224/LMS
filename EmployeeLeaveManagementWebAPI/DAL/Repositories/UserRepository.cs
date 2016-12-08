using LMS_WebAPI_DAL.Repositories.Interfaces;
using System.Linq;
using LMS_WebAPI_Utils;
using LMS_WebAPI_DAL;

namespace LMS_WebAPI_DAL.Repositories
{
    public class UserRepository:IUser
    {
        public EmployeeCommon GetUser(string emailId, string password)
        {
            using (var ctx = new LeaveManagementSystemEntities1())
            {
                var userData = (from c in ctx.UserAccounts
                                where c.UserName == emailId && c.Password == password
                                select c).FirstOrDefault();
                if (userData != null)
                {

                    var EmpDetails = ctx.EmployeeDetails.Select(n => new EmployeeCommon()
                    {
                        Name = n.Name,
                        ManagerId = n.ManagerId,
                        Experience = n.Experience,
                        RoleName = n.MasterDataValue.Value,
                        DateOfJoining = n.DateOfJoining,
                    }
                     ).FirstOrDefault();
                    var LeaveType = ctx.LeaveMasters.ToList();
                    EmpDetails.TotalLeaveCount = LeaveType.Sum(q => q.Count);

                    EmpDetails.TotalCountTaken = (from c in ctx.EmployeeLeaveTransactions
                                                  where c.RefEmployeeId == userData.RefEmployeeId
                                                  select c.NumberOfWorkingDays).ToList().Sum();
                    var empdata = (from n in ctx.EmployeeProjectDetails
                                   where n.RefEmployeeId == userData.RefEmployeeId
                                   select n).SingleOrDefault();
                    EmpDetails.ProjectName = empdata.MasterDataValue.Value;
                    EmpDetails.ManagerName = (from n in ctx.EmployeeDetails where n.Id == EmpDetails.ManagerId select n.Name).SingleOrDefault();
                    return EmpDetails;
                }
                else
                    return null;
            }
        }
    }
}
