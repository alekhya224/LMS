using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS_WebAPI_Domain;
using LMS_WebAPI_Utils;
using LMS_WebAPI_DAL;
using LMS_WebAPI_DAL.Repositories;
using LMS_WebAPI_DAL.Repositories.Interfaces;

namespace LMS_WebAPI_ServiceHelpers
{
    public class UserManagement
    {
        private IUser user = new UserRepository();
        public UserAccountModel GetUser(string name, string password)
        {
            var userData = user.GetUser(name, password);
            var VerifiedUser = new UserAccountModel();
            VerifiedUser.UserName = userData.UserName;
            VerifiedUser.Password = userData.Password;
            VerifiedUser.Lastlogin = userData.Lastlogin;
            VerifiedUser.CreatedDate = userData.CreatedDate;
            VerifiedUser.RoleName = userData.RoleName;
            VerifiedUser.TotalCountTaken = userData.TotalCountTaken;
            VerifiedUser.TotalLeaveCount = userData.TotalLeaveCount;
            VerifiedUser.ManagerName = userData.ManagerName;
            VerifiedUser.ProjectName = userData.ProjectName;
            VerifiedUser.DateOfJoining = Convert.ToDateTime(userData.DateOfJoining);
            return VerifiedUser;
        }
    }
}
