using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResumeCreator.Models
{
    public class ResumeViewModel
    {
       public PersonalInfo personalinfo { get; set; }
       public IList<Education> educations { get; set; }
       public IList<Experience> experiences { get; set; }
       public IList<Skill> skills { get; set; }
       public IList<Summary> summary{get;set;}
    }
}