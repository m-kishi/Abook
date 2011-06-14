namespace Abook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// 自動補完クラス
    /// </summary>
    public class AbComplement
    {
        /// <summary>補完候補</summary>
        private Dictionary<string, string> dicComp;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public AbComplement(List<AbExpense> abExpenses)
        {
            if (abExpenses == null)
            {
                throw new ArgumentException("支出リストが指定されませんでした。");
            }

            dicComp = new Dictionary<string, string>();

            foreach (var name in abExpenses.GroupBy(exp => exp.Name).Select(gObj => gObj.Key))
            {
                int max = 0;
                string type = string.Empty;

                foreach (var gObj in abExpenses.Where(exp => exp.Name == name).GroupBy(exp => exp.Type))
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
        public string GetType(string name)
        {
            if (string.IsNullOrEmpty(name)) { return string.Empty; }
            return dicComp.ContainsKey(name) ? dicComp[name] : string.Empty;
        }
    }
}
