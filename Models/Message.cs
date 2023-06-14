

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MessageApp.Models
{
    public class Message
    {
        [Key]
        public int MessageID { get; set; }
        public string? Content { get; set; }
        public DateTime Date { get; set; }

        [Display(Name = "User")]
        public int UserId { get; set; }

    }
}
