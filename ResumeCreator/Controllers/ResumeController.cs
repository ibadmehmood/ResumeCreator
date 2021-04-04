using ResumeCreator.Models;
using SelectPdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.AspNet.Identity;
using ResumeCreator.Custom;
namespace ResumeCreator.Controllers
{
    [Authorize]
    //[AuthorizeResume]
    [ValidateInput(false)]
    public class ResumeController : Controller
    {
        //
        // GET: /get personal info/
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        //POST: /post Personal Info/
        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            using (ResumeCreatorEntities context = new ResumeCreatorEntities())
            {
                PersonalInfo p = new PersonalInfo()
                {
                    first_name = form["first_name"],
                    last_name = form["last_name"],
                    city = form["city"],
                    state = form["state"],
                    zip_code = form["zip_code"],
                    address = form["address"],
                    email = form["email"],
                    phone = form["phone"]
                };

                context.PersonalInfoes.Add(p);
                context.SaveChanges();
               
                
                UserResume userresume = new UserResume
                {
                    UserId = User.Identity.GetUserId().ToString(),
                    PersonalId = p.id
                };
                
                 context.UserResumes.Add(userresume);
                context.SaveChanges();
                return RedirectToAction("Experience", "Resume", new { id=p.id});
            }
            
        }

        public ActionResult Experience(int id)
        {
            ViewBag.resumeid = id;
            return View();
        }

        [HttpPost]
        public ActionResult Experience(FormCollection form)
        {
            using (ResumeCreatorEntities context = new ResumeCreatorEntities())
            {
                int id = Convert.ToInt32(form["resumeid"].ToString());
                string userid = User.Identity.GetUserId().ToString();
                UserResume userresume = context.UserResumes.SingleOrDefault(u => u.PersonalId == id && u.UserId == userid);
                if (userresume == null)
                {
                    return RedirectToAction("Index","Home");

                }
                Experience e = new Experience()
                {
                    PersonalInfo_id=Convert.ToInt32(form["resumeid"]),
                    employer=form["employer"],
                    job_title=form["job_title"],
                    city=form["city"],
                    state=form["state"],
                    start_date=form["start_date"],
                    end_date=form["end_date"],
                    description=form["description"]

                };
                context.Experiences.Add(e);
                context.SaveChanges();
                return RedirectToAction("ExperienceList", "Resume", new { id = e.PersonalInfo_id });
            }
        }
       

       
        [HttpGet]
        [Route("Resume/Experience/List/{id}",Name="ExperienceList")]
        public ActionResult ExperienceList(int id)
        {
            ViewBag.resumeid = id;
            using(var context= new ResumeCreatorEntities()){

                ExperienceListViewModel experienceListViewModel = new ExperienceListViewModel();
                experienceListViewModel.experiences = context.Experiences.Where(c => c.PersonalInfo_id == id).ToList<Experience>();
        
              
               return View(experienceListViewModel);
            }
            
            //return View("ExperienceList");
        }

       
        [HttpGet]
        public ActionResult Education(int id)
        {
            ViewBag.resumeid = id;
            return View();
        }

        [HttpPost]
        public ActionResult Education(FormCollection form)
        {
            using (ResumeCreatorEntities context = new ResumeCreatorEntities())
            {
                int id = Convert.ToInt32(form["resumeid"].ToString());
                string userid = User.Identity.GetUserId().ToString();
                UserResume userresume = context.UserResumes.SingleOrDefault(u => u.PersonalId == id && u.UserId == userid);
                if (userresume == null)
                {
                    return RedirectToAction("Index", "Home");

                }
                Education e = new Education()
                {
                   PersonalInfo_id=Convert.ToInt32(form["resumeid"]),
                   school_name=form["school_name"],
                   city=form["city"],
                   state=form["state"],
                   degree=form["degree"],
                   field_of_study=form["field_of_study"],
                   end_date=form["end_date"]

                };
                context.Educations.Add(e);
                context.SaveChanges();
                return RedirectToAction("EducationList", "Resume", new { id = e.PersonalInfo_id });
            }
        }

