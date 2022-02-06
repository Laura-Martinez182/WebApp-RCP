using System.ComponentModel.DataAnnotations;

namespace WebApp_RCP.Models
{
    public class User
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDay { get; set; } = DateTime.MinValue;
    }
}
