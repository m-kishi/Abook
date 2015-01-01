namespace Abook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CHK = Abook.AbUtilities.CHK;

    /// <summary>
    /// 自動補完クラス
    /// </summary>
    public class AbComplete
    {
        /// <summary>補完候補</summary>
        private Dictionary<string, string> dicComp;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="expenses">支出情報リスト</param>
        public AbComplete(List<AbExpense> expenses)
        {
            CHK.ExpNull(expenses);

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
    }
}
