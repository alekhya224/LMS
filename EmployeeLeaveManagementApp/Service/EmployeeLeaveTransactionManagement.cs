﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using LMS_WebAPP_Domain;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Linq;

namespace LMS_WebAPP_ServiceHelpers
{
    public class EmployeeLeaveTransactionManagement
    {
        static HttpClient client = new HttpClient();


        private string URL = "http://localhost:64476/api/EmployeeLeaveTrans";
        // private string urlParameters = "?userName=anualoor&password=Temp@123";

        public async Task<IList<LeaveTransaction>> GetProductAsync()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);
            
            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = await client.GetAsync(URL);  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!
                var dataObjects =  response.Content.ReadAsAsync<IList<LeaveTransaction>>().Result.ToList();
                return dataObjects;

            }
            return null;
        }

        public async Task<IList<LeaveTransaction>> SubmitLeaveRequestAsync(int leaveType,string fromDate,string toDate,string comments,int workingDays)
        {
            HttpClient client = new HttpClient();
           var urlParameters = "?leaveType=" + leaveType + "&fromDate=" + fromDate + "&toDate="+ toDate+"&comments="+comments+"&workingDays="+workingDays;
            //URL = URL + "/SubmitLeaveRequest";
            client.BaseAddress = new Uri(URL);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = await client.GetAsync(urlParameters);  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!
                var dataObjects = response.Content.ReadAsAsync<IList<LeaveTransaction>>().Result.ToList();
                return dataObjects;

            }
            return null;
        }

        public async Task<IList<LeaveTransaction>> SubmitLeaveForApprovalAsync(int id)
        {
            HttpClient client = new HttpClient();
            var urlParameters = "?id=" + id;
            //URL = URL + "/SubmitLeaveRequest";
            client.BaseAddress = new Uri(URL);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = await client.GetAsync(urlParameters);  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!
                var dataObjects = response.Content.ReadAsAsync<IList<LeaveTransaction>>().Result.ToList();
                return dataObjects;

            }
            return null;
        }


        public async Task<IList<LeaveTransaction>> DeleteLeaveRequestAsync(int leaveId)
        {
            HttpClient client = new HttpClient();
            var urlParameters = "?leaveId=" + leaveId+"&employeeId="+leaveId;
            //URL = URL + "/SubmitLeaveRequest";
            client.BaseAddress = new Uri(URL);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = await client.GetAsync(urlParameters);  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!
                var dataObjects = response.Content.ReadAsAsync<IList<LeaveTransaction>>().Result.ToList();
                return dataObjects;

            }
            return null;
        }

    }
}
