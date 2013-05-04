namespace Abook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using EX   = Abook.AbException.EX;
    using TYPE = Abook.AbConstants.TYPE;

    /// <summary>
    /// 秘密収支情報管理クラス
    /// </summary>
    public class AbPrivateManager
    {
        /// <summary>秘密収支情報リスト</summary>
        private List<AbPrivate> abPrivates;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="expenses">支出情報リスト</param>
        public AbPrivateManager(List<AbExpense> expenses)
        {
            abPrivates = new List<AbPrivate>();
            if (expenses == null)
            {
                AbException.Throw(EX.EXPENSES_NULL);
            }

            var balance = decimal.Zero;
            var privates = expenses.Where(exp => TYPE.PRIVATE.Contains(exp.Type));
            foreach (var exp in privates)
            {
                var prv = new AbPrivate(exp, balance);
                balance = prv.Blnc;
                abPrivates.Add(prv);
            }
        }

        /// <summary>
        /// 秘密収支情報リスト
        /// </summary>
        /// <returns>秘密収支情報リスト</returns>
        public IEnumerable<AbPrivate> Privates()
        {
            foreach (var prv in abPrivates)
            {
                yield return prv;
            }
        }
    }
}
