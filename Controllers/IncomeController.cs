using BudgetController.Data;
using BudgetController.Models;
using Microsoft.AspNetCore.Mvc;

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
    public IActionResult GetIncomes()
    {
        List<Income>? incomes = _dal.ListAll().ToList();
        
        if (incomes == null)
        {
            return NotFound();
        }

        return Ok(incomes);
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

        return Ok(incomeFound);
    }

    [HttpPost("incomes")]
    public IActionResult Create([FromBody] Income incomeItem)
    {
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
    public IActionResult Update([FromRoute] int id, [FromBody] Income incomeItem)
    {
        Income? incomeFound = _dal.SearchFor(i => i.Id == id);

        if (incomeFound == null)
        {
            return NotFound();
        }

        incomeFound.Description = incomeItem.Description;
        incomeFound.Value = incomeItem.Value;
        incomeFound.Date = incomeItem.Date;

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
