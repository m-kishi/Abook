// ------------------------------------------------------------
// © 2010 https://github.com/m-kishi
// ------------------------------------------------------------
namespace Abook
{
    using System.Collections.Generic;
    using System.Linq;
    using CHK = Abook.AbUtilities.CHK;
    using TYPE = Abook.AbConstants.TYPE;

    /// <summary>
    /// 投資情報管理クラス
    /// </summary>
    public class AbFinanceManager
    {
        /// <summary>投資情報リスト</summary>
        private List<AbFinance> abFinances;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="expenses">支出情報リスト</param>
        public AbFinanceManager(List<AbExpense> expenses)
        {
            CHK.ExpNull(expenses);

            abFinances = new List<AbFinance>();
            var total = decimal.Zero;
            var finances = expenses.Where(exp => exp.Type == TYPE.FNCE);
            foreach (var exp in finances)
            {
                var fnc = new AbFinance(exp, total);
                total = fnc.Ttal;
                abFinances.Add(fnc);
            }
        }

        /// <summary>
        /// 投資情報リスト
        /// </summary>
        /// <returns>投資情報リスト</returns>
        public IEnumerable<AbFinance> Finances()
        {
            foreach (var fnc in abFinances) yield return fnc;
        }
    }
}
