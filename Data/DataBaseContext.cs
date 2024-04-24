using Microsoft.EntityFrameworkCore;


namespace TurnSystem.Data{
    public class DataBaseContext : DbContext{

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options){}

        //aqui se deben registrar los modelos
    }
}