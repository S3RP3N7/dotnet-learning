
using TicketPriority;

List<Ticket> ticketList = new List<Ticket>();

while (true)
{
    Console.WriteLine("Menu");
    Console.WriteLine("Please select an option:");
    Console.WriteLine("Option 1: Add Ticket");
    Console.WriteLine("Option 2: List Tickets");
    Console.WriteLine("Option 3: Close Ticket");
    Console.WriteLine("Option 4: Leave the program");

    string? option = Console.ReadLine();
    int.TryParse(option, out int choice);

    switch (choice)
    {
        case 1:
            {
                Ticket newTicket = AddTicket();
                newTicket.Id = ticketList.Count + 1;
                ticketList.Add(newTicket);
                break;

            }

        case 2:
            {
                if (ticketList.Count == 0)
                {
                    Console.WriteLine("No Tickets in List");
                }
                else
                {
                    foreach (var ticket in ticketList)
                    {
                        Console.WriteLine($"[{ticket.Priority}]: {ticket.Title} - {ticket.UsersAffected} affected, The ticket is: {ticket.Status}");
                    }
                }

                break;
            }

        case 3:
            {
                int id = ReadPositiveInt("Which ticket would you like to close");
                Ticket? found = ticketList.FirstOrDefault(t => t.Id == id);

                if (found == null)
                {
                    Console.WriteLine("There are no matching tickets with that Id.");
                }
                else
                {
                    if (found.Status == TicketStatus.Closed)
                    {
                        Console.WriteLine($"{found.Id} is already in a closed state");
                    }

                    found.Status = TicketStatus.Closed;
                    Console.WriteLine($"Ticket {found.Id} closed");
                }
                break;
            }

        case 4:

            return;

        default:
            Console.WriteLine("Please enter a valid option");
            break;
    }
}


static string ReadRequiredText(string prompt)
{
    while (true)
    {
        Console.WriteLine(prompt);
        string? input = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(input))
        {
            return input;
        }
        Console.WriteLine("This cannot be empty");
    }
}

static int ReadPositiveInt(string prompt)
{
    while (true)
    {
        Console.WriteLine(prompt);
        string? input = Console.ReadLine();

        if (int.TryParse(input, out int value) && value > 0)
        {
            return value;
        }
        Console.WriteLine("Please enter a whole number greater than 0");
    }
}

static bool ReadYesNo(string prompt)
{
    while (true) 
    {
        Console.WriteLine(prompt);
        string? input = Console.ReadLine();
        if (string.Equals(input, "Y", StringComparison.OrdinalIgnoreCase))
        {
            return true;
        }
        if (string.Equals(input, "N", StringComparison.OrdinalIgnoreCase)) 
        {
            return false;
        }
        Console.WriteLine("Please enter Y or N");

    }
}

static Ticket AddTicket()
{
    Ticket ticket = new Ticket();
    string title = ReadRequiredText("Please enter a ticket title");
    int numberOfUsers = ReadPositiveInt("How many users are currently affected?");
    Console.WriteLine("Is production down? Y/N");
    bool productionDown = ReadYesNo("Is production down? Y/N");
    Priority priority;


    if (productionDown)
    {
        priority = Priority.P1;
    }
    else if (numberOfUsers >= 50)
    {
        priority = Priority.P2;
    }
    else if (numberOfUsers >= 5)
    {
        priority = Priority.P3;
    }
    else
    {
        priority = Priority.P4;
    }
    ticket.Title = title;
    ticket.UsersAffected = numberOfUsers;
    ticket.Priority = priority;

    return ticket;
}


