namespace Abook
{
    using System;
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
        /// 下線表示とイベント設定
        /// </summary>
        private void _Label_TextChanged(object sender, EventArgs e)
        {
            if (TYPE.SUMMARY.EXPE.Contains(_Label.Text))
            {
                _Label.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                _Label.Click += new System.EventHandler(this._Label_Click);
                _Label.MouseEnter += new System.EventHandler(this._Label_MouseEnter);
                _Label.MouseLeave += new System.EventHandler(this._Label_MouseLeave);
            }
        }

        /// <summary>
        /// マウスオン
        /// </summary>
        private void _Label_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// マウスオフ
        /// </summary>
        private void _Label_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// 種別名クリック
        /// </summary>
        private void _Label_Click(object sender, EventArgs e)
        {
            TypeNameClick(sender, e);
        }
    }
}
