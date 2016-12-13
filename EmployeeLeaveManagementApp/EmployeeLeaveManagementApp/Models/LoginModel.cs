﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EmployeeLeaveManagementApp.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "Password length must be within 6 - 15")]
        [Display(Name = "Password")]
        public string Password { get; set; }

      //  public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please enter user name")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Display(Name = "User name")]
        [StringLength(256, MinimumLength = 5, ErrorMessage = "UserName length must be within 256")]
        public string UserName { get; set; }
        public bool RememberMe { get; set; }

        public string EmpName { get; set; }
        public int EmpExperience { get; set; }
        public string ManagerName { get; set; }
        public string Projectname { get; set; }
        public String RoleName { get; set; }
        public int TotalLeaveCount { get; set; }
        public int TotalLeft { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime DateOfJoining { get; set; }
        public int TotalTaken { get; set; }
        public string FormattedDate
        {
            get
            {
                if (DateOfJoining != null)
                    return Convert.ToDateTime(DateOfJoining).ToString("dd MMM yyyy");
                else
                {
                    return "";
                }
            }
        }

        public List<Announcement> Announcements { get; set; }
    }
    public class Announcement
    {
public string Title { get; set; }
        public string CarouselContent { get; set; }
        public string ImagePath { get; set; }
    }
}