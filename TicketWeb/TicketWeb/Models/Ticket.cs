namespace TicketWeb.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public int UsersAffected { get; set; }
        public Priority Priority { get; set; }
        public TicketStatus Status { get; set; }
    }
}
