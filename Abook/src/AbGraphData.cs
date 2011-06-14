namespace Abook
{
    using System;
    using System.Drawing;
    using System.Collections.Generic;

    /// <summary>
    /// グラフデータクラス
    /// </summary>
    public class AbGraphData
    {
        /// <summary>ペン</summary>
        private Pen pen;

        /// <summary>ブラシ</summary>
        private Brush brush;

        /// <summary>データ座標</summary>
        public List<Point> Points { get; private set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public AbGraphData(Brush brush)
        {
            this.brush  = brush;
            this.pen    = new Pen(brush);
            this.Points = new List<Point>();
        }

        /// <summary>
        /// 座標追加
        /// </summary>
        public void AddPoint(int value)
        {
            Points.Add(
                new Point(
                    (int)(AbCommonConst.HORIZONTAL * Points.Count),
                    (int)(AbCommonConst.COEFFICIENT * value + AbCommonConst.HEIGHT)
                )
            );
        }

        /// <summary>
        /// グラフ描画
        /// </summary>
        public void DrawData(Graphics g)
        {
            Point? prev = null;
            foreach (Point p in Points)
            {
                g.FillRectangle(
                    brush,
                    new Rectangle(
                        p.X - AbCommonConst.RECTANGLE_SIZE / 2,
                        p.Y - AbCommonConst.RECTANGLE_SIZE / 2,
                        AbCommonConst.RECTANGLE_SIZE,
                        AbCommonConst.RECTANGLE_SIZE
                    )
                );

                if (prev.HasValue)
                {
                    g.DrawLine(pen, prev.Value, p);
                }

                prev = p;
            }
        }
    }
}
