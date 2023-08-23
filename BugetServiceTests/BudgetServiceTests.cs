using Microsoft.VisualStudio.TestTools.UnitTesting;
using BugetService;
using NSubstitute;


namespace BugetService.Tests
{
    [TestClass()]
    public class BudgetServiceTests
    {
        //[Fact]
        //public void TotalAmountTest()
        //{
        //    var budgets = new List<Budget>
        //    {
        //        new Budget() { YearMonth = "202306", Amount = 3000 }
        //    };
        //    var mock = Substitute.For<IBudgetRepo>();
        //    mock.GetAll().Returns(budgets);

        //    var a = new BudgetService(mock);

        //    Assert.Equal(3000, a.TotalAmount());
        //}

        [TestMethod()]
        public void InvalidDate()
        {
            var budgets = new List<Budget>
            {
                new Budget() { YearMonth = "202306", Amount = 3000 }
            };
            var mock = Substitute.For<IBudgetRepo>();
            mock.GetAll().Returns(budgets);

            var a = new BudgetService(mock);

            Assert.AreEqual(0, a.TotalAmount(new DateTime(2023, 7, 1), new DateTime(2023,6,1)));
        }
        [TestMethod()]
        public void SingleDateHaveAmount()
        {
            var budgets = new List<Budget>
            {
                new Budget() { YearMonth = "202306", Amount = 3000 }
            };
            var mock = Substitute.For<IBudgetRepo>();
            mock.GetAll().Returns(budgets);

            var a = new BudgetService(mock);

            Assert.IsTrue(a.TotalAmount(new DateTime(2023, 6, 1), new DateTime(2023, 6, 1))>0);
        }
        [TestMethod()]
        public void SingleDateNoAmount()
        {
            var budgets = new List<Budget>
            {
                new Budget() { YearMonth = "202306", Amount = 3000 }
            };
            var mock = Substitute.For<IBudgetRepo>();
            mock.GetAll().Returns(budgets);

            var a = new BudgetService(mock);

            Assert.IsTrue(a.TotalAmount(new DateTime(2023, 6, 1), new DateTime(2023, 6, 1)) == 100);
        }
    }
}