        [HttpGet]
        [Route("Resume/Education/List/{id}",Name="EducationList")]
        public ActionResult EducationList(int id)
        {
            ViewBag.resumeid = id;
            using (var context = new ResumeCreatorEntities())
            {

                EducationListViewModel educationListViewModel = new EducationListViewModel();
                educationListViewModel.educations = context.Educations.Where(c => c.PersonalInfo_id == id).ToList<Education>();


                return View(educationListViewModel);
            }
        }
        [HttpGet]
        public ActionResult Skill(int id)
        {
            ViewBag.resumeid = id;
            return View();
        }

        [HttpPost]
        public ActionResult Skill(FormCollection form)
        {
            using (ResumeCreatorEntities context = new ResumeCreatorEntities())
            {

                int id = Convert.ToInt32(form["resumeid"].ToString());
                string userid = User.Identity.GetUserId().ToString();
                UserResume userresume = context.UserResumes.SingleOrDefault(u => u.PersonalId == id && u.UserId == userid);
                if (userresume == null)
                {
                    return RedirectToAction("Index", "Home");

                }

            }
            
            using (ResumeCreatorEntities context = new ResumeCreatorEntities())
            {
                Skill s1 = new Skill()
                {
                    PersonalInfo_id = Convert.ToInt32(form["resumeid"]),
                    skill1=form["a"],
                    level=form["la"]
                 };
                Skill s2 = new Skill()
                {
                    PersonalInfo_id = Convert.ToInt32(form["resumeid"]),
                    skill1 = form["b"],
                    level = form["lb"]
                };
                Skill s3 = new Skill()
                {
                    PersonalInfo_id = Convert.ToInt32(form["resumeid"]),
                    skill1 = form["c"],
                    level = form["lc"]
                };
                Skill s4 = new Skill()
                {
                    PersonalInfo_id = Convert.ToInt32(form["resumeid"]),
                    skill1 = form["d"],
                    level = form["ld"]
                };
                Skill s5 = new Skill()
                {
                    PersonalInfo_id = Convert.ToInt32(form["resumeid"]),
                    skill1 = form["e"],
                    level = form["le"]
                };
                Skill s6 = new Skill()
                {
                    PersonalInfo_id = Convert.ToInt32(form["resumeid"]),
                    skill1 = form["f"],
                    level = form["lf"]
                };

                    context.Skills.Add(s1);
                    context.Skills.Add(s2);
                    context.Skills.Add(s3);
                    context.Skills.Add(s4);
                    context.Skills.Add(s5);
                    context.Skills.Add(s6);
                    context.SaveChanges();

                
               
               
                
                return RedirectToAction("Summary", "Resume", new { id = form["resumeid"] });
            }
            
        }


        [HttpGet]
        public ActionResult Summary(int id)
        {
            ViewBag.resumeid = id;
            return View();
        }


        [HttpPost]
        public ActionResult Summary(FormCollection form)
        {
            using (ResumeCreatorEntities context = new ResumeCreatorEntities())
            {
                int id = Convert.ToInt32(form["resumeid"].ToString());
                string userid = User.Identity.GetUserId().ToString();
                UserResume userresume = context.UserResumes.SingleOrDefault(u => u.PersonalId == id && u.UserId == userid);
                if (userresume == null)
                {
                    return RedirectToAction("Index", "Home");

                }
                Summary e = new Summary()
                {
                    PersonalInfo_id = Convert.ToInt32(form["resumeid"]),
                    text=form["summary"]

                };
                context.Summaries.Add(e);
                context.SaveChanges();
                return RedirectToAction("Review", "Resume", new { id = e.PersonalInfo_id });
            }
            
        }

