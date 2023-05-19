using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Alumno
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            //  ML.Departamento departamento = new ML.Departamento();
            ML.Alumno alumno = new ML.Alumno();
            ServiceReferenceAlumno.AlumnoClient servicioAlumno = new ServiceReferenceAlumno.AlumnoClient();
            var result = servicioAlumno.GetAll();
            if (result.Correct)
            {
                alumno.Alumnos = result.Objects.ToList();
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al hacer la consulta de alumnos" + result.ErrorMessage;
            }
            return View(alumno);

        }

        //[HttpGet]
        //public ActionResult Delete(ML.Departamento departamento)
        //{


        //    if (departamento.IdDepartamento > 0)
        //    {
        //        BL.Departamento.DeleteEF(departamento);



        //        return View("Modal");
        //        //return View();
        //        //return RedirectToAction("Usuario");

        //    }
        //    else
        //    {

        //        return View();
        //    }


        //    // return View(IdUsuario);


        //}

        [HttpGet]
        public ActionResult Delete(ML.Alumno alumno)
        {


            if (alumno.IdAlumno > 0)
            {
                //BL.Departamento.DeleteEF(departamento);
                ServiceReferenceAlumno.AlumnoClient servicioAlumno = new ServiceReferenceAlumno.AlumnoClient();

                var result = servicioAlumno.Delete(alumno);


                return View("Modal");
                //return View();
                //return RedirectToAction("Usuario");

            }
            else
            {

                return View();
            }


            // return View(IdUsuario);


        }


        //[HttpPost]
        //public ActionResult Form(ML.Departamento departamento)
        //{
        //    ML.Result result = new ML.Result();

        //    //add o update
        //    if (departamento.IdDepartamento == 0)
        //    {
        //        //add
        //        result = BL.Departamento.AddEF(departamento);
        //        if (result.Correct)
        //        {
        //            ViewBag.Message = "Se inserto correctamente el Departamento";
        //        }
        //        else
        //        {
        //            ViewBag.Message = "Ocurrio un error al insertar el Departamento" + result.ErrorMessage;
        //        }
        //        //return View("/Views/Home/index.cshtml", usuario);


        //    }
        //    else
        //    {
        //        result = BL.Departamento.UpdateEF(departamento);
        //        if (result.Correct)
        //        {
        //            ViewBag.Message = "Se Actualizo correctamente el Departamento";
        //        }
        //        else
        //        {
        //            ViewBag.Message = "Ocurrio un error al actualizo el Departamento" + result.ErrorMessage;
        //        }
        //        //update


        //    }
        //    return View("Modal");

        //}
        [HttpPost]
        public ActionResult Form(ML.Alumno alumno)
        {
            //ML.Result result = new ML.Result();

            //add o update
            if (alumno.IdAlumno == 0)
            {
                //add
                ServiceReferenceAlumno.AlumnoClient servicioDepartamento = new ServiceReferenceAlumno.AlumnoClient();

                var result = servicioDepartamento.Add(alumno);
                if (result.Correct)
                {
                    ViewBag.Message = "Se inserto correctamente el Alumno";
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al insertar el Alumno" + result.ErrorMessage;
                }
                //return View("/Views/Home/index.cshtml", usuario);


            }
            else
            {
                ServiceReferenceAlumno.AlumnoClient servicioDepartamento = new ServiceReferenceAlumno.AlumnoClient();

                var result = servicioDepartamento.Update(alumno);
                if (result.Correct)
                {
                    ViewBag.Message = "Se Actualizo correctamente el Alumno";
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al actualizo el Alumno" + result.ErrorMessage;
                }
                //update


            }
            return View("Modal");

        }


        //[HttpGet]
        //public ActionResult Form(int? idDepartamento)
        //{
        //    ML.Result resultAre = BL.Area.GetAll();
        //    ML.Departamento departamento = new ML.Departamento();
        //    departamento.Area = new ML.Area();

        //    if (resultAre.Correct)
        //    {
        //        departamento.Area.Areas = resultAre.Objects;
        //    }




        //    if (idDepartamento == null)
        //    {
        //        return View(departamento);

        //    }
        //    else
        //    {


        //        ML.Result result = BL.Departamento.GetByIdEF(idDepartamento.Value);


        //        if (result.Correct)
        //        {
        //            departamento = (ML.Departamento)result.Object;
        //            departamento.Area.Areas = resultAre.Objects;
        //            return View(departamento);

        //        }
        //        else
        //        {
        //            ViewBag.Message = "Ocurrio un error al hacer la consulta de Departamento " + result.ErrorMessage;
        //            return View("Modal");
        //        }




        //    }
        //}


        [HttpGet]
        public ActionResult Form(int? idAlumno)
        {


            ML.Alumno alumno = new ML.Alumno();
            //departamento.Area = new ML.Area();

            //if (resultAre.Correct)
            //{
            //    departamento.Area.Areas = resultAre.Objects;
            //}
            if (idAlumno == null)
            {
                return View(alumno);//puede ir vacio

            }
            else
            {

                ServiceReferenceAlumno.AlumnoClient servicioDepartamento = new ServiceReferenceAlumno.AlumnoClient();

                var result = servicioDepartamento.GetById(idAlumno.Value);
                //ML.Result result = BL.Departamento.GetByIdEF(idDepartamento.Value);


                if (result.Correct)
                {
                    alumno = (ML.Alumno)result.Object;
                    //departamento.Area.Areas = resultAre.Objects;
                    return View(alumno);

                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al hacer la consulta de Departamento " + result.ErrorMessage;
                    return View("Modal");
                }
            }
        }

    }
}