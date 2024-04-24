namespace TurnSystem.Models{
    public class Shift{
        public int id { get; set; }
        public int user_id {get; set;}
        public int adviser_id {get; set;}
        public int type_procedure_id {get; set;}
        public int status_id {get; set;}
        public DateTime shift_date {get; set;}
        

    }
}