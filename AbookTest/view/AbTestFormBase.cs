// ------------------------------------------------------------
// © 2010 https://github.com/m-kishi
// ------------------------------------------------------------
namespace AbookTest
{
    using Abook;
    using System;
    using System.Windows.Forms;
    using NUnit.Framework;
    using NUnit.Extensions.Forms;

    /// <summary>
    /// フォームテスト
    /// 抽象ベースクラス
    /// </summary>
    public abstract class AbTestFormBase : NUnitFormTest
    {
        /// <summary>対象:メイン画面</summary>
        protected AbFormMain form;

        /// <summary>
        /// Setup
        /// </summary>
        public override void Setup()
        {
            base.Setup();
        }

        /// <summary>
        /// TearDown
        /// </summary>
        public override void TearDown()
        {
            try
            {
                CtAbFormMain().Close();
            }
            catch (NoSuchControlException)
            {
                //すでに閉じられている
            }
            base.TearDown();
        }

        #region "共通メソッド"

        /// <summary>
        /// フォーム表示
        /// </summary>
        /// <param name="csv">CSVファイル</param>
        protected void ShowFormMain(string csv)
        {
            form = new AbFormMain(csv);
            form.Show();
        }

        /// <summary>
        /// フォーム表示
        /// フォーム表示時にタブを選択
        /// </summary>
        /// <param name="csv">CSVファイル</param>
        /// <param name="idxTab">タブインデックス</param>
        protected void ShowFormMain(string csv, int idxTab)
        {
            ShowFormMain(csv);
            TsTabControl().SelectTab(idxTab);
        }

        /// <summary>
        /// フォーム表示
        /// アップロードテスト用の表示
        /// </summary>
        /// <param name="csv">CSVファイル</param>
        /// <param name="login">ログインURL</param>
        /// <param name="upload">アップロードURL</param>
        protected void ShowFormMain(string csv, string login, string upload)
        {
            form = new AbFormMain(csv);
            form.Show();
        }

        #endregion

        #region "Tester取得メソッド"

        /// <summary>
        /// 終了メニュー取得
        /// </summary>
        /// <returns>終了メニュー</returns>
        protected ToolStripMenuItemTester TsMenuExit()
        {
            return (new ToolStripMenuItemTester("MenuExit", form));
        }

        /// <summary>
        /// 光熱費メニュー取得
        /// </summary>
        /// <returns>光熱費メニュー</returns>
        protected ToolStripMenuItemTester TsMenuEnergy()
        {
            return (new ToolStripMenuItemTester("MenuEnergy", form));
        }

        /// <summary>
        /// バージョン情報メニュー取得
        /// </summary>
        /// <returns>バージョン情報メニュー</returns>
        protected ToolStripMenuItemTester TsMenuVersion()
        {
            return (new ToolStripMenuItemTester("MenuVersion", form));
        }

        /// <summary>
        /// タブコントロール取得
        /// </summary>
        /// <returns>タブコントロール</returns>
        protected TabControlTester TsTabControl()
        {
            return (new TabControlTester("TabControl", form));
        }

        /// <summary>
        /// ボタン取得
        /// </summary>
        /// <param name="name">コントロール名</param>
        /// <returns>ボタン</returns>
        protected ButtonTester TsButton(string name)
        {
            return (new ButtonTester(name, form));
        }

        /// <summary>
        /// 登録ボタン取得
        /// </summary>
        /// <returns>登録ボタン</returns>
        protected ButtonTester TsBtnEntry()
        {
            return TsButton("BtnEntry");
        }

        /// <summary>
        /// 入力行追加ボタン取得
        /// </summary>
        /// <returns>入力行追加ボタン</returns>
        protected ButtonTester TsBtnAddRow()
        {
            return TsButton("BtnAddRow");
        }

        /// <summary>
        /// 支出ビュー取得
        /// </summary>
        /// <returns>支出ビュー</returns>
        protected ControlTester TsDgvExpense()
        {
            return (new ControlTester("DgvExpense", form));
        }

        /// <summary>
        /// 月次タブ前年ボタン取得
        /// </summary>
        /// <returns>月次タブ前年ボタン</returns>
        protected ButtonTester TsSummaryBtnPrevYear()
        {
            return TsButton("HeadSummary.BtnPrevYear");
        }

        /// <summary>
        /// 月次タブ前月ボタン取得
        /// </summary>
        /// <returns>月次タブ前月ボタン</returns>
        protected ButtonTester TsSummaryBtnPrevMonth()
        {
            return TsButton("HeadSummary.BtnPrevMonth");
        }

        /// <summary>
        /// 月次タブ翌月ボタン取得
        /// </summary>
        /// <returns>月次タブ翌月ボタン</returns>
        protected ButtonTester TsSummaryBtnNextMonth()
        {
            return TsButton("HeadSummary.BtnNextMonth");
        }

        /// <summary>
        /// 月次タブ翌年ボタン取得
        /// </summary>
        /// <returns>月次タブ翌年ボタン</returns>
        protected ButtonTester TsSummaryBtnNextYear()
        {
            return TsButton("HeadSummary.BtnNextYear");
        }

