using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Util
{
    public class EmployeeCommon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RefRoleId { get; set; }
        public Nullable<System.DateTime> DateOfJoining { get; set; }
        public double Experience { get; set; }
        public Nullable<int> ManagerId { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Nullable<System.DateTime> Lastlogin { get; set; }
        public int RefEmployeeId { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    }
}
