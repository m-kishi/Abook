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
    using CHK = Abook.AbUtilities.CHK;
    using COL = Abook.AbConstants.COL;
    using FMT = Abook.AbConstants.FMT;

    /// <summary>
    /// 検索サブフォーム
    /// </summary>
    public partial class AbSubSearch : Form
    {
        /// <summary>支出情報リスト</summary>
        private List<AbExpense> abExpenses;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="expenses">支出情報リスト</param>
        public AbSubSearch(List<AbExpense> expenses)
        {
            InitializeComponent();

            CHK.ExpNull(expenses);
            this.abExpenses = expenses;
        }

        /// <summary>
        /// フォームロード
        /// </summary>
        private void AbSubSearch_Load(object sender, EventArgs e)
        {
            var names = abExpenses.GroupBy(exp => exp.Name).Select(obj => obj.Key).ToList();
            names.Sort();

            CmbName.DataSource = names;
        }

        /// <summary>
        /// 検索
        /// </summary>
        private void BtnEntry_Click(object sender, EventArgs e)
        {
            var text = CmbName.Text;
            var selectedIndex = CmbName.SelectedIndex;

            var predicate = new Func<AbExpense, bool>(exp =>
                exp.Name == text
            );
            if (selectedIndex < 0)
            {
                predicate = new Func<AbExpense, bool>(exp =>
                    exp.Name.Contains(text)
                );
            }

            DgvExpense.Rows.Clear();
            var expenses = abExpenses.Where(predicate);
            if (expenses != null && expenses.Count() > 0)
            {
                DgvExpense.Rows.Add(expenses.Count());

                var idx = 0;
                foreach (var exp in expenses)
                {
                    var row = DgvExpense.Rows[idx++];
                    row.Cells[COL.DATE].Value = exp.Date.ToString(FMT.DATE);
                    row.Cells[COL.NAME].Value = exp.Name;
                    row.Cells[COL.TYPE].Value = exp.Type;
                    row.Cells[COL.COST].Value = exp.Cost;
                }
            }
        }
    }
}