        public ActionResult Review(int id)
        {
            ViewBag.resumeid = id;

            ResumeViewModel resumeViewModel = new ResumeViewModel();
             
            using(var context= new ResumeCreatorEntities())
            {
                var resume=context.PersonalInfoes.Include("Experiences").Include("Educations").Include("Skills")
                    .Include("Summaries").Where(p=>p.id==id);
                foreach(var r in resume){
                    resumeViewModel.personalinfo = r;
                    resumeViewModel.experiences = r.Experiences.ToList();
                    resumeViewModel.educations = r.Educations.ToList();
                    resumeViewModel.skills = r.Skills.ToList();
                    resumeViewModel.summary =r.Summaries.ToList();
                    
                }

                return View(resumeViewModel);
                
            }
            


           
        }
        [AllowAnonymous]
        public ActionResult Preview(int id)
        {
            ViewBag.resumeid = id;

            ResumeViewModel resumeViewModel = new ResumeViewModel();

            using (var context = new ResumeCreatorEntities())
            {
                var resume = context.PersonalInfoes.Include("Experiences").Include("Educations").Include("Skills")
                    .Include("Summaries").Where(p => p.id == id);
                foreach (var r in resume)
                {
                    resumeViewModel.personalinfo = r;
                    resumeViewModel.experiences = r.Experiences.ToList();
                    resumeViewModel.educations = r.Educations.ToList();
                    resumeViewModel.skills = r.Skills.ToList();
                    resumeViewModel.summary = r.Summaries.ToList();

                }

                return View(resumeViewModel);

            }

           
        }

        [HttpPost]
        public ActionResult Download(int id)
        {
            // read parameters from the webpage
           string url = Request.Url.Authority + "/Resume/Preview/" + id;

           // string url = "http://localhost:51547/Resume/Review/" + id;
            string pdf_page_size = "A4";
            PdfPageSize pageSize =
                (PdfPageSize)Enum.Parse(typeof(PdfPageSize), pdf_page_size, true);

            string pdf_orientation = "Portrait";
            PdfPageOrientation pdfOrientation =
                (PdfPageOrientation)Enum.Parse(typeof(PdfPageOrientation),
                pdf_orientation, true);

            int webPageWidth = 793;
          

            int webPageHeight = 1122;
            
          

            // instantiate a html to pdf converter object
            HtmlToPdf converter = new HtmlToPdf();

            // set converter options
            converter.Options.PdfPageSize = pageSize;
            converter.Options.PdfPageOrientation = pdfOrientation;
            converter.Options.WebPageWidth = webPageWidth;
            converter.Options.WebPageHeight = webPageHeight;

            // create a new pdf document converting an url
            PdfDocument doc = converter.ConvertUrl(url);

            // save pdf document
            byte[] pdf = doc.Save();

            // close pdf document
            doc.Close();

            // return resulted pdf document
            FileResult fileResult = new FileContentResult(pdf, "application/pdf");
            fileResult.FileDownloadName = id + "_Resume.pdf";
            return fileResult;
        }


        [Route("Resume/Personal/Edit/{id}")]
        public ActionResult PersonalEdit(int id)
        {
            ViewBag.resumeid = id;

            using (var context = new ResumeCreatorEntities())
            {
                PersonalInfo personal = context.PersonalInfoes.Single(p => p.id == id);
              

                return View(personal);
                
            }

            
        }
        [HttpPost]
        [Route("Resume/Personal/Edit/")]
        public ActionResult PersonalEdit(FormCollection form)
        {
            int id = Convert.ToInt32(form["resumeid"]);


            using (var context = new ResumeCreatorEntities())
            {

               
                string userid = User.Identity.GetUserId().ToString();
                UserResume userresume = context.UserResumes.SingleOrDefault(u => u.PersonalId == id && u.UserId == userid);
                if (userresume == null)
                {
                    return RedirectToAction("Index", "Home");

                }
                PersonalInfo personal = context.PersonalInfoes.Single(p => p.id == id);



                //personal.id = Convert.ToInt32(form["resumeid"]);
                personal.city = form["city"];
                personal.address = form["address"];
                personal.email = form["email"];
                personal.first_name = form["first_name"];
                personal.last_name = form["last_name"];
                personal.zip_code=form["zip_code"];
                personal.state = form["state"];
                personal.phone = form["phone"];
                
              
                context.SaveChanges();



                return RedirectToAction("Review", "Resume", new { id = id });

            }


        }

