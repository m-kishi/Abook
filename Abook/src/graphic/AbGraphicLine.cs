// ------------------------------------------------------------
// © 2010 https://github.com/m-kishi
// ------------------------------------------------------------
namespace Abook
{
    using System;
    using System.Drawing;
    using GRAPH = Abook.AbConstants.GRAPH;

    /// <summary>
    /// グラフ基準線クラス
    /// </summary>
    public class AbGraphicLine
    {
        /// <summary>描画ペン</summary>
        private Pen pen;
        /// <summary>開始座標</summary>
        private Point strPoint;
        /// <summary>終了座標</summary>
        private Point endPoint;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="value">基準値</param>
        public AbGraphicLine(int value)
        {
            pen = new Pen(Brushes.Gray);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

            int h = (int)(GRAPH.COEFFICIENT * value + GRAPH.HEIGHT);
            strPoint = new Point(0, h);
            endPoint = new Point((int)GRAPH.WIDTH, h);
        }

        /// <summary>
        /// 基準線描画
        /// </summary>
        /// <param name="g">Graphicsオブジェクト</param>
        public void DrawLine(Graphics g)
        {
            g.DrawLine(pen, strPoint, endPoint);
        }
    }
}
