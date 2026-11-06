using Microsoft.Data.SqlClient;


string connectionString =
    "Server=localhost\\SQLEXPRESS;Database=Sandbox;Trusted_Connection=True;TrustServerCertificate=True;";

GetTickets(connectionString);
InsertTickets(connectionString);
bool closed = CloseTicket(connectionString,99);
Console.WriteLine(closed ? "Ticket closed" : "Ticket not found");

static void GetTickets(string connectionString)
{
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();

        string sql = "SELECT Id, Title, Priority, Status from Tickets";

        using (SqlCommand command = new SqlCommand(sql, connection))
        using (SqlDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string title = reader.GetString(1);
                int priority = reader.GetInt32(2);
                int status = reader.GetInt32(3);

                Console.WriteLine($"{id}, {title}, {priority}, {status}");
            }
        }
    }
}
static void InsertTickets(string connectionString)
{
    using (SqlConnection connection = new SqlConnection(connectionString))
    {

        connection.Open();
        string insertSQL =
            "insert Into Tickets (Title, UsersAffected, [Priority], [Status])" +
             " Values (@title, @users, @priority, @status)";

        using (SqlCommand insert = new SqlCommand(insertSQL, connection))
        {
            insert.Parameters.AddWithValue("@title", "Printer jammed");
            insert.Parameters.AddWithValue("@priority", 3);
            insert.Parameters.AddWithValue("@status", 0);
            insert.Parameters.AddWithValue("@users", 1);

            int rowsAffected = insert.ExecuteNonQuery();
            Console.WriteLine($"{rowsAffected} row(s) inserted");
        }
    }
}

static bool CloseTicket(string connectionString, int id)
{
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();
        string updateSQL = "UPDATE Tickets SET [Status] = 3 WHERE Id = @id";
        using (SqlCommand update = new SqlCommand(updateSQL, connection))
        {
            update.Parameters.AddWithValue("@id", id);
            int rowsChanged = update.ExecuteNonQuery();

            return rowsChanged > 0;
        }

    }
}




