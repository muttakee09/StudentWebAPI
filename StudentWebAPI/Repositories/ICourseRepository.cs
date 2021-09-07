using StudentWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentWebAPI.Repositories
{
    public interface ICourseRepository
    {
        IList<Course> GetAll();
        Course Get(int id);
    }
}
