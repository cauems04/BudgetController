using BudgetController.Models.Interfaces;

namespace BudgetController.Models;

public class Income : IModel
{

    public Income(string description, double value, DateOnly date)
    {
        Description = description;
        Value = value;
        Date = date;
    }

    public int Id { get; set; }
    public string? Description { get; set; }
    public double Value { get; set; }
    public DateOnly Date { get; set; }
}
