// ------------------------------------------------------------
// Copyright (C) 2010-2017 Masaaki Kishi. All rights reserved.
// Author: Masaaki Kishi <m.kishi.5@gmail.com>
// ------------------------------------------------------------
namespace Abook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CHK  = Abook.AbUtilities.CHK;
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
            CHK.ExpNull(expenses);

            abPrivates = new List<AbPrivate>();
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
            foreach (var prv in abPrivates) yield return prv;
        }
    }
}
