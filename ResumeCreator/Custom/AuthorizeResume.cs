using ResumeCreator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
namespace ResumeCreator.Custom
{
    public class AuthorizeResume : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.ActionParameters.Keys.Contains("id"))
            {
                if (filterContext.ActionParameters["id"].ToString() != null)
                {
                   int id= Convert.ToInt32(filterContext.ActionParameters["id"].ToString());
                    string userid=filterContext.HttpContext.User.Identity.GetUserId().ToString();
                   using (var context = new ResumeCreatorEntities())
                   {
                      UserResume userresume= context.UserResumes.SingleOrDefault(u => u.PersonalId == id && u.UserId == userid);
                      if (userresume != null)
                      {
                          base.OnActionExecuting(filterContext);

                      }
                      else
                      {
                              filterContext.Result = new RedirectResult("~/Home/Index");

                          
                      }

                   }
                }
            }
            
           
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.Controller.ViewBag.CustomActionMessage2 = "Custom Action Filter: Message from OnActionExecuted method.";
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.CustomActionMessage3 = "Custom Action Filter: Message from OnResultExecuting method.";
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            filterContext.Controller.ViewBag.CustomActionMessage4 = "Custom Action Filter: Message from OnResultExecuted method.";
        }  
    }
}