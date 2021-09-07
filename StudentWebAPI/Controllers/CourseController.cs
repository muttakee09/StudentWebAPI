using StudentWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudentWebAPI.Services;

namespace StudentWebAPI.Controllers
{
    public class CourseController : ApiController
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        // GET: api/Course
        public IHttpActionResult Get()
        {
            var courses = _courseService.GetCourseList();
            return Ok(courses);
        }

        // GET: api/Course/5
        public IHttpActionResult Get(int id)
        {
            var course = _courseService.GetCourse(id);
            return Ok(course);
        }

        // POST: api/Course
        public IHttpActionResult Post([FromBody]Course course)
        {
            var dataContext = new PetaPoco.Database("studentdbstring");
            var newStudent = dataContext.Insert("courses", "Id", course);
            return Ok(newStudent);
        }

        // PUT: api/Course/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Course/5
        public void Delete(int id)
        {
        }
    }
}
