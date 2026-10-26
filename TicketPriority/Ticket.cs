using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using TicketPriority;

namespace TicketPriority
{
    internal class Ticket
    {
        public int Id {  get; set; }
        public string? Title { get; set; }
        public int UsersAffected { get; set; }
        public Priority Priority { get; set; }
        public string? Status { get; set;  }
    }
}
