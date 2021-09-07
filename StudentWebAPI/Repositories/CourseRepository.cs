using StudentWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentWebAPI.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        public Course Get(int id)
        {
            var dataContext = new PetaPoco.Database("studentdbstring");
            var course = dataContext.Single<Course>("Select * FROM Courses WHERE Id = @0", id);
            return course;
        }

        public IList<Course> GetAll()
        {
            var dataContext = new PetaPoco.Database("studentdbstring");
            var courses = dataContext.Query<Course>("Select * from Courses").ToList();
            return courses;
        }
    }
}