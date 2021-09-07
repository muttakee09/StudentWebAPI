using StudentWebAPI.Models;
using StudentWebAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace StudentWebAPI.Repositories
{
    public interface IStudentRepository
    {
        IList<Student> GetAll();
        StudentWithCourseViewModel Get(int id);
        void Insert(Student student);
        int Update(int id, Student student);
        int Delete(int id);
    }
}
