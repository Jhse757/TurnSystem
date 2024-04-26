namespace TurnSystem.Models
{
    public class Type_Procedure{
        public int id {get; set;}
        public string description  {get; set;}
        public string icon  {get; set;}
        public ICollection<Shift> Shifts { get; set; }

    }
}