using Microsoft.EntityFrameworkCore;

namespace WebInventarios.Models
{
    public partial class ConexionContext : DbContext
    {

        public ConexionContext() 
        { 
        }
        public ConexionContext(DbContextOptions<ConexionContext> options)
            : base(options) 
        {
        }

        public virtual DbSet<Inventarios> Inventarios { get; set; } = null!;
        public virtual DbSet<Productos> Productos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured) 
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; DataBase =Inventarios;Trusted_Connection=True;MultipleActiveResultSets=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inventarios>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Inventarios");

                entity.Property(e => e.ProductoId).HasColumnName("ProductoID");
            });

            modelBuilder.Entity<Productos>(entity =>
            {
                //entity.HasNoKey();


                entity.Property(e => e.ProductoDesc)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.ProductoId).HasColumnName("ProductoID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
