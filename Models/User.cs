

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MessageApp.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public bool IsAdmin { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}
