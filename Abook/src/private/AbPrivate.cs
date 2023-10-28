// ------------------------------------------------------------
// © 2010 https://github.com/m-kishi
// ------------------------------------------------------------
namespace Abook
{
    using System;
    using EX   = Abook.AbException.EX;
    using CHK  = Abook.AbUtilities.CHK;
    using FMT  = Abook.AbConstants.FMT;
    using TYPE = Abook.AbConstants.TYPE;

    /// <summary>
    /// 秘密収支情報クラス
    /// </summary>
    public class AbPrivate
    {
        /// <summary>年月</summary>
        public string  Date { get; private set; }
        /// <summary>名称</summary>
        public string  Name { get; private set; }
        /// <summary>金額</summary>
        public decimal Cost { get; private set; }
        /// <summary>収支</summary>
        public decimal Blnc { get; private set; }
        /// <summary>備考</summary>
        public string  Note { get; private set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="expense">支出情報</param>
        /// <param name="balance">収支    </param>
        public AbPrivate(AbExpense expense, decimal balance)
        {
            CHK.ExpNull(expense);

            Date = ParseDate(expense);
            Name = ParseName(expense);
            Cost = ParseCost(expense);
            Note = ParseNote(expense);
            Blnc = ParseBlnc(Cost, balance);
        }

        /// <summary>
        /// 年月設定
        /// </summary>
        /// <param name="expense">支出情報</param>
        /// <returns>年月</returns>
        private string ParseDate(AbExpense expense)
        {
            return expense.Date.ToString(FMT.YEAR_MONTH);
        }

        /// <summary>
        /// 名称設定
        /// </summary>
        /// <param name="expense">支出情報</param>
        /// <returns>名称</returns>
        private string ParseName(AbExpense expense)
        {
            return expense.Name;
        }

        /// <summary>
        /// 金額設定
        /// </summary>
        /// <param name="expense">支出情報</param>
        /// <returns>金額</returns>
        private decimal ParseCost(AbExpense expense)
        {
            switch (expense.Type)
            {
                case TYPE.PRVI: return  expense.Cost;
                case TYPE.PRVO: return -expense.Cost;
                default:
                    AbException.Throw(EX.TYPE_PRIVATE_ERR);
                    break;
            }
            return decimal.Zero;
        }

        /// <summary>
        /// 収支設定
        /// </summary>
        /// <param name="cost"   >金額</param>
        /// <param name="balance">収支</param>
        /// <returns>収支</returns>
        private decimal ParseBlnc(decimal cost, decimal balance)
        {
            return balance + cost;
        }

        /// <summary>
        /// 備考設定
        /// </summary>
        /// <param name="expense">支出情報</param>
        /// <returns>備考</returns>
        private string ParseNote(AbExpense expense)
        {
            return expense.Note;
        }
    }
}