        /// <summary>
        /// 推移(グラフ)タブ前年ボタン取得
        /// </summary>
        /// <returns>推移(グラフ)タブ前年ボタン</returns>
        protected ButtonTester TsGraphicBtnPrevYear()
        {
            return TsButton("HeadGraphic.BtnPrevYear");
        }

        /// <summary>
        /// 推移(グラフ)タブ前月ボタン取得
        /// </summary>
        /// <returns>推移(グラフ)タブ前月ボタン</returns>
        protected ButtonTester TsGraphicBtnPrevMonth()
        {
            return TsButton("HeadGraphic.BtnPrevMonth");
        }

        /// <summary>
        /// 推移(グラフ)タブ翌月ボタン取得
        /// </summary>
        /// <returns>推移(グラフ)タブ翌月ボタン</returns>
        protected ButtonTester TsGraphicBtnNextMonth()
        {
            return TsButton("HeadGraphic.BtnNextMonth");
        }

        /// <summary>
        /// 推移(グラフ)タブ翌年ボタン取得
        /// </summary>
        /// <returns>推移(グラフ)タブ翌年ボタン</returns>
        protected ButtonTester TsGraphicBtnNextYear()
        {
            return TsButton("HeadGraphic.BtnNextYear");
        }

        /// <summary>
        /// グラフ領域取得
        /// </summary>
        /// <returns>グラフ領域</returns>
        protected ControlTester TsPboxGraph()
        {
            return (new ControlTester("PboxGraph", form));
        }

        /// <summary>
        /// ラベルコントロール中のLabel取得
        /// </summary>
        /// <param name="name">コントロール名</param>
        /// <returns>ラベルコントロール中のLabel取得</returns>
        protected ControlTester TsAbLabelLabel(string name)
        {
            return (new ControlTester(name + "._Label", form));
        }

        /// <summary>
        /// ラベルコントロール中のValue取得
        /// </summary>
        /// <param name="name">コントロール名</param>
        /// <returns>ラベルコントロール中のValue取得</returns>
        protected ControlTester TsAbLabelValue(string name)
        {
            return (new ControlTester(name + "._Value", form));
        }

        #endregion

        #region "Control取得メソッド"

        /// <summary>
        /// メイン画面フォーム取得
        /// </summary>
        /// <returns>メイン画面フォーム</returns>
        protected Form CtAbFormMain()
        {
            var finder = new FormFinder();
            return finder.Find(typeof(AbFormMain).Name);
        }

        /// <summary>
        /// コントロール取得
        /// </summary>
        /// <typeparam name="T">型パラメタ</typeparam>
        /// <param name="name">コントロール名</param>
        /// <returns>コントロール</returns>
        protected T CtControl<T>(string name)
        {
            return (new Finder<T>(name, form).Find());
        }

        /// <summary>
        /// 支出ビュー取得
        /// </summary>
        /// <returns>支出ビュー</returns>
        protected DataGridView CtDgvExpense()
        {
            return CtControl<DataGridView>("DgvExpense");
        }

        /// <summary>
        /// 月次タブヘッダ取得
        /// </summary>
        /// <returns>月次タブヘッダ</returns>
        protected AbHeaderControl CtHeadSummary()
        {
            return CtControl<AbHeaderControl>("HeadSummary");
        }

        /// <summary>
        /// ラベルコントロール取得
        /// </summary>
        /// <param name="name">コントロール名</param>
        /// <returns>ラベルコントロール</returns>
        protected AbLabelControl CtAbLabel(string name)
        {
            return CtControl<AbLabelControl>(name);
        }

        /// <summary>
        /// ラベルコントロール中のLabel取得
        /// </summary>
        /// <param name="name">コントロール名</param>
        /// <returns>ラベルコントロール中のLabel</returns>
        protected Label CtAbLabelLabel(string name)
        {
            return CtControl<Label>(name + "._Label");
        }

        /// <summary>
        /// ラベルコントロール中のValue取得
        /// </summary>
        /// <param name="name">コントロール名</param>
        /// <returns>ラベルコントロール中のValue</returns>
        protected Label CtAbLabelValue(string name)
        {
            return CtControl<Label>(name + "._Value");
        }

        /// <summary>
        /// 推移(グラフ)タブヘッダ取得
        /// </summary>
        /// <returns>推移(グラフ)タブヘッダ</returns>
        protected AbHeaderControl CtHeadGraphic()
        {
            return CtControl<AbHeaderControl>("HeadGraphic");
        }

        /// <summary>
        /// グラフ領域取得
        /// </summary>
        /// <returns>グラフ領域</returns>
        protected PictureBox CtPboxGraph()
        {
            return CtControl<PictureBox>("PboxGraph");
        }

        /// <summary>
        /// 収支ビュー取得
        /// </summary>
        /// <returns>収支ビュー</returns>
        protected DataGridView CtDgvBalance()
        {
            return CtControl<DataGridView>("DgvBalance");
        }

        /// <summary>
        /// 秘密収支ビュー取得
        /// </summary>
        /// <returns>秘密収支ビュー</returns>
        protected DataGridView CtDgvPrivate()
        {
            return CtControl<DataGridView>("DgvPrivate");
        }

        #endregion
    }
}
