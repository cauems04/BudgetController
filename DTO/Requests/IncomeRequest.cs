using BudgetController.DTO.Interfaces;

namespace BudgetController.DTO.Requests;

public record class IncomeRequest(string Description, double Value, DateOnly Date) : IRequest;
