using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using StudentWebAPI.Models;
using StudentWebAPI.Repositories;
using StudentWebAPI.ViewModel;

namespace StudentWebAPI.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public StudentWithCourseViewModel GetStudentWithCourseDetails(int id)
        {
            var student = _studentRepository.Get(id);
            return student;
        }

        public IList<StudentWithCourseViewModel> GetStudentList(string search, string sortParams)
        {
            var students = _studentRepository.GetAll(search, sortParams);
            return students;
        }

        public void CreateStudent(Student student, HttpPostedFile image)
        {
            string imagePath = null;
            if (image != null && image.ContentLength > 0)
            {
                string fileName = DateTime.Now.ToString("yyMMddHHmmss-") + Path.GetFileName(image.FileName);
                var address = HttpContext.Current.Server.MapPath("~/Photos/");
                string path = Path.Combine(address, fileName);
                image.SaveAs(path);
                imagePath = Path.GetFileName(fileName);
            }
            student.Image = imagePath;
            _studentRepository.Insert(student);
        }

        public int UpdateStudent(int id, Student student, HttpPostedFile image, string prevImage)
        {
            if (image != null && image.ContentLength > 0)
            {
                string fileName = DateTime.Now.ToString("yyMMddHHmmss-") + Path.GetFileName(image.FileName);
                var address = HttpContext.Current.Server.MapPath("~/Photos/");
                string path = Path.Combine(address, fileName);
                image.SaveAs(path);
                string imagePath = Path.GetFileName(fileName);
                student.Image = imagePath;
            }
            else
            {
                student.Image = prevImage;
            }
            int updatedId = _studentRepository.Update(id, student);
            return updatedId;

        }

        public int DeleteStudent(int id)
        {
            int affectedRows = _studentRepository.Delete(id);
            return affectedRows;
        }
    }
}