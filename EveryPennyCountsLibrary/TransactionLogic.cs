using EveryPennyCounts.Models;

namespace EveryPennyCountsLibrary
{
    public class TransactionLogic
    {
        public static decimal CalculateTotal(List<Transaction> transactions)
        {
            decimal total = 0;
            foreach (Transaction transaction in transactions)
            {
                if (transaction.Category.Type == "Expense") {
                    total -= transaction.Amount;
                } else
                {
                    total += transaction.Amount;
                }
            }
            return total;
        }

        public static decimal AddTax(Transaction transaction)
        {
            return transaction.Amount * 1.13m;
        }

        public static decimal DeductTax(Transaction transaction)
        {
            return transaction.Amount / 1.13m;
        }
    }
}