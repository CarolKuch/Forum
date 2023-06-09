

namespace MessageApp.Models
{
    public class User
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public bool IsAdmin { get; set; }
    }
}
