using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResumeCreator.Models
{
    public class PersonalInfoViewModel
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip_code { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
    }
}