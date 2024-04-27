namespace TurnSystem.Models
{
    public class Shift
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public int type_procedure_id { get; set; }
        public int adviser_id { get; set; }
        public int status_id { get; set; }
        public string? document_number { get; set; }
        public string? codigo_turno {get; set;}
        public int type_user_id {get; set;}

        public DateTime shift_date { get; set; }
        public User User { get; set; }
        public Adviser Adviser { get; set; }
        public Type_Procedure Type_Procedure { get; set; }
        public Status Status { get; set; }
    }
}