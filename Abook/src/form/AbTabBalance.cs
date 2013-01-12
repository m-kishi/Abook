﻿namespace Abook
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
        /// <summary>収支データ管理</summary>
        private AbBalanceManager abBalanceManager;

        /// <summary>
        /// 収支タブ初期化
        /// </summary>
        /// <param name="expenses">支出レコードリスト</param>
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
                    DataGridViewRow row = DgvBalance.Rows[i++];
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