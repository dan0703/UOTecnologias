﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FEIDBEntities : DbContext
    {
        public FEIDBEntities()
            : base("name=FEIDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Administrator> Administrators { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Career> Careers { get; set; }
        public virtual DbSet<Procedure> Procedures { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Tutor> Tutors { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<GetStudentInfo> GetStudentInfoes { get; set; }
        public virtual DbSet<ViewStudentInfo> ViewStudentInfoes { get; set; }
    }
}
