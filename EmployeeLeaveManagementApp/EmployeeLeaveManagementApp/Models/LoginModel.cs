using System;
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
    }
}