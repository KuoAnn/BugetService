using System;

namespace BugetService
{

    public class BudgetService
    {
        private readonly IBudgetRepo budgetRepo;

        public BudgetService(IBudgetRepo budgetRepo)
        {
            this.budgetRepo = budgetRepo;
        }
        public decimal? TotalAmount(DateTime StartDate,DateTime EndDate)
        {
            var query = budgetRepo.GetAll();
            decimal? amount = null;
            //
            if (StartDate > EndDate)
            {
                return 0;
            }
            if (StartDate == EndDate)
            {
                amount = query.Where(x => x.YearMonth == StartDate.ToString("yyyyMM")).Select(x => x.Amount).FirstOrDefault();
                if (amount is not null)
                {
                    amount = amount / DateTime.DaysInMonth(StartDate.Year, StartDate.Month);
                }
                else {
                    return 0;
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