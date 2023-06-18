namespace MessageApp.DTOs
{
    public class MessageAuthorDto
    {
        public int MessageID { get; set; }
        public string? Content { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public string UserLogin { get; set; }
        public bool IsUserAdmin { get; set; }
    }
}
