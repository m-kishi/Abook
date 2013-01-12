namespace Abook
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// ヘッダーコントロール
    /// </summary>
    public partial class AbHeaderControl : UserControl
    {
        /// <summary>前年ボタンクリック</summary>
        public event EventHandler PrevYearClick;
        /// <summary>前月ボタンクリック</summary>
        public event EventHandler PrevMonthClick;
        /// <summary>翌月ボタンクリック</summary>
        public event EventHandler NextMonthClick;
        /// <summary>翌年ボタンクリック</summary>
        public event EventHandler NextYearClick;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public AbHeaderControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// タイトル
        /// </summary>
        public string Title
        {
            get { return LblTitle.Text; }
            set { LblTitle.Text = value; }
        }

        /// <summary>
        /// 前年ボタンクリック
        /// </summary>
        private void BtnPrevYear_Click(object sender, EventArgs e)
        {
            PrevYearClick(sender, e);
        }

        /// <summary>
        /// 前月ボタンクリック
        /// </summary>
        private void BtnPrevMonth_Click(object sender, EventArgs e)
        {
            PrevMonthClick(sender, e);
        }

        /// <summary>
        /// 翌月ボタンクリック
        /// </summary>
        private void BtnNextMonth_Click(object sender, EventArgs e)
        {
            NextMonthClick(sender, e);
        }

        /// <summary>
        /// 翌年ボタンクリック
        /// </summary>
        private void BtnNextYear_Click(object sender, EventArgs e)
        {
            NextYearClick(sender, e);
        }
    }
}
