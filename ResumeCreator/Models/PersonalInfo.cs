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
    
    public partial class PersonalInfo
    {
        public PersonalInfo()
        {
            this.Skills = new HashSet<Skill>();
            this.Educations = new HashSet<Education>();
            this.Summaries = new HashSet<Summary>();
            this.Experiences = new HashSet<Experience>();
            this.UserResumes = new HashSet<UserResume>();
        }
    
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip_code { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
    
        public virtual ICollection<Skill> Skills { get; set; }
        public virtual ICollection<Education> Educations { get; set; }
        public virtual ICollection<Summary> Summaries { get; set; }
        public virtual ICollection<Experience> Experiences { get; set; }
        public virtual ICollection<UserResume> UserResumes { get; set; }
    }
}
