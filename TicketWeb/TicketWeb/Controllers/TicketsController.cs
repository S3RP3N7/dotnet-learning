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
        public IActionResult Create(CreateTicketViewModel form)
        {
            if (!ModelState.IsValid) 
            {
                return View(form);
            }
            Ticket ticket = new Ticket
            {
                Title = form.Title,
                UsersAffected = form.UsersAffected,
            };
            if (form.ProductionDown)
            {
                ticket.Priority = Priority.P1;
            }
            else if (form.UsersAffected >= 50)
            {
                ticket.Priority = Priority.P2;
            }
            else if (form.UsersAffected >= 5)
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
    

