using StudentWebAPI.Models;
using StudentWebAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentWebAPI.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly PetaPoco.Database _dataContext;

        public StudentRepository()
        {
            _dataContext = new PetaPoco.Database("studentdbstring");
        }
        public void Insert(Student student)
        {
            _dataContext.Insert("students", "Id", student);
        }

        public int Update(int id, Student student)
        {
            int updatedId = _dataContext.Update("students", "Id", student, id);
            return updatedId;
        }

        public IList<StudentWithCourseViewModel> GetAll()
        {
            var students = _dataContext.Query<StudentWithCourseViewModel>(
                @"SELECT s.Id, s.StudentName, s.Age, s.BloodGroup, s.Gender, s.Image,
                c1.Id AS MainCourse, c1.CourseName AS MainCourseName, c2.Id AS SupplementaryCourse, c2.CourseName AS SupplementaryCourseName FROM Students s 
                LEFT JOIN Courses c1 ON s.MainCourse = c1.Id 
                LEFT JOIN Courses c2 ON s.SupplementaryCourse = c2.Id").ToList();
            return students;
        }

        public StudentWithCourseViewModel Get(int id)
        {
            var student = _dataContext.Fetch<StudentWithCourseViewModel>(
                @"SELECT s.Id, s.StudentName, s.Age, s.BloodGroup, s.Gender, s.Image, 
                c1.Id AS MainCourse, c1.CourseName AS MainCourseName, c2.Id AS SupplementaryCourse, c2.CourseName AS SupplementaryCourseName FROM Students s 
                LEFT JOIN Courses c1 ON s.MainCourse = c1.Id 
                LEFT JOIN Courses c2 ON s.SupplementaryCourse = c2.Id 
                WHERE s.Id=@0", id).SingleOrDefault();
            return student;
        }

        public int Delete(int id)
        {
            int affectedRows = _dataContext.Delete("students", "Id", null, id);
            return affectedRows;
        }
    }
}