// ------------------------------------------------------------
// © 2010 https://github.com/m-kishi
// ------------------------------------------------------------
namespace Abook
{
    using System;
    using EX = Abook.AbException.EX;
    using CHK = Abook.AbUtilities.CHK;
    using TYPE = Abook.AbConstants.TYPE;

    /// <summary>
    /// 投資情報クラス
    /// </summary>
    public class AbFinance
    {
        /// <summary>日付</summary>
        public DateTime Date { get; private set; }
        /// <summary>名称</summary>
        public string   Name { get; private set; }
        /// <summary>金額</summary>
        public decimal  Cost { get; private set; }
        /// <summary>累計</summary>
        public decimal  Ttal { get; private set; }
        /// <summary>備考</summary>
        public string   Note { get; private set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="expense">支出情報</param>
        /// <param name="total">累計</param>
        public AbFinance(AbExpense expense, decimal total)
        {
            CHK.ExpNull(expense);

            Date = ParseDate(expense);
            Name = ParseName(expense);
            Cost = ParseCost(expense);
            Ttal = ParseTtal(expense.Cost, total);
            Note = ParseNote(expense);
        }

        /// <summary>
        /// 日付設定
        /// </summary>
        /// <param name="expense">支出情報</param>
        /// <returns>日付</returns>
        private DateTime ParseDate(AbExpense expense)
        {
            return expense.Date;
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
            if (expense.Type != TYPE.FNCE)
            {
                AbException.Throw(EX.TYPE_FINANCE_ERR);
            }
            return expense.Cost;
        }

        /// <summary>
        /// 累計設定
        /// </summary>
        /// <param name="cost" >金額</param>
        /// <param name="total">累計</param>
        /// <returns>累計</returns>
        private decimal ParseTtal(decimal cost, decimal total)
        {
            return total + cost;
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
