using System.Collections.Generic;
using UniversityApps.Models;

namespace UniversityApps.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<UniversityApps.Models.UniversityDBcontext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(UniversityApps.Models.UniversityDBcontext context)
        {


            var semister = new List<Semester>

            {
                new Semester() { SemisterName = "1st"},
                new Semester() { SemisterName = "2nd"},
                new Semester() { SemisterName = "3rd"},
                new Semester() { SemisterName = "4th"},
                new Semester() { SemisterName = "5th"},
                new Semester() { SemisterName = "6th"},
                new Semester() { SemisterName = "7th"},
                new Semester() { SemisterName = "8th"}

            };

            semister.ForEach(s => context.Semesters.AddOrUpdate(s));
            context.SaveChanges();


            var designation = new List<Designation>
            {

                new Designation() {Name = "Chancellor"},
                new Designation() {Name = "Vic-Chancellor"},
                new Designation() {Name = "Professor"},
                new Designation() {Name = "Associate Professor"},
                new Designation() {Name = "Assistant Professor"},
                new Designation() {Name = "Lecturer"},
                new Designation() {Name = "Guest Lecturer"}
            };


            designation.ForEach(des => context.Designations.AddOrUpdate(des));
            context.SaveChanges();
        }
    }
}
