﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using StudentWebAPI.Models;
using StudentWebAPI.ViewModel;

namespace StudentWebAPI.Services
{
    public interface IStudentService
    {
        IList<Student> GetStudentList();
        StudentWithCourseViewModel GetStudentWithCourseDetails(int id);
        void CreateStudent(Student student, HttpPostedFile image);
        int UpdateStudent(int id, Student student, HttpPostedFile image, string prevImage);
        int DeleteStudent(int id);
    }
}