using Microsoft.AspNetCore.Mvc;
using BudgetController.Data;
using BudgetController.Models;


namespace BudgetController.Controllers;

[ApiController]
public class ExpenseController : ControllerBase
{
    private DAL<Expense> _dal;

    public ExpenseController([FromServices] DAL<Expense> dal)
    {
        _dal = dal;
    }

    [HttpGet("expenses")]
    public IActionResult GetExpenses()
    {
        List<Expense>? expenses = _dal.ListAll().ToList();

        if (expenses == null)
        {
            return NotFound();
        }

        return Ok(expenses);
    }

    [HttpGet("expenses/{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        Expense? expenseFound = _dal.SearchFor(e => e.Id == id);

        if (expenseFound == null)
        {
            return NotFound();
        }

        return Ok(expenseFound);
    }

    [HttpPost("expenses")]
    public IActionResult Create([FromBody] Expense expenseItem)
    {
        _dal.Create(expenseItem);

        //Tentar implementar essa verificação - obs:incomeItem não tem Id definido
        //Income? incomeFound = _dal.SearchFor(x => x.Id == incomeItem.Id);

        //if (incomeFound == null)
        //{
        //    return NotFound();
        //}

        return Ok();
    }

    [HttpPut("expenses/{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] Expense expenseItem)
    {
        Expense? expenseFound = _dal.SearchFor(e => e.Id == id);

        if (expenseFound == null)
        {
            return NotFound();
        }

        expenseFound.Description = expenseItem.Description;
        expenseFound.Value = expenseItem.Value;
        expenseFound.Date = expenseItem.Date;

        _dal.Update(expenseFound);

        return Ok(expenseFound);
    }

    [HttpDelete("expenses/{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        Expense? expenseFound = _dal.SearchFor(e => e.Id == id);

        if (expenseFound == null)
        {
            return NotFound();
        }

        _dal.Remove(expenseFound);
        return NoContent();
    }
}
