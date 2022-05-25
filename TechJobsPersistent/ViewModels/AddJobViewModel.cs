using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechJobsPersistent.Models;



namespace TechJobsPersistent.ViewModels
{
    public class AddJobViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        //[Required(ErrorMessage = "Employer Id is required")]
        public int EmployerId { get; set; }

        public List<SelectListItem> Employers { get; set; }

        public AddJobViewModel(string name)
        {
            Name = name;
        }

        public AddJobViewModel()
        {
        }
    }
}
//public AddJobSkillViewModel(Job theJob, List<Skill> possibleSkills)
//{
//    Skills = new List<SelectListItem>();

//    foreach (var skill in possibleSkills)
//    {
//        Skills.Add(new SelectListItem
//        {
//            Value = skill.Id.ToString(),
//            Text = skill.Name
//        });
//    }

//    Job = theJob;
//}