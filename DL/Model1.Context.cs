﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class CCEscalonaControlEscolarEntities : DbContext
    {
        public CCEscalonaControlEscolarEntities()
            : base("name=CCEscalonaControlEscolarEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Alumno> Alumnoes { get; set; }
        public virtual DbSet<AlumnoMateria> AlumnoMaterias { get; set; }
        public virtual DbSet<Materia> Materias { get; set; }
    
        public virtual int AlumnoAdd(string nombre, string apellidoPaterno, string apellidoMaterno)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoPaternoParameter = apellidoPaterno != null ?
                new ObjectParameter("ApellidoPaterno", apellidoPaterno) :
                new ObjectParameter("ApellidoPaterno", typeof(string));
    
            var apellidoMaternoParameter = apellidoMaterno != null ?
                new ObjectParameter("ApellidoMaterno", apellidoMaterno) :
                new ObjectParameter("ApellidoMaterno", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AlumnoAdd", nombreParameter, apellidoPaternoParameter, apellidoMaternoParameter);
        }
    
        public virtual int AlumnoDelete(Nullable<int> idAlumno)
        {
            var idAlumnoParameter = idAlumno.HasValue ?
                new ObjectParameter("IdAlumno", idAlumno) :
                new ObjectParameter("IdAlumno", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AlumnoDelete", idAlumnoParameter);
        }
    
        public virtual ObjectResult<AlumnoGetAll_Result> AlumnoGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<AlumnoGetAll_Result>("AlumnoGetAll");
        }
    
        public virtual ObjectResult<AlumnoGetById_Result> AlumnoGetById(Nullable<int> idAlumno)
        {
            var idAlumnoParameter = idAlumno.HasValue ?
                new ObjectParameter("IdAlumno", idAlumno) :
                new ObjectParameter("IdAlumno", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<AlumnoGetById_Result>("AlumnoGetById", idAlumnoParameter);
        }
    
        public virtual int AlumnoUpdate(Nullable<int> idAlumno, string nombre, string apellidoPaterno, string apellidoMaterno)
        {
            var idAlumnoParameter = idAlumno.HasValue ?
                new ObjectParameter("IdAlumno", idAlumno) :
                new ObjectParameter("IdAlumno", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoPaternoParameter = apellidoPaterno != null ?
                new ObjectParameter("ApellidoPaterno", apellidoPaterno) :
                new ObjectParameter("ApellidoPaterno", typeof(string));
    
            var apellidoMaternoParameter = apellidoMaterno != null ?
                new ObjectParameter("ApellidoMaterno", apellidoMaterno) :
                new ObjectParameter("ApellidoMaterno", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AlumnoUpdate", idAlumnoParameter, nombreParameter, apellidoPaternoParameter, apellidoMaternoParameter);
        }
    
        public virtual int MateriaDelete(Nullable<int> idMateria)
        {
            var idMateriaParameter = idMateria.HasValue ?
                new ObjectParameter("IdMateria", idMateria) :
                new ObjectParameter("IdMateria", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MateriaDelete", idMateriaParameter);
        }
    
        public virtual int MateriaEstatus(Nullable<int> idMateria, Nullable<bool> estatus)
        {
            var idMateriaParameter = idMateria.HasValue ?
                new ObjectParameter("IdMateria", idMateria) :
                new ObjectParameter("IdMateria", typeof(int));
    
            var estatusParameter = estatus.HasValue ?
                new ObjectParameter("Estatus", estatus) :
                new ObjectParameter("Estatus", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MateriaEstatus", idMateriaParameter, estatusParameter);
        }
    
        public virtual int MateriaUpdate(Nullable<int> idMateria, string nombre, Nullable<decimal> costo)
        {
            var idMateriaParameter = idMateria.HasValue ?
                new ObjectParameter("IdMateria", idMateria) :
                new ObjectParameter("IdMateria", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var costoParameter = costo.HasValue ?
                new ObjectParameter("Costo", costo) :
                new ObjectParameter("Costo", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MateriaUpdate", idMateriaParameter, nombreParameter, costoParameter);
        }
    
        public virtual int MateriaEstatus1(Nullable<int> idMateria, Nullable<bool> estatus)
        {
            var idMateriaParameter = idMateria.HasValue ?
                new ObjectParameter("IdMateria", idMateria) :
                new ObjectParameter("IdMateria", typeof(int));
    
            var estatusParameter = estatus.HasValue ?
                new ObjectParameter("Estatus", estatus) :
                new ObjectParameter("Estatus", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MateriaEstatus1", idMateriaParameter, estatusParameter);
        }
    
        public virtual ObjectResult<MateriaGetAll_Result> MateriaGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MateriaGetAll_Result>("MateriaGetAll");
        }
    
        public virtual ObjectResult<MateriaGetById_Result> MateriaGetById(Nullable<int> idMateria)
        {
            var idMateriaParameter = idMateria.HasValue ?
                new ObjectParameter("IdMateria", idMateria) :
                new ObjectParameter("IdMateria", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MateriaGetById_Result>("MateriaGetById", idMateriaParameter);
        }
    
        public virtual int MateriaAdd(string nombre, Nullable<decimal> costo)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var costoParameter = costo.HasValue ?
                new ObjectParameter("Costo", costo) :
                new ObjectParameter("Costo", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MateriaAdd", nombreParameter, costoParameter);
        }
    
        public virtual ObjectResult<AlumnoGetMateriaAsiganda_Result> AlumnoGetMateriaAsiganda(Nullable<int> idAlumno)
        {
            var idAlumnoParameter = idAlumno.HasValue ?
                new ObjectParameter("IdAlumno", idAlumno) :
                new ObjectParameter("IdAlumno", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<AlumnoGetMateriaAsiganda_Result>("AlumnoGetMateriaAsiganda", idAlumnoParameter);
        }
    
        public virtual ObjectResult<AlumnoGetMateriaSinAsiganda_Result> AlumnoGetMateriaSinAsiganda(Nullable<int> idAlumno)
        {
            var idAlumnoParameter = idAlumno.HasValue ?
                new ObjectParameter("IdAlumno", idAlumno) :
                new ObjectParameter("IdAlumno", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<AlumnoGetMateriaSinAsiganda_Result>("AlumnoGetMateriaSinAsiganda", idAlumnoParameter);
        }
    
        public virtual int AlumnoMateriaDelete(Nullable<int> idAlumnoMateria)
        {
            var idAlumnoMateriaParameter = idAlumnoMateria.HasValue ?
                new ObjectParameter("IdAlumnoMateria", idAlumnoMateria) :
                new ObjectParameter("IdAlumnoMateria", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AlumnoMateriaDelete", idAlumnoMateriaParameter);
        }
    
        public virtual int AlumnoMateriaAdd(Nullable<int> idAlumno, Nullable<int> idMateria)
        {
            var idAlumnoParameter = idAlumno.HasValue ?
                new ObjectParameter("IdAlumno", idAlumno) :
                new ObjectParameter("IdAlumno", typeof(int));
    
            var idMateriaParameter = idMateria.HasValue ?
                new ObjectParameter("IdMateria", idMateria) :
                new ObjectParameter("IdMateria", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AlumnoMateriaAdd", idAlumnoParameter, idMateriaParameter);
        }
    }
}
