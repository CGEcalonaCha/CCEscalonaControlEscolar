using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Materia
    {
        public static ML.Result Add(ML.Materia materia)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.CCEscalonaControlEscolarEntities context = new DL.CCEscalonaControlEscolarEntities())
                {
                    int queryEF = context.MateriaAdd(materia.Nombre, materia.Costo);

                    if (queryEF > 0)
                    {
                        result.Correct = true;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "Ocurrio un error al insertar el alumno" + ex;
            }
            return result;
        }
        public static ML.Result Update(ML.Materia materia)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.CCEscalonaControlEscolarEntities context = new DL.CCEscalonaControlEscolarEntities())
                {
                    int queryEF = context.MateriaUpdate(materia.IdMateria, materia.Nombre, materia.Costo);

                    if (queryEF > 0)
                    {
                        result.Correct = true;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "Ocurrio un error al insertar el alumno" + ex;
            }
            return result;
        }
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.CCEscalonaControlEscolarEntities context = new DL.CCEscalonaControlEscolarEntities())
                {
                    //var queryEF = context.AlumnoGetAll();
                    var queryEFList = context.MateriaGetAll().ToList();

                    result.Objects = new List<object>();

                    foreach (var row in queryEFList)
                    {
                        ML.Materia materia = new ML.Materia();
                        materia.IdMateria = row.IdMateria;
                        materia.Nombre = row.Nombre;
                        materia.Costo = row.Costo.Value;
         
                        


                        result.Objects.Add(materia);
                    }

                    result.Correct = true;

                }
            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = "Ocurrió un error al actualizar el registro en la tabla Alumno" + result.Ex;
                //throw;
            }
            return result;
        }
        public static ML.Result GetById(int idMateria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.CCEscalonaControlEscolarEntities context = new DL.CCEscalonaControlEscolarEntities())
                {

                    var objMateria = context.MateriaGetById(idMateria).FirstOrDefault();

                    result.Objects = new List<object>();

                    if (objMateria != null)
                    {

                        ML.Materia materia = new ML.Materia();
                        materia.IdMateria = objMateria.IdMateria;
                        materia.Nombre = objMateria.Nombre;
                        materia.Costo = objMateria.Costo.Value;
             
                      

                        result.Object = materia; //boxing


                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrió un error al obtener los registros en la tabla Alumno";
                    }

                }


            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }
        public static ML.Result Delete(int materia)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.CCEscalonaControlEscolarEntities context = new DL.CCEscalonaControlEscolarEntities())
                {
                    var query = context.MateriaDelete(materia);
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se elinino el regristro";
                    }

                    result.Correct = true;
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }



    }
}
