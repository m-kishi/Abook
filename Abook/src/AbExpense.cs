namespace Abook
{
    using System;

    /// <summary>
    /// 支出レコードクラス
    /// </summary>
    public class AbExpense
    {
        /// <summary>日付</summary>
        public DateTime Date { get; private set; }

        /// <summary>名前</summary>
        public string Name { get; private set; }

        /// <summary>種別</summary>
        public string Type { get; private set; }

        /// <summary>金額</summary>
        public int Price { get; private set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public AbExpense(string date, string name, string type, string price)
        {
            if (string.IsNullOrEmpty(date) ) { throw new ArgumentException("日付が不正な値です。"); }
            if (string.IsNullOrEmpty(name) ) { throw new ArgumentException("名前が不正な値です。"); }
            if (string.IsNullOrEmpty(type) ) { throw new ArgumentException("種別が不正な値です。"); }
            if (string.IsNullOrEmpty(price)) { throw new ArgumentException("金額が不正な値です。"); }

            Date = DateTime.Parse(date);
            Name = name;
            Type = type;
            Price = int.Parse(price);
        }

        /// <summary>
        /// CSV フォーマット
        /// </summary>
        public string ToCSVFormat()
        {
            return string.Format(
                "{0},{1},{2},{3}",
                Date.ToShortDateString(),
                Name,
                Type,
                Price.ToString()
            );
        }
    }
}
