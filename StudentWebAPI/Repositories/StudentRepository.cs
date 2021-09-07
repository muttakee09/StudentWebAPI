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
        public void Insert(Student student)
        {
            var dataContext = new PetaPoco.Database("studentdbstring");
            dataContext.Insert("students", "Id", student);
        }

        public int Update(int id, Student student)
        {
            var dataContext = new PetaPoco.Database("studentdbstring");
            int updatedId = dataContext.Update("students", "Id", student, id);
            return updatedId;
        }

        public IList<Student> GetAll()
        {
            var dataContext = new PetaPoco.Database("studentdbstring");
            var students = dataContext.Query<Student>("SELECT * FROM Students").ToList();
            return students;

        }

        public StudentWithCourseViewModel Get(int id)
        {
            var dataContext = new PetaPoco.Database("studentdbstring");
            var student = dataContext.Fetch<StudentWithCourseViewModel>(
                "SELECT s.Id, s.StudentName, s.Age, s.BloodGroup, s.Gender, s.Image, " +
                "c1.Id AS MainCourse, c1.CourseName AS MainCourseName, c2.Id AS SupplementaryCourse, c2.CourseName AS SupplementaryCourseName FROM Students s " +
                "LEFT OUTER JOIN Courses c1 ON s.MainCourse = c1.Id " +
                "LEFT OUTER JOIN Courses c2 ON s.SupplementaryCourse = c2.Id " +
                " WHERE s.Id=@0", id).SingleOrDefault();
            return student;
        }

        public int Delete(int id)
        {
            var dataContext = new PetaPoco.Database("studentdbstring");
            int affectedRows = dataContext.Delete("students", "Id", null, id);
            return affectedRows;
        }
    }
}