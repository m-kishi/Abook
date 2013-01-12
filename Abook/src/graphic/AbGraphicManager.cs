namespace Abook
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using EX    = Abook.AbException.EX;
    using FMT   = Abook.AbConstants.FMT;
    using NAME  = Abook.AbConstants.NAME;
    using TYPE  = Abook.AbConstants.TYPE;
    using GRAPH = Abook.AbConstants.GRAPH;

    /// <summary>
    /// グラフデータ管理クラス
    /// </summary>
    public class AbGraphicManager
    {
        /// <summary>グラフ表示年月</summary>
        private DateTime dtNow;

        /// <summary>グラフデータ</summary>
        public List<AbGraphicData> abGraphDatas;

        /// <summary>基準線データ</summary>
        private List<AbGraphicLine> abGraphLines;

        /// <summary>集計値リスト</summary>
        private List<AbSummary> abSummaries;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="date">日付</param>
        /// <param name="summaries">集計値リスト</param>
        public AbGraphicManager(DateTime date, List<AbSummary> summaries)
        {
            this.dtNow = date;
            if (summaries == null)
            {
                AbException.Throw(EX.SUMMARIES_NULL);
            }
            this.abSummaries = summaries;

            SetGraphLine();
            SetGraphData(() => { });
        }

        /// <summary>
        /// グラフ基準線設定
        /// </summary>
        private void SetGraphLine()
        {
            abGraphLines = new List<AbGraphicLine>();
            foreach (int value in GRAPH.LINE_VALUES)
            {
                abGraphLines.Add(new AbGraphicLine(value));
            }
        }

        /// <summary>
        /// グラフデータ設定
        /// </summary>
        /// <param name="DtChange">日付更新</param>
        private void SetGraphData(Action DtChange)
        {
            DtChange();

            abGraphDatas = new List<AbGraphicData>();
            var gdF = new AbGraphicData(Brushes.Red   ); // 食費
            var gdO = new AbGraphicData(Brushes.Orange); // 外食費
            var gdE = new AbGraphicData(Brushes.Yellow); // 電気代
            var gdG = new AbGraphicData(Brushes.Gray  ); // ガス代
            var gdW = new AbGraphicData(Brushes.Blue  ); // 水道代

            decimal valF, valO, valE, valG, valW;
            for (var dt = dtNow.AddYears(-1); dt <= dtNow; dt = dt.AddMonths(1))
            {
                var emptySummary = new AbSummary(dt, new List<AbExpense>());
                var selectedSummary = abSummaries.Where(sum =>
                    sum.Year == dt.Year && sum.Month == dt.Month
                ).FirstOrDefault();
                var summary = selectedSummary == null ? emptySummary : selectedSummary;

                valF = summary.GetCostByType(TYPE.FOOD);
                valO = summary.GetCostByType(TYPE.OTFD);
                valE = summary.GetCostByName(NAME.EL);
                valG = summary.GetCostByName(NAME.GS);
                valW = summary.GetCostByName(NAME.WT);

                gdF.AddPoint(valF);
                gdO.AddPoint(valO);
                gdE.AddPoint(valE);
                gdG.AddPoint(valG);
                gdW.AddPoint(valW);
            }

            abGraphDatas.Add(gdF);
            abGraphDatas.Add(gdO);
            abGraphDatas.Add(gdE);
            abGraphDatas.Add(gdG);
            abGraphDatas.Add(gdW);
        }

        /// <summary>
        /// タイトル
        /// </summary>
        public string Title
        {
            get { return dtNow.ToString(FMT.TITLE); }
        }

        /// <summary>
        /// グラフ描画
        /// </summary>
        /// <param name="g">Graphics オブジェクト</param>
        public void DrawGraph(Graphics g)
        {
            foreach (var gl in abGraphLines)
            {
                gl.DrawLine(g);
            }

            foreach (var gd in abGraphDatas)
            {
                gd.DrawData(g);
            }
        }

        /// <summary>
        /// 表示月取得
        /// </summary>
        /// <param name="prev">月指定</param>
        /// <returns>表示月</returns>
        public string GetMonth(int prev)
        {
            return dtNow.AddMonths(prev).ToString(FMT.MONTH);
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
