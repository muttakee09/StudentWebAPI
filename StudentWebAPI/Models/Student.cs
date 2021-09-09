using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentWebAPI.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }
        public int BloodGroup { get; set; }
        public int Gender { get; set; }
        public string Image { get; set; }
        public int? MainCourse { get; set; }
        public int? SupplementaryCourse { get; set; }

        public Student() { }

        public Student(string studentName, int age, int bloodGroup,
           int gender, string image, int? mainCourseEntity, int? supplementaryCourseEntity)
        {
            StudentName = studentName;
            Age = age;
            BloodGroup = bloodGroup;
            Gender = gender;
            Image = image;
            MainCourse = mainCourseEntity;
            SupplementaryCourse = supplementaryCourseEntity;
        }
    }
}