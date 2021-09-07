using StudentWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using System.Web;
using System.Web.Mvc;
using StudentWebAPI.ViewModel;
using StudentWebAPI.Services;

namespace StudentWebAPI.Controllers
{
    public class StudentController : ApiController
    {
        private readonly IStudentService _studentServices;

        public StudentController(IStudentService studentService)
        {
            _studentServices = studentService;
        }
        /*public IHttpActionResult UploadImage()
        {
            var httpRequest = HttpContext.Current.Request;
            var file = HttpContext.Current.Request.Files.Count > 0 ?
        HttpContext.Current.Request.Files[0] : null;
            var filePath = HttpContext.Current.Server.MapPath("~/Photos/" + file.FileName);
            file.SaveAs(filePath);
            return Ok(filePath);
        }*/
        // GET: api/Student
        public IHttpActionResult Get()
        {
            try
            {
                IList<Student> students = _studentServices.GetStudentList();
                return Ok(students);
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
        }
        // GET: api/Student/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                StudentWithCourseViewModel student = _studentServices.GetStudentWithCourseDetails(id);
                return Ok(student);
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

        // GET: api/Student/details/5

        // POST: api/Student
        public IHttpActionResult Post()
        {
            var image = HttpContext.Current.Request.Files.Count > 0 ?
                HttpContext.Current.Request.Files[0] : null;
            try
            {
                var name = HttpContext.Current.Request.Form["StudentName"];
                var age = HttpContext.Current.Request.Form["Age"];
                var bloodGroup = HttpContext.Current.Request.Form["BloodGroup"];
                var gender = HttpContext.Current.Request.Form["Gender"];
                int? mainCourse = int.TryParse(
                    s: HttpContext.Current.Request.Form["MainCourse"], out int i) ? i : (int?)null;
                int? supplementaryCourse = int.TryParse(
                    s: HttpContext.Current.Request.Form["SupplementaryCourse"], out int j) ? j : (int?)null;
                Student newStudent = new Student(
                    name, int.Parse(age), int.Parse(bloodGroup), int.Parse(gender), null,
                    mainCourse,
                    supplementaryCourse);
                _studentServices.CreateStudent(newStudent, image);
                return Ok("New Student Created");
            }
            catch (Exception e)
            {
                return InternalServerError();
            }

        }

        // PUT: api/Student/5
 
        public IHttpActionResult Put(int id)
        {
            try
            {
                var image = HttpContext.Current.Request.Files.Count > 0 ?
                HttpContext.Current.Request.Files[0] : null;
                var name = HttpContext.Current.Request.Form["StudentName"];
                var age = HttpContext.Current.Request.Form["Age"];
                var bloodGroup = HttpContext.Current.Request.Form["BloodGroup"];
                var gender = HttpContext.Current.Request.Form["Gender"];
                var prevImage = HttpContext.Current.Request.Form["Image"];
                prevImage = prevImage == "null" ? null : prevImage;
                int? mainCourse = int.TryParse(
                    s: HttpContext.Current.Request.Form["MainCourse"], out int i) ? i : (int?)null;
                int? supplementaryCourse = int.TryParse(
                    s: HttpContext.Current.Request.Form["SupplementaryCourse"], out int j) ? j : (int?)null;
                Student newStudent = new Student(
                    name, int.Parse(age), int.Parse(bloodGroup), int.Parse(gender), prevImage,
                    mainCourse, supplementaryCourse);
                int updatedId = _studentServices.UpdateStudent(id, newStudent, image, prevImage);
                return Ok($"Student {updatedId} updated.");
            }
            catch(Exception e)
            {
                return InternalServerError();
            }
        }

        // DELETE: api/Student/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                int affectedRows = _studentServices.DeleteStudent(id);
                if (affectedRows > 0)
                {
                    return Ok($"Student with Id {id} deleted.");
                }
                else
                {  
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
            
        }

    }
}
