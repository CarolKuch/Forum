

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MessageApp.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string? Title { get; set; }
        public DateTime Date { get; set; }
        public ICollection<Topic> Topics { get; set; }
    }
}
