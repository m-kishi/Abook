namespace Abook
{
    using System;
    using System.Drawing;

    /// <summary>
    /// グラフ基準線クラス
    /// </summary>
    public class AbGraphLine
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
        public AbGraphLine(int value)
        {
            pen = new Pen(Brushes.Gray);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

            int h = (int)(AbCommonConst.COEFFICIENT * value + AbCommonConst.HEIGHT);
            strPoint = new Point(0, h);
            endPoint = new Point((int)AbCommonConst.WIDTH, h);
        }

        /// <summary>
        /// 基準線描画
        /// </summary>
        public void DrawLine(Graphics g)
        {
            g.DrawLine(pen, strPoint, endPoint);
        }

        /// <summary>
        /// 座標点表示
        /// </summary>
        public override string ToString()
        {
            return string.Format(
                "({0},{1})-({2},{3})",
                strPoint.X, strPoint.Y,
                endPoint.X, endPoint.Y
            );
        }
    }
}
