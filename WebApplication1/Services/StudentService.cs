using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;


using WebApplication1.Entities;
using WebApplication1.Helpers;

namespace WebApplication1.Services
{

    public interface IStudentService
    {        
        IEnumerable<Student> GetAll();
        Student GetById(int id);
        IList<Person> GetAllPersons();
    }

    public class StudentService : IStudentService
    {
        private DataContext _context;

        public StudentService(DataContext context)
        {
            _context = context;
        }
        

        public IEnumerable<Student> GetAll()
        {
            return _context.Students.Include(s=>s.Enrollment).ThenInclude(e => e.Course);
                
        }

        public Student GetById(int id)
        {
            return _context.Students.Find(id);
        } 
        
        public IList<Person> GetAllPersons()
        {
            return _context.Person.ToList<Person>();
        }





    }   
}
