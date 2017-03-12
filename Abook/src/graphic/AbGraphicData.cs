// ------------------------------------------------------------
// Copyright (C) 2010-2017 Masaaki Kishi. All rights reserved.
// Author: Masaaki Kishi <m.kishi.5@gmail.com>
// ------------------------------------------------------------
namespace Abook
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using GRAPH = Abook.AbConstants.GRAPH;

    /// <summary>
    /// グラフデータクラス
    /// </summary>
    public class AbGraphicData
    {
        /// <summary>ペン</summary>
        private Pen pen;
        /// <summary>ブラシ</summary>
        private Brush brush;
        /// <summary>データ座標</summary>
        private List<Point> Points;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="brush">Brushオブジェクト</param>
        public AbGraphicData(Brush brush)
        {
            this.brush  = brush;
            this.pen    = new Pen(brush);
            this.Points = new List<Point>();
        }

        /// <summary>
        /// 座標追加
        /// </summary>
        /// <param name="value">金額</param>
        public void AddPoint(decimal value)
        {
            var x = (int)(GRAPH.HORIZONTAL * Points.Count);
            var y = (int)(GRAPH.COEFFICIENT * value + GRAPH.HEIGHT);
            Points.Add(new Point(x, y));
        }

        /// <summary>
        /// グラフ描画
        /// </summary>
        /// <param name="g">Graphicsオブジェクト</param>
        public void DrawData(Graphics g)
        {
            Point? prev = null;
            foreach (var point in Points)
            {
                g.FillRectangle(
                    brush,
                    new Rectangle(
                        point.X - GRAPH.RECTANGLE_SIZE / 2,
                        point.Y - GRAPH.RECTANGLE_SIZE / 2,
                        GRAPH.RECTANGLE_SIZE,
                        GRAPH.RECTANGLE_SIZE
                    )
                );

                if (prev.HasValue)
                {
                    g.DrawLine(pen, prev.Value, point);
                }

                prev = point;
            }
        }
    }
}
