using System.ComponentModel.DataAnnotations;

namespace MessageApp.DTOs
{
    public class LoginDto
    {
        [Required]
        public string Login { get; set; }   
        [Required]
        public string Password { get; set; }
    }
}
