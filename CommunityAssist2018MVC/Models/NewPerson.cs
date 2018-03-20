using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CommunityAssist2018MVC.Models
{
    public class NewPerson
    {
        [DisplayName("Last Name"), DisplayFormat(NullDisplayText = "Last Name")]
        public string PersonLastName { get; set; }

        [DisplayName("First Name"), DisplayFormat(NullDisplayText = "First Name")]
        public string PersonFirstName { get; set; }

        [DisplayName("Email"), DisplayFormat(NullDisplayText = "Email")]
        public string PersonEmail { get; set; }

        [DisplayName("Primary Phone Number"), DisplayFormat(NullDisplayText = "Phone")]
        public string PersonPrimaryPhone { get; set; }

        [DisplayName("Apartment Number"), DisplayFormat(NullDisplayText = "Apt Number")]
        public string PersonAddressApt { get; set; }

        [DisplayName("Sreet Address"), DisplayFormat(NullDisplayText = "Street Address")]
        public string PersonAddressStreet { get; set; }

        [DisplayName("City"), DisplayFormat(NullDisplayText = "City")]
        public string PersonAddressCity { get; set; }

        [DisplayName("State"), DisplayFormat(NullDisplayText = "State")]
        public string PersonAddressState { get; set; }

        [DisplayName("Zip Code"), DisplayFormat(NullDisplayText = "Zip")]
        public string PersonAddressPostal { get; set; }

        [DisplayName("Password"), DisplayFormat(NullDisplayText = "Password")]
        public string PersonPlainPassword { get; set; }
    }
}