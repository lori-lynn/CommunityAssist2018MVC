using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CommunityAssist2018MVC.Models
{
    public class LoginClass
    {
        [DisplayName("User Email"), DisplayFormat(NullDisplayText = "email")]
        public string Email { get; set; }

        [DisplayName("Password"), DisplayFormat(NullDisplayText = "password")]
        public string Password { get; set; }

        public int PersonKey { get; set; }
    }
}