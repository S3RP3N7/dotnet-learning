using TicketWeb.Models;

namespace TicketWeb.Tests;

public class PriorityCalculatorTests
{
    [Theory]
    [InlineData(4, false, Priority.P4)]
    [InlineData(5, false, Priority.P3)]
    [InlineData(49, false, Priority.P3)]
    [InlineData(50, false, Priority.P2)]
    [InlineData(1, true, Priority.P1)]
    [InlineData(500, true, Priority.P1)]
    public void Calculate_ReturnsExpectedPriority(int users, bool productionDown, Priority expected)
    {
        Priority actual = PriorityCalculator.Calculate(users, productionDown);

        Assert.Equal(expected, actual);
    }
}

