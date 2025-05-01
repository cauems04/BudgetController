using BudgetController.DTO.Interfaces;

namespace BudgetController.DTO.Responses;

public record class ExpenseResponse(string Description, double Value, DateOnly Date) : IResponse;
