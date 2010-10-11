using System;
using System.Collections.Generic;
using System.Drawing;

namespace Abook
{
    /// <summary>
    /// グラフデータ管理クラス
    /// </summary>
    public class AbGraphManager
    {
        /// <summary>レコードリスト</summary>
        private List<AbExpense> abExpenses;

        /// <summary>基準線データ</summary>
        private List<AbGraphLine> abGraphLines;

        /// <summary>グラフデータ</summary>
        private List<AbGraphPoints> abGraphPoints;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public AbGraphManager(DateTime today, List<AbExpense> expenses)
        {
            abExpenses = expenses;
            abGraphLines = new List<AbGraphLine>();

            reload(today);
        }

        /// <summary>
        /// グラフデータの再読み込み
        /// </summary>
        public void reload(DateTime newDay)
        {
            abGraphPoints = new List<AbGraphPoints>();
            AbGraphPoints gpF = new AbGraphPoints(Brushes.Red   ); //食費
            AbGraphPoints gpO = new AbGraphPoints(Brushes.Orange); //外食費
            AbGraphPoints gpE = new AbGraphPoints(Brushes.Yellow); //電気代
            AbGraphPoints gpG = new AbGraphPoints(Brushes.Gray  ); //ガス代
            AbGraphPoints gpW = new AbGraphPoints(Brushes.Blue  ); //水道代

            AbSummary sum;
            int valF, valO, valE, valG, valW;
            DateTime dtEnd = newDay.AddMonths(1);
            for (DateTime dt = newDay.AddMonths(-10); dt <= newDay.AddMonths(1); dt = dt.AddMonths(1))
            {
                sum = new AbSummary(dt.Year, dt.Month, abExpenses);
                valF = sum.GetPrice("食費");
                valO = sum.GetPrice("外食費");
                valE = sum.GetPrice("電気代");
                valG = sum.GetPrice("ガス代");
                valW = sum.GetPrice("水道代");

                gpF.add(valF);
                gpO.add(valO);
                gpE.add(valE);
                gpG.add(valG);
                gpW.add(valW);
            }

            abGraphPoints.Add(gpF);
            abGraphPoints.Add(gpO);
            abGraphPoints.Add(gpE);
            abGraphPoints.Add(gpG);
            abGraphPoints.Add(gpW);

            foreach (int value in AbCommonConst.LINE_VALUES)
            {
                abGraphLines.Add(new AbGraphLine(value));
            }
        }

        /// <summary>
        /// グラフ描画
        /// </summary>
        public void drawGraph(Graphics g)
        {
            foreach (AbGraphLine gl in abGraphLines)
            {
                gl.draw(g);
            }

            foreach (AbGraphPoints gp in abGraphPoints)
            {
                gp.draw(g);
            }
        }
    }
}
