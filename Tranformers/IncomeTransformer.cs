using BudgetController.Models.Interfaces;
using BudgetController.Models;
using BudgetController.DTO.Interfaces;
using BudgetController.DTO.Requests;
using BudgetController.DTO.Responses;

namespace BudgetController.Tranformers;

public class IncomeTransformer
{
    public static IRequest ModelToRequest(Income model)
    {
        return new IncomeRequest(model.Description, model.Value, model.Date);
    }

    public static IResponse ModelToResponse(Income model)
    {
        return new IncomeResponse(model.Description, model.Value, model.Date);
    }

    public static Income RequestToModel(IncomeRequest request)
    {
        return new Income(request.Description, request.Value, request.Date);
    }
}
