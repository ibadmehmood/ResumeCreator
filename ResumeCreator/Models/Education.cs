//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ResumeCreator.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Education
    {
        public int id { get; set; }
        public string school_name { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string degree { get; set; }
        public string field_of_study { get; set; }
        public string end_date { get; set; }
        public int PersonalInfo_id { get; set; }
    
        public virtual PersonalInfo PersonalInfo { get; set; }
    }
}
