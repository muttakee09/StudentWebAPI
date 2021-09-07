using StudentWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentWebAPI.Services
{
    public interface ICourseService
    {
        IList<Course> GetCourseList();
        Course GetCourse(int id);
    }
}
