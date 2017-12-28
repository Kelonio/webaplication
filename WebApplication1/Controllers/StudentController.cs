using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Entities;
using AutoMapper;
using WebApplication1.Services;
using Microsoft.Extensions.Options;
using WebApplication1.Helpers;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private IStudentService _studentService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public StudentController(
            IStudentService studentService,
            IMapper mapper,
            IOptions<AppSettings> appSettings
        )
        {

            _studentService = studentService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        
        [HttpGet("[action]")]
        public IActionResult List()
        {

            /* esto no pirula , creo que es porque es un map de una clase heredada */
            /*
            var users = _userService.GetAll();
            var userDtos = _mapper.Map<IList<UserDto>>(users);
            return Ok(userDtos);
            */




            var students = _studentService.GetAll().ToList();
            return Ok(students);        
            
        }


        private static string[] SimpleStudents = new[]
        {
            "Juan", "Pedro", "Ana", "Andres"
        };

        [HttpGet("[action]")]
        public IEnumerable<SimpleStudent> SimpleStudentList()
        {

            return Enumerable.Range(0, 3).Select(index => new SimpleStudent
            {
                nombre = SimpleStudents[index]
            });
        }

        public class SimpleStudent
        {  
            public string nombre { get; set; }           
        }



    }


}
