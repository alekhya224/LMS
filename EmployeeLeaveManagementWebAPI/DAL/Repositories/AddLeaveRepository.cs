using System.Collections.Generic;
using System.Linq;
using LMS_WebAPI_DAL.Repositories.Interfaces;
using LMS_WebAPI_Domain;
using LMS_WebAPI_DAL;

namespace DAL.Repositories
{
    public class AddLeaveRepository 
    {
        public List<LeaveTypeModel> GetLeaveType()
        {
            using (var ctx = new LeaveManagementSystemEntities1())
            {

                var leavetypeid  = (from s in ctx.MasterDataTypes
                                    where s.Type=="LeaveType"
                                    select s).SingleOrDefault();

                var leavetypes = (from s in ctx.MasterDataValues
                                where s.RefMasterType == leavetypeid.Id
                                select s).ToList();



                if (leavetypes != null)
                {
                    return null;
                }
                else
                    return null;
            }
        }
    }
    
}