        [Route("Resume/Summary/Edit/{id}")]
        public ActionResult SummaryEdit(int id)
        {
            ViewBag.resumeid = id;

            using (var context = new ResumeCreatorEntities())
            {
                

                Summary summary = context.Summaries.Single(p => p.PersonalInfo_id == id);


                return View(summary);

            }


        }


        [HttpPost]
        [Route("Resume/Summary/Edit")]
        public ActionResult SummaryEdit(FormCollection form)
        {
            int id = Convert.ToInt32(form["resumeid"]);


            using (var context = new ResumeCreatorEntities())
            {
                
                string userid = User.Identity.GetUserId().ToString();
                UserResume userresume = context.UserResumes.SingleOrDefault(u => u.PersonalId == id && u.UserId == userid);
                if (userresume == null)
                {
                    return RedirectToAction("Index", "Home");

                }
                Summary summary = context.Summaries.Single(p => p.PersonalInfo_id == id);



                //personal.id = Convert.ToInt32(form["resumeid"]);
                summary.text = form["summary"];


                context.SaveChanges();



                return RedirectToAction("Review", "Resume", new { id = id });

            }


        }

        [Route("Resume/Employment/Edit/{id}")]
        public ActionResult ExperienceEditList(int id)
        {
            ViewBag.resumeid = id;
            using (var context = new ResumeCreatorEntities())
            {


                ExperienceListViewModel experienceListViewModel = new ExperienceListViewModel();
                experienceListViewModel.experiences = context.Experiences.Where(c => c.PersonalInfo_id == id).ToList<Experience>();


                return View(experienceListViewModel);
            }
            

        }


        [HttpPost]
        [Route("Resume/Experience/Edit/{resumeid}/{experienceid}")]
        public ActionResult ExperienceEdit(FormCollection form)
        {
            int resumeid = Convert.ToInt32(form["resumeid"]);
            int experienceid = Convert.ToInt32(form["experienceid"]);

            using (var context = new ResumeCreatorEntities())
            {
                int id = Convert.ToInt32(form["resumeid"].ToString());
                string userid = User.Identity.GetUserId().ToString();
                UserResume userresume = context.UserResumes.SingleOrDefault(u => u.PersonalId == id && u.UserId == userid);
                if (userresume == null)
                {
                    return RedirectToAction("Index", "Home");

                }
                Experience experience = context.Experiences.Single(p => p.PersonalInfo_id == resumeid && p.id == experienceid);
                experience.employer = form["employer"];
                experience.job_title = form["job_title"];
                experience.start_date = form["start_date"];
                experience.end_date = form["end_date"];
                experience.description = form["description"];
                experience.city = form["city"];
                experience.state = form["state"];


                context.SaveChanges();



                return RedirectToAction("Review", "Resume", new { id = resumeid });

            }


        }


       
        [Route("Resume/Experience/Edit/{resumeid}/{experienceid}")]
        public ActionResult ExperienceEdit(int resumeid,int experienceid)
        {



            using (var context = new ResumeCreatorEntities())
            {
                Experience experience = context.Experiences.Single(p => p.PersonalInfo_id == resumeid && p.id==experienceid);


                return View(experience);

            }


        }

        [HttpGet]
        [Route("Resume/Education/Edit/{id}")]
        public ActionResult EducationEditList(int id)
        {
            ViewBag.resumeid = id;
            using (var context = new ResumeCreatorEntities())
            {

                EducationListViewModel educationListViewModel = new EducationListViewModel();
                educationListViewModel.educations = context.Educations.Where(c => c.PersonalInfo_id == id).ToList<Education>();


                return View(educationListViewModel);
            }
        }

        [Route("Resume/Education/Edit/{resumeid}/{experienceid}")]
        public ActionResult EducationEdit(int resumeid, int experienceid)
        {



            using (var context = new ResumeCreatorEntities())
            {
                Education experience = context.Educations.Single(p => p.PersonalInfo_id == resumeid && p.id == experienceid);


                return View(experience);

            }


        }

