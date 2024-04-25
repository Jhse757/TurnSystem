namespace TurnSystem.Models{
    public class User{
        public int id { get; set; }
        public string name { get; set; }
        public int type_document_id { get; set;}
        public int type_user_id{get; set;}
        public string document_number { get; set; }
        public string contact_info {get; set;}
        public ICollection<Shift> Shifts { get; set; }

    }
}