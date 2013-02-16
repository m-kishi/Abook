namespace Abook
{
    using System;
    using System.Windows.Forms;
    using UTIL = Abook.AbUtilities;

    /// <summary>
    /// ラベルコントロール
    /// </summary>
    public partial class AbLabelControl : UserControl
    {
        /// <summary>内部保持用</summary>
        private decimal _cost = decimal.Zero;

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
    }
}
