using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TechJobsPersistent.Models;
using TechJobsPersistent.ViewModels;
using TechJobsPersistent.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace TechJobsPersistent.Controllers
{
    public class HomeController : Controller
    {
        private JobDbContext context;

        public HomeController(JobDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<Job> jobs = context.Jobs.Include(j => j.Employer).ToList();
            return View(jobs);
        }

        [HttpGet("/Add")]
        public IActionResult AddJob()
        {
            List<Skill> skills = context.Skills.ToList();
            ViewBag.skills = context.Skills.ToList();
            List<Employer> employers = context.Employers.ToList();
            AddJobViewModel viewModel = new AddJobViewModel(employers,skills);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult ProcessAddJobForm(AddJobViewModel addJobViewModel, AddJobSkillViewModel addJobskillViewModel, string [] selectedSkills)
        {
            if (ModelState.IsValid)
            {

                int jobId = addJobskillViewModel.JobId;
                //int skillId = addJobskillViewModel.SkillId;
                Employer employer = context.Employers.Find(addJobViewModel.EmployerId);
                Job newJob = new Job
                {
                    Name = addJobViewModel.Name,
                    Employer = employer
                };

                //selectedskills loop
                foreach (string skillSkill in selectedSkills)
                {
                    int skillId = int.Parse(skillSkill);
                    JobSkill jobSkill = new JobSkill
                    {
                        JobId = jobId,
                        SkillId = skillId
                    };
                    context.JobSkills.Add(jobSkill);
                }

                context.Jobs.Add(newJob);
                context.SaveChanges();
                return Redirect("Index");
            }

            List<Skill> skills = context.Skills.ToList();
            List<Employer> employers = context.Employers.ToList();
            AddJobViewModel viewModel = new AddJobViewModel(employers, skills);
            return View("AddJob", viewModel);
        }

        public IActionResult Detail(int id)
        {
            Job theJob = context.Jobs
                .Include(j => j.Employer)
                .Single(j => j.Id == id);

            List<JobSkill> jobSkills = context.JobSkills
                .Where(js => js.JobId == id)
                .Include(js => js.Skill)
                .ToList();

            JobDetailViewModel viewModel = new JobDetailViewModel(theJob, jobSkills);
            return View(viewModel);
        }
    }
}
