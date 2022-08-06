using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CRUDMVC.Models
{
    public partial class dbCRUDWebAppContext : DbContext
    {
        public dbCRUDWebAppContext()
        {
        }

        public dbCRUDWebAppContext(DbContextOptions<dbCRUDWebAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblEmpleado> TblEmpleados { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("server=localhost; database=dbCRUDWebApp; integrated security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblEmpleado>(entity =>
            {

                entity.ToTable("tblEmpleados");

                entity.Property(e => e.Apellido).HasMaxLength(50);

                entity.Property(e => e.Correo).HasMaxLength(50);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.Property(e => e.Puesto).HasMaxLength(50);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
