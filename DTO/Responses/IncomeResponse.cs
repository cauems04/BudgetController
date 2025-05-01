using BudgetController.DTO.Interfaces;

namespace BudgetController.DTO.Responses;

public record class IncomeResponse(string Description, double Value, DateOnly Date) : IResponse;
