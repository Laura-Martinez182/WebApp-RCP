namespace WebApp_RCP.Models
{
    public class User
    {
        public int ID { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime BirthDay { get; set; } = DateTime.MinValue;


        
    }
}
