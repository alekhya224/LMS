using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS_WebAPI_Domain;

using DAL;
using DAL.Repositories;
using DAL.Repositories.Interfaces;

namespace LMS_WebAPI_ServiceHelpers
{
    public class EmployeeLeaveTransactionManagement
    {
        private IEmployeeLeaveTransaction EmployeeLeaves  = new EmployeeLeaveTransactionRepository();
        public List<EmployeeLeaveTransactionModel> GetEmployeeLeaveTransaction()
        {
            var EmployeeLeaveTransaction = EmployeeLeaves.GetEmployeeLeaveTransaction();
            var retResult = ToModel(EmployeeLeaveTransaction);

            return retResult;
        }

        private List<EmployeeLeaveTransactionModel> ToModel(List<EmployeeLeaveTransaction> employeeLeaveTransaction)
        {
            List<EmployeeLeaveTransactionModel> Empres = new List<EmployeeLeaveTransactionModel>();
            try
            {
                foreach (var m in employeeLeaveTransaction)
                {
                    var newTrans = new EmployeeLeaveTransactionModel();
                    newTrans.Id = m.Id;
                    newTrans.RefEmployeeId = m.RefEmployeeId;
                    newTrans.FromDate = m.FromDate;
                    newTrans.ToDate = m.ToDate;
                    newTrans.CreatedDate = m.CreatedDate;
                    newTrans.RefStatus = m.RefStatus;
                    newTrans.NumberOfWorkingDays = m.NumberOfWorkingDays;
                    newTrans.RefLeaveType = m.RefLeaveType;
                    newTrans.EmployeeComment = m.EmployeeComment;
                    newTrans.ManagerComments = m.ManagerComments;
                    newTrans.ModifiedDate = m.ModifiedDate;
                    Empres.Add(newTrans);


                }
            }
            catch (Exception)
            {

                throw;
            }
            return Empres;



        }
    }
}
