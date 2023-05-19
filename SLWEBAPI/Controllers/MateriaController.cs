using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using System.Net;
using System.Net.Http;


namespace SLWEBAPI.Controllers
{
    public class MateriaController : ApiController
    {
        // GET: Materia

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Materia/GetAll")]
        public IHttpActionResult GetAll()
        {
            ML.Result result = BL.Materia.GetAll();

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Materia/Add")]
        public IHttpActionResult Add([FromBody] ML.Materia materia)
        {
            ML.Result result = BL.Materia.Add(materia);

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Materia/Delete")]
        public IHttpActionResult Delete([FromBody] byte materia)
        {

            ML.Result result = BL.Materia.Delete(materia);

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Materia/GetById/{id}")]
        public IHttpActionResult GetById(int id)
        {

            ML.Result result = BL.Materia.GetById(id);

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK,result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }
        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("api/Materia/Update/{id}")]
        public IHttpActionResult Update(int id, [FromBody] ML.Materia materia)
        {
            //alumno.IdAlumno = id;
            ML.Result result = BL.Materia.Update(materia);

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK,result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }
    }
}