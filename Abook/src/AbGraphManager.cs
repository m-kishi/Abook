namespace Abook
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;

    /// <summary>
    /// グラフデータ管理クラス
    /// </summary>
    public class AbGraphManager
    {
        /// <summary>グラフ表示年月</summary>
        private DateTime dtNow;

        /// <summary>グラフデータ</summary>
        public List<AbGraphData> AbGraphDatas { get; private set; }

        /// <summary>基準線データ</summary>
        private List<AbGraphLine> abGraphLines;

        /// <summary>集計値リスト</summary>
        private List<AbSummary> abSummaries;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public AbGraphManager(DateTime dtToday, List<AbSummary> abSummaries)
        {
            if (abSummaries == null)
            {
                throw new ArgumentException("集計値リストが設定されませんでした。");
            }

            this.dtNow = dtToday;
            this.abGraphLines = new List<AbGraphLine>();
            this.abSummaries = abSummaries;

            SetGraphData(() => { });
        }

        /// <summary>
        /// グラフデータ作成
        /// </summary>
        private void SetGraphData(Action DtChange)
        {
            DtChange();

            AbGraphDatas = new List<AbGraphData>();
            var gdF = new AbGraphData(Brushes.Red   ); //食費
            var gdO = new AbGraphData(Brushes.Orange); //外食費
            var gdE = new AbGraphData(Brushes.Yellow); //電気代
            var gdG = new AbGraphData(Brushes.Gray  ); //ガス代
            var gdW = new AbGraphData(Brushes.Blue  ); //水道代

            int valF, valO, valE, valG, valW;
            for (var dt = dtNow.AddYears(-1); dt <= dtNow; dt = dt.AddMonths(1))
            {
                var sums = abSummaries.Where(sum => sum.Predicate(dt));
                var abSummary = (sums.Count() > 0) ? sums.First() : new AbSummary(dt, new List<AbExpense>());

                valF = abSummary.GetPriceByType("食費"  );
                valO = abSummary.GetPriceByType("外食費");
                valE = abSummary.GetPriceByName("電気代");
                valG = abSummary.GetPriceByName("ガス代");
                valW = abSummary.GetPriceByName("水道代");

                gdF.AddPoint(valF);
                gdO.AddPoint(valO);
                gdE.AddPoint(valE);
                gdG.AddPoint(valG);
                gdW.AddPoint(valW);
            }

            AbGraphDatas.Add(gdF);
            AbGraphDatas.Add(gdO);
            AbGraphDatas.Add(gdE);
            AbGraphDatas.Add(gdG);
            AbGraphDatas.Add(gdW);

            foreach (int value in AbCommonConst.LINE_VALUES)
            {
                abGraphLines.Add(new AbGraphLine(value));
            }
        }

        /// <summary>
        /// グラフ描画
        /// </summary>
        public void DrawGraph(Graphics g)
        {
            foreach (var gl in abGraphLines)
            {
                gl.DrawLine(g);
            }

            foreach (var gp in AbGraphDatas)
            {
                gp.DrawData(g);
            }
        }

        /// <summary>
        /// 表示月取得
        /// </summary>
        public string GetMonth(int prev)
        {
            return dtNow.AddMonths(prev).Month.ToString("00");
        }

        /// <summary>
        /// グラフ表示月取得
        /// </summary>
        public override string ToString()
        {
            return string.Format("～{0}年{1:d2}月", dtNow.Year, dtNow.Month);
        }

        /// <summary>
        /// 前年グラフ
        /// </summary>
        public void PrevYear()
        {
            SetGraphData(() => { dtNow = dtNow.AddYears(-1); });
        }

        /// <summary>
        /// 前月グラフ
        /// </summary>
        public void PrevMonth()
        {
            SetGraphData(() => { dtNow = dtNow.AddMonths(-1); });
        }

        /// <summary>
        /// 翌月グラフ
        /// </summary>
        public void NextMonth()
        {
            SetGraphData(() => { dtNow = dtNow.AddMonths(1); });
        }

        /// <summary>
        /// 翌年グラフ
        /// </summary>
        public void NextYear()
        {
            SetGraphData(() => { dtNow = dtNow.AddYears(1); });
        }
    }
}
