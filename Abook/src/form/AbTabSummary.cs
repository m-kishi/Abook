namespace Abook
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using TYPE = Abook.AbConstants.TYPE;
    using UTIL = Abook.AbUtilities;

    /// <summary>
    /// 集計タブ
    /// </summary>
    public partial class AbFormMain
    {
        /// <summary>支出データ管理</summary>
        private AbExpenseManager abExpenseManager;

        /// <summary>
        /// 集計タブ初期化
        /// </summary>
        /// <param name="summaries">集計値リスト</param>
        private void InitTabSummary(List<AbSummary> summaries)
        {
            abExpenseManager = new AbExpenseManager(DateTime.Now, summaries);
            SetTabSummary(() => { });
        }

        /// <summary>
        /// 集計タブ表示
        /// </summary>
        /// <param name="ExpenseManager">支出データ管理処理</param>
        private void SetTabSummary(Action ExpenseManager)
        {
            ExpenseManager();

            LblSummary.Text = abExpenseManager.Title;
            LblYen01食費.Text   = UTIL.ToYen(abExpenseManager.GetCost(TYPE.FOOD));
            LblYen02外食費.Text = UTIL.ToYen(abExpenseManager.GetCost(TYPE.OTFD));
            LblYen03雑貨.Text   = UTIL.ToYen(abExpenseManager.GetCost(TYPE.GOOD));
            LblYen04交際費.Text = UTIL.ToYen(abExpenseManager.GetCost(TYPE.FRND));
            LblYen05交通費.Text = UTIL.ToYen(abExpenseManager.GetCost(TYPE.TRFC));
            LblYen06遊行費.Text = UTIL.ToYen(abExpenseManager.GetCost(TYPE.PLAY));
            LblYen07家賃.Text   = UTIL.ToYen(abExpenseManager.GetCost(TYPE.HOUS));
            LblYen08光熱費.Text = UTIL.ToYen(abExpenseManager.GetCost(TYPE.ENGY));
            LblYen09通信費.Text = UTIL.ToYen(abExpenseManager.GetCost(TYPE.CNCT));
            LblYen10医療費.Text = UTIL.ToYen(abExpenseManager.GetCost(TYPE.MEDI));
            LblYen11保険料.Text = UTIL.ToYen(abExpenseManager.GetCost(TYPE.INSU));
            LblYen12その他.Text = UTIL.ToYen(abExpenseManager.GetCost(TYPE.OTHR));
            LblYen13合計.Text   = UTIL.ToYen(abExpenseManager.GetCost(TYPE.TTAL));
            LblYen14残金.Text   = UTIL.ToYen(abExpenseManager.GetCost(TYPE.BLNC));
        }

        /// <summary>
        /// 前年表示
        /// </summary>
        private void BtnExpPrevYear_Click(object sender, EventArgs e)
        {
            SetTabSummary(abExpenseManager.PrevYear);
        }

        /// <summary>
        /// 前月表示
        /// </summary>
        private void BtnExpPrevMonth_Click(object sender, EventArgs e)
        {
            SetTabSummary(abExpenseManager.PrevMonth);
        }

        /// <summary>
        /// 翌月表示
        /// </summary>
        private void BtnExpNextMonth_Click(object sender, EventArgs e)
        {
            SetTabSummary(abExpenseManager.NextMonth);
        }

        /// <summary>
        /// 翌年表示
        /// </summary>
        private void BtnExpNextYear_Click(object sender, EventArgs e)
        {
            SetTabSummary(abExpenseManager.NextYear);
        }
    }
}
