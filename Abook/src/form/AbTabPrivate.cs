namespace Abook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using COL = Abook.AbConstants.COL.PRIVATE;

    /// <summary>
    /// 秘密収支タブ
    /// </summary>
    public partial class AbFormMain
    {
        /// <summary>秘密収支情報管理</summary>
        private AbPrivateManager abPrivateManager;

        /// <summary>
        /// 秘密収支タブ初期化
        /// </summary>
        /// <param name="expenses">支出情報リスト</param>
        private void InitTabPrivate(List<AbExpense> expenses)
        {
            abPrivateManager = new AbPrivateManager(expenses);
            SetTabPrivate();
        }

        /// <summary>
        /// 秘密収支タブ表示
        /// </summary>
        private void SetTabPrivate()
        {
            DgvPrivate.Rows.Clear();
            var privates = abPrivateManager.Privates();
            if (privates.Count() > 0)
            {
                var i = 0;
                DgvPrivate.Rows.Add(privates.Count());
                foreach (var prv in privates)
                {
                    DataGridViewRow row = DgvPrivate.Rows[i++];
                    row.Cells[COL.DATE].Value = prv.Date;
                    row.Cells[COL.NAME].Value = prv.Name;
                    row.Cells[COL.COST].Value = prv.Cost;
                    row.Cells[COL.BLNC].Value = prv.Blnc;
                }
            }

            DgvPrivate.ClearSelection();
            if (DgvPrivate.Rows.Count > 0)
            {
                var idx = DgvPrivate.Rows.Count - 1;
                DgvPrivate.Rows[idx].Selected = true;
                DgvPrivate.FirstDisplayedScrollingRowIndex = idx;
                DgvPrivate.Rows[idx].Cells[COL.BLNC].Selected = true;
            }
        }
    }
}
