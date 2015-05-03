using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityApps.Models
{
    public class Semester
    {
        [Key]
        public int SemisterId { get; set; }
        public string SemisterName { get; set; }
    }
}