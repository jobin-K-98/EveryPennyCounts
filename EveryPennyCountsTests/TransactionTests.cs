using EveryPennyCounts.Models;
using EveryPennyCountsLibrary;

namespace EveryPennyCountsTests
{
    [TestClass]
    public class TransactionTests
    {
        [TestMethod]
        public void Calculate_Total_Based_On_Different_Category_Types()
        {
            Transaction transaction1 = new()
            {
                Category = new Category()
                {
                    Type = "Expense"
                },
                Amount = 5000
            };
            Transaction transaction2 = new()
            {
                Category = new Category()
                {
                    Type = "Income"
                },
                Amount = 3000
            };
            List<Transaction> transactionList = new List<Transaction>();
            transactionList.Add(transaction1);
            transactionList.Add(transaction2);
            var result = TransactionLogic.CalculateTotal(transactionList);
            Decimal expectedResult = -2000;
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Calculate_Total_Based_On_Two_Expenses()
        {
            Transaction transaction1 = new()
            {
                Category = new Category()
                {
                    Type = "Expense"
                },
                Amount = 5000
            };
            Transaction transaction2 = new()
            {
                Category = new Category()
                {
                    Type = "Expense"
                },
                Amount = 3000
            };
            List<Transaction> transactionList = new List<Transaction>();
            transactionList.Add(transaction1);
            transactionList.Add(transaction2);
            var result = TransactionLogic.CalculateTotal(transactionList);
            Decimal expectedResult = -8000;
            Assert.AreEqual(expectedResult, result);
        }
    
        [TestMethod]
        public void Calculate_Total_Based_On_Two_Incomes()
        {
            Transaction transaction1 = new()
            {
                Category = new Category()
                {
                    Type = "Income"
                },
                Amount = 5000
            };
            Transaction transaction2 = new()
            {
                Category = new Category()
                {
                    Type = "Income"
                },
                Amount = 3000
            };
            List<Transaction> transactionList = new List<Transaction>();
            transactionList.Add(transaction1);
            transactionList.Add(transaction2);
            var result = TransactionLogic.CalculateTotal(transactionList);
            Decimal expectedResult = 8000;
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Add_Tax()
        {
            Transaction transaction1 = new()
            {
                Category = new Category()
                {
                    Type = "Income"
                },
                Amount = 5000
            };
            var result = TransactionLogic.AddTax(transaction1);
            Assert.AreEqual(5650m, result);
        }

        [TestMethod]
        public void Remove_Tax()
        {
            Transaction transaction1 = new()
            {
                Category = new Category()
                {
                    Type = "Income"
                },
                Amount = 5650
            };
            var result = TransactionLogic.DeductTax(transaction1);
            Assert.AreEqual(5000m, result);
        }
    }
}