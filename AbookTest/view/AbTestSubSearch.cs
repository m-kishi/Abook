﻿// ------------------------------------------------------------
// © 2010 https://github.com/m-kishi
// ------------------------------------------------------------
namespace AbookTest
{
    using Abook;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using NUnit.Framework;
    using NUnit.Extensions.Forms;
    using TT   = AbTestTool;
    using EX   = Abook.AbException.EX;
    using DB   = Abook.AbConstants.DB;
    using COL  = Abook.AbConstants.COL.EXPENSE;
    using DGV  = Abook.AbConstants.DGV;
    using TYPE = Abook.AbConstants.TYPE;

    /// <summary>
    /// 検索サブフォームテスト
    /// </summary>
    [TestFixture]
    public class AbTestSubSearch : NUnitFormTest
    {
        /// <summary>DBファイル</summary>
        private const string DB_FILE_EMPTY = "AbTestSubSearchEmpty.db";
        /// <summary>DBファイル</summary>
        private const string DB_FILE_EXIST = "AbTestSubSearchExist.db";
        /// <summary>対象:検索サブフォーム</summary>
        protected AbSubSearch form;

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
                CtAbSubSearch().Close();
            }
            catch (NoSuchControlException)
            {
                // すでに閉じられている
            }
            base.TearDown();
        }

        /// <summary>
        /// TestFixtureSetUp
        /// </summary>
        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            using (StreamWriter sw = new StreamWriter(DB_FILE_EXIST, false, DB.ENCODING))
            {
                sw.NewLine = DB.LF;
                sw.WriteLine(TT.ToDBFileFormat("2017-12-01", "おにぎり"    , TYPE.FOOD, "100", "note1"));
                sw.WriteLine(TT.ToDBFileFormat("2017-12-02", "おにぎり"    , TYPE.FOOD, "200"));
                sw.WriteLine(TT.ToDBFileFormat("2017-12-03", "おにぎりＡ"  , TYPE.FOOD, "300"));
                sw.WriteLine(TT.ToDBFileFormat("2017-12-04", "Ｂおにぎり"  , TYPE.FOOD, "400"));
                sw.WriteLine(TT.ToDBFileFormat("2017-12-05", "ＣおにぎりＤ", TYPE.FOOD, "500"));
                sw.WriteLine(TT.ToDBFileFormat("2019-12-21", "おにぎり"    , TYPE.OTFD, "101"));
                sw.WriteLine(TT.ToDBFileFormat("2019-12-22", "おにぎり"    , TYPE.OTFD, "202"));
                sw.WriteLine(TT.ToDBFileFormat("2019-12-23", "おにぎりＡ"  , TYPE.TRFC, "303"));
                sw.WriteLine(TT.ToDBFileFormat("2019-12-24", "Ｂおにぎり"  , TYPE.FRND, "404"));
                sw.WriteLine(TT.ToDBFileFormat("2019-12-25", "ＣおにぎりＤ", TYPE.INSU, "505"));
                sw.Close();
            }
        }

        /// <summary>
        /// TestFixtureTearDown
        /// </summary>
        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            if (File.Exists(DB_FILE_EMPTY)) File.Delete(DB_FILE_EMPTY);
            if (File.Exists(DB_FILE_EXIST)) File.Delete(DB_FILE_EXIST);
        }

        /// <summary>
        /// フォーム表示
        /// </summary>
        /// <param name="dbFile">DBファイル</param>
        protected void ShowSubSearch(string dbFile)
        {
            var expenses = AbDBManager.Load(dbFile);

            form = new AbSubSearch(expenses);
            form.Show();
        }

        /// <summary>
        /// 検索サブフォーム取得
        /// </summary>
        /// <returns>検索サブフォーム</returns>
        protected Form CtAbSubSearch()
        {
            var finder = new FormFinder();
            return finder.Find(typeof(AbSubSearch).Name);
        }

        /// <summary>
        /// コンボボックス取得(名称)
        /// </summary>
        /// <returns>コンボボックス</returns>
        protected ComboBox CtCmbName()
        {
            return (new Finder<ComboBox>("CmbName", form).Find());
        }

        /// <summary>
        /// コンボボックス取得(名称)
        /// </summary>
        /// <returns>コンボボックス</returns>
        protected ComboBoxTester TsCmbName()
        {
            return new ComboBoxTester("CmbName", form);
        }

        /// <summary>
        /// コンボボックス取得(種別)
        /// </summary>
        /// <returns>コンボボックス</returns>
        protected ComboBox CtCmbType()
        {
            return (new Finder<ComboBox>("CmbType", form).Find());
        }

        /// <summary>
        /// コンボボックス取得(種別)
        /// </summary>
        /// <returns>コンボボックス</returns>
        protected ComboBoxTester TsCmbType()
        {
            return new ComboBoxTester("CmbType", form);
        }

        /// <summary>
        /// 検索ボタン取得
        /// </summary>
        /// <returns>検索ボタン</returns>
        protected ButtonTester TsBtnSearch()
        {
            return new ButtonTester("BtnSearch", form);
        }

        /// <summary>
        /// 支出ビュー取得
        /// </summary>
        /// <returns>支出ビュー</returns>
        protected DataGridView CtDgvExpense()
        {
            return (new Finder<DataGridView>("DgvExpense", form).Find());
        }

        /// <summary>
        /// Loadテスト
        /// </summary>
        /// <remarks>
        /// ComboBoxでAutoCompleteModeを使用するため、RequiresSTAの指定が必要
        /// </remarks>
        [Test, RequiresSTA]
        public void Load()
        {
            ShowSubSearch(DB_FILE_EMPTY);
            Assert.IsTrue(CtAbSubSearch().Visible);
        }

        /// <summary>
        /// Loadテスト
        /// 引数:支出情報リストがNULL
        /// </summary>
        [Test, RequiresSTA]
        public void LoadWithNullExpenses()
        {
            var ex = Assert.Throws<AbException>(() =>
                new AbSubSearch(null)
            );
            Assert.AreEqual(EX.EXPENSES_NULL, ex.Message);
        }

        /// <summary>
        /// タイトルテスト
        /// </summary>
        [Test, RequiresSTA]
        public void LoadWithTitle()
        {
            ShowSubSearch(DB_FILE_EMPTY);
            Assert.AreEqual("支出検索", form.Text);
        }

        /// <summary>
        /// コンボボックステスト
        /// 件数: 0件
        /// </summary>
        [Test, RequiresSTA]
        public void LoadWithCmbNameEmpty()
        {
            ShowSubSearch(DB_FILE_EMPTY);

            var cmbName = CtCmbName();
            Assert.AreEqual( 0, cmbName.Items.Count);
            Assert.AreEqual(-1, cmbName.SelectedIndex);
            Assert.AreEqual("", cmbName.Text);
        }

        /// <summary>
        /// コンボボックステスト
        /// 件数: 複数件
        /// </summary>
        [Test, RequiresSTA]
        public void LoadWithCmbName()
        {
            ShowSubSearch(DB_FILE_EXIST);

            var cmbName = CtCmbName();
            Assert.AreEqual(4, cmbName.Items.Count);
            Assert.AreEqual(0, cmbName.SelectedIndex);
            Assert.AreEqual("Ｂおにぎり", cmbName.Text);
        }

        /// <summary>
        /// コンボボックステスト
        /// 名称のソート
        /// </summary>
        [Test, RequiresSTA]
        public void LoadWithCmbNameWithSort()
        {
            ShowSubSearch(DB_FILE_EXIST);

            var cmbName = CtCmbName();
            Assert.AreEqual("Ｂおにぎり"  , cmbName.Items[0]);
            Assert.AreEqual("ＣおにぎりＤ", cmbName.Items[1]);
            Assert.AreEqual("おにぎり"    , cmbName.Items[2]);
            Assert.AreEqual("おにぎりＡ"  , cmbName.Items[3]);
        }

        /// <summary>
        /// コンボボックステスト
        /// 種別
        /// </summary>
        [Test, RequiresSTA]
        public void LoadWithType()
        {
            ShowSubSearch(DB_FILE_EMPTY);

            var cmbType = CtCmbType();

            // +1は空白
            Assert.AreEqual(TYPE.EXPENCE.Length + 1, cmbType.Items.Count);

            Assert.AreEqual("", cmbType.Items[0]);
            for (int i = 0; i < TYPE.EXPENCE.Length; i++)
            {
                Assert.AreEqual(TYPE.EXPENCE[i], cmbType.Items[i + 1]);
            }
        }

        /// <summary>
        /// レコード数のテスト
        /// 初期表示: 0件
        /// </summary>
        [Test, RequiresSTA]
        public void LoadWithDgvExpense()
        {
            ShowSubSearch(DB_FILE_EXIST);
            Assert.AreEqual(0, CtDgvExpense().Rows.Count);
        }

        /// <summary>
        /// 支出検索
        /// 検索条件: 空白
        /// </summary>
        [Test, RequiresSTA]
        public void SearchWithEmptyName()
        {
            ShowSubSearch(DB_FILE_EXIST);

            var cmbName = CtCmbName();
            cmbName.SelectedIndex = -1;
            cmbName.Text = "";

            TsBtnSearch().Click();

            var dgvExpense = CtDgvExpense();
            Assert.AreEqual(10, dgvExpense.Rows.Count);
            Assert.AreEqual("2017-12-01", dgvExpense.Rows[0].Cells[0].Value);
            Assert.AreEqual("2017-12-02", dgvExpense.Rows[1].Cells[0].Value);
            Assert.AreEqual("2017-12-03", dgvExpense.Rows[2].Cells[0].Value);
            Assert.AreEqual("2017-12-04", dgvExpense.Rows[3].Cells[0].Value);
            Assert.AreEqual("2017-12-05", dgvExpense.Rows[4].Cells[0].Value);
            Assert.AreEqual("おにぎり"    , dgvExpense.Rows[0].Cells[1].Value);
            Assert.AreEqual("おにぎり"    , dgvExpense.Rows[1].Cells[1].Value);
            Assert.AreEqual("おにぎりＡ"  , dgvExpense.Rows[2].Cells[1].Value);
            Assert.AreEqual("Ｂおにぎり"  , dgvExpense.Rows[3].Cells[1].Value);
            Assert.AreEqual("ＣおにぎりＤ", dgvExpense.Rows[4].Cells[1].Value);

            Assert.AreEqual("2019-12-21", dgvExpense.Rows[5].Cells[0].Value);
            Assert.AreEqual("2019-12-22", dgvExpense.Rows[6].Cells[0].Value);
            Assert.AreEqual("2019-12-23", dgvExpense.Rows[7].Cells[0].Value);
            Assert.AreEqual("2019-12-24", dgvExpense.Rows[8].Cells[0].Value);
            Assert.AreEqual("2019-12-25", dgvExpense.Rows[9].Cells[0].Value);
            Assert.AreEqual("おにぎり"    , dgvExpense.Rows[5].Cells[1].Value);
            Assert.AreEqual("おにぎり"    , dgvExpense.Rows[6].Cells[1].Value);
            Assert.AreEqual("おにぎりＡ"  , dgvExpense.Rows[7].Cells[1].Value);
            Assert.AreEqual("Ｂおにぎり"  , dgvExpense.Rows[8].Cells[1].Value);
            Assert.AreEqual("ＣおにぎりＤ", dgvExpense.Rows[9].Cells[1].Value);
        }

        /// <summary>
        /// 支出検索
        /// 検索条件: ヒットなし
        /// </summary>
        [Test, RequiresSTA]
        public void SearchWithNotFound()
        {
            ShowSubSearch(DB_FILE_EXIST);

            var cmbName = CtCmbName();
            cmbName.SelectedIndex = -1;
            cmbName.Text = "Not Found";

            TsBtnSearch().Click();

            var dgvExpense = CtDgvExpense();
            Assert.AreEqual(0, dgvExpense.Rows.Count);
        }

        /// <summary>
        /// 支出検索
        /// 検索条件: 完全一致
        /// </summary>
        [Test, RequiresSTA]
        public void SearchWithExactMatch()
        {
            ShowSubSearch(DB_FILE_EXIST);

            var cmbName = CtCmbName();
            cmbName.Text = "おにぎり";

            TsBtnSearch().Click();

            var dgvExpense = CtDgvExpense();
            Assert.AreEqual(2, cmbName.SelectedIndex);
            Assert.AreEqual(4, dgvExpense.Rows.Count);
            Assert.AreEqual("2017-12-01", dgvExpense.Rows[0].Cells[0].Value);
            Assert.AreEqual("2017-12-02", dgvExpense.Rows[1].Cells[0].Value);
            Assert.AreEqual("おにぎり"  , dgvExpense.Rows[0].Cells[1].Value);
            Assert.AreEqual("おにぎり"  , dgvExpense.Rows[1].Cells[1].Value);

            Assert.AreEqual("2019-12-21", dgvExpense.Rows[2].Cells[0].Value);
            Assert.AreEqual("2019-12-22", dgvExpense.Rows[3].Cells[0].Value);
            Assert.AreEqual("おにぎり"  , dgvExpense.Rows[2].Cells[1].Value);
            Assert.AreEqual("おにぎり"  , dgvExpense.Rows[3].Cells[1].Value);

        }

        /// <summary>
        /// 支出検索
        /// 検索条件: 部分一致
        /// </summary>
        [Test, RequiresSTA]
        public void SearchWithPartialMatch()
        {
            ShowSubSearch(DB_FILE_EXIST);

            var cmbName = CtCmbName();
            cmbName.Text = "おにぎり";
            cmbName.SelectedIndex = -1;

            TsBtnSearch().Click();

            var dgvExpense = CtDgvExpense();
            Assert.AreEqual(10, dgvExpense.Rows.Count);
            Assert.AreEqual("2017-12-01", dgvExpense.Rows[0].Cells[0].Value);
            Assert.AreEqual("2017-12-02", dgvExpense.Rows[1].Cells[0].Value);
            Assert.AreEqual("2017-12-03", dgvExpense.Rows[2].Cells[0].Value);
            Assert.AreEqual("2017-12-04", dgvExpense.Rows[3].Cells[0].Value);
            Assert.AreEqual("2017-12-05", dgvExpense.Rows[4].Cells[0].Value);
            Assert.AreEqual("おにぎり"    , dgvExpense.Rows[0].Cells[1].Value);
            Assert.AreEqual("おにぎり"    , dgvExpense.Rows[1].Cells[1].Value);
            Assert.AreEqual("おにぎりＡ"  , dgvExpense.Rows[2].Cells[1].Value);
            Assert.AreEqual("Ｂおにぎり"  , dgvExpense.Rows[3].Cells[1].Value);
            Assert.AreEqual("ＣおにぎりＤ", dgvExpense.Rows[4].Cells[1].Value);

            Assert.AreEqual("2019-12-21", dgvExpense.Rows[5].Cells[0].Value);
            Assert.AreEqual("2019-12-22", dgvExpense.Rows[6].Cells[0].Value);
            Assert.AreEqual("2019-12-23", dgvExpense.Rows[7].Cells[0].Value);
            Assert.AreEqual("2019-12-24", dgvExpense.Rows[8].Cells[0].Value);
            Assert.AreEqual("2019-12-25", dgvExpense.Rows[9].Cells[0].Value);
            Assert.AreEqual("おにぎり"    , dgvExpense.Rows[5].Cells[1].Value);
            Assert.AreEqual("おにぎり"    , dgvExpense.Rows[6].Cells[1].Value);
            Assert.AreEqual("おにぎりＡ"  , dgvExpense.Rows[7].Cells[1].Value);
            Assert.AreEqual("Ｂおにぎり"  , dgvExpense.Rows[8].Cells[1].Value);
            Assert.AreEqual("ＣおにぎりＤ", dgvExpense.Rows[9].Cells[1].Value);
        }

        /// <summary>
        /// 支出検索
        /// 検索条件: 部分一致(前方一致)
        /// </summary>
        [Test, RequiresSTA]
        public void SearchWithPartialMatchForward()
        {
            ShowSubSearch(DB_FILE_EXIST);

            var cmbName = CtCmbName();
            cmbName.SelectedIndex = -1;
            cmbName.Text = "Ｂ";

            TsBtnSearch().Click();

            var dgvExpense = CtDgvExpense();
            Assert.AreEqual(2, dgvExpense.Rows.Count);
            Assert.AreEqual("2017-12-04", dgvExpense.Rows[0].Cells[0].Value);
            Assert.AreEqual("Ｂおにぎり", dgvExpense.Rows[0].Cells[1].Value);

            Assert.AreEqual("2019-12-24", dgvExpense.Rows[1].Cells[0].Value);
            Assert.AreEqual("Ｂおにぎり", dgvExpense.Rows[1].Cells[1].Value);
        }

        /// <summary>
        /// 支出検索
        /// 検索条件: 部分一致(後方一致)
        /// </summary>
        [Test, RequiresSTA]
        public void SearchWithPartialMatchBackward()
        {
            ShowSubSearch(DB_FILE_EXIST);

            var cmbName = CtCmbName();
            cmbName.SelectedIndex = -1;
            cmbName.Text = "Ｄ";

            TsBtnSearch().Click();

            var dgvExpense = CtDgvExpense();
            Assert.AreEqual(2, dgvExpense.Rows.Count);
            Assert.AreEqual("2017-12-05", dgvExpense.Rows[0].Cells[0].Value);
            Assert.AreEqual("ＣおにぎりＤ", dgvExpense.Rows[0].Cells[1].Value);

            Assert.AreEqual("2019-12-25", dgvExpense.Rows[1].Cells[0].Value);
            Assert.AreEqual("ＣおにぎりＤ", dgvExpense.Rows[1].Cells[1].Value);
        }

        /// <summary>
        /// 支出検索
        /// 検索条件: 種別指定
        /// </summary>
        [Test, RequiresSTA]
        public void SearchWithType()
        {
            ShowSubSearch(DB_FILE_EXIST);

            var cmbName = CtCmbName();
            cmbName.SelectedIndex = -1;
            cmbName.Text = "";

            var cmbType = CtCmbType();
            cmbType.SelectedIndex = 2;

            TsBtnSearch().Click();

            var dgvExpense = CtDgvExpense();
            Assert.AreEqual(2, dgvExpense.Rows.Count);
            Assert.AreEqual("2019-12-21", dgvExpense.Rows[0].Cells[0].Value);
            Assert.AreEqual("2019-12-22", dgvExpense.Rows[1].Cells[0].Value);
            Assert.AreEqual("おにぎり"  , dgvExpense.Rows[0].Cells[1].Value);
            Assert.AreEqual("おにぎり"  , dgvExpense.Rows[1].Cells[1].Value);
        }

        /// <summary>
        /// 支出検索
        /// 検索条件: ヒットなし
        /// </summary>
        [Test, RequiresSTA]
        public void SearchWithTypeNotFound()
        {
            ShowSubSearch(DB_FILE_EXIST);

            var cmbName = CtCmbName();
            cmbName.SelectedIndex = -1;
            cmbName.Text = "";

            var cmbType = CtCmbType();
            cmbType.SelectedIndex = 6;

            TsBtnSearch().Click();

            var dgvExpense = CtDgvExpense();
            Assert.AreEqual(0, dgvExpense.Rows.Count);
        }

        /// <summary>
        /// 支出検索
        /// 検索条件: 名称(部分一致)+種別
        /// </summary>
        [Test, RequiresSTA]
        public void SearchWithPartialNameAndType()
        {
            ShowSubSearch(DB_FILE_EXIST);

            var cmbName = CtCmbName();
            cmbName.Text = "おにぎり";
            cmbName.SelectedIndex = -1;

            var cmbType = CtCmbType();
            cmbType.SelectedIndex = 1;

            TsBtnSearch().Click();

            var dgvExpense = CtDgvExpense();
            Assert.AreEqual(5, dgvExpense.Rows.Count);
            Assert.AreEqual("2017-12-01", dgvExpense.Rows[0].Cells[0].Value);
            Assert.AreEqual("2017-12-02", dgvExpense.Rows[1].Cells[0].Value);
            Assert.AreEqual("2017-12-03", dgvExpense.Rows[2].Cells[0].Value);
            Assert.AreEqual("2017-12-04", dgvExpense.Rows[3].Cells[0].Value);
            Assert.AreEqual("2017-12-05", dgvExpense.Rows[4].Cells[0].Value);
            Assert.AreEqual("おにぎり"    , dgvExpense.Rows[0].Cells[1].Value);
            Assert.AreEqual("おにぎり"    , dgvExpense.Rows[1].Cells[1].Value);
            Assert.AreEqual("おにぎりＡ"  , dgvExpense.Rows[2].Cells[1].Value);
            Assert.AreEqual("Ｂおにぎり"  , dgvExpense.Rows[3].Cells[1].Value);
            Assert.AreEqual("ＣおにぎりＤ", dgvExpense.Rows[4].Cells[1].Value);
        }

        /// <summary>
        /// 支出検索
        /// 検索条件: 名称(完全)+種別
        /// </summary>
        [Test, RequiresSTA]
        public void SearchWithMatchNameAndType()
        {
            ShowSubSearch(DB_FILE_EXIST);

            var cmbName = CtCmbName();
            cmbName.SelectedIndex = 3;

            var cmbType = CtCmbType();
            cmbType.SelectedIndex = 1;

            TsBtnSearch().Click();

            var dgvExpense = CtDgvExpense();
            Assert.AreEqual(1, dgvExpense.Rows.Count);
            Assert.AreEqual("2017-12-03", dgvExpense.Rows[0].Cells[0].Value);
            Assert.AreEqual("おにぎりＡ", dgvExpense.Rows[0].Cells[1].Value);
        }

        /// <summary>
        /// スクロール位置のテスト
        /// 条件: 検索結果あり
        /// </summary>
        [Test, RequiresSTA]
        public void SearchWithScrollingRowIndex()
        {
            ShowSubSearch(DB_FILE_EXIST);

            var cmbName = CtCmbName();
            cmbName.Text = "";
            cmbName.SelectedIndex = -1;

            TsBtnSearch().Click();

            var dgvExpense = CtDgvExpense();
            dgvExpense.FirstDisplayedScrollingRowIndex = 4;

            TsBtnSearch().Click();

            Assert.AreEqual(0, dgvExpense.FirstDisplayedScrollingRowIndex);
        }

        /// <summary>
        /// スクロール位置のテスト
        /// 条件: 検索結果なし
        /// </summary>
        [Test, RequiresSTA]
        public void SearchWithScrollingRowIndexWithNotFound()
        {
            ShowSubSearch(DB_FILE_EXIST);

            var cmbName = CtCmbName();
            cmbName.Text = "";
            cmbName.SelectedIndex = -1;

            TsBtnSearch().Click();

            var dgvExpense = CtDgvExpense();
            dgvExpense.FirstDisplayedScrollingRowIndex = 4;

            cmbName.Text = "Not Found";

            TsBtnSearch().Click();

            Assert.AreEqual(-1, dgvExpense.FirstDisplayedScrollingRowIndex);
        }

        /// <summary>
        /// 備考のテスト
        /// 備考: あり
        /// </summary>
        [Test, RequiresSTA]
        public void Note()
        {
            ShowSubSearch(DB_FILE_EXIST);

            var cmbName = CtCmbName();
            cmbName.SelectedIndex = 2;

            TsBtnSearch().Click();

            var dgvExpense = CtDgvExpense();
            Assert.AreEqual("note1", dgvExpense.Rows[0].Cells[COL.NOTE].Value);
            Assert.AreEqual("note1", dgvExpense.Rows[0].Cells[COL.NAME].ToolTipText);
            Assert.AreEqual(DGV.NOTE_BG_COLOR, dgvExpense.Rows[0].DefaultCellStyle.BackColor);
        }

        /// <summary>
        /// 備考のテスト
        /// 備考: なし
        /// </summary>
        [Test, RequiresSTA]
        public void NoteWithEmpty()
        {
            ShowSubSearch(DB_FILE_EXIST);

            var cmbName = CtCmbName();
            cmbName.SelectedIndex = 2;

            TsBtnSearch().Click();

            var dgvExpense = CtDgvExpense();
            Assert.AreEqual("", dgvExpense.Rows[1].Cells[COL.NOTE].Value);
            Assert.AreEqual("", dgvExpense.Rows[1].Cells[COL.NAME].ToolTipText);
            Assert.AreEqual(Color.Empty, dgvExpense.Rows[1].DefaultCellStyle.BackColor);
        }
    }
}
