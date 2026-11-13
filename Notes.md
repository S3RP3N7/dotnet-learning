ADO Vs EF Core

There are a lot of benefits to using EF Core mainly attributed to automation and efficiency.
A lot of the manual aspects of writing items such as the SQL connection, Command and the Reader code are removed as EF Core will do these aspects for you. 
There are however trade offs these could be slower queries and a lack of control over the exact SQL code that is being executed. 
A block of code in ADO could be written in 24 lines to get tickets from a database, however the same code block in EF Core could be written in 4 lines

```csharp
static List<Ticket> GetTicketsEf()
{
    using (TicketContext context = new TicketContext())
    {
        return context.Tickets.ToList();
    }
}
```
This code above 

GetTicketsEf returns a List<Ticket>. 
It creates a TicketContext, which holds the connection string, and ToList() runs the query against the Tickets table and builds the list of Ticket objects. 
The using closes the connection afterwards.