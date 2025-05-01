namespace BudgetController.DTO.Interfaces
{
    public interface IRequest
    {
        public string Description { get; init; }
        public double Value { get; init; }
        public DateOnly Date { get; init; }
    }
}
