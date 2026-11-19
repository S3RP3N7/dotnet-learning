namespace TicketWeb.Models
{
    public static class PriorityCalculator
    {
        public static Priority Calculate(int usersAffected, bool productionDown) 
        {
            if (productionDown)
            {
                return Priority.P1;
            }

            if (usersAffected >= 50)
            {
                return Priority.P2;
            }

            if (usersAffected >= 5)
            {
                return Priority.P3;
            }

            return Priority.P4;
        }
    }
}
