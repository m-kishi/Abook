// ------------------------------------------------------------
// Copyright (C) 2010-2017 Masaaki Kishi. All rights reserved.
// Author: Masaaki Kishi <m.kishi.5@gmail.com>
// ------------------------------------------------------------
namespace Abook
{
    using System;
    using System.Drawing;
    using System.Linq;
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
            if (assembly == null) return;

            //タイトル
            this.Text = Application.ProductName + " のバージョン情報";

            //製品名
            LblProduct.Text = Application.ProductName;

            //バージョン
            LblVersion.Text = "Version " + Application.ProductVersion;

            //コピーライト
            LblCopyright.Text = "-";
            var cpyArr = assembly.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
            if (cpyArr != null && cpyArr.Length > 0)
            {
                LblCopyright.Text = ((AssemblyCopyrightAttribute)cpyArr.First()).Copyright;
            }

            //詳細情報
            LblDescription.Text = "-";
            var desArr = assembly.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
            if (desArr != null && desArr.Length > 0)
            {
                LblDescription.Text = ((AssemblyDescriptionAttribute)desArr.First()).Description;
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
