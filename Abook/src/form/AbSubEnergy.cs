namespace Abook
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using FMT  = Abook.AbConstants.FMT;
    using CHK  = Abook.AbUtilities.CHK;
    using NAME = Abook.AbConstants.NAME;

    /// <summary>
    /// 光熱費サブフォーム
    /// </summary>
    public partial class AbSubEnergy : Form
    {
        /// <summary>支出情報リスト</summary>
        private List<AbExpense> expenses;

        /// <summary>
        /// 光熱費クラス
        /// </summary>
        private class Energy
        {
            /// <summary>年月</summary>
            public DateTime Date;
            /// <summary>電気代</summary>
            public decimal El;
            /// <summary>ガス代</summary>
            public decimal Gs;
            /// <summary>水道代</summary>
            public decimal Wt;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="expenses">支出情報リスト</param>
        public AbSubEnergy(List<AbExpense> expenses)
        {
            InitializeComponent();

            CHK.ExpNull(expenses);
            this.expenses = expenses;
        }

        /// <summary>
        /// フォームロード
        /// </summary>
        private void AbSubEnergy_Load(object sender, EventArgs e)
        {
            try
            {
                //最大値・最小値
                var minEl = new decimal[12]; var maxEl = new decimal[12];
                var minGs = new decimal[12]; var maxGs = new decimal[12];
                var minWt = new decimal[12]; var maxWt = new decimal[12];

                //光熱費の情報を抽出して集計
                var energies = GetExtracedEnergy(expenses);
                if (energies == null || energies.Count <= 0) return;

                //表示範囲の設定(年度は4/1～3/31)
                var dtStr = energies.First().Date;
                var dtEnd = energies.Last ().Date;
                dtStr = new DateTime(dtStr.Year - (dtStr.Month < 4 ? 1 : 0), 4,  1);
                dtEnd = new DateTime(dtEnd.Year + (dtEnd.Month < 4 ? 0 : 1), 3, 31);

                int count = dtEnd.Year - dtStr.Year + 1;
                DgvEl.Rows.Clear(); DgvEl.Rows.Add(count);
                DgvGs.Rows.Clear(); DgvGs.Rows.Add(count);
                DgvWt.Rows.Clear(); DgvWt.Rows.Add(count);

                //平均(最大値・最小値も同時に計算)
                var dtAve = dtStr;
                var rowAveEl = DgvEl.Rows[DgvEl.Rows.Count - 1]; rowAveEl.Cells[0].Value = "ave";
                var rowAveGs = DgvGs.Rows[DgvEl.Rows.Count - 1]; rowAveGs.Cells[0].Value = "ave";
                var rowAveWt = DgvWt.Rows[DgvEl.Rows.Count - 1]; rowAveWt.Cells[0].Value = "ave";
                for (int cIdx = 1; cIdx <= 12; cIdx++, dtAve = dtAve.AddMonths(1))
                {
                    var filter = energies.Where(eng => eng.Date.Month == dtAve.Month);
                    if (filter != null && filter.Count() > 0)
                    {
                        rowAveEl.Cells[cIdx].Value = filter.Average(eng => eng.El);
                        rowAveGs.Cells[cIdx].Value = filter.Average(eng => eng.Gs);
                        rowAveWt.Cells[cIdx].Value = filter.Average(eng => eng.Wt);
                        minEl[cIdx - 1] = filter.Min(eng => eng.El); maxEl[cIdx - 1] = filter.Max(eng => eng.El);
                        minGs[cIdx - 1] = filter.Min(eng => eng.Gs); maxGs[cIdx - 1] = filter.Max(eng => eng.Gs);
                        minWt[cIdx - 1] = filter.Min(eng => eng.Wt); maxWt[cIdx - 1] = filter.Max(eng => eng.Wt);
                    }
                }

                //各年月の光熱費
                for (int rIdx = 0; dtStr <= dtEnd; rIdx++)
                {
                    var rowEl = DgvEl.Rows[rIdx]; rowEl.Cells[0].Value = dtStr.Year;
                    var rowGs = DgvGs.Rows[rIdx]; rowGs.Cells[0].Value = dtStr.Year;
                    var rowWt = DgvWt.Rows[rIdx]; rowWt.Cells[0].Value = dtStr.Year;
                    for (int cIdx = 1; cIdx <= 12; cIdx++, dtStr = dtStr.AddMonths(1))
                    {
                        var energy = energies.Where(eng =>
                            eng.Date.Year == dtStr.Year && eng.Date.Month == dtStr.Month
                        ).FirstOrDefault();

                        var valueEl = (energy == null ? -1m : energy.El);
                        var valueGs = (energy == null ? -1m : energy.Gs);
                        var valueWt = (energy == null ? -1m : energy.Wt);
                        SetCellValue(rowEl.Cells[cIdx], valueEl, minEl[cIdx - 1], maxEl[cIdx - 1]);
                        SetCellValue(rowGs.Cells[cIdx], valueGs, minGs[cIdx - 1], maxGs[cIdx - 1]);
                        SetCellValue(rowWt.Cells[cIdx], valueWt, minWt[cIdx - 1], maxWt[cIdx - 1]);
                    }
                }

            }
            finally
            {
                expenses.Clear();
            }
        }

        /// <summary>
        /// 光熱費の情報を抽出して集計
        /// </summary>
        /// <param name="expenses">支出情報リスト</param>
        /// <returns>光熱費情報リスト</returns>
        private List<Energy> GetExtracedEnergy(List<AbExpense> expenses)
        {
            return expenses.Where(exp =>
                NAME.ENERGY.Contains(exp.Name)
            ).GroupBy(exp =>
                exp.Date.ToString(FMT.MONTHLY_GROUP)
            ).Select(gObj =>
                new Energy
                {
                    Date = DateTime.ParseExact(string.Format(FMT.DAILY_GROUP, gObj.Key), FMT.DATE, null),
                    El = gObj.Where(exp => exp.Name == NAME.EL).Sum(exp => exp.Cost),
                    Gs = gObj.Where(exp => exp.Name == NAME.GS).Sum(exp => exp.Cost),
                    Wt = gObj.Where(exp => exp.Name == NAME.WT).Sum(exp => exp.Cost),
                }
            ).ToList();
        }

        /// <summary>
        /// セルへ光熱費の値を設定
        /// </summary>
        /// <param name="cell" >セル  </param>
        /// <param name="value">金額  </param>
        /// <param name="min"  >最小値</param>
        /// <param name="max"  >最大値</param>
        private void SetCellValue(DataGridViewCell cell, decimal value, decimal min, decimal max)
        {
            if (value == -1) return;

            cell.Value = value;
            if (value == min) { cell.Style.ForeColor = Color.Blue; }
            if (value == max) { cell.Style.ForeColor = Color.Red;  }
        }
    }
}
