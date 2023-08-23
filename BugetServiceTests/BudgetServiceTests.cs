using Microsoft.VisualStudio.TestTools.UnitTesting;
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

            Assert.AreEqual(0, a.TotalAmount(new DateTime(2023, 7, 1), new DateTime(2023, 6, 1)));
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

            Assert.IsTrue(a.TotalAmount(new DateTime(2023, 6, 1), new DateTime(2023, 6, 1)) > 0);
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

        [TestMethod()]
        public void CrossMonthAmount()
        {
            var budgets = new List<Budget>
            {
                new Budget() { YearMonth = "202306", Amount = 3000 },   //100
                new Budget() { YearMonth = "202307", Amount = 31000 }, //1000
                new Budget() { YearMonth = "202308", Amount = 310 } // 10
            };
            var mock = Substitute.For<IBudgetRepo>();
            mock.GetAll().Returns(budgets);

            var a = new BudgetService(mock);

            Assert.IsTrue(a.TotalAmount(new DateTime(2023, 6, 29), new DateTime(2023, 8, 2)) == 31220);
        }
    }
}