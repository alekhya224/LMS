using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_WebAPP_Domain
{
   public class EmployeeDetailsModel
    {
        public int Id { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ProjectName { get; set; }
        public String RoleName { get; set; }
        public int? TotalLeaveCount { get; set; }
        public int TotalCountTaken { get; set; }
        public int TotalLeft { get; set; }
        public string ManagerName { get; set; }
        public System.DateTime DateOfJoining { get; set; }
    }
}
