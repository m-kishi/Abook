using System;
using System.Drawing;

namespace Abook
{
    /// <summary>
    /// グラフ基準線情報
    /// </summary>
    public class AbGraphLine
    {
        /// <summary>描画ペン</summary>
        private Pen pen;

        /// <summary>開始座標</summary>
        private Point fPoint;

        /// <summary>終了座標</summary>
        private Point tPoint;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public AbGraphLine(int value)
        {
            pen = new Pen(Brushes.Gray);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

            int h = (int)(AbCommonConst.COEFFICIENT * value + AbCommonConst.HEIGHT);
            fPoint = new Point(0, h);
            tPoint = new Point((int)AbCommonConst.WIDTH, h);
        }

        /// <summary>
        /// 基準線描画
        /// </summary>
        public void draw(Graphics g)
        {
            g.DrawLine(pen, fPoint, tPoint);
        }
    }
}
