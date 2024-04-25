namespace TurnSystem.Models{
    public class Status{
        public int id { get; set; }
        public string description {get; set; }
    public ICollection<Shift> Shifts { get; set; }


    }
}