﻿// ------------------------------------------------------------
// © 2010 https://github.com/m-kishi
// ------------------------------------------------------------
namespace Abook
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using CHK   = Abook.AbUtilities.CHK;
    using FMT   = Abook.AbConstants.FMT;
    using NAME  = Abook.AbConstants.NAME;
    using TYPE  = Abook.AbConstants.TYPE;
    using GRAPH = Abook.AbConstants.GRAPH;

    /// <summary>
    /// 推移情報管理クラス
    /// </summary>
    public class AbGraphicManager
    {
        /// <summary>表示年月</summary>
        private DateTime dtNow;
        /// <summary>推移情報リスト</summary>
        public List<AbGraphicData> abGraphDatas;
        /// <summary>基準線データリスト</summary>
        private List<AbGraphicLine> abGraphLines;
        /// <summary>月次情報リスト</summary>
        private List<AbSummary> abSummaries;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="date">日付</param>
        /// <param name="summaries">月次情報リスト</param>
        public AbGraphicManager(DateTime date, List<AbSummary> summaries)
        {
            CHK.SumNull(summaries);

            dtNow = date;
            abSummaries = summaries;

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
        /// 推移情報設定
        /// </summary>
        /// <param name="DtChange">日付更新</param>
        private void SetGraphData(Action DtChange)
        {
            DtChange();

            abGraphDatas = new List<AbGraphicData>();
            // 食費
            var gdF = new AbGraphicData(Brushes.Red   );
            // 外食費
            var gdO = new AbGraphicData(Brushes.Orange);
            // 電気代
            var gdE = new AbGraphicData(Brushes.Yellow);
            // ガス代
            var gdG = new AbGraphicData(Brushes.Gray  );
            // 水道代
            var gdW = new AbGraphicData(Brushes.Blue  );

            decimal valF, valO, valE, valG, valW;
            for (var dt = dtNow.AddYears(-1); dt <= dtNow; dt = dt.AddMonths(1))
            {
                var emptySummary = new AbSummary(dt, new List<AbExpense>());
                var selectedSummary = abSummaries.Where(sum =>
                    sum.Year == dt.Year && sum.Month == dt.Month
                ).FirstOrDefault();
                var summary = (selectedSummary == null) ? emptySummary : selectedSummary;

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
        /// <param name="g">Graphicsオブジェクト</param>
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
        /// 前年へ切り替え
        /// </summary>
        public void PrevYear()
        {
            SetGraphData(() => { dtNow = dtNow.AddYears(-1); });
        }

        /// <summary>
        /// 前月へ切り替え
        /// </summary>
        public void PrevMonth()
        {
            SetGraphData(() => { dtNow = dtNow.AddMonths(-1); });
        }

        /// <summary>
        /// 翌月へ切り替え
        /// </summary>
        public void NextMonth()
        {
            SetGraphData(() => { dtNow = dtNow.AddMonths(1); });
        }

        /// <summary>
        /// 翌年へ切り替え
        /// </summary>
        public void NextYear()
        {
            SetGraphData(() => { dtNow = dtNow.AddYears(1); });
        }
    }
}
