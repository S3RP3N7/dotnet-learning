using Microsoft.AspNetCore.Mvc;
using TicketWeb.Models;

namespace TicketWeb.Controllers
{
    public class TicketsController : Controller
    {
        public IActionResult Index() 
        {
            using (TicketContext context = new TicketContext())
            {
                List<Ticket> tickets = context.Tickets.ToList();
                return View(tickets);
            }
        }
    }
}
