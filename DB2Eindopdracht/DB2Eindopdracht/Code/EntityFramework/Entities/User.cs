namespace DB2Eindopdracht.EntityFramework.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string EmailAdress { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public int LoginAttempts { get; set; }
        public bool Blocked { get; set; }
        public string Date { get; set; }
    }
}
