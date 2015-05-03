using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UniversityApps.Models
{
    public class UniversityDBcontext:DbContext
    {
        public UniversityDBcontext() : base("UniversityAppcontext")
        {
            
        }
        public DbSet<Student> Students { set; get; }
        public DbSet<Department> Departments { set; get; }
        public DbSet<Course> Courses { set; get; }
        public DbSet<Teacher> Teachers { set; get; }
       
        public DbSet<Semester> Semesters { set; get; }
        public DbSet<Designation> Designations { set; get; }
        public DbSet<AssignCourse> AssignCourses { get; set; }

        public System.Data.Entity.DbSet<UniversityApps.Models.RoomAllocation> RoomAllocations { get; set; }

        public System.Data.Entity.DbSet<UniversityApps.Models.Day> Days { get; set; }

        public System.Data.Entity.DbSet<UniversityApps.Models.Room> Rooms { get; set; }

       

       

       

    }
}