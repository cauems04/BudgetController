namespace BudgetController.Models;

public class Expense
{
    public int Id { get; }
    public string Description { get; set; }
    public double Value { get; set; }
    public DateOnly Date { get; set; }
}
