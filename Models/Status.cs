namespace TurnSystem.Models{
    public class Status{
        public int id { get; set; }
        public string description {get; set; }
        public string Codigo{get; set;}
        public string Nombre{get; set; }
    public ICollection<Shift> Shifts { get; set; }


    }
}