using StudentWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentWebAPI.ViewModel
{
    public class StudentWithCourseViewModel
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }
        public int BloodGroup { get; set; }
        public int Gender { get; set; }
        public string Image { get; set; }
        public int? MainCourse { get; set; }
        public string MainCourseName { get; set; }
        public int? SupplementaryCourse { get; set; }
        public string SupplementaryCourseName { get; set; }
    }
}