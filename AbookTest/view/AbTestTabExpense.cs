namespace AbookTest
{
    using Abook;
    using System;
    using System.IO;
    using System.Windows.Forms;
    using NUnit.Framework;
    using NUnit.Extensions.Forms;
    using EX   = Abook.AbException.EX;
    using COL  = Abook.AbConstants.COL;
    using FMT  = Abook.AbConstants.FMT;
    using DGV  = Abook.AbConstants.DGV;
    using TYPE = Abook.AbConstants.TYPE;

    /// <summary>
    /// 支出タブテスト
    /// </summary>
    public class AbTestTabExpense
    {
        /// <summary>
        /// 初期表示テスト
        /// </summary>
        [TestFixture]
        public class InitialDataGridView : NUnitFormTest
        {
            /// <summary>引数:DB ファイル</summary>
            private string argDbFile = "AbTestTabExpenseWithInitialDgv.db";
            /// <summary>対象:メイン画面フォーム</summary>
            private AbFormMain abFormMain;

            /// <summary>
            /// TestFixtureSetUp
            /// </summary>
            [TestFixtureSetUp]
            public void TestFixtureSetUp()
            {
                argDbFile = "AbTestTabExpenseWithInitialDgv.db";
                using (StreamWriter sw = new StreamWriter(argDbFile, false, System.Text.Encoding.UTF8))
                {
                    for (var i = 1; i <= 15; i++)
                    {
                        var date = (new DateTime(2012, 1, i)).ToString(FMT.DATE);
                        var name = "name" + i.ToString("D2");
                        var type = "type" + i.ToString("D2");
                        var cost = i * 100M;
                        sw.WriteLine(GenerateWriteLine(date, name, type, cost));
                    }
                }
            }

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
                    var finder = new FormFinder();
                    var form = finder.Find(typeof(AbFormMain).Name);
                    form.Close();
                }
                catch (NoSuchControlException)
                {
                    //すでに閉じられている
                }
                base.TearDown();
            }

            /// <summary>
            /// TestFixtureTearDown
            /// </summary>
            [TestFixtureTearDown]
            public void TestFixtureTearDown()
            {
                argDbFile = "AbTestTabExpenseWithInitialDataGridViewWithEmptyData.db";
                if (System.IO.File.Exists(argDbFile))
                {
                    System.IO.File.Delete(argDbFile);
                }
                argDbFile = "AbTestTabExpenseWithInitialDgv.db";
                if (System.IO.File.Exists(argDbFile))
                {
                    System.IO.File.Delete(argDbFile);
                }
            }

            /// <summary>GenerateWriteLine メソッド用テンプレ</summary>
            private const string TEMPLATE = "\"{0}\",\"{1}\",\"{2}\",\"{3}\"";

            /// <summary>
            /// 出力用レコード文字列生成
            /// </summary>
            /// <param name="date">日付</param>
            /// <param name="name">名前</param>
            /// <param name="type">種別</param>
            /// <param name="cost">金額</param>
            /// <returns>出力用レコード文字列</returns>
            private string GenerateWriteLine(string date, string name, string type, decimal cost)
            {
                return string.Format(TEMPLATE, date, name, type, cost);
            }

            /// <summary>
            /// フォームを表示
            /// </summary>
            /// <param name="db">DB ファイル名</param>
            private void ShowForm(string db)
            {
                abFormMain = new AbFormMain(db);
                abFormMain.Show();
            }

            /// <summary>
            /// DataGridView 取得
            /// </summary>
            /// <returns>DataGridView</returns>
            private DataGridView GetDgvExpense()
            {
                var finder = new Finder<DataGridView>("DgvExpense", abFormMain);
                return finder.Find();
            }

            /// <summary>
            /// DataGridView
            /// データなしのテスト
            /// </summary>
            [Test]
            public void CountWithEmptyData()
            {
                argDbFile = "AbTestTabExpenseWithInitialDataGridViewWithEmptyData.db";
                ShowForm(argDbFile);
                var dgvExpense = GetDgvExpense();
                Assert.AreEqual(0, dgvExpense.Rows.Count);
            }

            /// <summary>
            /// DataGridView
            /// 入力行数のテスト
            /// </summary>
            [Test]
            public void CountWithExistData()
            {
                argDbFile = "AbTestTabExpenseWithInitialDgv.db";
                ShowForm(argDbFile);
                var dgvExpense = GetDgvExpense();
                Assert.AreEqual(15, dgvExpense.Rows.Count);
            }

            /// <summary>
            /// DataGridView
            /// 支出レコードのテスト
            /// </summary>
            [Test]
            public void DgvWithExistData()
            {
                argDbFile = "AbTestTabExpenseWithInitialDgv.db";
                ShowForm(argDbFile);
                var dgvExpense = GetDgvExpense();
                for (var i = 1; i <= 15; i++)
                {
                    var row = dgvExpense.Rows[i - 1];

                    var date = string.Format("2012-01-{0:D2}", i);
                    var name = string.Format("name{0:D2}", i);
                    var type = string.Format("type{0:D2}", i);
                    var cost = i * 100M;

                    Assert.AreEqual(date, row.Cells[COL.DATE].Value);
                    Assert.AreEqual(name, row.Cells[COL.NAME].Value);
                    Assert.AreEqual(type, row.Cells[COL.TYPE].Value);
                    Assert.AreEqual(cost, row.Cells[COL.COST].Value);
                }
            }

            /// <summary>
            /// DataGridView
            /// セル選択位置のテスト
            /// </summary>
            [Test]
            public void DgvWithSelectedCell()
            {
                argDbFile = "AbTestTabExpenseWithInitialDgv.db";
                ShowForm(argDbFile);

                var dgvExpense = GetDgvExpense();

                var selectedCells = dgvExpense.SelectedCells;
                Assert.AreEqual(1, selectedCells.Count);

                var selectedCell = selectedCells[0];
                Assert.True(selectedCell.Selected);
                Assert.AreEqual(14, selectedCell.RowIndex);
                Assert.AreEqual(0, selectedCell.ColumnIndex);
            }

            /// <summary>
            /// DataGridView
            /// スクロールバーのテスト
            /// </summary>
            [Test]
            public void DgvWithScrollBar()
            {
                argDbFile = "AbTestTabExpenseWithInitialDgv.db";
                ShowForm(argDbFile);

                var dgvExpense = GetDgvExpense();

                var selectedCell = dgvExpense.SelectedCells[0];
                Assert.AreEqual(dgvExpense.FirstDisplayedCell.RowIndex, selectedCell.RowIndex - 9); //最終行から 9 行上の行がFirstDisplayedCell
                Assert.AreEqual(dgvExpense.FirstDisplayedCell.ColumnIndex, selectedCell.ColumnIndex);
            }
        }

        /// <summary>
        /// DataGridView 操作テスト
        /// </summary>
        [TestFixture]
        public class DataGridViewControl : NUnitFormTest
        {
            /// <summary>引数:DB ファイル</summary>
            private string argDbFile = "AbTestTabExpenseWithDataGridViewControl.db";
            /// <summary>対象:メイン画面フォーム</summary>
            private AbFormMain abFormMain;

            /// <summary>
            /// TestFixtureSetUp
            /// </summary>
            [TestFixtureSetUp]
            public void TestFixtureSetUp()
            {
                argDbFile = "AbTestTabExpenseWithDataGridViewControl.db";
                using (StreamWriter sw = new StreamWriter(argDbFile, false, System.Text.Encoding.UTF8))
                {
                    for (var i = 1; i <= 15; i++)
                    {
                        var date = (new DateTime(2012, 1, i)).ToString(FMT.DATE);
                        var name = "name" + i.ToString("D2");
                        var type = "type" + i.ToString("D2");
                        var cost = i * 100M;
                        sw.WriteLine(GenerateWriteLine(date, name, type, cost));
                    }
                }
            }

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
                    var finder = new FormFinder();
                    var form = finder.Find(typeof(AbFormMain).Name);
                    form.Close();
                }
                catch (NoSuchControlException)
                {
                    //すでに閉じられている
                }
                base.TearDown();
            }

            /// <summary>
            /// TestFixtureTearDown
            /// </summary>
            [TestFixtureTearDown]
            public void TestFixtureTearDown()
            {
                argDbFile = "AbTestTabExpenseWithDataGridViewControl.db";
                if (System.IO.File.Exists(argDbFile))
                {
                    System.IO.File.Delete(argDbFile);
                }
            }

            /// <summary>GenerateWriteLine メソッド用テンプレ</summary>
            private const string TEMPLATE = "\"{0}\",\"{1}\",\"{2}\",\"{3}\"";

            /// <summary>
            /// 出力用レコード文字列生成
            /// </summary>
            /// <param name="date">日付</param>
            /// <param name="name">名前</param>
            /// <param name="type">種別</param>
            /// <param name="cost">金額</param>
            /// <returns>出力用レコード文字列</returns>
            private string GenerateWriteLine(string date, string name, string type, decimal cost)
            {
                return string.Format(TEMPLATE, date, name, type, cost);
            }

            /// <summary>
            /// フォームを表示
            /// </summary>
            /// <param name="db">DB ファイル名</param>
            private void ShowForm(string db)
            {
                abFormMain = new AbFormMain(db);
                abFormMain.Show();
            }

            /// <summary>
            /// DataGridView 取得
            /// </summary>
            /// <returns>DataGridView</returns>
            private DataGridView GetDgvExpense()
            {
                var finder = new Finder<DataGridView>("DgvExpense", abFormMain);
                return finder.Find();
            }

            /// <summary>
            /// TabControlTester 取得
            /// </summary>
            /// <returns>TabControlTester</returns>
            private TabControlTester GetTabControlTester()
            {
                return new TabControlTester("TabControl", abFormMain);
            }

            /// <summary>
            /// ButtonTester 取得
            /// </summary>
            /// <returns>ButtonTester</returns>
            private ButtonTester GetAddRowTester()
            {
                return new ButtonTester("BtnAddRow", abFormMain);
            }

            /// <summary>
            /// ControlTester 取得
            /// </summary>
            /// <returns>ControlTester</returns>
            private ControlTester GetDgvExpenseTester()
            {
                return new ControlTester("DgvExpense", abFormMain);
            }

            /// <summary>
            /// 入力行の追加
            /// クリック: 1 回
            /// </summary>
            [Test]
            public void BtnAddRowClickWithOnce()
            {
                ShowForm(argDbFile);

                var dgvExpense = GetDgvExpense();
                var initRowCount = dgvExpense.Rows.Count;

                GetTabControlTester().SelectTab(0);
                GetAddRowTester().Click();

                var totalRowCount = initRowCount + DGV.NEW_ROW_SIZE;
                Assert.AreEqual(totalRowCount, dgvExpense.Rows.Count);
            }

            /// <summary>
            /// 入力行の追加
            /// クリック: 2 回
            /// </summary>
            [Test]
            public void BtnAddRowClickWithTwice()
            {
                ShowForm(argDbFile);

                var dgvExpense = GetDgvExpense();
                var initRowCount = dgvExpense.Rows.Count;

                GetTabControlTester().SelectTab(0);
                var btnAddRow = GetAddRowTester();
                btnAddRow.Click();
                btnAddRow.Click();

                var totalRowCount = initRowCount + DGV.NEW_ROW_SIZE * 2;
                Assert.AreEqual(totalRowCount, dgvExpense.Rows.Count);
            }

            /// <summary>
            /// 入力行の追加
            /// 追加入力行の日付初期値
            /// </summary>
            [Test]
            public void BtnAddRowClickWithInitialDate()
            {
                ShowForm(argDbFile);

                var dgvExpense = GetDgvExpense();
                var initRowCount = dgvExpense.Rows.Count;

                GetTabControlTester().SelectTab(0);
                GetAddRowTester().Click();

                var expectedDate = DateTime.Now.ToString(FMT.DATE);
                for (int i = initRowCount; i < dgvExpense.Rows.Count; i++)
                {
                    var row = dgvExpense.Rows[i];
                    Assert.AreEqual(expectedDate, row.Cells[COL.DATE].Value);
                }
            }

            /// <summary>
            /// KeyDown テスト
            /// キー: Ctrl + v
            /// 自動補完:補完候補あり
            /// </summary>
            /// <remarks>Clipboard を使用するため、RequiresSTA の指定が必要</remarks>
            [Test, RequiresSTA]
            public void KeyDownWithComplemented()
            {
                ShowForm(argDbFile);

                GetTabControlTester().SelectTab(0);
                GetAddRowTester().Click();

                var dgvExpense = GetDgvExpense();
                var idxRow = dgvExpense.Rows.Count - 1;
                dgvExpense.CurrentCell = dgvExpense.Rows[idxRow].Cells[COL.NAME];
                Assert.AreEqual(1, dgvExpense.CurrentCell.ColumnIndex);

                Clipboard.Clear();
                Clipboard.SetText("name01");

                var dgvTester = GetDgvExpenseTester();
                dgvTester.FireEvent("KeyDown", (new KeyEventArgs(Keys.Control | Keys.V)));

                Assert.AreEqual("type01", dgvExpense.Rows[idxRow].Cells[COL.TYPE].Value);
            }

            /// <summary>
            /// KeyDown テスト
            /// キー: Ctrl + v
            /// 自動補完:補完候補なし
            /// </summary>
            /// <remarks>Clipboard を使用するため、RequiresSTA の指定が必要</remarks>
            [Test, RequiresSTA]
            public void KeyDownWithNotComplemented()
            {
                ShowForm(argDbFile);

                GetTabControlTester().SelectTab(0);
                GetAddRowTester().Click();

                var dgvExpense = GetDgvExpense();
                var idxRow = dgvExpense.Rows.Count - 1;
                dgvExpense.CurrentCell = dgvExpense.Rows[idxRow].Cells[COL.NAME];
                Assert.AreEqual(1, dgvExpense.CurrentCell.ColumnIndex);

                Clipboard.Clear();
                Clipboard.SetText("nameXX");

                var dgvTester = GetDgvExpenseTester();
                dgvTester.FireEvent("KeyDown", (new KeyEventArgs(Keys.Control | Keys.V)));

                Assert.AreEqual(string.Empty, dgvExpense.Rows[idxRow].Cells[COL.TYPE].Value);
            }

            /// <summary>
            /// KeyDown テスト
            /// キー: Ctrl + v 以外 => Ctrl + c
            /// </summary>
            /// <remarks>Clipboard を使用するため、RequiresSTA の指定が必要</remarks>
            [Test, RequiresSTA]
            public void KeyDownWithNotCtrlV()
            {
                ShowForm(argDbFile);

                GetTabControlTester().SelectTab(0);
                GetAddRowTester().Click();

                var dgvExpense = GetDgvExpense();
                var idxRow = dgvExpense.Rows.Count - 1;
                dgvExpense.CurrentCell = dgvExpense.Rows[idxRow].Cells[COL.NAME];
                Assert.AreEqual(1, dgvExpense.CurrentCell.ColumnIndex);

                var dgvTester = GetDgvExpenseTester();
                dgvTester.FireEvent("KeyDown", (new KeyEventArgs(Keys.Control | Keys.C)));

                Assert.Null(dgvExpense.Rows[idxRow].Cells[COL.TYPE].Value);
            }

            /// <summary>
            /// CellEndEdit テスト
            /// セル:名称セル
            /// 自動補完:補完候補あり
            /// </summary>
            [Test]
            public void DgvExpenseCellEndEditWithComplemented()
            {
                ShowForm(argDbFile);

                GetTabControlTester().SelectTab(0);
                GetAddRowTester().Click();

                var dgvExpense = GetDgvExpense();
                var idxRow = dgvExpense.Rows.Count - 1;
                dgvExpense.CurrentCell = dgvExpense.Rows[idxRow].Cells[COL.NAME];
                dgvExpense.CurrentCell.Value = "name01";

                var dgvTester = GetDgvExpenseTester();
                dgvTester.FireEvent("CellEndEdit", (new DataGridViewCellEventArgs(1, idxRow)));

                Assert.AreEqual("type01", dgvExpense.Rows[idxRow].Cells[COL.TYPE].Value);
            }

            /// <summary>
            /// CellEndEdit テスト
            /// セル:名称セル
            /// 自動補完:補完候補なし
            /// </summary>
            [Test]
            public void DgvExpenseCellEndEditWithNotComplemented()
            {
                ShowForm(argDbFile);

                GetTabControlTester().SelectTab(0);
                GetAddRowTester().Click();

                var dgvExpense = GetDgvExpense();
                var idxRow = dgvExpense.Rows.Count - 1;
                dgvExpense.CurrentCell = dgvExpense.Rows[idxRow].Cells[COL.NAME];
                dgvExpense.CurrentCell.Value = "nameXX";

                var dgvTester = GetDgvExpenseTester();
                dgvTester.FireEvent("CellEndEdit", (new DataGridViewCellEventArgs(1, idxRow)));

                Assert.AreEqual(string.Empty, dgvExpense.Rows[idxRow].Cells[COL.TYPE].Value);
            }

            /// <summary>
            /// CellEndEdit テスト
            /// セル:名称セル以外
            /// </summary>
            [Test]
            public void DgvExpenseCellEndEditWithNotNameCell()
            {
                ShowForm(argDbFile);

                GetTabControlTester().SelectTab(0);
                GetAddRowTester().Click();

                var dgvExpense = GetDgvExpense();
                var idxRow = dgvExpense.Rows.Count - 1;
                dgvExpense.CurrentCell = dgvExpense.Rows[idxRow].Cells[COL.NAME];
                dgvExpense.CurrentCell.Value = "2013-01-01";

                var dgvTester = GetDgvExpenseTester();
                dgvTester.FireEvent("CellEndEdit", (new DataGridViewCellEventArgs(0, idxRow)));

                Assert.AreEqual(string.Empty, dgvExpense.Rows[idxRow].Cells[COL.TYPE].Value);
            }
        }

        /// <summary>
        /// 登録処理テスト
        /// </summary>
        [TestFixture]
        public class BtnEntryClick : NUnitFormTest
        {
            /// <summary>引数:DB ファイル</summary>
            private string argDbFile = "AbTestTabExpenseWithBtnEntryClick.db";
            /// <summary>対象:メイン画面フォーム</summary>
            private AbFormMain abFormMain;

            /// <summary>
            /// TestFixtureSetUp
            /// </summary>
            [TestFixtureSetUp]
            public void TestFixtureSetUp()
            {
                argDbFile = "AbTestTabExpenseWithBtnEntryClick.db";
                using (StreamWriter sw = new StreamWriter(argDbFile, false, System.Text.Encoding.UTF8))
                {
                    for (var i = 1; i <= 15; i++)
                    {
                        var date = (new DateTime(2012, 1, i)).ToString(FMT.DATE);
                        var name = "name" + i.ToString("D2");
                        var type = "type" + i.ToString("D2");
                        var cost = i * 100M;
                        sw.WriteLine(GenerateWriteLine(date, name, type, cost));
                    }
                }
                System.IO.File.Copy(argDbFile, "ExpectedDbFile.db");
            }

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
                    var finder = new FormFinder();
                    var form = finder.Find(typeof(AbFormMain).Name);
                    form.Close();
                }
                catch (NoSuchControlException)
                {
                    //すでに閉じられている
                }
                base.TearDown();
            }

            /// <summary>
            /// TestFixtureTearDown
            /// </summary>
            [TestFixtureTearDown]
            public void TestFixtureTearDown()
            {
                argDbFile = "AbTestTabExpenseWithBtnEntryClick.db";
                if (System.IO.File.Exists(argDbFile))
                {
                    System.IO.File.Delete(argDbFile);
                }
                if (System.IO.File.Exists("ExpectedDbFile.db"))
                {
                    System.IO.File.Delete("ExpectedDbFile.db");
                }
            }

            /// <summary>GenerateWriteLine メソッド用テンプレ</summary>
            private const string TEMPLATE = "\"{0}\",\"{1}\",\"{2}\",\"{3}\"";

            /// <summary>
            /// 出力用レコード文字列生成
            /// </summary>
            /// <param name="date">日付</param>
            /// <param name="name">名前</param>
            /// <param name="type">種別</param>
            /// <param name="cost">金額</param>
            /// <returns>出力用レコード文字列</returns>
            private string GenerateWriteLine(string date, string name, string type, decimal cost)
            {
                return string.Format(TEMPLATE, date, name, type, cost);
            }

            /// <summary>
            /// フォームを表示
            /// </summary>
            /// <param name="db">DB ファイル名</param>
            private void ShowForm(string db)
            {
                abFormMain = new AbFormMain(db);
                abFormMain.Show();
            }

            /// <summary>
            /// DataGridView 取得
            /// </summary>
            /// <returns>DataGridView</returns>
            private DataGridView GetDgvExpense()
            {
                var finder = new Finder<DataGridView>("DgvExpense", abFormMain);
                return finder.Find();
            }

            /// <summary>
            /// TabControlTester 取得
            /// </summary>
            /// <returns>TabControlTester</returns>
            private TabControlTester GetTabControlTester()
            {
                return new TabControlTester("TabControl", abFormMain);
            }

            /// <summary>
            /// ButtonTester 取得
            /// </summary>
            /// <returns>ButtonTester</returns>
            private ButtonTester GetBtnEntryTester()
            {
                return new ButtonTester("BtnEntry", abFormMain);
            }

            /// <summary>
            /// ButtonTester 取得
            /// </summary>
            /// <returns>ButtonTester</returns>
            private ButtonTester GetBtnAddRowTester()
            {
                return new ButtonTester("BtnAddRow", abFormMain);
            }

            /// <summary>
            /// 登録ボタンクリック
            /// </summary>
            [Test]
            public void WithSuccess()
            {
                ShowForm(argDbFile);

                //ダイアログの表示テスト
                DialogBoxHandler = (name, hWnd) =>
                {
                    var messageBox = new MessageBoxTester(hWnd);
                    Assert.AreEqual("登録完了", messageBox.Title);
                    Assert.AreEqual("正常に登録しました。", messageBox.Text);
                    messageBox.ClickOk();
                };

                GetTabControlTester().SelectTab(0);
                GetBtnEntryTester().Click();
                NUnit.Framework.FileAssert.AreEqual("ExpectedDbFile.db", argDbFile);
            }

            /// <summary>
            /// 登録ボタンクリック
            /// 入力行 0 件のエラー
            /// </summary>
            [Test]
            public void WithRowCountZeroError()
            {
                ShowForm(argDbFile);

                //ダイアログの表示テスト
                DialogBoxHandler = (name, hWnd) =>
                {
                    var messageBox = new MessageBoxTester(hWnd);
                    Assert.AreEqual("エラー", messageBox.Title);
                    Assert.AreEqual("レコードが1件もありません。", messageBox.Text);
                    messageBox.ClickOk();
                };

                GetDgvExpense().Rows.Clear();
                GetTabControlTester().SelectTab(0);
                GetBtnEntryTester().Click();
            }

            /// <summary>
            /// 登録ボタンクリック
            /// 空欄のある行は無視される
            /// </summary>
            [Test]
            public void WithIgnoreEmptyCell()
            {
                ShowForm(argDbFile);

                //ダイアログの表示テスト
                DialogBoxHandler = (name, hWnd) =>
                {
                    var messageBox = new MessageBoxTester(hWnd);
                    Assert.AreEqual("登録完了", messageBox.Title);
                    Assert.AreEqual("正常に登録しました。", messageBox.Text);
                    messageBox.ClickOk();
                };

                GetTabControlTester().SelectTab(0);
                GetBtnAddRowTester().Click();
                var dgvExpense = GetDgvExpense();
                var idxRow = dgvExpense.Rows.Count - 1;
                for (int i = 0; i < DGV.NEW_ROW_SIZE; i++)
                {
                    var row = dgvExpense.Rows[idxRow--];
                    row.Cells[COL.DATE].Value = string.Empty;
                }

                GetBtnEntryTester().Click();
                NUnit.Framework.FileAssert.AreEqual("ExpectedDbFile.db", argDbFile);
            }

            /// <summary>
            /// 登録ボタンクリック
            /// 日付の形式が不正
            /// </summary>
            [Test]
            public void WithInvalidDate()
            {
                ShowForm(argDbFile);

                //ダイアログの表示テスト
                DialogBoxHandler = (name, hWnd) =>
                {
                    var messageBox = new MessageBoxTester(hWnd);
                    var expected = string.Format(EX.DB_STORE, 2, EX.DATE_FORMAT);
                    Assert.AreEqual("エラー", messageBox.Title);
                    Assert.AreEqual(expected, messageBox.Text);
                    messageBox.ClickOk();

                    //エラー行が選択される
                    Assert.AreEqual(1, GetDgvExpense().SelectedRows[0].Index);
                };

                GetTabControlTester().SelectTab(0);
                GetDgvExpense().Rows[1].Cells[COL.DATE].Value = "2013-02-31";
                GetBtnEntryTester().Click();
            }

            /// <summary>
            /// 登録ボタンクリック
            /// 金額の形式が不正
            /// </summary>
            [Test]
            public void WithInvalidCost()
            {
                ShowForm(argDbFile);

                //ダイアログの表示テスト
                DialogBoxHandler = (name, hWnd) =>
                {
                    var messageBox = new MessageBoxTester(hWnd);
                    var expected = string.Format(EX.DB_STORE, 5, EX.COST_FORMAT);
                    Assert.AreEqual("エラー", messageBox.Title);
                    Assert.AreEqual(expected, messageBox.Text);
                    messageBox.ClickOk();

                    //エラー行が選択される
                    Assert.AreEqual(4, GetDgvExpense().SelectedRows[0].Index);
                };

                GetTabControlTester().SelectTab(0);
                GetDgvExpense().Rows[4].Cells[COL.COST].Value = "XXXXXXXX";
                GetBtnEntryTester().Click();
            }
        }
    }
}
