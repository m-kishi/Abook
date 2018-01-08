// ------------------------------------------------------------
// Copyright (C) 2010-2017 Masaaki Kishi. All rights reserved.
// Author: Masaaki Kishi <m.kishi.5@gmail.com>
// ------------------------------------------------------------
namespace Abook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using COL = Abook.AbConstants.COL;

    /// <summary>
    /// 収支タブ
    /// </summary>
    public partial class AbFormMain
    {
        /// <summary>収支情報管理</summary>
        private AbBalanceManager abBalanceManager;

        /// <summary>
        /// 収支タブ初期化
        /// </summary>
        /// <param name="expenses">支出情報リスト</param>
        private void InitTabBalance(List<AbExpense> expenses)
        {
            abBalanceManager = new AbBalanceManager(expenses);
            SetTabBalance();
        }

        /// <summary>
        /// 収支タブ表示
        /// </summary>
        private void SetTabBalance()
        {
            DgvBalance.Rows.Clear();
            var balances = abBalanceManager.Balances();
            if (balances.Count() > 0)
            {
                var i = 0;
                DgvBalance.Rows.Add(balances.Count());
                foreach (var bln in balances)
                {
                    var row = DgvBalance.Rows[i++];
                    row.Cells[COL.YEAR].Value = bln.Year;
                    row.Cells[COL.EARN].Value = bln.Earn;
                    row.Cells[COL.EXPENSE].Value = bln.Expense;
                    row.Cells[COL.SPECIAL].Value = bln.Special;
                    row.Cells[COL.BALANCE].Value = bln.Balance;
                }
            }
        }
    }
}
