// ------------------------------------------------------------
// Copyright (C) 2010-2017 Masaaki Kishi. All rights reserved.
// Author: Masaaki Kishi <m.kishi.5@gmail.com>
// ------------------------------------------------------------
namespace Abook
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using COL = Abook.AbConstants.COL;
    using CSV = Abook.AbConstants.CSV;
    using DGV = Abook.AbConstants.DGV;
    using FMT = Abook.AbConstants.FMT;
    using MSG = Abook.AbUtilities.MSG;

    /// <summary>
    /// 支出タブ
    /// </summary>
    public partial class AbFormMain
    {
        /// <summary>自動補完</summary>
        private AbComplete abComplete;

        /// <summary>
        /// 支出タブ初期化
        /// </summary>
        /// <param name="expenses">支出情報リスト</param>
        private void InitTabExpense(List<AbExpense> expenses)
        {
            abComplete = new AbComplete(expenses);
            SetTabExpense(expenses);
        }

        /// <summary>
        /// 支出タブ表示
        /// </summary>
        /// <param name="expenses">支出情報リスト</param>
        private void SetTabExpense(List<AbExpense> expenses)
        {
            if (expenses != null && expenses.Count > 0)
            {
                DgvExpense.Rows.Clear();
                DgvExpense.Rows.Add(expenses.Count);

                int idx = 0;
                foreach (var exp in expenses)
                {
                    var row = DgvExpense.Rows[idx++];
                    row.Cells[COL.DATE].Value = exp.Date.ToString(FMT.DATE);
                    row.Cells[COL.NAME].Value = exp.Name;
                    row.Cells[COL.TYPE].Value = exp.Type;
                    row.Cells[COL.COST].Value = exp.Cost;
                }
            }

            DgvExpense.ClearSelection();
            if (DgvExpense.Rows.Count > 0)
            {
                var idx = DgvExpense.Rows.Count - 1;
                var selectedCell = DgvExpense.Rows[idx].Cells[COL.DATE];

                selectedCell.Selected = true;
                DgvExpense.FirstDisplayedCell = selectedCell;
            }
        }

        /// <summary>
        /// 入力行追加
        /// </summary>
        private void BtnAddRow_Click(object sender, EventArgs e)
        {
            DgvExpense.Rows.Add(DGV.NEW_ROW_SIZE);
            var date = DateTime.Today.ToString(FMT.DATE);
            for (int i = DgvExpense.Rows.Count - DGV.NEW_ROW_SIZE; i < DgvExpense.Rows.Count; i++)
            {
                DgvExpense.Rows[i].Cells[COL.DATE].Value = date;
            }
        }

        /// <summary>
        /// セルの編集終了後の処理
        /// </summary>
        /// <remarks>
        /// ・種別と金額の自動補完
        /// ・金額はカンマ編集する
        /// </remarks>
        private void DgvExpense_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var row = DgvExpense.Rows[DgvExpense.CurrentCell.RowIndex];
            switch (DgvExpense.CurrentCell.ColumnIndex)
            {
                case 0:
                    break;
                case 1:
                    {
                        var name = row.Cells[COL.NAME].Value as string;
                        var type = abComplete.GetType(name);
                        row.Cells[COL.TYPE].Value = type;
                        row.Cells[COL.COST].Value = abComplete.GetCost(name, type);
                    }
                    break;
                case 2:
                    {
                        var name = row.Cells[COL.NAME].Value as string;
                        var type = row.Cells[COL.TYPE].Value as string;
                        row.Cells[COL.COST].Value = abComplete.GetCost(name, type);
                    }
                    break;
                case 3:
                    {
                        var cost = row.Cells[COL.COST].Value;
                        row.Cells[COL.COST].Value = AbUtilities.ToComma(cost);
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// DataGridViewへペースト
        /// </summary>
        private void DgvExpense_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.V)
            {
                var row = DgvExpense.Rows[DgvExpense.CurrentCell.RowIndex];

                var value = Clipboard.GetText();
                DgvExpense.CurrentCell.Value = value;
                switch (DgvExpense.CurrentCell.ColumnIndex)
                {
                    case 0:
                        break;
                    case 1:
                        {
                            var type = abComplete.GetType(value);
                            row.Cells[COL.TYPE].Value = type;
                            row.Cells[COL.COST].Value = abComplete.GetCost(value, type);
                        }
                        break;
                    case 2:
                        {
                            var name = row.Cells[COL.NAME].Value as string;
                            row.Cells[COL.COST].Value = abComplete.GetCost(name, value);
                        }
                        break;
                    case 3:
                        {
                            DgvExpense.CurrentCell.Value = AbUtilities.ToComma(value);
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// CSVファイルへ書き出し
        /// </summary>
        private void BtnEntry_Click(object sender, EventArgs e)
        {
            if (DgvExpense.Rows.Count == 0)
            {
                MSG.Warning("警告", "レコードが1件もありません。");
                return;
            }

            var errLine = 0;
            try
            {
                var expenses = AbDBManager.Load(DgvExpense, out errLine);

                AbDBManager.Store(CSV_FILE, expenses);

                InitFormMain(expenses);

                MSG.OK("登録完了", "正常に登録しました。");
            }
            catch (AbException ex)
            {
                var errIdx = errLine - 1;
                DgvExpense.ClearSelection();
                DgvExpense.Rows[errIdx].Selected = true;
                DgvExpense.FirstDisplayedScrollingRowIndex = errIdx;

                MSG.Error(ex.Message);
                return;
            }
        }
    }
}
