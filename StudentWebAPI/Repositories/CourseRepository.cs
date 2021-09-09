using StudentWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentWebAPI.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly PetaPoco.Database _dataContext;

        public CourseRepository()
        {
            _dataContext = new PetaPoco.Database("studentdbstring");
        }
        public Course Get(int id)
        {
            var course = _dataContext.Single<Course>(
                "Select Id, CourseName, CourseCredit, CourseCode FROM Courses WHERE Id = @0", id);
            return course;
        }

        public IList<Course> GetAll()
        {
            var courses = _dataContext.Query<Course>(
                "Select Id, CourseName, CourseCredit, CourseCode FROM Courses").ToList();
            return courses;
        }
    }
}