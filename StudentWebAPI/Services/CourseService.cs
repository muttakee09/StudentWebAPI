using StudentWebAPI.Models;
using StudentWebAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentWebAPI.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public Course GetCourse(int id)
        {
            var course = _courseRepository.Get(id);
            return course;
        }

        public IList<Course> GetCourseList()
        {
            var courses = _courseRepository.GetAll();
            return courses;
        }
    }
}