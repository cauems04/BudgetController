using Microsoft.AspNetCore.Mvc;
using BudgetController.Data;
using BudgetController.Models;
using BudgetController.Tranformers;
using BudgetController.DTO.Responses;
using BudgetController.DTO.Requests;
using BudgetController.DTO.Interfaces;

namespace BudgetController.Controllers;

[ApiController]
public class IncomeController : ControllerBase
{

    private DAL<Income> _dal;

    public IncomeController([FromServices]DAL<Income> dal)
    {
        _dal = dal;
    }

    [HttpGet("incomes")]
    public IActionResult GetAll()
    {
        List<Income>? incomesFound = _dal.ListAll().ToList();
        
        if (incomesFound == null)
        {
            return NotFound();
        }

        List<IResponse> incomeList = incomesFound.Select(i => IncomeTransformer.ModelToResponse(i)).ToList();

        return Ok(incomeList);
    }

    [HttpGet("incomes/{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        Func<Income, bool> condition = (x) => { return x.Id == id; };

        Income? incomeFound = _dal.SearchFor(condition);

        if (incomeFound == null)
        {
            return NotFound();
        }

        IResponse income = IncomeTransformer.ModelToResponse(incomeFound);

        return Ok(income);
    }

    [HttpPost("incomes")]
    public IActionResult Create([FromBody] IncomeRequest incomeRequest)
    {

        Income incomeItem = IncomeTransformer.RequestToModel(incomeRequest);

        _dal.Create(incomeItem);

        //Tentar implementar essa verificação - obs:incomeItem não tem Id definido
        //Income? incomeFound = _dal.SearchFor(x => x.Id == incomeItem.Id);

        //if (incomeFound == null)
        //{
        //    return NotFound();
        //}

        return Ok();
    }

    [HttpPut("incomes/{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] IncomeRequest incomeRequest)
    {
        Income? incomeFound = _dal.SearchFor(i => i.Id == id);

        if (incomeFound == null)
        {
            return NotFound();
        }    

        incomeFound.Description = incomeRequest.Description;
        incomeFound.Value = incomeRequest.Value;
        incomeFound.Date = incomeRequest.Date;

        _dal.Update(incomeFound);

        return Ok(incomeFound);
    }

    [HttpDelete("incomes/{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        Income? incomeFound = _dal.SearchFor(i => i.Id == id);

        if (incomeFound == null)
        {
            return NotFound();
        }

        _dal.Remove(incomeFound);
        return NoContent();
    }
}
