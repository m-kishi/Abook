using System;
using System.Drawing;
using System.Collections.Generic;

namespace Abook
{
    /// <summary>
    /// グラフデータ座標クラス
    /// </summary>
    public class AbGraphPoints
    {
        /// <summary>ペン</summary>
        private Pen pen;

        /// <summary>ブラシ</summary>
        private Brush brush;

        /// <summary>データ座標</summary>
        private List<Point> points;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public AbGraphPoints(Brush brush)
        {
            this.brush  = brush;
            this.pen    = new Pen(brush);
            this.points = new List<Point>();
        }

        /// <summary>
        /// 座標追加
        /// </summary>
        public void add(int value)
        {
            points.Add(
                new Point(
                    (int)(AbCommonConst.HORIZONTAL * points.Count),
                    (int)(AbCommonConst.COEFFICIENT * value + AbCommonConst.HEIGHT)
                )
            );
        }

        /// <summary>
        /// グラフ描画
        /// </summary>
        public void draw(Graphics g)
        {
            Point? prev = null;
            foreach (Point p in points)
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
