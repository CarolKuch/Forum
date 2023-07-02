

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MessageApp.Models
{
    public class Topic
    {
        [Key]
        public int TopisID { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }

        public ICollection<Message>? Messages { get; set; }
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

    }
}
