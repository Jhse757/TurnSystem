using Microsoft.EntityFrameworkCore;
using TurnSystem.Models;


namespace TurnSystem.Data{
    public class DataBaseContext : DbContext{

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options){}

        //aqui se deben registrar los modelos

        public DbSet<Adviser> Advisers  {get; set;}
        public DbSet<Shift> Shifts  {get; set;}
        public DbSet<Status> Status  {get; set;}
        public DbSet<Document> Documents  {get; set;}
        public DbSet<Procedure> Procedures   {get; set;}
        public DbSet<Type_User> Type_Users   {get; set;}
        public DbSet<User> Users   {get; set;}


    }
}