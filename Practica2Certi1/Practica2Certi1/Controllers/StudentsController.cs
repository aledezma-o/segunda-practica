using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practica2Certi1.Controllers
{
    [ApiController]
    [Route("[/api/students]")]
    public class WeatherForecastController : ControllerBase
    {
        public WeatherForecastController()
        {
        }

        [HttpPost]
        public Student CreatePerson([FromBody] string studentName) // a. Create User
        {
            return new Student() 
            { 
                NombreDePila = studentName
            };
        }

        [HttpPut]
        public Student UpdateStudent([FromBody] Student student, List<Student> lista) // b. Update User
        {
            foreach(Student s in lista)
                if(student == s)
                    s.NombreDePila = "actualizado";

            return student;
        }

        [HttpDelete]
        public Student DeletePerson([FromBody] Student student, List<Student> lista) // c. Delete User
        {
            if (lista.Contains(student))
                lista.Remove(student);

            return student;
        }

        [HttpGet]
        public List<Student> GetStudents() // d. Get User
        {
            List<Student> estudiantes = new List<Student>();
            LlenarListaDeEstudiantes(estudiantes);
            return estudiantes;
        }
        public void LlenarListaDeEstudiantes(List<Student> lista) 
        {
            // metodo auxiliar para agregar estudiantes hardcodeados
            Student a = new Student(); 
            a.NombreDePila = "Frank"; a.Apellido1 = "Sinatra"; 
            a.codigo = 1; a.carrera = "Derecho";
            Student b = new Student();
            b.NombreDePila = "Omar"; b.Apellido1 = "Banos"; 
            b.codigo = 2; b.carrera = "Administracion de Empresas";
            Student c = new Student();
            c.NombreDePila = "George"; c.Apellido1 = "Kusonoki"; 
            c.codigo = 3; c.carrera = "ISC";

            lista.Add(a);
            lista.Add(b);
            lista.Add(c);
        }
    }
}
