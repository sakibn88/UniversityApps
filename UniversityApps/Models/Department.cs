using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityApps.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Department code can't be empty")]
        [Remote("CheckDepartmentName", "Departments", ErrorMessage = "Department code already exist")]
        [Display(Name = "Department Code")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Department name can't be empty")]
        [Remote("CheckDepartmentName", "Departments", ErrorMessage = "This department name already exist")]
        [Display(Name = "Department Name")]
        public string Name { get; set; }
        public virtual List<Course> CoursesList { get; set; }
        public virtual List<Teacher> TeachersList { get; set; }
        
    }
}