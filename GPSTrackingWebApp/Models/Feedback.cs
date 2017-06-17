using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using GPSTrackingWebApp.Models;
using System.ComponentModel.DataAnnotations;

namespace GPSTrackingWebApp.Models
{
//    [MetadataType(typeof(Feedback))]
  //  public partial class personaltracking
   // {
    //}
    public class Feedback
    {
        public string pid { get; set; }

        public string pname { get; set; }

       //  [Remote("Personal", "Personal", ErrorMessage = "User name already exists. Please enter a different user name.")]
         public string email { get; set; }

        public string password { get; set; }

        public string repassword { get; set; }

        public string contact { get; set; }

        public string rcontact1 { get; set; }

        public string rcontact2 { get; set; }

        public string rcontact3 { get; set; }

        public string rcontact4 { get; set; }

        public string pimg { get; set; }

    }
}