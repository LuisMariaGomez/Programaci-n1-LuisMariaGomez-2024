using CEntidades.Entidades;
using Microsoft.EntityFrameworkCore;

namespace CDatos.Contexts
{
    public partial class LibreriaContext : DbContext
    {
        public LibreriaContext()
        {
        }

        public LibreriaContext(DbContextOptions<LibreriaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autor> Autor { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Copia> Copia { get; set; }
        public virtual DbSet<Editorial> Editorial { get; set; }
        public virtual DbSet<Forma_Pago> Forma_Pago { get; set; }
        public virtual DbSet<Genero> Genero { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<Prestamo> Prestamo { get; set; }
        public virtual DbSet<Vendedor> Vendedor { get; set; }
        public virtual DbSet<Venta> Venta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=LibreriaProg2024;Integrated Security=True;TrustServerCertificate=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.UTF-8");

            modelBuilder.Entity<Autor>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_ID_AUTOR");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_ID_CLIENTE");
            });
            modelBuilder.Entity<Copia>(entity =>
            {
                entity.HasKey(e => e.Id)  
                    .HasName("PK_ID_COPIA");
            });
            modelBuilder.Entity<Editorial>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_ID_EDITORIAL");
            });
            modelBuilder.Entity<Forma_Pago>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_ID_FORMA_PAGO");
            });
            modelBuilder.Entity<Genero>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_ID_GENERO");
            });
            modelBuilder.Entity<Libro>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_ID_LIBRO");
            });
            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_ID_PERSONA");
            });
            modelBuilder.Entity<Prestamo>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_ID_PRESTAMO");
            });
            modelBuilder.Entity<Vendedor>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_ID_VENDEDOR");
            });
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
