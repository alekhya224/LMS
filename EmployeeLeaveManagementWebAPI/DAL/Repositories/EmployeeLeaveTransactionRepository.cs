using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories
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
