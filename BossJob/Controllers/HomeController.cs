using BossJob.Context;
using BossJob.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BossJob.Controllers
{
    public class HomeController : Controller
    {
        JobContext db = new JobContext();
       
        public ActionResult Index()
        {
            if(TempData["message"]!= null)
            {
                ViewBag.Message = TempData["message"].ToString();
                TempData.Remove("message");
            }
           
            return View(db.Jobs.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file, int id)
        {
            int count = 0;
            if (file != null && file.ContentLength > 0 & id > 0)
            {
                var filename = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/App_Data/uploads/cv"), filename);
                file.SaveAs(path);

                CV mycv = new CV();
                mycv.JobId = id;
                mycv.CVLoc ="~/App_Data/uploads/cv/"+filename;
                db.CVs.Add(mycv);
                db.SaveChanges();
                TempData["message"] = "Your C.V has been uploaded";
                count += 1;
            }

            if (count == 0) {
                TempData["message"] = "Sorry Something went wrong";
            } 

           
  
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteJob(int id)
        {
            Job job;
            job = db.Jobs.Where(d => d.JobId == id).First();
            db.Jobs.Remove(job);
            db.SaveChanges();


            return RedirectToAction("Index");
        }

        
        [HttpPost]
        public ActionResult EditJob(int id,string jobName, string jobDesc, string jobDate)
        {
            Job job;
            job = db.Jobs.Where(d => d.JobId == id).First();
            job.JobName = jobName;
            job.JobDesc = jobDesc;
            job.JobExpire = jobDate;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        /// <summary>
        /// This will allow the user to login
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SignIn(string username, string password)
        {
            Job job;
            job = db.Jobs.Where(d => d.JobId == id).First();
            db.Jobs.Remove(job);
            db.SaveChanges();


            return RedirectToAction("Index");
        }

    }
}