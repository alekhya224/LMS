﻿using LMS_WebAPI_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_WebAPI_DAL.Repositories.Interfaces
{
  public  interface IAddLeaveRepository
    {
        List<string> GetLeaveType();
        bool InsertEmployeeLeaveDetails(int leaveType, string fromDate, string toDate, string comments, int workingDays);

        bool SubmitLeaveForApproval(int id);

        bool DeleteLeaveRequest(int id);
    }
}
