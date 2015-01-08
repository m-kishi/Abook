namespace Abook
{
    using System;
    using System.Linq;
    using EX   = Abook.AbException.EX;
    using CHK  = Abook.AbUtilities.CHK;
    using FMT  = Abook.AbConstants.FMT;
    using UTIL = Abook.AbUtilities;

    /// <summary>
    /// 支出情報クラス
    /// </summary>
    public class AbExpense
    {
        /// <summary>日付</summary>
        public DateTime Date { get; private set; }
        /// <summary>名称</summary>
        public string   Name { get; private set; }
        /// <summary>種別</summary>
        public string   Type { get; private set; }
        /// <summary>金額</summary>
        public decimal  Cost { get; private set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="date">日付</param>
        /// <param name="name">名称</param>
        /// <param name="type">種別</param>
        /// <param name="cost">金額</param>
        public AbExpense(string date, string name, string type, string cost)
        {
            Date = ParseDate(date);
            Name = ParseName(name);
            Type = ParseType(type);
            Cost = ParseCost(cost);
        }

        /// <summary>
        /// 日付設定
        /// </summary>
        /// <param name="date">日付</param>
        /// <returns>日付</returns>
        private DateTime ParseDate(string date)
        {
            CHK.DateNull(date);

            var dt = DateTime.MinValue;
            var st = System.Globalization.DateTimeStyles.None;
            if (!DateTime.TryParseExact(date, FMT.DATE, null, st, out dt))
            {
                AbException.Throw(EX.DATE_FORMAT);
            }
            return dt;
        }

        /// <summary>
        /// 名称設定
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns>名称</returns>
        private string ParseName(string name)
        {
            CHK.NameNull(name);
            return name;
        }

        /// <summary>
        /// 種別設定
        /// </summary>
        /// <param name="type">種別</param>
        /// <returns>種別</returns>
        private string ParseType(string type)
        {
            CHK.TypeNull(type);
            CHK.TypeWrong(type);
            return type;
        }

        /// <summary>
        /// 金額設定
        /// </summary>
        /// <param name="cost">金額</param>
        /// <returns>金額</returns>
        private decimal ParseCost(string cost)
        {
            CHK.CostNull(cost);

            var ct = decimal.Zero;
            try
            {
                ct = decimal.Parse(cost);
                if (ct < decimal.Zero)
                {
                    AbException.Throw(EX.COST_MINUS);
                }
            }
            catch (FormatException)
            {
                AbException.Throw(EX.COST_FORMAT);
            }
            catch (OverflowException)
            {
                AbException.Throw(EX.COST_OVERFLOW);
            }
            return ct;
        }

        /// <summary>
        /// CSV形式
        /// </summary>
        /// <returns>CSV形式</returns>
        public string ToCSV()
        {
            return string.Format(FMT.CSV, Date.ToString(FMT.DATE), Name, Type, Cost);
        }

        /// <summary>
        /// SQL形式
        /// </summary>
        /// <returns>SQL形式</returns>
        public string ToSQL()
        {
            var type = UTIL.ToTypeId(Type);
            return string.Format(FMT.SQL, Date.ToString(FMT.DATE), Name, type, Cost);
        }
    }
}
