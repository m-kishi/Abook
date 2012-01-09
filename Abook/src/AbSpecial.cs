namespace Abook
{
    using System;

    /// <summary>
    /// 特別支出クラス
    /// </summary>
    public class AbSpecial
    {
        /// <summary>年</summary>
        public int Year    { get; private set; }
        /// <summary>収入</summary>
        public int Earn    { get; private set; }
        /// <summary>支出</summary>
        public int Expense { get; private set; }
        /// <summary>特別支出</summary>
        public int Special { get; private set; }
        /// <summary>残金</summary>
        public int Balance { get; private set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="year"   >年      </param>
        /// <param name="earn"   >収入    </param>
        /// <param name="expense">支出    </param>
        /// <param name="special">特別支出</param>
        /// <param name="balance">残金    </param>
        public AbSpecial(int year, int earn, int expense, int special, int balance)
        {
            if (year    < 0) { throw new ArgumentException("年が不正な値です。"      ); }
            if (earn    < 0) { throw new ArgumentException("収入が不正な値です。"    ); }
            if (expense < 0) { throw new ArgumentException("支出が不正な値です。"    ); }
            if (special < 0) { throw new ArgumentException("特別支出が不正な値です。"); }
            if (balance != earn - (expense + special))
            {
                throw new ArgumentException("残金が不正な値です。");
            }

            this.Year    = year;
            this.Earn    = earn;
            this.Expense = expense;
            this.Special = special;
            this.Balance = balance;
        }
    }
}