        [HttpPost]
        [Route("Resume/Education/Edit/{resumeid}/{educationid}")]
        public ActionResult EducationEdit(FormCollection form)
        {
            int resumeid = Convert.ToInt32(form["resumeid"]);
            int educationid = Convert.ToInt32(form["educationid"]);

            using (var context = new ResumeCreatorEntities())
            {
                int id = Convert.ToInt32(form["resumeid"].ToString());
                string userid = User.Identity.GetUserId().ToString();
                UserResume userresume = context.UserResumes.SingleOrDefault(u => u.PersonalId == id && u.UserId == userid);
                if (userresume == null)
                {
                    return RedirectToAction("Index", "Home");

                }
                Education education = context.Educations.Single(p => p.PersonalInfo_id == resumeid && p.id == educationid);
                education.state = form["state"];
                education.school_name = form["school_name"];
                education.field_of_study = form["field_of_study"];
                education.degree = form["degree"];
                education.end_date = form["end_date"];
                education.city = form["city"];
          
                context.SaveChanges();



                return RedirectToAction("Review", "Resume", new { id = resumeid });

            }


        }

        [HttpGet]
        [Route("Resume/Skill/Edit/{resumeid}")]
        public ActionResult SkillEdit(int resumeid)
        {


            ViewBag.resumeid = resumeid;
            using (var context = new ResumeCreatorEntities())
            {
                List<Skill> experience = context.Skills.Where(p => p.PersonalInfo_id == resumeid).ToList<Skill>();


                return View(experience);

            }


        }
        [HttpPost]
        [Route("Resume/Skill/Edit/{resumeid}")]
        public ActionResult SkillEdit(FormCollection form)
        {
            int resumeid=Convert.ToInt32(form["resumeid"]);
            int aid=Convert.ToInt32(form["aid"]);
            int bid=Convert.ToInt32(form["bid"]);
            int cid=Convert.ToInt32(form["cid"]);
            int did=Convert.ToInt32(form["did"]);
            int eid=Convert.ToInt32(form["eid"]);
            int fid=Convert.ToInt32(form["fid"]);
            using (ResumeCreatorEntities context = new ResumeCreatorEntities())
            {
                int id = Convert.ToInt32(form["resumeid"].ToString());
                string userid = User.Identity.GetUserId().ToString();
                UserResume userresume = context.UserResumes.SingleOrDefault(u => u.PersonalId == id && u.UserId == userid);
                if (userresume == null)
                {
                    return RedirectToAction("Index", "Home");

                }
                Skill s1 =context.Skills.SingleOrDefault(s=>s.PersonalInfo_id==resumeid && s.id==aid);
                if(s1!=null)
                {
                   
                    s1.skill1 = form["a"];
                    s1.level = form["la"];
                }
                Skill s2 =context.Skills.SingleOrDefault(s=>s.PersonalInfo_id==resumeid && s.id==bid);
                if (s2 != null)
                {
                   
                    s2.skill1 = form["b"];
                    s2.level = form["lb"];
                }
                Skill s3 =context.Skills.SingleOrDefault(s=>s.PersonalInfo_id==resumeid && s.id==cid);
                if (s3 != null)
                {
                    
                    s3.skill1 = form["c"];
                    s3.level = form["lc"];
                }
                Skill s4 = context.Skills.SingleOrDefault(s=>s.PersonalInfo_id==resumeid && s.id==did);
                if (s4 != null)
                {
                    
                    s4.skill1 = form["d"];
                    s4.level = form["ld"];
                }
                Skill s5 = context.Skills.SingleOrDefault(s=>s.PersonalInfo_id==resumeid && s.id==eid);
                if (s5 != null)
                {
                    
                    s5.skill1 = form["e"];
                    s5.level = form["le"];
                };
                Skill s6 = context.Skills.SingleOrDefault(s=>s.PersonalInfo_id==resumeid && s.id==fid);
                if (s6 != null)
                {
                  
                    s6.skill1 = form["f"];
                    s6.level = form["lf"];
                };

               
                context.SaveChanges();





                return RedirectToAction("Review", "Resume", new { id = resumeid });
            }
        }



	}
}