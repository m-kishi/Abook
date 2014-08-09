namespace Abook
{
    using System;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using TYPE = Abook.AbConstants.TYPE;
    using UTIL = Abook.AbUtilities;

    /// <summary>
    /// ラベルコントロール
    /// </summary>
    public partial class AbLabelControl : UserControl
    {
        /// <summary>内部保持用</summary>
        private decimal _cost = decimal.Zero;

        /// <summary>種別名クリック</summary>
        public event EventHandler TypeNameClick;

        /// <summary>通常フォント</summary>
        private static readonly Font FONT_REGULAR   = new Font("MS UI Gothic", 9F, FontStyle.Regular  , GraphicsUnit.Point, ((byte)(128)));

        /// <summary>下線フォント</summary>
        private static readonly Font FONT_UNDERLINE = new Font("MS UI Gothic", 9F, FontStyle.Underline, GraphicsUnit.Point, ((byte)(128)));

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public AbLabelControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ラベル
        /// </summary>
        public string Label
        {
            get { return _Label.Text; }
            set { _Label.Text = value; }
        }

        /// <summary>
        /// 値
        /// </summary>
        public decimal Cost
        {
            get { return _cost; }
            set { _cost = value; _Value.Text = UTIL.ToYen(value); }
        }

        /// <summary>
        /// イベント設定
        /// </summary>
        private void _Label_TextChanged(object sender, EventArgs e)
        {
            if (TYPE.SUMMARY.EXPE.Contains(_Label.Text))
            {
                _Label.Click += new System.EventHandler(this._Label_Click);
                _Value.Click += new System.EventHandler(this._Value_Click);
                _Label.MouseEnter += new System.EventHandler(this._Label_MouseEnter);
                _Value.MouseEnter += new System.EventHandler(this._Value_MouseEnter);
                _Label.MouseLeave += new System.EventHandler(this._Label_MouseLeave);
                _Value.MouseLeave += new System.EventHandler(this._Value_MouseLeave);
            }
        }

        /// <summary>
        /// マウスオン
        /// </summary>
        private void _Label_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            if (TYPE.SUMMARY.EXPE.Contains(_Label.Text))
            {
                _Label.Font = FONT_UNDERLINE;
            }
        }

        /// <summary>
        /// マウスオン
        /// </summary>
        private void _Value_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            if (TYPE.SUMMARY.EXPE.Contains(_Label.Text))
            {
                _Value.Font = FONT_UNDERLINE;
            }
        }

        /// <summary>
        /// マウスオフ
        /// </summary>
        private void _Label_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            if (TYPE.SUMMARY.EXPE.Contains(_Label.Text))
            {
                _Label.Font = FONT_REGULAR;
            }
        }

        /// <summary>
        /// マウスオフ
        /// </summary>
        private void _Value_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            if (TYPE.SUMMARY.EXPE.Contains(_Label.Text))
            {
                _Value.Font = FONT_REGULAR;
            }
        }

        /// <summary>
        /// 種別名クリック
        /// </summary>
        private void _Label_Click(object sender, EventArgs e)
        {
            TypeNameClick(sender, e);
        }

        /// <summary>
        /// 金額クリック
        /// </summary>
        private void _Value_Click(object sender, EventArgs e)
        {
            TypeNameClick(_Label, e);
        }
    }
}
