

string title = ReadRequiredText("Please enter a ticket title");
int numberOfUsers = ReadPositiveInt("How many users are currently affected?");

Console.WriteLine("Is production down? Y/N");
string? productionDown = Console.ReadLine();

if (string.Equals(productionDown, "Y", StringComparison.OrdinalIgnoreCase))
{
    Console.WriteLine($"[P1]: {title} - {numberOfUsers} have been affected");
}
else if (numberOfUsers >= 50)
{
    Console.WriteLine($"[P2]: {title} - {numberOfUsers} have been affected");
}
else if (numberOfUsers >= 5)
{
    Console.WriteLine($"[P3]: {title} - {numberOfUsers} have been affected");
}
else
{
    Console.WriteLine($"[P4]: {title} - {numberOfUsers} have been affected");
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