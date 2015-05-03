using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityApps.Models
{
    public class University
    {
        [Key]
        public int UniversityId { get; set; }

        public int DepartmentId { set; get; }
        public int TeacherId { get; set; }
        public int StudentId { set; get; }
        public int CourseId { set; get; } 
        public virtual ICollection<Department> Departments { set; get; }
        public virtual ICollection<Student> Students { set; get; }
        public virtual ICollection<Teacher> Teachers { set; get; }
        public virtual ICollection<Course> Courses { set; get; }  
    }
}