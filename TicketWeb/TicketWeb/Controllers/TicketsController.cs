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
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Ticket ticket)
        {
            if (!ModelState.IsValid)
            {
                return View(ticket);
            }

            if (ticket.UsersAffected >= 50)
            {
                ticket.Priority = Priority.P2;
            }
            else if (ticket.UsersAffected >= 5)
            {
                ticket.Priority = Priority.P3;
            }
            else
            {
                ticket.Priority = Priority.P4;
            }

            using (TicketContext context = new TicketContext())
            {
                context.Tickets.Add(ticket);
                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }

}
