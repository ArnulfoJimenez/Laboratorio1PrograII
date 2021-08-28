using Lab1PrograII.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab1PrograII.Controllers
{
    public class NotasController : Controller
    {
        // GET: Notas
        public ActionResult Index()
        {

            using (EstudianteEntities estudiante = new EstudianteEntities())
            {
                var listaestudiante = estudiante.Tbl_NotasEstudiante.ToList();

                return View(listaestudiante);
            }

        }


        [HttpPost]

        public ActionResult Resultado(String Nombre, String Lab1, String Lab2, String Lab3, String Par1, String Par2, String Par3)

        {
            int L1 = Convert.ToInt32(Lab1);
            int L2 = Convert.ToInt32(Lab2);
            int L3 = Convert.ToInt32(Lab3);
            int P1 = Convert.ToInt32(Par1);
            int P2 = Convert.ToInt32(Par2);
            int P3 = Convert.ToInt32(Par3);
                

            ViewBag.Nombre = Nombre;
            ViewBag.L1 = Lab1;
            ViewBag.L2 = Lab2;
            ViewBag.L3 = Lab3;
            ViewBag.P1 = Par1;
            ViewBag.P2 = Par2;
            ViewBag.P3 = Par3;
            ViewBag.TotalL = (L1 + L2 + L3 * 0.40);
            ViewBag.TotalP = (P1 + P2 + P3 * 0.60);
            ViewBag.NotaF = ((L1 + L2 + L3 * 0.40) + (P1 + P2 + P3 * 0.60));

            _ = Nombre;

            return View();
        }

        public ActionResult Save(String Nombre, int Lab1, int Lab2, int Lab3, int Par1, int Par2, int Par3)
        {
            using (EstudianteEntities estudiante = new EstudianteEntities())
            {
                Tbl_NotasEstudiante estud = new Tbl_NotasEstudiante();

                estud.NombreEstudiante = Nombre;
                estud.Lab1 = Lab1;
                estud.Lab2 = Lab2;
                estud.Lab3 = Lab3;
                estud.Par1 = Par1;
                estud.Par2 = Par2;
                estud.Par3 = Par3;
                estudiante.Tbl_NotasEstudiante.Add(estud);
                estudiante.SaveChanges();
            }

                return Redirect("/Index/Estudiante");
        }

        public ActionResult Estudiantes()
        {
            return View();
        }
    }
}