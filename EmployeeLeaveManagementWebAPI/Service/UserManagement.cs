using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Utils;
using DAL;
using DAL.Repositories;
using DAL.Repositories.Interfaces;

namespace Service
{
    public class UserManagement
    {
        private IUser user = new UserRepository();
        public UserAccountModel GetUser(string name, string password)
        {
            var userData = user.GetUser(name, password);
            var VerifiedUser = new UserAccountModel();
            VerifiedUser.UserName = userData.Name;
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
