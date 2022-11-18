using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Webb_app_MVC_PostgreSQL_DAL.Modelos;

namespace Webb_app_MVC_PostgreSQl.Controllers
{
    public class Ejercicio : Controller
    {
        public List<EjemploAlumno> alumnos;
        public Webb_app_MVC_PostgreSQL_DAL.Modelos.AlumnosContext db = new Webb_app_MVC_PostgreSQL_DAL.Modelos.AlumnosContext();
        // GET: Ejercicio
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Alumnos()
        {
            var alumnos = db.EjemploAlumnos.ToList();
            return View(alumnos);
        }
        [HttpPost]
        public ActionResult Alumos(int IdAsignatura)
        {
            Console.WriteLine(IdAsignatura);
            EjemploAlumno alumno = db.EjemploAlumnos.Where(a => a.IdAsignatura == IdAsignatura).FirstOrDefault();
            if (alumno != null)
            {
                ViewBag.Asignatura = "Empleado:" + alumno.AlumnoNombre + "Con la asignatura: " + alumno.IdNavigation.NombreAsignatura;
            }
            return View(alumnos);
        }



    }
}
