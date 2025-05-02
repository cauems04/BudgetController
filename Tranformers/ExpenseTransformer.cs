using BudgetController.Models.Interfaces;
using BudgetController.Models;
using BudgetController.DTO.Interfaces;
using BudgetController.DTO.Requests;
using BudgetController.DTO.Responses;

namespace BudgetController.Tranformers;

public static class ExpenseTransformer
{
    public static IRequest ModelToRequest(Expense model)
    {
        return new ExpenseRequest(model.Description, model.Value, model.Date);
    }

    public static IResponse ModelToResponse(Expense model)
    {
        return new ExpenseResponse(model.Description, model.Value, model.Date);
    }

    public static Expense RequestToModel(ExpenseRequest request)
    {
        return new Expense(request.Description, request.Value, request.Date);
    }
}
