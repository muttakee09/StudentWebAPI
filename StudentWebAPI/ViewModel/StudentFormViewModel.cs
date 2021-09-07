using StudentWebAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace StudentWebAPI.ViewModel
{
    public class StudentFormViewModel
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }
        public int BloodGroup { get; set; }
        public int Gender { get; set; }
        public HttpPostedFileBase Image { get; set; }
        public int? MainCourse { get; set; }
        public int? SupplementaryCourse { get; set; }
    }
}