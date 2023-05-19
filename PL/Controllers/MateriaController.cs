using System;
using System.Web.Mvc;
using System.Net.Http;
using System.Collections.Generic;
using BL;

namespace PL.Controllers
{
    public class MateriaController : Controller
    {
        // GET: Materia
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Materia aseguradora = new ML.Materia();
            ML.Result resultAseguradoras = new ML.Result();
            resultAseguradoras.Objects = new List<object>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:61306/api/");

                var responseTask = client.GetAsync("Materia/GetAll");
                responseTask.Wait(); //esperar a que se resuelva la llamada al servicio

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    foreach (var resultItem in readTask.Result.Objects)
                    {
                        ML.Materia resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Materia>(resultItem.ToString());
                        resultAseguradoras.Objects.Add(resultItemList);
                    }
                }
                aseguradora.Materias = resultAseguradoras.Objects;
            }
            return View(aseguradora);
        }
       
        [HttpGet]
        public ActionResult Form(int? idMateria)
        {
            //ML.Result result = new ML.Result();
            ML.Materia materia = new ML.Materia();


            if (idMateria == null)
            {

                return View(materia);
            }

            else
            {

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:61306/api/");

                    var responseTask = client.GetAsync("Materia/GetById/" + idMateria);
                    responseTask.Wait();
                    var resultAPI = responseTask.Result;
                    if (resultAPI.IsSuccessStatusCode)
                    {
                        var readTask = resultAPI.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();
                        ML.Materia resultItemList = new ML.Materia();
                        resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Materia>(readTask.Result.Object.ToString());
                        materia = resultItemList;


                    }

                }
                return View(materia);
                if (materia != null)
                {
                    return View();

                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al hacer la consulta del alumno ";
                    return View("Modal");
                }


                //hola

                //ML.Result result = BL.Aseguradora.GetById(idAseguradora.Value);
                //aseguradora.Usuario = new ML.Usuario();
                //aseguradora.Usuario.Usuarios = resultUsuario.Objects;
                //ML.Result result11 = BL.Aseguradora.GetById(idAseguradora.Value);



                //if (result.Correct)
                //{


                //    ML.Aseguradora ase = (ML.Aseguradora)result.Object;
                //    ase.Usuario.Usuarios = resultUsuario.Objects;
                //    return View(ase);

                //}
                //else
                //{
                //    ViewBag.Message = "Ocurrio un error al hacer la consulta de la aseguradora " + result.ErrorMessage;
                //    return View("Modal");
                //}


            }

        }
       
        [HttpPost]
        public ActionResult Form(ML.Materia aseguradora)
        {

            ML.Result result = new ML.Result();
            if (aseguradora.IdMateria == 0)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:61306/api/");

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<ML.Materia>("Materia/Add", aseguradora);
                    postTask.Wait();

                    var resulAseguradora = postTask.Result;

                    if (resulAseguradora.IsSuccessStatusCode)
                    {
                        ViewBag.Mensaje = "Se ha insertado la aseguradora";
                        return PartialView("Modal");
                    }
                    else
                    {
                        ViewBag.Mensaje = "No ha insertado la aseguradora";
                        return PartialView("Modal");
                    }
                }
                return View("GetAll");
                //result = BL.Aseguradora.Add(aseguradora);
                //if (result.Correct)
                //{
                //    ViewBag.Mensaje = "Se ha insertado la aseguradora";
                //}
                //else
                //{
                //    ViewBag.Mensaje = "Ne ha insertado la aseguradora" + result.ErrorMessage;
                //}
            }
            else
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:61306/api/");

                    //HTTP POST
                    var postTask = client.PutAsJsonAsync<ML.Materia>("Materia/Update/" + aseguradora.IdMateria, aseguradora);
                    postTask.Wait();

                    var resultAlumno = postTask.Result;
                    if (resultAlumno.IsSuccessStatusCode)
                    {
                        ViewBag.Mensaje = "Se ha actualizado el Aseguradora";
                        return PartialView("Modal");
                    }
                }
                return PartialView("Modal");
            }

            return View();
        }
        [HttpPost]//servicio web
        public ActionResult Delete(ML.Materia materia)
        {
            ML.Result resultMaterias = new ML.Result();
            int IdAseguradora = materia.IdMateria;
            //int id = Aseguradora.IdAseguradora;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:61306/api");

                //HTTP POST
                var postTask = client.GetAsync("Materia/Delete/" + IdAseguradora);
                postTask.Wait();

                var resultDelete = postTask.Result;
                if (resultDelete.IsSuccessStatusCode)
                {
                    ViewBag.Message = "Se Borro correctamente el Aseguradora";

                    //ML.Aseguradora Aseguradora = new ML.Producto();

                    //resultListAseguradora= BL.Aseguradora.GetAll(Aseguradora);
                    //return RedirectToAction("Modal");
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Message = "Nose Se Borro correctamente el Aseguradora";

                }
            }

            //ML.Aseguradora Aseguradora = new ML.Aseguradora();

            //resultListAseguradora = BL.Aseguradora.GetAll(Aseguradora);
            //ViewBag.Message = "Nose Se Borro correctamente el Aseguradora";

            return View("Modal");
        }
       
    }
}