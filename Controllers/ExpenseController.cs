using Microsoft.AspNetCore.Mvc;
using BudgetController.Data;
using BudgetController.Models;
using BudgetController.Tranformers;
using BudgetController.DTO.Responses;
using BudgetController.DTO.Requests;
using BudgetController.DTO.Interfaces;


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
    public IActionResult GetAll()
    {
        List<Expense>? expensesFound = _dal.ListAll().ToList();

        if (expensesFound == null)
        {
            return NotFound();
        }

        List<IResponse> expenseList = expensesFound.Select(e => ExpenseTransformer.ModelToResponse(e)).ToList();

        return Ok(expenseList);
    }

    [HttpGet("expenses/{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        Expense? expenseFound = _dal.SearchFor(e => e.Id == id);

        if (expenseFound == null)
        {
            return NotFound();
        }

        IResponse expense = ExpenseTransformer.ModelToResponse(expenseFound);

        return Ok(expense);
    }

    [HttpPost("expenses")]
    public IActionResult Create([FromBody] ExpenseRequest expenseRequest)
    {
        Expense expenseItem = ExpenseTransformer.RequestToModel(expenseRequest);

        _dal.Create(expenseItem);

        return Ok();
    }

    [HttpPut("expenses/{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] ExpenseRequest expenseRequest)
    {
        Expense? expenseFound = _dal.SearchFor(e => e.Id == id);

        if (expenseFound == null)
        {
            return NotFound();
        }

        expenseFound.Description = expenseRequest.Description;
        expenseFound.Value = expenseRequest.Value;
        expenseFound.Date = expenseRequest.Date;

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
