using Microsoft.EntityFrameworkCore;

namespace TicketWeb.Models
{
    internal class TicketContext : DbContext
    {
        public DbSet<Ticket> Tickets => Set<Ticket>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Sandbox;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }

}
