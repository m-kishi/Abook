using System;
using System.Collections.Generic;

namespace Abook
{
    /// <summary>
    /// 月別集計値クラス
    /// </summary>
    public class AbSummary
    {
        /// <summary>開始年月日</summary>
        private DateTime dtStr;

        /// <summary>終了年月日</summary>
        private DateTime dtEnd;

        /// <summary>種別ごとの集計値</summary>
        private Dictionary<string, int> dicSummary;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public AbSummary(int y, int m, List<AbExpense> expenses)
        {
            dicSummary = new Dictionary<string, int>();

            dtStr = new DateTime(y, m, 1);
            dtEnd = dtStr.AddMonths(1).AddDays(-1);

            List<AbExpense> list = expenses.FindAll((exp) => {
                return (dtStr <= exp.Date && exp.Date <= dtEnd);
            });

            foreach (AbExpense exp in list)
            {
                if (dicSummary.ContainsKey(exp.Type))
                {
                    dicSummary[exp.Type] += exp.Price;
                }
                else
                {
                    dicSummary.Add(exp.Type, exp.Price);
                }
            }
        }

        /// <summary>
        /// 集計値取得
        /// </summary>
        public int GetPrice(string type)
        {
            if (dicSummary.ContainsKey(type))
            {
                return dicSummary[type];
            }
            else if (type == "合計")
            {
                int total = 0;
                foreach (int v in dicSummary.Values)
                {
                    total += v;
                }

                if (dicSummary.ContainsKey("給料"))
                {
                    total -= dicSummary["給料"];
                }

                return total;
            }
            else if (type == "貯金")
            {
                int total = 0;
                foreach (int v in dicSummary.Values)
                {
                    total += v;
                }

                if (dicSummary.ContainsKey("給料"))
                {
                    return dicSummary["給料"] * 2 - total;
                }
                else
                {
                    return -total;
                }
            }

            return 0;
        }

        /// <summary>
        /// 集計値アクセッサ
        /// </summary>
        public Dictionary<string, int> DicSummary
        {
            get { return this.dicSummary; }
        }
    }
}
