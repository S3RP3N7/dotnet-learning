
List<string> ticketList = new List<string>();

while (true)
{
    Console.WriteLine("Menu");
    Console.WriteLine("Please select an option:");
    Console.WriteLine("Option 1: Add Ticket");
    Console.WriteLine("Option 2: List Tickets");
    Console.WriteLine("Option 3: Leave the program");
    string? option = Console.ReadLine(); 
    int.TryParse(option, out int choice );

    switch (choice) 
    {
        case 1:
            ticketList.Add(AddTicket());
            break;

        case 2:
            if (ticketList.Count == 0)
            {
                Console.WriteLine("No Tickets in List");
            }
            else 
            {
                foreach (var ticket in ticketList)
                {
                    Console.WriteLine(ticket);
                }
            }

            break;

        case 3:
            
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

        if (int.TryParse(input, out int numberOfUsers) && numberOfUsers > 0)
        {
            return numberOfUsers;
        }
        Console.WriteLine("Please enter a whole number greater than 0");
    }
}

static string AddTicket() 
{
    string title = ReadRequiredText("Please enter a ticket title");
    int numberOfUsers = ReadPositiveInt("How many users are currently affected?");

    Console.WriteLine("Is production down? Y/N");
    string? productionDown = Console.ReadLine();
    string priority;

    if (string.Equals(productionDown, "Y", StringComparison.OrdinalIgnoreCase))
    {
        priority = "P1";
    }
    else if (numberOfUsers >= 50)
    {
        priority = "P2";
    }
    else if (numberOfUsers >= 5)
    {
        priority = "P3";
    }
    else
    {
        priority = "P4";
    }

    return $"[{priority}]: {title} - {numberOfUsers} affected";
}