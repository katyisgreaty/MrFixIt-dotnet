using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MrFixIt.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MrFixIt.Controllers
{
    public class JobsController : Controller
    {
        private MrFixItContext db = new MrFixItContext();

        // GET: /<controller>/
        public IActionResult Index()
        {
            //On the index page you only view the jobs for that one worker?
            return View(db.Jobs.Include(i => i.Worker).ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Job job)
        {
            db.Jobs.Add(job);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Claim(int id)
        {
            var thisItem = db.Jobs.FirstOrDefault(items => items.JobId == id);
            return View(thisItem);
        }

        //Still In Progress -- check functionality (works like an edit page but just for one property) -- Change to AJAX!
        //Also, this will be similar to what the Complete and Pending functionality will be like 
        [HttpPost]
        public IActionResult Claim(Job job)
        {
            job.Worker = db.Workers.FirstOrDefault(i => i.UserName == User.Identity.Name);
            db.Entry(job).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Index(Job job)
        {
            job.Worker = db.Workers.FirstOrDefault(i => i.UserName == User.Identity.Name);
            db.Entry(job).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Activate(int id)
        {
            var currentJob = db.Jobs.FirstOrDefault(jobs => jobs.JobId == id);
            currentJob.Worker = db.Workers.FirstOrDefault(workers => workers.UserName == User.Identity.Name);

            currentJob.Worker.Avaliable = false;
            currentJob.Pending = true;

            db.Entry(currentJob).State = EntityState.Modified;
            db.SaveChanges();
            return Json(currentJob);
        }
    }
}
