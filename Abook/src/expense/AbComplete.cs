// ------------------------------------------------------------
// © 2010 Masaaki Kishi
// ------------------------------------------------------------
namespace Abook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CHK = Abook.AbUtilities.CHK;
    using CMM = Abook.AbConstants.CMM;

    /// <summary>
    /// 自動補完クラス
    /// </summary>
    public class AbComplete
    {
        /// <summary>支出情報リスト</summary>
        private List<AbExpense> abExpenses;
        /// <summary>補完候補</summary>
        private Dictionary<string, string> dicComp;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="expenses">支出情報リスト</param>
        public AbComplete(List<AbExpense> expenses)
        {
            CHK.ExpNull(expenses);
            abExpenses = expenses;

            dicComp = new Dictionary<string, string>();
            foreach (var name in expenses.GroupBy(exp => exp.Name).Select(gObj => gObj.Key))
            {
                var max = 0;
                var type = string.Empty;

                foreach (var gObj in expenses.Where(exp => exp.Name == name).GroupBy(exp => exp.Type))
                {
                    var cnt = gObj.Count();
                    if (max == cnt)
                    {
                        type = type + " " + gObj.Key;
                    }
                    else if (max < cnt)
                    {
                        max = cnt;
                        type = gObj.Key;
                    }
                }
                dicComp.Add(name, type);
            }
        }

        /// <summary>
        /// 種別取得
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns>種別</returns>
        public string GetType(string name)
        {
            if (string.IsNullOrEmpty(name)) return string.Empty;
            return dicComp.ContainsKey(name) ? dicComp[name] : string.Empty;
        }

        /// <summary>
        /// 金額取得
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="type">種別</param>
        /// <returns>金額</returns>
        /// <remarks>直近3件の金額を取得する。</remarks>
        public string GetCost(string name, string type)
        {
            if (string.IsNullOrEmpty(name)) return string.Empty;
            if (string.IsNullOrEmpty(type)) return string.Empty;

            var targets = abExpenses.Where(exp =>
                exp.Name == name && exp.Type == type
            ).Reverse().Take(CMM.MAX_COST_CANDIDATE).Select(exp => AbUtilities.ToComma(exp.Cost)).Distinct().ToArray();
            return String.Join("/", targets);
        }
    }
}
