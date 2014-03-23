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
        /// <summary>支出情報管理</summary>
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
        /// <param name="ExpenseManager">支出情報管理処理</param>
        private void SetTabSummary(Action ExpenseManager)
        {
            ExpenseManager();

            HeadSummary.Title = abExpenseManager.Title;
            LblFood.Cost = abExpenseManager.GetCost(TYPE.FOOD);
            LblOtfd.Cost = abExpenseManager.GetCost(TYPE.OTFD);
            LblGood.Cost = abExpenseManager.GetCost(TYPE.GOOD);
            LblFrnd.Cost = abExpenseManager.GetCost(TYPE.FRND);
            LblTrfc.Cost = abExpenseManager.GetCost(TYPE.TRFC);
            LblPlay.Cost = abExpenseManager.GetCost(TYPE.PLAY);
            LblHous.Cost = abExpenseManager.GetCost(TYPE.HOUS);
            LblEngy.Cost = abExpenseManager.GetCost(TYPE.ENGY);
            LblCnct.Cost = abExpenseManager.GetCost(TYPE.CNCT);
            LblMedi.Cost = abExpenseManager.GetCost(TYPE.MEDI);
            LblInsu.Cost = abExpenseManager.GetCost(TYPE.INSU);
            LblOthr.Cost = abExpenseManager.GetCost(TYPE.OTHR);
            LblTtal.Cost = abExpenseManager.GetCost(TYPE.TTAL);
            LblBlnc.Cost = abExpenseManager.GetCost(TYPE.BLNC);
        }

        /// <summary>
        /// 前年表示
        /// </summary>
        private void HeadSummary_PrevYearClick(object sender, EventArgs e)
        {
            SetTabSummary(abExpenseManager.PrevYear);
        }

        /// <summary>
        /// 前月表示
        /// </summary>
        private void HeadSummary_PrevMonthClick(object sender, EventArgs e)
        {
            SetTabSummary(abExpenseManager.PrevMonth);
        }

        /// <summary>
        /// 翌月表示
        /// </summary>
        private void HeadSummary_NextMonthClick(object sender, EventArgs e)
        {
            SetTabSummary(abExpenseManager.NextMonth);
        }

        /// <summary>
        /// 翌年表示
        /// </summary>
        private void HeadSummary_NextYearClick(object sender, EventArgs e)
        {
            SetTabSummary(abExpenseManager.NextYear);
        }

        /// <summary>
        /// 種別名クリック
        /// </summary>
        private void LabelControl_TypeNameClick(object sender, EventArgs e)
        {
            var label = (Label)sender;
            var subFromType = new AbSubType(
                this,
                label.Text,
                abExpenseManager.CurrentDate
            );
            subFromType.ShowDialog();
        }
    }
}
