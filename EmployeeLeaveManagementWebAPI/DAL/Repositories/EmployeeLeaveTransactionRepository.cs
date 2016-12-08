using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS_WEBAPI_DAL.Repositories.Interfaces;

namespace LMS_WEBAPI_DAL.Repositories
{
    public class EmployeeLeaveTransactionRepository : IEmployeeLeaveTransaction
    {
        public List<EmployeeLeaveTransaction> GetEmployeeLeaveTransaction()
        {
            using (var ctx = new LeaveManagementSystemEntities())
            {

                var EmployeeLeaveTransactions = ctx.EmployeeLeaveTransactions.ToList();
                if (EmployeeLeaveTransactions != null)
                {
                    return EmployeeLeaveTransactions;
                }
                else
                    return null;
            }
        }
    }
}
