namespace BugetService
{
    public class BudgetService
    {
        private readonly IBudgetRepo budgetRepo;

        public BudgetService(IBudgetRepo budgetRepo)
        {
            this.budgetRepo = budgetRepo;
        }

        public decimal? TotalAmount(DateTime StartDate, DateTime EndDate)
        {
            var query = budgetRepo.GetAll();
            decimal? amount = 0;
            //
            if (StartDate > EndDate)
            {
                return amount;
            }

            var sDate = Convert.ToInt32(StartDate.ToString("yyyyMM"));
            var eDate = Convert.ToInt32(EndDate.ToString("yyyyMM"));

            var budgets = query.Where(x => Convert.ToInt32(x.YearMonth) >= sDate && Convert.ToInt32(x.YearMonth) <= eDate);
            foreach (var budget in budgets)
            {
                if (budget.YearMonth == StartDate.ToString("yyyyMM"))
                {
                    amount += budget.Amount / DateTime.DaysInMonth(StartDate.Year, StartDate.Month) * (DateTime.DaysInMonth(StartDate.Year, StartDate.Month) - StartDate.Day + 1);
                }
                else if (budget.YearMonth == EndDate.ToString("yyyyMM"))
                {
                    amount += budget.Amount / DateTime.DaysInMonth(EndDate.Year, EndDate.Month) * EndDate.Day;
                }
                else
                {
                    amount += budget.Amount;
                }
            }

            return amount;
        }
    }

    public interface IBudgetService
    {
        decimal? TotalAmount();
    }
}