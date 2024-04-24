using Microsoft.EntityFrameworkCore;
using TurnSystem.Models;


namespace TurnSystem.Data{
    public class DataBaseContext : DbContext{

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options){}

        //aqui se deben registrar los modelos

        public DbSet<Adviser> Advisers  {get; set;}
        public DbSet<Shift> Shifts  {get; set;}
        


    }
}