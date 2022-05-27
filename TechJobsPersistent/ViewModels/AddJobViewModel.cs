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

        [Required(ErrorMessage = "Employer is required")]
        public int EmployerId { get; set; }

        [Required(ErrorMessage = "Atleast one skill is required")]
        public int SkillId { get; set; }

        public List<SelectListItem> Employers { get; set; }

        public List<SelectListItem> Skill { get; set; }

        public AddJobViewModel(List<Employer> employers, List<Skill> skills)
        {
            Employers = new List<SelectListItem>();

            foreach (var employer in employers)
            {
                Employers.Add(new SelectListItem
                {
                    Value = employer.Id.ToString(),
                    Text = employer.Name
                });

            }

            Skill = new List<SelectListItem>();

            foreach (var skill in skills)
            {
                Skill.Add(new SelectListItem
                {
                    Value = skill.Id.ToString(),
                    Text = skill.Name
                });

            }

        }

        public AddJobViewModel()
        {
        }
    }
}

