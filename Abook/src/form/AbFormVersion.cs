namespace Abook
{
    using System;
    using System.Drawing;
    using System.Reflection;
    using System.Windows.Forms;

    /// <summary>
    /// バージョン情報フォーム
    /// </summary>
    public partial class AbFormVersion : Form
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public AbFormVersion()
        {
            InitializeComponent();
        }

        /// <summary>
        /// バージョン情報の設定
        /// </summary>
        private void AbFormVersion_Load(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.GetEntryAssembly();

            //タイトル
            this.Text = Application.ProductName + " のバージョン情報";

            //システムアイコン
            PboxIcon.Image = SystemIcons.Application.ToBitmap();

            //製品名
            LblProduct.Text = Application.ProductName;

            //バージョン
            LblVersion.Text = "Version " + Application.ProductVersion;

            //コピーライト
            LblCopyright.Text = "-";
            object[] cpyArr = assembly.GetCustomAttributes(
                typeof(AssemblyCopyrightAttribute),
                false
            );
            if (cpyArr != null && cpyArr.Length > 0)
            {
                LblCopyright.Text = ((AssemblyCopyrightAttribute)cpyArr[0]).Copyright;
            }

            //詳細情報
            LblDescription.Text = "-";
            object[] desArr = assembly.GetCustomAttributes(
                typeof(AssemblyDescriptionAttribute),
                false
            );
            if (desArr != null && desArr.Length > 0)
            {
                LblDescription.Text = ((AssemblyDescriptionAttribute)desArr[0]).Description;
            }
        }

        /// <summary>
        /// フォームを閉じる
        /// </summary>
        private void BtnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
