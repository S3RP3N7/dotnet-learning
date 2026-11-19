using Microsoft.EntityFrameworkCore;

namespace TicketWeb.Models
{
    public class TicketContext : DbContext
    {
        public TicketContext(DbContextOptions<TicketContext> options) : base(options)
        {
        }

        public DbSet<Ticket> Tickets => Set<Ticket>();
    }
}
