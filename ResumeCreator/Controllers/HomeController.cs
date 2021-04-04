using ResumeCreator.Models;
using SelectPdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResumeCreator.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        
        public string About()
        {
            ViewBag.Message = "Your application description page.";

            using (ResumeCreatorEntities context = new ResumeCreatorEntities())
            {
                PersonalInfo p=new PersonalInfo(){
                    first_name="Ibad",
                    last_name="Ullah",
                    city="Peshawar",
                    state="KPK",
                    zip_code="25000",
                    address="Gulabahar # 3,Rasheed Town",
                    email="ibadkhogyani@gmail.com",
                    phone="03143005033"
                };
                context.PersonalInfoes.Add(p);
                context.SaveChanges();
                return p.id +" ";
            }

            
        }
        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        
        [HttpGet]
        
        public ActionResult getPDF()
        {
            // read parameters from the webpage
            string htmlString = @"<html><body><h1>Pakistan</h1></body></html>";
            string baseUrl = "";

            string pdf_page_size = "A4";
            PdfPageSize pageSize = (PdfPageSize)Enum.Parse(typeof(PdfPageSize),
                pdf_page_size, true);

            string pdf_orientation = "Portrait";
            PdfPageOrientation pdfOrientation =
                (PdfPageOrientation)Enum.Parse(typeof(PdfPageOrientation),
                pdf_orientation, true);

            int webPageWidth = 1024;
            try
            {
                webPageWidth = Convert.ToInt32("1024");
            }
            catch { }

            int webPageHeight = 0;
            try
            {
                webPageHeight = Convert.ToInt32("1024");
            }
            catch { }

            // instantiate a html to pdf converter object
            HtmlToPdf converter = new HtmlToPdf();

            // set converter options
            converter.Options.PdfPageSize = pageSize;
            converter.Options.PdfPageOrientation = pdfOrientation;
            converter.Options.WebPageWidth = webPageWidth;
            converter.Options.WebPageHeight = webPageHeight;

            // create a new pdf document converting an url
            PdfDocument doc = converter.ConvertHtmlString(htmlString, baseUrl);

            // save pdf document
            byte[] pdf = doc.Save();

            // close pdf document
            doc.Close();

            // return resulted pdf document
            FileResult fileResult = new FileContentResult(pdf, "application/pdf");
            fileResult.FileDownloadName = "Document.pdf";
            return fileResult;

        }

        [HttpGet]
        public ActionResult ResumeView()
        {
            
            return View();
        }

        [HttpGet]
        public ActionResult Real()
        {

            return View();
        }

    }
}