using System.ComponentModel.DataAnnotations;

namespace TicketWeb.Models
{
    public class CreateTicketViewModel
    {
        [Required]

        public string Title { get; set; } = "";
        [Range(1, int.MaxValue, ErrorMessage = "Enter a whole number greater than 0")]
        public int UsersAffected { get; set; }
        public bool ProductionDown { get; set; }
    }
}
