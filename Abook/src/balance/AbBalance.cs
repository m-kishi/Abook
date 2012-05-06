namespace Abook
{
    using System;
    using EX = Abook.AbException.EX;

    /// <summary>
    /// 収支データクラス
    /// </summary>
    public class AbBalance
    {
        /// <summary>年度</summary>
        public int     Year    { get; private set; }

        /// <summary>収入</summary>
        public decimal Earn    { get; private set; }

        /// <summary>支出</summary>
        public decimal Expense { get; private set; }

        /// <summary>特出</summary>
        public decimal Special { get; private set; }

        /// <summary>収支</summary>
        public decimal Balance { get; private set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="year"   >年度</param>
        /// <param name="earn"   >収入</param>
        /// <param name="expense">支出</param>
        /// <param name="special">特出</param>
        /// <param name="balance">収支</param>
        public AbBalance(int year, decimal earn, decimal expense, decimal special, decimal balance)
        {
            Year    = ParseYear(year);
            Earn    = ParseEarn(earn);
            Expense = ParseExpense(expense);
            Special = ParseSpecial(special);
            Balance = ParseBalance(earn, expense, special, balance);
        }

        /// <summary>
        /// 年度設定
        /// </summary>
        /// <param name="year">年度</param>
        /// <returns>年度</returns>
        private int ParseYear(int year)
        {
            if (year < 0)
            {
                AbException.Throw(EX.YEAR_MINUS);
            }
            return year;
        }

        /// <summary>
        /// 収入設定
        /// </summary>
        /// <param name="earn">収入</param>
        /// <returns>収入</returns>
        private decimal ParseEarn(decimal earn)
        {
            if (earn < 0)
            {
                AbException.Throw(EX.EARN_MINUS);
            }
            return earn;
        }

        /// <summary>
        /// 支出設定
        /// </summary>
        /// <param name="expense">支出</param>
        /// <returns>支出</returns>
        private decimal ParseExpense(decimal expense)
        {
            if (expense < 0)
            {
                AbException.Throw(EX.EXPENSE_MINUS);
            }
            return expense;
        }

        /// <summary>
        /// 特出設定
        /// </summary>
        /// <param name="special">特出</param>
        /// <returns>特出</returns>
        private decimal ParseSpecial(decimal special)
        {
            if (special < 0)
            {
                AbException.Throw(EX.SPECIAL_MINUS);
            }
            return special;
        }

        /// <summary>
        /// 収支設定
        /// </summary>
        /// <param name="earn"   >収入</param>
        /// <param name="expense">支出</param>
        /// <param name="special">特出</param>
        /// <param name="balance">収支</param>
        /// <returns>収支</returns>
        private decimal ParseBalance(decimal earn, decimal expense, decimal special, decimal balance)
        {
            var expected = earn - (expense + special);
            if (expected != balance)
            {
                AbException.Throw(EX.BALANCE_INCORRECT);
            }
            return balance;
        }
    }
}
