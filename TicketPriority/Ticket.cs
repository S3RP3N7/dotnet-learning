using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace TicketPriority
{
    internal class Ticket
    {
        public string? Title { get; set; }
        public int UsersAffected { get; set; }
        public string? Priority { get; set; }
    }
}
