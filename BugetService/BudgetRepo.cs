namespace BugetService
{
    public interface IBudgetRepo
    {
        List<Budget> GetAll();
    }

    public class BudgetRepo
    {
        public List<Budget> GetAll()
        {
            return new List<Budget>();
        }
    }

    public class Budget
    {
        public string YearMonth { get; set; }
        public decimal Amount { get; set; }
    }
}