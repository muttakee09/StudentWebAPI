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
        [Display(Name = "Student Id")]
        public int Id { get; set; }
        [Display(Name = "Student Name")]
        public string StudentName { get; set; }
        [Range(0, 200)]
        public int Age { get; set; }
        [Display(Name = "Blood Group")]
        public int BloodGroup { get; set; }
        public int Gender { get; set; }
        public string Image { get; set; }
        [Display(Name = "Main course")]
        public int? MainCourse { get; set; }
        [ForeignKey("SupplementaryCourse"), Display(Name = "Supplementary course")]
        public int? SupplementaryCourse { get; set; }

        public Student() { }

        /*public Student(string studentName, int age, BloodGroupType bloodGroup,
           GenderType gender, string image, int mainCourseEntity, int supplementaryCourseEntity)
        {
            StudentName = studentName;
            Age = age;
            BloodGroup = bloodGroup;
            Gender = gender;
            Image = image;
            MainCourse = mainCourseEntity;
            SupplementaryCourse = supplementaryCourseEntity;
        }*/

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