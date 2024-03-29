﻿// ------------------------------------------------------------
// © 2010 https://github.com/m-kishi
// ------------------------------------------------------------
namespace AbookTest
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using NUnit.Framework;
    using NUnit.Extensions.Forms;
    using TT   = AbTestTool;
    using EX   = Abook.AbException.EX;
    using DB   = Abook.AbConstants.DB;
    using COL  = Abook.AbConstants.COL.EXPENSE;
    using DGV  = Abook.AbConstants.DGV;
    using FMT  = Abook.AbConstants.FMT;
    using TYPE = Abook.AbConstants.TYPE;

    /// <summary>
    /// 支出タブテスト
    /// 抽象ベースクラス
    /// </summary>
    public abstract class AbTestTabExpenseBase : AbTestFormBase
    {
        /// <summary>DBファイル</summary>
        protected const string DB_FILE_EXIST = "AbTestTabExpenseExist.db";
        /// <summary>DBファイル</summary>
        protected const string DB_FILE_EMPTY = "AbTestTabExpenseEmpty.db";
        /// <summary>DBファイル</summary>
        protected const string DB_FILE_ENTRY = "AbTestTabExpenseEntry.db";
        /// <summary>DBファイル</summary>
        protected const string DB_FILE_TAX_TEST = "AbTestTabExpenseTaxTest.cb";
        /// <summary>DBファイル</summary>
        protected const string DB_FILE_NOTE_TEST = "AbTestTabExpenseNoteTest.db";
        /// <summary>DBファイル</summary>
        protected const string DB_FILE_NOTE_ENTRY = "AbTestTabExpenseNoteEntry.db";
        /// <summary>タブインデックス</summary>
        protected const int TAB_IDX = 0;

        /// <summary>
        /// TestFixtureSetUp
        /// </summary>
        [TestFixtureSetUp]
        protected void TestFixtureSetUp()
        {
            using (StreamWriter sw = new StreamWriter(DB_FILE_EXIST, false, DB.ENCODING))
            {
                sw.NewLine = DB.LF;
                for (var i = 1; i <= 15; i++)
                {
                    var date = (new DateTime(2012, 1, i)).ToString(FMT.DATE);
                    var name = "name" + i.ToString("D2");
                    var type = TYPE.FOOD;
                    var cost = (i * 100M).ToString();
                    var note = "note" + i.ToString("D2");
                    sw.WriteLine(TT.ToDBFileFormat(date, name, type, cost, note));
                }
                sw.WriteLine(TT.ToDBFileFormat("2017-03-01", "name16", TYPE.FOOD, "1000"));
                sw.WriteLine(TT.ToDBFileFormat("2017-03-01", "name16", TYPE.OTFD, "2000"));
                sw.Close();
            }
            if (File.Exists(DB_FILE_ENTRY))
            {
                File.Delete(DB_FILE_ENTRY);
            }
            File.Copy(DB_FILE_EXIST, DB_FILE_ENTRY);

            using (StreamWriter sw = new StreamWriter(DB_FILE_TAX_TEST, false, DB.ENCODING))
            {
                sw.NewLine = DB.LF;
                for (var i = 1; i <= 5; i++)
                {
                    var date = (new DateTime(2021, 11, i)).ToString(FMT.DATE);
                    var name = "name" + i.ToString("D2");
                    var type = TYPE.FOOD;
                    var cost = (i * 100M).ToString();
                    var note = "note" + i.ToString("D2");
                    sw.WriteLine(TT.ToDBFileFormat(date, name, type, cost, note));
                }
                sw.Close();
            }

            using (StreamWriter sw = new StreamWriter(DB_FILE_NOTE_TEST, false, DB.ENCODING))
            {
                sw.NewLine = DB.LF;
                for (var i = 1; i <= 5; i++)
                {
                    var date = (new DateTime(2024, 3, i)).ToString(FMT.DATE);
                    var name = "name" + i.ToString("D2");
                    var type = TYPE.FOOD;
                    var cost = (i * 100M).ToString();
                    var note = "note" + i.ToString("D2");
                    if (i % 2 == 0)
                    {
                        note = "";
                    }
                    sw.WriteLine(TT.ToDBFileFormat(date, name, type, cost, note));
                }
                sw.Close();
            }

            File.Copy(DB_FILE_NOTE_TEST, DB_FILE_NOTE_ENTRY);
            using (StreamWriter sw = new StreamWriter(DB_FILE_NOTE_ENTRY, true, DB.ENCODING))
            {
                sw.NewLine = DB.LF;
                sw.WriteLine(TT.ToDBFileFormat("2024-03-01", "おにぎり", "食費", "150", "シャケ"));
                sw.Close();
            }
        }

        /// <summary>
        /// TestFixtureTearDown
        /// </summary>
        [TestFixtureTearDown]
        protected void TestFixtureTearDown()
        {
            if (File.Exists(DB_FILE_EXIST)) File.Delete(DB_FILE_EXIST);
            if (File.Exists(DB_FILE_EMPTY)) File.Delete(DB_FILE_EMPTY);
            if (File.Exists(DB_FILE_ENTRY)) File.Delete(DB_FILE_ENTRY);
            if (File.Exists(DB_FILE_TAX_TEST)) File.Delete(DB_FILE_TAX_TEST);
            if (File.Exists(DB_FILE_NOTE_TEST)) File.Delete(DB_FILE_NOTE_TEST);
            if (File.Exists(DB_FILE_NOTE_ENTRY)) File.Delete(DB_FILE_NOTE_ENTRY);
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
                ShowFormMain(DB_FILE_EMPTY, TAB_IDX);
                Assert.AreEqual(0, CtDgvExpense().Rows.Count);
            }

            /// <summary>
            /// DataGridView
            /// 入力行数のテスト
            /// </summary>
            [Test]
            public void CountWithExistData()
            {
                ShowFormMain(DB_FILE_EXIST, TAB_IDX);
                Assert.AreEqual(17, CtDgvExpense().Rows.Count);
            }

            /// <summary>
            /// DataGridView
            /// 支出情報のテスト
            /// </summary>
            [Test]
            public void DgvWithExistData()
            {
                ShowFormMain(DB_FILE_EXIST, TAB_IDX);

                var dgvExpense = CtDgvExpense();
                for (var i = 1; i <= 15; i++)
                {
                    var row = dgvExpense.Rows[i - 1];

                    var date = string.Format("2012-01-{0:D2}", i);
                    var name = string.Format("name{0:D2}", i);
                    var type = TYPE.FOOD;
                    var cost = i * 100M;
                    var note = string.Format("note{0:D2}", i);

                    Assert.AreEqual(date, row.Cells[COL.DATE].Value, "DATE");
                    Assert.AreEqual(name, row.Cells[COL.NAME].Value, "NAME");
                    Assert.AreEqual(type, row.Cells[COL.TYPE].Value, "TYPE");
                    Assert.AreEqual(cost, row.Cells[COL.COST].Value, "COST");
                    Assert.AreEqual(note, row.Cells[COL.NAME].ToolTipText, "NOTE");
                    Assert.AreEqual(DGV.NOTE_BG_COLOR, row.DefaultCellStyle.BackColor);
                }

                Assert.AreEqual("", dgvExpense.Rows[15].Cells[COL.NAME].ToolTipText, "NOTE");
                Assert.AreEqual("", dgvExpense.Rows[16].Cells[COL.NAME].ToolTipText, "NOTE");
                Assert.AreEqual(Color.Empty, dgvExpense.Rows[15].DefaultCellStyle.BackColor);
                Assert.AreEqual(Color.Empty, dgvExpense.Rows[16].DefaultCellStyle.BackColor);
            }

            /// <summary>
            /// DataGridView
            /// 支出情報(備考)のテスト
            /// </summary>
            [Test]
            public void DgvWithColNote()
            {
                ShowFormMain(DB_FILE_NOTE_TEST, TAB_IDX);

                var dgvExpense = CtDgvExpense();
                for (var i = 1; i <= 5; i++)
                {
                    var row = dgvExpense.Rows[i - 1];

                    var note = string.Format("note{0:D2}", i);
                    var color = DGV.NOTE_BG_COLOR;
                    if (i % 2 == 0)
                    {
                        note = "";
                        color = Color.Empty;
                    }

                    Assert.AreEqual(note, row.Cells[COL.NOTE].Value);
                    Assert.AreEqual(color, row.DefaultCellStyle.BackColor);
                }
            }

            /// <summary>
            /// DataGridView
            /// セル選択位置のテスト
            /// </summary>
            [Test]
            public void DgvWithSelectedCell()
            {
                ShowFormMain(DB_FILE_EXIST, TAB_IDX);

                var cell = CtDgvExpense().SelectedCells[0];
                Assert.True(cell.Selected);
                Assert.AreEqual(16, cell.RowIndex);
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
                ShowFormMain(DB_FILE_EXIST, TAB_IDX);

                // 最終行から 9 行上の行がFirstDisplayedCell
                var cell = CtDgvExpense().SelectedCells[0];
                Assert.AreEqual(CtDgvExpense().FirstDisplayedCell.RowIndex, cell.RowIndex - 9);
                Assert.AreEqual(CtDgvExpense().FirstDisplayedCell.ColumnIndex, cell.ColumnIndex);
            }
        }

        /// <summary>
        /// DataGridView操作テスト
        /// </summary>
        [TestFixture]
        public class DataGridViewControl : AbTestTabExpenseBase
        {
            /// <summary>
            /// 入力行の追加
            /// クリック: 1回
            /// </summary>
            [Test]
            public void BtnAddRowClickWithOnce()
            {
                ShowFormMain(DB_FILE_EXIST, TAB_IDX);

                var dgvExpense = CtDgvExpense();
                var initRowCount = dgvExpense.Rows.Count;

                TsBtnAddRow().Click();

                var totalRowCount = initRowCount + DGV.NEW_ROW_SIZE;
                Assert.AreEqual(totalRowCount, dgvExpense.Rows.Count);
            }

            /// <summary>
            /// 入力行の追加
            /// クリック: 2回
            /// </summary>
            [Test]
            public void BtnAddRowClickWithTwice()
            {
                ShowFormMain(DB_FILE_EXIST, TAB_IDX);

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
                ShowFormMain(DB_FILE_EXIST, TAB_IDX);

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
            /// KeyDownテスト
            /// キー: Ctrl + v
            /// 自動補完:補完候補あり
            /// </summary>
            /// <remarks>Clipboardを使用するため、RequiresSTAの指定が必要</remarks>
            [Test, RequiresSTA]
            public void KeyDownWithComplemented()
            {
                ShowFormMain(DB_FILE_EXIST, TAB_IDX);

                var dgvExpense = CtDgvExpense();
                var idxRow = dgvExpense.Rows.Count - 1;
                dgvExpense.CurrentCell = dgvExpense.Rows[idxRow].Cells[COL.NAME];

                Clipboard.Clear();
                Clipboard.SetText("name01");

                TsDgvExpense().FireEvent("KeyDown", (new KeyEventArgs(Keys.Control | Keys.V)));

                Assert.AreEqual(TYPE.FOOD, dgvExpense.Rows[idxRow].Cells[COL.TYPE].Value);
            }

            /// <summary>
            /// KeyDownテスト
            /// キー: Ctrl + v
            /// 自動補完:補完候補なし
            /// </summary>
            /// <remarks>Clipboardを使用するため、RequiresSTAの指定が必要</remarks>
            [Test, RequiresSTA]
            public void KeyDownWithNotComplemented()
            {
                ShowFormMain(DB_FILE_EXIST, TAB_IDX);

                var dgvExpense = CtDgvExpense();
                var idxRow = dgvExpense.Rows.Count - 1;
                dgvExpense.CurrentCell = dgvExpense.Rows[idxRow].Cells[COL.NAME];

                Clipboard.Clear();
                Clipboard.SetText("nameXX");

                TsDgvExpense().FireEvent("KeyDown", (new KeyEventArgs(Keys.Control | Keys.V)));

                Assert.AreEqual(string.Empty, dgvExpense.Rows[idxRow].Cells[COL.TYPE].Value);
            }

            /// <summary>
            /// KeyDownテスト
            /// キー: Ctrl + v
            /// 自動補完:金額のカンマ編集
            /// </summary>
            /// <remarks>Clipboardを使用するため、RequiresSTAの指定が必要</remarks>
            [Test, RequiresSTA]
            public void KeyDownWithCommaFormat()
            {
                ShowFormMain(DB_FILE_EXIST, TAB_IDX);

                var dgvExpense = CtDgvExpense();
                var idxRow = dgvExpense.Rows.Count - 1;
                dgvExpense.CurrentCell = dgvExpense.Rows[idxRow].Cells[COL.COST];

                Clipboard.Clear();
                Clipboard.SetText("1000000");

                TsDgvExpense().FireEvent("KeyDown", (new KeyEventArgs(Keys.Control | Keys.V)));

                Assert.AreEqual("1,000,000", dgvExpense.Rows[idxRow].Cells[COL.COST].Value);
            }

            /// <summary>
            /// KeyDownテスト
            /// キー: Ctrl + v
            /// 自動補完:名称貼り付け 補完候補あり
            /// </summary>
            /// <remarks>Clipboardを使用するため、RequiresSTAの指定が必要</remarks>
            [Test, RequiresSTA]
            public void KeyDownWithCostComplementedOfNameCell()
            {
                ShowFormMain(DB_FILE_EXIST, TAB_IDX);

                var dgvExpense = CtDgvExpense();
                var idxRow = dgvExpense.Rows.Count - 1;
                dgvExpense.CurrentCell = dgvExpense.Rows[idxRow].Cells[COL.NAME];

                Clipboard.Clear();
                Clipboard.SetText("name10");

                TsDgvExpense().FireEvent("KeyDown", (new KeyEventArgs(Keys.Control | Keys.V)));

                Assert.AreEqual(TYPE.FOOD, dgvExpense.Rows[idxRow].Cells[COL.TYPE].Value);
                Assert.AreEqual("1,000", dgvExpense.Rows[idxRow].Cells[COL.COST].Value);
            }

            /// <summary>
            /// KeyDownテスト
            /// キー: Ctrl + v
            /// 自動補完:名称貼り付け 補完候補なし
            /// </summary>
            /// <remarks>Clipboardを使用するため、RequiresSTAの指定が必要</remarks>
            [Test, RequiresSTA]
            public void KeyDownWithCostNotComplementedOfNameCell()
            {
                ShowFormMain(DB_FILE_EXIST, TAB_IDX);

                var dgvExpense = CtDgvExpense();
                var idxRow = dgvExpense.Rows.Count - 1;
                dgvExpense.CurrentCell = dgvExpense.Rows[idxRow].Cells[COL.NAME];

                Clipboard.Clear();
                Clipboard.SetText("not match");

                TsDgvExpense().FireEvent("KeyDown", (new KeyEventArgs(Keys.Control | Keys.V)));

                Assert.AreEqual(string.Empty, dgvExpense.Rows[idxRow].Cells[COL.TYPE].Value);
                Assert.AreEqual(string.Empty, dgvExpense.Rows[idxRow].Cells[COL.COST].Value);
            }

            /// <summary>
            /// KeyDownテスト
            /// キー: Ctrl + v
            /// 自動補完:名称貼り付け 補完候補あり
            /// </summary>
            /// <remarks>Clipboardを使用するため、RequiresSTAの指定が必要</remarks>
            [Test, RequiresSTA]
            public void KeyDownWithCostComplementedOfTypeCell()
            {
                ShowFormMain(DB_FILE_EXIST, TAB_IDX);

                var dgvExpense = CtDgvExpense();
                var idxRow = dgvExpense.Rows.Count - 1;
                dgvExpense.CurrentCell = dgvExpense.Rows[idxRow].Cells[COL.TYPE];
                Assert.AreEqual(2000, dgvExpense.Rows[idxRow].Cells[COL.COST].Value);

                Clipboard.Clear();
                Clipboard.SetText(TYPE.FOOD);

                TsDgvExpense().FireEvent("KeyDown", (new KeyEventArgs(Keys.Control | Keys.V)));

                Assert.AreEqual("1,000", dgvExpense.Rows[idxRow].Cells[COL.COST].Value);
            }

            /// <summary>
            /// KeyDownテスト
            /// キー: Ctrl + v
            /// 自動補完:名称貼り付け 補完候補なし
            /// </summary>
            /// <remarks>Clipboardを使用するため、RequiresSTAの指定が必要</remarks>
            [Test, RequiresSTA]
            public void KeyDownWithCostNotComplementedOfTypeCell()
            {
                ShowFormMain(DB_FILE_EXIST, TAB_IDX);

                var dgvExpense = CtDgvExpense();
                var idxRow = dgvExpense.Rows.Count - 1;
                dgvExpense.CurrentCell = dgvExpense.Rows[idxRow].Cells[COL.TYPE];
                Assert.AreEqual(2000, dgvExpense.Rows[idxRow].Cells[COL.COST].Value);

                Clipboard.Clear();
                Clipboard.SetText("not match");

                TsDgvExpense().FireEvent("KeyDown", (new KeyEventArgs(Keys.Control | Keys.V)));

                Assert.AreEqual(string.Empty, dgvExpense.Rows[idxRow].Cells[COL.COST].Value);
            }

            /// <summary>
            /// KeyDownテスト
            /// キー: Ctrl + v 以外 => Ctrl + c
            /// </summary>
            /// <remarks>Clipboardを使用するため、RequiresSTAの指定が必要</remarks>
            [Test, RequiresSTA]
            public void KeyDownWithNotCtrlV()
            {
                ShowFormMain(DB_FILE_EXIST, TAB_IDX);

                TsBtnAddRow().Click();

                var dgvExpense = CtDgvExpense();
                var idxRow = dgvExpense.Rows.Count - 1;
                dgvExpense.CurrentCell = dgvExpense.Rows[idxRow].Cells[COL.NAME];

                TsDgvExpense().FireEvent("KeyDown", (new KeyEventArgs(Keys.Control | Keys.C)));

                Assert.Null(dgvExpense.Rows[idxRow].Cells[COL.TYPE].Value);
            }

            /// <summary>
            /// KeyDownテスト
            /// キー: Ctrl + t
            /// 選択範囲の合計表示:範囲選択なし
            /// </summary>
            [Test]
            public void KeyDownWithTotalCostNoSelection()
            {
                // ダイアログの表示テスト
                DialogBoxHandler = (name, hWnd) =>
                {
                    var tsMessageBox = new MessageBoxTester(hWnd);

                    // タイトル
                    var title = "合計";
                    Assert.AreEqual(title, tsMessageBox.Title);

                    // テキスト
                    var text = @"\0";
                    Assert.AreEqual(text, tsMessageBox.Text);

                    // OKボタンクリック
                    tsMessageBox.ClickOk();
                };

                ShowFormMain(DB_FILE_EXIST, TAB_IDX);

                var dgvExpense = CtDgvExpense();
                dgvExpense.ClearSelection();

                TsDgvExpense().FireEvent("KeyDown", (new KeyEventArgs(Keys.Control | Keys.T)));
            }

            /// <summary>
            /// KeyDownテスト
            /// キー: Ctrl + t
            /// 選択範囲の合計表示:金額列範囲外
            /// </summary>
            [Test]
            public void KeyDownWithTotalCostWithoutCostColumn()
            {
                // ダイアログの表示テスト
                DialogBoxHandler = (name, hWnd) =>
                {
                    var tsMessageBox = new MessageBoxTester(hWnd);

                    // タイトル
                    var title = "合計";
                    Assert.AreEqual(title, tsMessageBox.Title);

                    // テキスト
                    var text = @"\0";
                    Assert.AreEqual(text, tsMessageBox.Text);

                    // OKボタンクリック
                    tsMessageBox.ClickOk();
                };

                ShowFormMain(DB_FILE_EXIST, TAB_IDX);

                var dgvExpense = CtDgvExpense();
                for (int i = 0; i < 3; i++) {
                    var row = dgvExpense.Rows[i];
                    row.Cells[COL.DATE].Selected = true;
                    row.Cells[COL.NAME].Selected = true;
                    row.Cells[COL.TYPE].Selected = true;
                }

                TsDgvExpense().FireEvent("KeyDown", (new KeyEventArgs(Keys.Control | Keys.T)));
            }

            /// <summary>
            /// KeyDownテスト
            /// キー: Ctrl + t
            /// 選択範囲の合計表示:金額単一セル
            /// </summary>
            [Test]
            public void KeyDownWithTotalCostSingleCell()
            {
                // ダイアログの表示テスト
                DialogBoxHandler = (name, hWnd) =>
                {
                    var tsMessageBox = new MessageBoxTester(hWnd);

                    // タイトル
                    var title = "合計";
                    Assert.AreEqual(title, tsMessageBox.Title);

                    // テキスト
                    var text = @"\100";
                    Assert.AreEqual(text, tsMessageBox.Text);

                    // OKボタンクリック
                    tsMessageBox.ClickOk();
                };

                ShowFormMain(DB_FILE_EXIST, TAB_IDX);

                var dgvExpense = CtDgvExpense();
                dgvExpense.Rows[0].Cells[COL.COST].Selected = true;

                TsDgvExpense().FireEvent("KeyDown", (new KeyEventArgs(Keys.Control | Keys.T)));
            }

            /// <summary>
            /// KeyDownテスト
            /// キー: Ctrl + t
            /// 選択範囲の合計表示:金額複数セル
            /// </summary>
            [Test]
            public void KeyDownWithTotalCostMultiCell()
            {
                // ダイアログの表示テスト
                DialogBoxHandler = (name, hWnd) =>
                {
                    var tsMessageBox = new MessageBoxTester(hWnd);

                    // タイトル
                    var title = "合計";
                    Assert.AreEqual(title, tsMessageBox.Title);

                    // テキスト
                    var text = @"\900";
                    Assert.AreEqual(text, tsMessageBox.Text);

                    // OKボタンクリック
                    tsMessageBox.ClickOk();
                };

                ShowFormMain(DB_FILE_EXIST, TAB_IDX);

                var dgvExpense = CtDgvExpense();
                for (int i = 1; i < 4; i++)
                {
                    dgvExpense.Rows[i].Cells[COL.COST].Selected = true;
                }

                TsDgvExpense().FireEvent("KeyDown", (new KeyEventArgs(Keys.Control | Keys.T)));
            }

            /// <summary>
            /// KeyDownテスト
            /// キー: Ctrl + t
            /// 選択範囲の合計表示:金額列以外のセルも含む
            /// </summary>
            [Test]
            public void KeyDownWithTotalCostIncludeOtherCell()
            {
                // ダイアログの表示テスト
                DialogBoxHandler = (name, hWnd) =>
                {
                    var tsMessageBox = new MessageBoxTester(hWnd);

                    // タイトル
                    var title = "合計";
                    Assert.AreEqual(title, tsMessageBox.Title);

                    // テキスト
                    var text = @"\900";
                    Assert.AreEqual(text, tsMessageBox.Text);

                    // OKボタンクリック
                    tsMessageBox.ClickOk();
                };

                ShowFormMain(DB_FILE_EXIST, TAB_IDX);

                var dgvExpense = CtDgvExpense();
                for (int i = 1; i < 4; i++)
                {
                    var row = dgvExpense.Rows[i];
                    row.Cells[COL.DATE].Selected = true;
                    row.Cells[COL.NAME].Selected = true;
                    row.Cells[COL.TYPE].Selected = true;
                    row.Cells[COL.COST].Selected = true;
                }

                TsDgvExpense().FireEvent("KeyDown", (new KeyEventArgs(Keys.Control | Keys.T)));
            }

            /// <summary>
            /// KeyDownテスト
            /// キー: Ctrl + t
            /// 選択範囲の合計表示:金額列に空白を含む
            /// </summary>
            [Test]
            public void KeyDownWithTotalCostIncludeEmptyCost()
            {
                // ダイアログの表示テスト
                DialogBoxHandler = (name, hWnd) =>
                {
                    var tsMessageBox = new MessageBoxTester(hWnd);

                    // タイトル
                    var title = "合計";
                    Assert.AreEqual(title, tsMessageBox.Title);

                    // テキスト
                    var text = @"\600";
                    Assert.AreEqual(text, tsMessageBox.Text);

                    // OKボタンクリック
                    tsMessageBox.ClickOk();
                };

                ShowFormMain(DB_FILE_EXIST, TAB_IDX);

                var dgvExpense = CtDgvExpense();
                for (int i = 1; i < 4; i++)
                {
                    var row = dgvExpense.Rows[i];
                    row.Cells[COL.DATE].Selected = true;
                    row.Cells[COL.NAME].Selected = true;
                    row.Cells[COL.TYPE].Selected = true;
                    row.Cells[COL.COST].Selected = true;

                    if (i == 2)
                    {
                        row.Cells[COL.COST].Value = "";
                    }
                }

                TsDgvExpense().FireEvent("KeyDown", (new KeyEventArgs(Keys.Control | Keys.T)));
            }

            /// <summary>
            /// KeyDownテスト
            /// キー: Ctrl + 8
            /// 消費税(8%):範囲選択なし
            /// </summary>
            [Test]
            public void KeyDownWithTax8NoSelection()
            {
                ShowFormMain(DB_FILE_TAX_TEST, TAB_IDX);

                var dgvExpense = CtDgvExpense();
                dgvExpense.ClearSelection();

                var expecteds = dgvExpense.Rows.Cast<DataGridViewRow>().Select(r => r.Cells[COL.COST].Value).ToList();
                TsDgvExpense().FireEvent("KeyDown", (new KeyEventArgs(Keys.Control | Keys.D8)));

                for (int i = 0; i < dgvExpense.Rows.Count; i++)
                {
                    Assert.AreEqual(expecteds[i], dgvExpense.Rows[i].Cells[COL.COST].Value);
                }
            }

            /// <summary>
            /// KeyDownテスト
            /// キー: Ctrl + 8
            /// 消費税(8%):金額列範囲外
            /// </summary>
            [Test]
            public void KeyDownWithTax8WithoutCostColumn()
            {
                ShowFormMain(DB_FILE_TAX_TEST, TAB_IDX);

                var dgvExpense = CtDgvExpense();
                for (int i = 0; i < dgvExpense.Rows.Count; i++)
                {
                    var row = dgvExpense.Rows[i];
                    row.Cells[COL.DATE].Selected = true;
                    row.Cells[COL.NAME].Selected = true;
                    row.Cells[COL.TYPE].Selected = true;
                }

                var expecteds = dgvExpense.Rows.Cast<DataGridViewRow>().Select(r => r.Cells[COL.COST].Value).ToList();
                TsDgvExpense().FireEvent("KeyDown", (new KeyEventArgs(Keys.Control | Keys.D8)));

                for (int i = 0; i < dgvExpense.Rows.Count; i++)
                {
                    Assert.AreEqual(expecteds[i], dgvExpense.Rows[i].Cells[COL.COST].Value);
                }
            }

            /// <summary>
            /// KeyDownテスト
            /// キー: Ctrl + 8
            /// 消費税(8%):金額単一セル
            /// </summary>
            [Test]
            public void KeyDownWithTax8SingleCell()
            {
                ShowFormMain(DB_FILE_TAX_TEST, TAB_IDX);

                var dgvExpense = CtDgvExpense();
                dgvExpense.Rows[0].Cells[COL.COST].Selected = true;

                TsDgvExpense().FireEvent("KeyDown", (new KeyEventArgs(Keys.Control | Keys.D8)));

                Assert.AreEqual(108, dgvExpense.Rows[0].Cells[COL.COST].Value);
            }

            /// <summary>
            /// KeyDownテスト
            /// キー: Ctrl + 8
            /// 消費税(8%):金額複数セル
            /// </summary>
            [Test]
            public void KeyDownWithTax8MultiCell()
            {
                ShowFormMain(DB_FILE_TAX_TEST, TAB_IDX);

                var dgvExpense = CtDgvExpense();
                for (int i = 0; i < dgvExpense.Rows.Count; i++)
                {
                    dgvExpense.Rows[i].Cells[COL.COST].Selected = true;
                }

                TsDgvExpense().FireEvent("KeyDown", (new KeyEventArgs(Keys.Control | Keys.D8)));

                var expecteds = new decimal[] { 108, 216, 324, 432, 540 };
                for (int i = 0; i < dgvExpense.Rows.Count; i++)
                {
                    var row = dgvExpense.Rows[i];
                    Assert.AreEqual(expecteds[i], row.Cells[COL.COST].Value);
                }
            }

            /// <summary>
            /// KeyDownテスト
            /// キー: Ctrl + 8
            /// 消費税(8%):金額列以外のセルも含む
            /// </summary>
            [Test]
            public void KeyDownWithTax8IncludeOtherCell()
            {
                ShowFormMain(DB_FILE_TAX_TEST, TAB_IDX);

                var dgvExpense = CtDgvExpense();
                for (int i = 0; i < dgvExpense.Rows.Count; i++)
                {
                    var row = dgvExpense.Rows[i];
                    row.Cells[COL.DATE].Selected = true;
                    row.Cells[COL.NAME].Selected = true;
                    row.Cells[COL.TYPE].Selected = true;
                    row.Cells[COL.COST].Selected = true;
                }

                TsDgvExpense().FireEvent("KeyDown", (new KeyEventArgs(Keys.Control | Keys.D8)));

                var expecteds = new decimal[] { 108, 216, 324, 432, 540 };
                for (int i = 0; i < dgvExpense.Rows.Count; i++)
                {
                    var row = dgvExpense.Rows[i];
                    Assert.AreEqual(expecteds[i], row.Cells[COL.COST].Value);
                }
            }

            /// <summary>
            /// KeyDownテスト
            /// キー: Ctrl + 8
            /// 消費税(8%):金額列に空白を含む
            /// </summary>
            [Test]
            public void KeyDownWithTax8IncludeEmptyCost()
            {
                ShowFormMain(DB_FILE_TAX_TEST, TAB_IDX);

                var dgvExpense = CtDgvExpense();
                for (int i = 0; i < dgvExpense.Rows.Count; i++)
                {
                    var row = dgvExpense.Rows[i];
                    row.Cells[COL.DATE].Selected = true;
                    row.Cells[COL.NAME].Selected = true;
                    row.Cells[COL.TYPE].Selected = true;
                    row.Cells[COL.COST].Selected = true;

                    if (i == 2)
                    {
                        row.Cells[COL.COST].Value = "";
                    }
                }

                TsDgvExpense().FireEvent("KeyDown", (new KeyEventArgs(Keys.Control | Keys.D8)));

                var expecteds = new decimal[] { 108, 216, 300, 432, 540 };
                for (int i = 0; i < dgvExpense.Rows.Count; i++)
                {
                    var row = dgvExpense.Rows[i];
                    if (i == 2)
                    {
                        Assert.IsNullOrEmpty(row.Cells[COL.COST].Value as string);
                    }
                    else
                    {
                        Assert.AreEqual(expecteds[i], row.Cells[COL.COST].Value);
                    }
                }
            }

            /// <summary>
            /// KeyDownテスト
            /// キー: Ctrl + 0
            /// 消費税(10%):範囲選択なし
            /// </summary>
            [Test]
            public void KeyDownWithTax10NoSelection()
            {
                ShowFormMain(DB_FILE_TAX_TEST, TAB_IDX);

                var dgvExpense = CtDgvExpense();
                dgvExpense.ClearSelection();

                var expecteds = dgvExpense.Rows.Cast<DataGridViewRow>().Select(r => r.Cells[COL.COST].Value).ToList();
                TsDgvExpense().FireEvent("KeyDown", (new KeyEventArgs(Keys.Control | Keys.D0)));

                for (int i = 0; i < dgvExpense.Rows.Count; i++)
                {
                    Assert.AreEqual(expecteds[i], dgvExpense.Rows[i].Cells[COL.COST].Value);
                }
            }

            /// <summary>
            /// KeyDownテスト
            /// キー: Ctrl + 0
            /// 消費税(10%):金額列範囲外
            /// </summary>
            [Test]
            public void KeyDownWithTax10WithoutCostColumn()
            {
                ShowFormMain(DB_FILE_TAX_TEST, TAB_IDX);

                var dgvExpense = CtDgvExpense();
                for (int i = 0; i < dgvExpense.Rows.Count; i++)
                {
                    var row = dgvExpense.Rows[i];
                    row.Cells[COL.DATE].Selected = true;
                    row.Cells[COL.NAME].Selected = true;
                    row.Cells[COL.TYPE].Selected = true;
                }

                var expecteds = dgvExpense.Rows.Cast<DataGridViewRow>().Select(r => r.Cells[COL.COST].Value).ToList();
                TsDgvExpense().FireEvent("KeyDown", (new KeyEventArgs(Keys.Control | Keys.D0)));

                for (int i = 0; i < dgvExpense.Rows.Count; i++)
                {
                    Assert.AreEqual(expecteds[i], dgvExpense.Rows[i].Cells[COL.COST].Value);
                }
            }

            /// <summary>
            /// KeyDownテスト
            /// キー: Ctrl + 0
            /// 消費税(10%):金額単一セル
            /// </summary>
            [Test]
            public void KeyDownWithTax10SingleCell()
            {
                ShowFormMain(DB_FILE_TAX_TEST, TAB_IDX);

                var dgvExpense = CtDgvExpense();
                dgvExpense.Rows[0].Cells[COL.COST].Selected = true;

                TsDgvExpense().FireEvent("KeyDown", (new KeyEventArgs(Keys.Control | Keys.D0)));

                Assert.AreEqual(110, dgvExpense.Rows[0].Cells[COL.COST].Value);
            }

            /// <summary>
            /// KeyDownテスト
            /// キー: Ctrl + 0
            /// 消費税(10%):金額複数セル
            /// </summary>
            [Test]
            public void KeyDownWithTax10MultiCell()
            {
                ShowFormMain(DB_FILE_TAX_TEST, TAB_IDX);

                var dgvExpense = CtDgvExpense();
                for (int i = 0; i < dgvExpense.Rows.Count; i++)
                {
                    dgvExpense.Rows[i].Cells[COL.COST].Selected = true;
                }

                TsDgvExpense().FireEvent("KeyDown", (new KeyEventArgs(Keys.Control | Keys.D0)));

                var expecteds = new decimal[] { 110, 220, 330, 440, 550 };
                for (int i = 0; i < dgvExpense.Rows.Count; i++)
                {
                    var row = dgvExpense.Rows[i];
                    Assert.AreEqual(expecteds[i], row.Cells[COL.COST].Value);
                }
            }

            /// <summary>
            /// KeyDownテスト
            /// キー: Ctrl + 0
            /// 消費税(10%):金額列以外のセルも含む
            /// </summary>
            [Test]
            public void KeyDownWithTax10IncludeOtherCell()
            {
                ShowFormMain(DB_FILE_TAX_TEST, TAB_IDX);

                var dgvExpense = CtDgvExpense();
                for (int i = 0; i < dgvExpense.Rows.Count; i++)
                {
                    var row = dgvExpense.Rows[i];
                    row.Cells[COL.DATE].Selected = true;
                    row.Cells[COL.NAME].Selected = true;
                    row.Cells[COL.TYPE].Selected = true;
                    row.Cells[COL.COST].Selected = true;
                }

                TsDgvExpense().FireEvent("KeyDown", (new KeyEventArgs(Keys.Control | Keys.D0)));

                var expecteds = new decimal[] { 110, 220, 330, 440, 550 };
                for (int i = 0; i < dgvExpense.Rows.Count; i++)
                {
                    var row = dgvExpense.Rows[i];
                    Assert.AreEqual(expecteds[i], row.Cells[COL.COST].Value);
                }
            }

            /// <summary>
            /// KeyDownテスト
            /// キー: Ctrl + 0
            /// 消費税(10%):金額列に空白を含む
            /// </summary>
            [Test]
            public void KeyDownWithTax10IncludeEmptyCost()
            {
                ShowFormMain(DB_FILE_TAX_TEST, TAB_IDX);

                var dgvExpense = CtDgvExpense();
                for (int i = 0; i < dgvExpense.Rows.Count; i++)
                {
                    var row = dgvExpense.Rows[i];
                    row.Cells[COL.DATE].Selected = true;
                    row.Cells[COL.NAME].Selected = true;
                    row.Cells[COL.TYPE].Selected = true;
                    row.Cells[COL.COST].Selected = true;

                    if (i == 2)
                    {
                        row.Cells[COL.COST].Value = "";
                    }
                }

                TsDgvExpense().FireEvent("KeyDown", (new KeyEventArgs(Keys.Control | Keys.D0)));

                var expecteds = new decimal[] { 110, 220, 330, 440, 550 };
                for (int i = 0; i < dgvExpense.Rows.Count; i++)
                {
                    var row = dgvExpense.Rows[i];
                    if (i == 2)
                    {
                        Assert.IsNullOrEmpty(row.Cells[COL.COST].Value as string);
                    }
                    else
                    {
                        Assert.AreEqual(expecteds[i], row.Cells[COL.COST].Value);
                    }
                }
            }

            /// <summary>
            /// CellEndEditテスト
            /// セル:名称セル
            /// 自動補完:補完候補あり
            /// </summary>
            [Test]
            public void DgvExpenseCellEndEditWithComplemented()
            {
                ShowFormMain(DB_FILE_EXIST, TAB_IDX);

                var dgvExpense = CtDgvExpense();
                var idxRow = dgvExpense.Rows.Count - 1;
                dgvExpense.CurrentCell = dgvExpense.Rows[idxRow].Cells[COL.NAME];
                dgvExpense.CurrentCell.Value = "name01";

                TsDgvExpense().FireEvent("CellEndEdit", (new DataGridViewCellEventArgs(1, idxRow)));

                Assert.AreEqual(TYPE.FOOD, dgvExpense.Rows[idxRow].Cells[COL.TYPE].Value);
            }

            /// <summary>
            /// CellEndEditテスト
            /// セル:名称セル
            /// 自動補完:補完候補なし
            /// </summary>
            [Test]
            public void DgvExpenseCellEndEditWithNotComplemented()
            {
                ShowFormMain(DB_FILE_EXIST, TAB_IDX);

                var dgvExpense = CtDgvExpense();
                var idxRow = dgvExpense.Rows.Count - 1;
                dgvExpense.CurrentCell = dgvExpense.Rows[idxRow].Cells[COL.NAME];
                dgvExpense.CurrentCell.Value = "nameXX";

                TsDgvExpense().FireEvent("CellEndEdit", (new DataGridViewCellEventArgs(1, idxRow)));

                Assert.AreEqual(string.Empty, dgvExpense.Rows[idxRow].Cells[COL.TYPE].Value);
            }

            /// <summary>
            /// CellEndEditテスト
            /// セル:金額セル
            /// 金額:空白
            /// </summary>
            [Test]
            public void DgvExpenseCellEndEditWithCostEmpty()
            {
                ShowFormMain(DB_FILE_EXIST, TAB_IDX);

                var dgvExpense = CtDgvExpense();
                var idxRow = dgvExpense.Rows.Count - 1;
                dgvExpense.CurrentCell = dgvExpense.Rows[idxRow].Cells[COL.COST];
                dgvExpense.CurrentCell.Value = "";

                TsDgvExpense().FireEvent("CellEndEdit", (new DataGridViewCellEventArgs(3, idxRow)));

                Assert.AreEqual(string.Empty, dgvExpense.Rows[idxRow].Cells[COL.COST].Value);
            }

            /// <summary>
            /// CellEndEditテスト
            /// セル:金額セル
            /// 金額:1000未満
            /// </summary>
            [Test]
            public void DgvExpenseCellEndEditWithCostUnder1000()
            {
                ShowFormMain(DB_FILE_EXIST, TAB_IDX);

                var dgvExpense = CtDgvExpense();
                var idxRow = dgvExpense.Rows.Count - 1;
                dgvExpense.CurrentCell = dgvExpense.Rows[idxRow].Cells[COL.COST];
                dgvExpense.CurrentCell.Value = "999";

                TsDgvExpense().FireEvent("CellEndEdit", (new DataGridViewCellEventArgs(3, idxRow)));

                Assert.AreEqual("999", dgvExpense.Rows[idxRow].Cells[COL.COST].Value);
            }

            /// <summary>
            /// CellEndEditテスト
            /// セル:金額セル
            /// 金額:カンマ編集あり(1箇所)
            /// </summary>
            [Test]
            public void DgvExpenseCellEndEditWithCostIs1000()
            {
                ShowFormMain(DB_FILE_EXIST, TAB_IDX);

                var dgvExpense = CtDgvExpense();
                var idxRow = dgvExpense.Rows.Count - 1;
                dgvExpense.CurrentCell = dgvExpense.Rows[idxRow].Cells[COL.COST];
                dgvExpense.CurrentCell.Value = "1000";

                TsDgvExpense().FireEvent("CellEndEdit", (new DataGridViewCellEventArgs(3, idxRow)));

                Assert.AreEqual("1,000", dgvExpense.Rows[idxRow].Cells[COL.COST].Value);
            }

            /// <summary>
            /// CellEndEditテスト
            /// セル:金額セル
            /// 金額:カンマ編集あり(2箇所)
            /// </summary>
            [Test]
            public void DgvExpenseCellEndEditWithCostIs1000000()
            {
                ShowFormMain(DB_FILE_EXIST, TAB_IDX);

                var dgvExpense = CtDgvExpense();
                var idxRow = dgvExpense.Rows.Count - 1;
                dgvExpense.CurrentCell = dgvExpense.Rows[idxRow].Cells[COL.COST];
                dgvExpense.CurrentCell.Value = "1000000";

                TsDgvExpense().FireEvent("CellEndEdit", (new DataGridViewCellEventArgs(3, idxRow)));

                Assert.AreEqual("1,000,000", dgvExpense.Rows[idxRow].Cells[COL.COST].Value);
            }

            /// <summary>
            /// CellEndEditテスト
            /// セル:金額セル
            /// 金額:カンマ編集あり(3箇所)
            /// </summary>
            [Test]
            public void DgvExpenseCellEndEditWithCostIs1000000000()
            {
                ShowFormMain(DB_FILE_EXIST, TAB_IDX);

                var dgvExpense = CtDgvExpense();
                var idxRow = dgvExpense.Rows.Count - 1;
                dgvExpense.CurrentCell = dgvExpense.Rows[idxRow].Cells[COL.COST];
                dgvExpense.CurrentCell.Value = "1000000000";

                TsDgvExpense().FireEvent("CellEndEdit", (new DataGridViewCellEventArgs(3, idxRow)));

                Assert.AreEqual("1,000,000,000", dgvExpense.Rows[idxRow].Cells[COL.COST].Value);
            }

            /// <summary>
            /// CellEndEditテスト
            /// セル:金額セル
            /// 金額:オーバーフロー
            /// </summary>
            [Test]
            public void DgvExpenseCellEndEditWithCostIsOverflow()
            {
                ShowFormMain(DB_FILE_EXIST, TAB_IDX);

                var dgvExpense = CtDgvExpense();
                var idxRow = dgvExpense.Rows.Count - 1;
                dgvExpense.CurrentCell = dgvExpense.Rows[idxRow].Cells[COL.COST];
                dgvExpense.CurrentCell.Value = "99999999999999999999999999999";

                TsDgvExpense().FireEvent("CellEndEdit", (new DataGridViewCellEventArgs(3, idxRow)));

                Assert.AreEqual("", dgvExpense.Rows[idxRow].Cells[COL.COST].Value);
            }

            /// <summary>
            /// CellEndEditテスト
            /// セル:金額セル
            /// 金額:数値でない
            /// </summary>
            [Test]
            public void DgvExpenseCellEndEditWithCostIsNotNumber()
            {
                ShowFormMain(DB_FILE_EXIST, TAB_IDX);

                var dgvExpense = CtDgvExpense();
                var idxRow = dgvExpense.Rows.Count - 1;
                dgvExpense.CurrentCell = dgvExpense.Rows[idxRow].Cells[COL.COST];
                dgvExpense.CurrentCell.Value = "not number char";

                TsDgvExpense().FireEvent("CellEndEdit", (new DataGridViewCellEventArgs(3, idxRow)));

                Assert.AreEqual("", dgvExpense.Rows[idxRow].Cells[COL.COST].Value);
            }

            /// <summary>
            /// CellEndEditテスト
            /// セル:名称・金額セル以外(日付セル)
            /// </summary>
            [Test]
            public void DgvExpenseCellEndEditWithNotNameCell()
            {
                ShowFormMain(DB_FILE_EXIST, TAB_IDX);

                var dgvExpense = CtDgvExpense();
                var idxRow = dgvExpense.Rows.Count - 1;
                dgvExpense.CurrentCell = dgvExpense.Rows[idxRow].Cells[COL.NAME];
                dgvExpense.CurrentCell.Value = "2013-01-01";

                TsDgvExpense().FireEvent("CellEndEdit", (new DataGridViewCellEventArgs(0, idxRow)));

                Assert.AreEqual(string.Empty, dgvExpense.Rows[idxRow].Cells[COL.TYPE].Value);
            }

            /// <summary>
            /// CellEndEditテスト
            /// セル:名称セル
            /// 自動補完:補完候補あり
            /// </summary>
            [Test]
            public void DgvExpenseCellEndEditWithCostComplementedOfNameCell()
            {
                ShowFormMain(DB_FILE_EXIST, TAB_IDX);

                var dgvExpense = CtDgvExpense();
                var idxRow = dgvExpense.Rows.Count - 1;
                dgvExpense.CurrentCell = dgvExpense.Rows[idxRow].Cells[COL.NAME];
                dgvExpense.CurrentCell.Value = "name10";

                TsDgvExpense().FireEvent("CellEndEdit", (new DataGridViewCellEventArgs(0, idxRow)));

                Assert.AreEqual(TYPE.FOOD, dgvExpense.Rows[idxRow].Cells[COL.TYPE].Value);
                Assert.AreEqual("1,000", dgvExpense.Rows[idxRow].Cells[COL.COST].Value);
            }

            /// <summary>
            /// CellEndEditテスト
            /// セル:名称セル
            /// 自動補完:補完候補なし
            /// </summary>
            [Test]
            public void DgvExpenseCellEndEditWithCostNotComplementedOfNameCell()
            {
                ShowFormMain(DB_FILE_EXIST, TAB_IDX);

                var dgvExpense = CtDgvExpense();
                var idxRow = dgvExpense.Rows.Count - 1;
                dgvExpense.CurrentCell = dgvExpense.Rows[idxRow].Cells[COL.NAME];
                dgvExpense.CurrentCell.Value = "not match";

                TsDgvExpense().FireEvent("CellEndEdit", (new DataGridViewCellEventArgs(0, idxRow)));

                Assert.AreEqual(string.Empty, dgvExpense.Rows[idxRow].Cells[COL.TYPE].Value);
                Assert.AreEqual(string.Empty, dgvExpense.Rows[idxRow].Cells[COL.COST].Value);
            }

            /// <summary>
            /// CellEndEditテスト
            /// セル:種別セル
            /// 自動補完:補完候補あり
            /// </summary>
            [Test]
            public void DgvExpenseCellEndEditWithCostComplementedOfTypeCell()
            {
                ShowFormMain(DB_FILE_EXIST, TAB_IDX);

                var dgvExpense = CtDgvExpense();
                var idxRow = dgvExpense.Rows.Count - 1;
                dgvExpense.CurrentCell = dgvExpense.Rows[idxRow].Cells[COL.TYPE];
                dgvExpense.CurrentCell.Value = TYPE.FOOD;
                Assert.AreEqual(2000, dgvExpense.Rows[idxRow].Cells[COL.COST].Value);

                TsDgvExpense().FireEvent("CellEndEdit", (new DataGridViewCellEventArgs(0, idxRow)));

                Assert.AreEqual("1,000", dgvExpense.Rows[idxRow].Cells[COL.COST].Value);
            }

            /// <summary>
            /// CellEndEditテスト
            /// セル:種別セル
            /// 自動補完:補完候補あり
            /// </summary>
            [Test]
            public void DgvExpenseCellEndEditWithCostNotComplementedOfTypeCell()
            {
                ShowFormMain(DB_FILE_EXIST, TAB_IDX);

                var dgvExpense = CtDgvExpense();
                var idxRow = dgvExpense.Rows.Count - 1;
                dgvExpense.CurrentCell = dgvExpense.Rows[idxRow].Cells[COL.TYPE];
                dgvExpense.CurrentCell.Value = "not match";
                Assert.AreEqual(2000, dgvExpense.Rows[idxRow].Cells[COL.COST].Value);

                TsDgvExpense().FireEvent("CellEndEdit", (new DataGridViewCellEventArgs(0, idxRow)));

                Assert.AreEqual(string.Empty, dgvExpense.Rows[idxRow].Cells[COL.COST].Value);
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
                // ダイアログの表示テスト
                DialogBoxHandler = (name, hWnd) =>
                {
                    var tsMessageBox = new MessageBoxTester(hWnd);

                    // タイトル
                    var title = "登録完了";
                    Assert.AreEqual(title, tsMessageBox.Title);

                    // テキスト
                    var text = "正常に登録しました。";
                    Assert.AreEqual(text, tsMessageBox.Text);

                    // OKボタンクリック
                    tsMessageBox.ClickOk();
                };

                ShowFormMain(DB_FILE_EXIST, TAB_IDX);

                TsBtnEntry().Click();

                NUnit.Framework.FileAssert.AreEqual(DB_FILE_ENTRY, DB_FILE_EXIST);
            }

            /// <summary>
            /// 登録ボタンクリック
            /// 入力行0件のエラー
            /// </summary>
            [Test]
            public void ErrorWithRowCountZero()
            {
                // ダイアログの表示テスト
                DialogBoxHandler = (name, hWnd) =>
                {
                    var tsMessageBox = new MessageBoxTester(hWnd);

                    // タイトル
                    var title = "警告";
                    Assert.AreEqual(title, tsMessageBox.Title);

                    // テキスト
                    var text = "レコードが1件もありません。";
                    Assert.AreEqual(text, tsMessageBox.Text);

                    // OKボタンクリック
                    tsMessageBox.ClickOk();
                };

                ShowFormMain(DB_FILE_EXIST, TAB_IDX);

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
                // ダイアログの表示テスト
                DialogBoxHandler = (name, hWnd) =>
                {
                    var tsMessageBox = new MessageBoxTester(hWnd);

                    // タイトル
                    var title = "登録完了";
                    Assert.AreEqual(title, tsMessageBox.Title);

                    // テキスト
                    var text = "正常に登録しました。";
                    Assert.AreEqual(text, tsMessageBox.Text);

                    // OKボタンクリック
                    tsMessageBox.ClickOk();
                };

                ShowFormMain(DB_FILE_EXIST, TAB_IDX);

                TsBtnAddRow().Click();

                var dgvExpense = CtDgvExpense();
                var idxRow = dgvExpense.Rows.Count - 1;
                for (int i = 0; i < DGV.NEW_ROW_SIZE; i++)
                {
                    var row = dgvExpense.Rows[idxRow--];
                    row.Cells[COL.DATE].Value = string.Empty;
                }

                TsBtnEntry().Click();

                NUnit.Framework.FileAssert.AreEqual(DB_FILE_ENTRY, DB_FILE_EXIST);
            }

            /// <summary>
            /// 登録ボタンクリック
            /// 日付の形式が不正
            /// </summary>
            [Test]
            public void WithInvalidDate()
            {
                // ダイアログの表示テスト
                DialogBoxHandler = (name, hWnd) =>
                {
                    var tsMessageBox = new MessageBoxTester(hWnd);

                    // タイトル
                    var title = "エラー";
                    Assert.AreEqual(title, tsMessageBox.Title);

                    // テキスト
                    var text = string.Format(EX.DB_FILE_LOAD, 2, EX.DATE_FORMAT);
                    Assert.AreEqual(text, tsMessageBox.Text);

                    // OKボタンクリック
                    tsMessageBox.ClickOk();

                    // エラー行が選択される
                    Assert.AreEqual(1, CtDgvExpense().SelectedRows[0].Index);
                };

                ShowFormMain(DB_FILE_EXIST, TAB_IDX);

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
                // ダイアログの表示テスト
                DialogBoxHandler = (name, hWnd) =>
                {
                    var tsMessageBox = new MessageBoxTester(hWnd);

                    // タイトル
                    var title = "エラー";
                    Assert.AreEqual(title, tsMessageBox.Title);

                    // テキスト
                    var text = string.Format(EX.DB_FILE_LOAD, 5, EX.COST_FORMAT);
                    Assert.AreEqual(text, tsMessageBox.Text);

                    // OKボタンクリック
                    tsMessageBox.ClickOk();

                    // エラー行が選択される
                    Assert.AreEqual(4, CtDgvExpense().SelectedRows[0].Index);
                };

                ShowFormMain(DB_FILE_EXIST, TAB_IDX);

                CtDgvExpense().Rows[4].Cells[COL.COST].Value = "XXXXXXXX";

                TsBtnEntry().Click();
            }

            /// <summary>
            /// 登録ボタンクリック
            /// 備考入力のテスト
            /// </summary>
            [Test]
            public void WithNoteInput()
            {
                // ダイアログの表示テスト
                DialogBoxHandler = (name, hWnd) =>
                {
                    var tsMessageBox = new MessageBoxTester(hWnd);

                    // タイトル
                    var title = "登録完了";
                    Assert.AreEqual(title, tsMessageBox.Title);

                    // テキスト
                    var text = "正常に登録しました。";
                    Assert.AreEqual(text, tsMessageBox.Text);

                    // OKボタンクリック
                    tsMessageBox.ClickOk();
                };

                ShowFormMain(DB_FILE_NOTE_TEST, TAB_IDX);

                TsBtnAddRow().Click();

                var dgvExpense = CtDgvExpense();
                var row = dgvExpense.Rows[dgvExpense.Rows.Count - 1];
                row.Cells[COL.DATE].Value = "2024-03-01";
                row.Cells[COL.NAME].Value = "おにぎり";
                row.Cells[COL.TYPE].Value = "食費";
                row.Cells[COL.COST].Value = "150";
                row.Cells[COL.NOTE].Value = "シャケ";

                TsBtnEntry().Click();

                NUnit.Framework.FileAssert.AreEqual(DB_FILE_NOTE_ENTRY, DB_FILE_NOTE_TEST);
            }
        }
    }
}
