using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Abook
{
    /// <summary>
    /// バージョン情報フォーム
    /// </summary>
    public partial class AbFormVersion : Form
    {
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
            picbIcon.Image = SystemIcons.Application.ToBitmap();

            //製品名
            lblProduct.Text = Application.ProductName;

            //バージョン
            lblVersion.Text = "Version " + Application.ProductVersion;

            //コピーライト
            lblCopyright.Text = "-";
            object[] cpyArr =
                assembly.GetCustomAttributes(
                    typeof(AssemblyCopyrightAttribute),
                    false
            );
            if (cpyArr != null && cpyArr.Length > 0)
            {
                lblCopyright.Text = ((AssemblyCopyrightAttribute)cpyArr[0]).Copyright;
            }

            //詳細情報
            lblDescription.Text = "-";
            object[] desArr =
                assembly.GetCustomAttributes(
                    typeof(AssemblyDescriptionAttribute),
                    false
            );
            if (desArr != null && desArr.Length > 0)
            {
                lblDescription.Text = ((AssemblyDescriptionAttribute)desArr[0]).Description;
            }
        }

        /// <summary>
        /// フォームを閉じる
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
