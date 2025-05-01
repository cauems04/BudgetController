using BudgetController.DTO.Interfaces;

namespace BudgetController.DTO.Requests;

public record class ExpenseRequest(string Description, double Value, DateOnly Date) : IRequest;
