using Microsoft.AspNetCore.Mvc;
using TicketWeb.Models;

namespace TicketWeb.Controllers
{
    public class TicketsController : Controller
    {
        private readonly TicketContext _context;

        public TicketsController(TicketContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Ticket> tickets = _context.Tickets.ToList();
            return View(tickets);
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
                UsersAffected = form.UsersAffected
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

            _context.Tickets.Add(ticket);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Close(int id)
        {
            Ticket? ticket = _context.Tickets
                .FirstOrDefault(t => t.Id == id && t.Status != TicketStatus.Closed);

            if (ticket != null)
            {
                ticket.Status = TicketStatus.Closed;
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ReOpen(int id)
        {
            Ticket? ticket = _context.Tickets
                .FirstOrDefault(t => t.Id == id && t.Status == TicketStatus.Closed);

            if (ticket != null)
            {
                ticket.Status = TicketStatus.Open;
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}