using System;

namespace Abook
{
    /// <summary>
    /// 支出レコードクラス
    /// </summary>
    public class AbExpense
    {
        /// <summary>日付</summary>
        private DateTime date;

        /// <summary>名前</summary>
        private string name;

        /// <summary>種別</summary>
        private string type;

        /// <summary>金額</summary>
        private int price;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public AbExpense(string date, string name, string type, string price)
        {
            try
            {
                this.date  = DateTime.Parse(date);
                this.name  = name;
                this.type  = type;
                this.price = int.Parse(price);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 日付アクセッサ
        /// </summary>
        public DateTime Date
        {
            get { return this.date; }
            set { this.date = value; }
        }

        /// <summary>
        /// 名前アクセッサ
        /// </summary>
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        /// <summary>
        /// 種別アクセッサ
        /// </summary>
        public string Type
        {
            get { return this.type; }
            set { this.type = value; }
        }

        /// <summary>
        /// 金額アクセッサ
        /// </summary>
        public int Price
        {
            get { return this.price; }
            set { this.price = value; }
        }
    }
}
