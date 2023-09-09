using System.ComponentModel.DataAnnotations;

namespace MessageApp.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
