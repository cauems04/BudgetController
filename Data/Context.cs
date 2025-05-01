using Microsoft.EntityFrameworkCore;
using BudgetController.Models;

namespace BudgetController.Data;

public class Context : DbContext
{
    private string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BudgetController;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

    public DbSet<Income> Incomes { get; set; }
    public DbSet<Expense> Expenses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Income>().HasKey(i => i.Id);
        modelBuilder.Entity<Expense>().HasKey(e => e.Id);
    }
}
