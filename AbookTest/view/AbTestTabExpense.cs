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
    using CSV  = Abook.AbConstants.CSV;
    using FMT  = Abook.AbConstants.FMT;
    using DGV  = Abook.AbConstants.DGV;
    using TYPE = Abook.AbConstants.TYPE;

    /// <summary>
    /// 支出タブテスト
    /// 抽象ベースクラス
    /// </summary>
    public abstract class AbTestTabExpenseBase : AbTestFormBase
    {
        /// <summary>DB ファイル</summary>
        protected const string DB_EXIST = "AbTestTabExpenseExist.db";
        /// <summary>DB ファイル</summary>
        protected const string DB_EMPTY = "AbTestTabExpenseEmpty.db";
        /// <summary>DB ファイル</summary>
        protected const string DB_ENTRY = "AbTestTabExpenseEntry.db";
        /// <summary>タブインデックス</summary>
        protected const int TAB_IDX = 0;

        /// <summary>
        /// TestFixtureSetUp
        /// </summary>
        [TestFixtureSetUp]
        protected void TestFixtureSetUp()
        {
            using (StreamWriter sw = new StreamWriter(DB_EXIST, false, CSV.ENCODING))
            {
                sw.NewLine = CSV.LF;
                for (var i = 1; i <= 15; i++)
                {
                    var date = (new DateTime(2012, 1, i)).ToString(FMT.DATE);
                    var name = "name" + i.ToString("D2");
                    var type = "type" + i.ToString("D2");
                    var cost = (i * 100M).ToString();
                    sw.WriteLine(ToCSV(date, name, type, cost));
                }
            }
            System.IO.File.Copy(DB_EXIST, DB_ENTRY);
        }

        /// <summary>
        /// TestFixtureTearDown
        /// </summary>
        [TestFixtureTearDown]
        protected void TestFixtureTearDown()
        {
            if (System.IO.File.Exists(DB_EXIST)) System.IO.File.Delete(DB_EXIST);
            if (System.IO.File.Exists(DB_EMPTY)) System.IO.File.Delete(DB_EMPTY);
            if (System.IO.File.Exists(DB_ENTRY)) System.IO.File.Delete(DB_ENTRY);
        }
    }

    /// <summary>
    /// 支出タブテスト
    /// </summary>
    public class AbTestTabExpense
    {
        /// <summary>
        /// 初期表示テスト
        /// </summary>
        [TestFixture]
        public class InitialDataGridView : AbTestTabExpenseBase
        {
            /// <summary>
            /// DataGridView
            /// 入力行のテスト(データなし)
            /// </summary>
            [Test]
            public void CountWithEmptyData()
            {
                ShowFormMain(DB_EMPTY, TAB_IDX);

                Assert.AreEqual(0, CtDgvExpense().Rows.Count);
            }

            /// <summary>
            /// DataGridView
            /// 入力行数のテスト
            /// </summary>
            [Test]
            public void CountWithExistData()
            {
                ShowFormMain(DB_EXIST, TAB_IDX);

                Assert.AreEqual(15, CtDgvExpense().Rows.Count);
            }

            /// <summary>
            /// DataGridView
            /// 支出レコードのテスト
            /// </summary>
            [Test]
            public void DgvWithExistData()
            {
                ShowFormMain(DB_EXIST, TAB_IDX);

                var dgvExpense = CtDgvExpense();
                for (var i = 1; i <= 15; i++)
                {
                    var row = dgvExpense.Rows[i - 1];

                    var date = string.Format("2012-01-{0:D2}", i);
                    var name = string.Format("name{0:D2}", i);
                    var type = string.Format("type{0:D2}", i);
                    var cost = i * 100M;

                    Assert.AreEqual(date, row.Cells[COL.DATE].Value, "DATE");
                    Assert.AreEqual(name, row.Cells[COL.NAME].Value, "NAME");
                    Assert.AreEqual(type, row.Cells[COL.TYPE].Value, "TYPE");
                    Assert.AreEqual(cost, row.Cells[COL.COST].Value, "COST");
                }
            }

            /// <summary>
            /// DataGridView
            /// セル選択位置のテスト
            /// </summary>
            [Test]
            public void DgvWithSelectedCell()
            {
                ShowFormMain(DB_EXIST, TAB_IDX);

                var cell = CtDgvExpense().SelectedCells[0];
                Assert.True(cell.Selected);
                Assert.AreEqual(14, cell.RowIndex);
                Assert.AreEqual( 0, cell.ColumnIndex);
                Assert.AreEqual( 1, CtDgvExpense().SelectedCells.Count);
            }

            /// <summary>
            /// DataGridView
            /// スクロールバーのテスト
            /// </summary>
            [Test]
            public void DgvWithScrollBar()
            {
                ShowFormMain(DB_EXIST, TAB_IDX);

                var cell = CtDgvExpense().SelectedCells[0];
                Assert.AreEqual(CtDgvExpense().FirstDisplayedCell.RowIndex, cell.RowIndex - 9); //最終行から 9 行上の行がFirstDisplayedCell
                Assert.AreEqual(CtDgvExpense().FirstDisplayedCell.ColumnIndex, cell.ColumnIndex);
            }
        }

        /// <summary>
        /// DataGridView 操作テスト
        /// </summary>
        [TestFixture]
        public class DataGridViewControl : AbTestTabExpenseBase
        {
            /// <summary>
            /// 入力行の追加
            /// クリック: 1 回
            /// </summary>
            [Test]
            public void BtnAddRowClickWithOnce()
            {
                ShowFormMain(DB_EXIST, TAB_IDX);

                var dgvExpense = CtDgvExpense();
                var initRowCount = dgvExpense.Rows.Count;

                TsBtnAddRow().Click();

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
                ShowFormMain(DB_EXIST, TAB_IDX);

                var dgvExpense = CtDgvExpense();
                var initRowCount = dgvExpense.Rows.Count;

                TsBtnAddRow().Click();
                TsBtnAddRow().Click();

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
                ShowFormMain(DB_EXIST, TAB_IDX);

                var dgvExpense = CtDgvExpense();
                var initRowCount = dgvExpense.Rows.Count;

                TsBtnAddRow().Click();

                var date = DateTime.Now.ToString(FMT.DATE);
                for (int i = initRowCount; i < dgvExpense.Rows.Count; i++)
                {
                    var row = dgvExpense.Rows[i];
                    Assert.AreEqual(date, row.Cells[COL.DATE].Value);
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
                ShowFormMain(DB_EXIST, TAB_IDX);

                var dgvExpense = CtDgvExpense();
                var idxRow = dgvExpense.Rows.Count - 1;
                dgvExpense.CurrentCell = dgvExpense.Rows[idxRow].Cells[COL.NAME];

                Clipboard.Clear();
                Clipboard.SetText("name01");

                TsDgvExpense().FireEvent("KeyDown", (new KeyEventArgs(Keys.Control | Keys.V)));

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
                ShowFormMain(DB_EXIST, TAB_IDX);

                var dgvExpense = CtDgvExpense();
                var idxRow = dgvExpense.Rows.Count - 1;
                dgvExpense.CurrentCell = dgvExpense.Rows[idxRow].Cells[COL.NAME];

                Clipboard.Clear();
                Clipboard.SetText("nameXX");

                TsDgvExpense().FireEvent("KeyDown", (new KeyEventArgs(Keys.Control | Keys.V)));

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
                ShowFormMain(DB_EXIST, TAB_IDX);

                TsBtnAddRow().Click();

                var dgvExpense = CtDgvExpense();
                var idxRow = dgvExpense.Rows.Count - 1;
                dgvExpense.CurrentCell = dgvExpense.Rows[idxRow].Cells[COL.NAME];

                TsDgvExpense().FireEvent("KeyDown", (new KeyEventArgs(Keys.Control | Keys.C)));

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
                ShowFormMain(DB_EXIST, TAB_IDX);

                var dgvExpense = CtDgvExpense();
                var idxRow = dgvExpense.Rows.Count - 1;
                dgvExpense.CurrentCell = dgvExpense.Rows[idxRow].Cells[COL.NAME];
                dgvExpense.CurrentCell.Value = "name01";

                TsDgvExpense().FireEvent("CellEndEdit", (new DataGridViewCellEventArgs(1, idxRow)));

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
                ShowFormMain(DB_EXIST, TAB_IDX);

                var dgvExpense = CtDgvExpense();
                var idxRow = dgvExpense.Rows.Count - 1;
                dgvExpense.CurrentCell = dgvExpense.Rows[idxRow].Cells[COL.NAME];
                dgvExpense.CurrentCell.Value = "nameXX";

                TsDgvExpense().FireEvent("CellEndEdit", (new DataGridViewCellEventArgs(1, idxRow)));

                Assert.AreEqual(string.Empty, dgvExpense.Rows[idxRow].Cells[COL.TYPE].Value);
            }

            /// <summary>
            /// CellEndEdit テスト
            /// セル:名称セル以外
            /// </summary>
            [Test]
            public void DgvExpenseCellEndEditWithNotNameCell()
            {
                ShowFormMain(DB_EXIST, TAB_IDX);

                var dgvExpense = CtDgvExpense();
                var idxRow = dgvExpense.Rows.Count - 1;
                dgvExpense.CurrentCell = dgvExpense.Rows[idxRow].Cells[COL.NAME];
                dgvExpense.CurrentCell.Value = "2013-01-01";

                TsDgvExpense().FireEvent("CellEndEdit", (new DataGridViewCellEventArgs(0, idxRow)));

                Assert.AreEqual(string.Empty, dgvExpense.Rows[idxRow].Cells[COL.TYPE].Value);
            }
        }

        /// <summary>
        /// 登録処理テスト
        /// </summary>
        [TestFixture]
        public class BtnEntryClick : AbTestTabExpenseBase
        {
            /// <summary>
            /// 登録ボタンクリック
            /// </summary>
            [Test]
            public void WithSuccess()
            {
                //ダイアログの表示テスト
                DialogBoxHandler = (name, hWnd) =>
                {
                    var tsMessageBox = new MessageBoxTester(hWnd);

                    //タイトル
                    var title = "登録完了";
                    Assert.AreEqual(title, tsMessageBox.Title);

                    //テキスト
                    var text = "正常に登録しました。";
                    Assert.AreEqual(text, tsMessageBox.Text);

                    // OK ボタンクリック
                    tsMessageBox.ClickOk();
                };

                ShowFormMain(DB_EXIST, TAB_IDX);

                TsBtnEntry().Click();

                NUnit.Framework.FileAssert.AreEqual(DB_ENTRY, DB_EXIST);
            }

            /// <summary>
            /// 登録ボタンクリック
            /// 入力行 0 件のエラー
            /// </summary>
            [Test]
            public void ErrorWithRowCountZero()
            {
                //ダイアログの表示テスト
                DialogBoxHandler = (name, hWnd) =>
                {
                    var tsMessageBox = new MessageBoxTester(hWnd);

                    //タイトル
                    var title = "エラー";
                    Assert.AreEqual(title, tsMessageBox.Title);

                    //テキスト
                    var text = "レコードが1件もありません。";
                    Assert.AreEqual(text, tsMessageBox.Text);

                    // OK ボタンクリック
                    tsMessageBox.ClickOk();
                };

                ShowFormMain(DB_EXIST, TAB_IDX);

                CtDgvExpense().Rows.Clear();

                TsBtnEntry().Click();
            }

            /// <summary>
            /// 登録ボタンクリック
            /// 空欄のある行は無視される
            /// </summary>
            [Test]
            public void WithIgnoreEmptyCell()
            {
                //ダイアログの表示テスト
                DialogBoxHandler = (name, hWnd) =>
                {
                    var tsMessageBox = new MessageBoxTester(hWnd);

                    //タイトル
                    var title = "登録完了";
                    Assert.AreEqual(title, tsMessageBox.Title);

                    //テキスト
                    var text = "正常に登録しました。";
                    Assert.AreEqual(text, tsMessageBox.Text);

                    // OK ボタンクリック
                    tsMessageBox.ClickOk();
                };

                ShowFormMain(DB_EXIST, TAB_IDX);

                TsBtnAddRow().Click();

                var dgvExpense = CtDgvExpense();
                var idxRow = dgvExpense.Rows.Count - 1;
                for (int i = 0; i < DGV.NEW_ROW_SIZE; i++)
                {
                    var row = dgvExpense.Rows[idxRow--];
                    row.Cells[COL.DATE].Value = string.Empty;
                }

                TsBtnEntry().Click();

                NUnit.Framework.FileAssert.AreEqual(DB_ENTRY, DB_EXIST);
            }

            /// <summary>
            /// 登録ボタンクリック
            /// 日付の形式が不正
            /// </summary>
            [Test]
            public void WithInvalidDate()
            {
                //ダイアログの表示テスト
                DialogBoxHandler = (name, hWnd) =>
                {
                    var tsMessageBox = new MessageBoxTester(hWnd);

                    //タイトル
                    var title = "エラー";
                    Assert.AreEqual(title, tsMessageBox.Title);

                    //テキスト
                    var text = string.Format(EX.DB_STORE, 2, EX.DATE_FORMAT);
                    Assert.AreEqual(text, tsMessageBox.Text);

                    // OK ボタンクリック
                    tsMessageBox.ClickOk();

                    //エラー行が選択される
                    Assert.AreEqual(1, CtDgvExpense().SelectedRows[0].Index);
                };

                ShowFormMain(DB_EXIST, TAB_IDX);

                CtDgvExpense().Rows[1].Cells[COL.DATE].Value = "2013-02-31";

                TsBtnEntry().Click();
            }

            /// <summary>
            /// 登録ボタンクリック
            /// 金額の形式が不正
            /// </summary>
            [Test]
            public void WithInvalidCost()
            {
                //ダイアログの表示テスト
                DialogBoxHandler = (name, hWnd) =>
                {
                    var tsMessageBox = new MessageBoxTester(hWnd);

                    //タイトル
                    var title = "エラー";
                    Assert.AreEqual(title, tsMessageBox.Title);

                    //テキスト
                    var text = string.Format(EX.DB_STORE, 5, EX.COST_FORMAT);
                    Assert.AreEqual(text, tsMessageBox.Text);

                    // OK ボタンクリック
                    tsMessageBox.ClickOk();

                    //エラー行が選択される
                    Assert.AreEqual(4, CtDgvExpense().SelectedRows[0].Index);
                };

                ShowFormMain(DB_EXIST, TAB_IDX);

                CtDgvExpense().Rows[4].Cells[COL.COST].Value = "XXXXXXXX";

                TsBtnEntry().Click();
            }
        }
    }
}
