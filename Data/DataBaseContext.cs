using Microsoft.EntityFrameworkCore;
using TurnSystem.Models;


namespace TurnSystem.Data
{
    public class DataBaseContext : DbContext
    {

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }

        //aqui se deben registrar los modelos

        public DbSet<Adviser> Advisers { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Type_Document> Type_Documents { get; set; }
        public DbSet<Type_Procedure> Type_Procedures { get; set; }
        public DbSet<Type_User> Type_Users { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de la relación entre Shift y Adviser
            modelBuilder.Entity<Shift>()
            .HasOne(s => s.Adviser)
            .WithMany(a => a.Shifts)
            .HasForeignKey(s => s.adviser_id)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Shift>()
               .HasOne(s => s.Status)
               .WithMany(st => st.Shifts)
               .HasForeignKey(s => s.status_id)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Shift>()
                .HasOne(s => s.Type_Procedure)
                .WithMany(st => st.Shifts)
                .HasForeignKey(s => s.type_procedure_id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Shift>()
                .HasOne(s => s.User)
                .WithMany(st => st.Shifts)
                .HasForeignKey(s => s.user_id)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}