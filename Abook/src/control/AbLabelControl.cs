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
            set { _Value.Text = UTIL.ToYen(value); }
        }
    }
}
