// ------------------------------------------------------------
// © 2010 https://github.com/m-kishi
// ------------------------------------------------------------
namespace Abook
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// 推移タブ
    /// </summary>
    public partial class AbFormMain
    {
        /// <summary>推移情報管理</summary>
        private AbGraphicManager abGraphicManager;

        /// <summary>
        /// 推移タブ初期化
        /// </summary>
        /// <param name="summaries">月次情報リスト</param>
        private void InitTabGraphic(List<AbSummary> summaries)
        {
            abGraphicManager = new AbGraphicManager(DateTime.Now, summaries);
        }

        /// <summary>
        /// 描画イベント
        /// </summary>
        private void PboxGraph_Paint(object sender, PaintEventArgs e)
        {
            SetViewGraph(e.Graphics, () => { });
        }

        /// <summary>
        /// 推移タブ表示
        /// </summary>
        /// <param name="g">Graphicsオブジェクト</param>
        /// <param name="GraphicManager">推移情報管理</param>
        private void SetViewGraph(Graphics g, Action GraphicManager)
        {
            GraphicManager();

            g.Clear(Color.Black);
            abGraphicManager.DrawGraph(g);

            HeadGraphic.Title = abGraphicManager.Title;
            LblX6.Text = abGraphicManager.GetMonth(0);
            LblX5.Text = abGraphicManager.GetMonth(-2);
            LblX4.Text = abGraphicManager.GetMonth(-4);
            LblX3.Text = abGraphicManager.GetMonth(-6);
            LblX2.Text = abGraphicManager.GetMonth(-8);
            LblX1.Text = abGraphicManager.GetMonth(-10);
        }

        /// <summary>
        /// 前年表示
        /// </summary>
        private void HeadGraphic_PrevYearClick(object sender, EventArgs e)
        {
            var g = PboxGraph.CreateGraphics();
            SetViewGraph(g, abGraphicManager.PrevYear);
        }

        /// <summary>
        /// 前月表示
        /// </summary>
        private void HeadGraphic_PrevMonthClick(object sender, EventArgs e)
        {
            var g = PboxGraph.CreateGraphics();
            SetViewGraph(g, abGraphicManager.PrevMonth);
        }

        /// <summary>
        /// 翌月表示
        /// </summary>
        private void HeadGraphic_NextMonthClick(object sender, EventArgs e)
        {
            var g = PboxGraph.CreateGraphics();
            SetViewGraph(g, abGraphicManager.NextMonth);
        }

        /// <summary>
        /// 翌年表示
        /// </summary>
        private void HeadGraphic_NextYearClick(object sender, EventArgs e)
        {
            var g = PboxGraph.CreateGraphics();
            SetViewGraph(g, abGraphicManager.NextYear);
        }
    }
}
