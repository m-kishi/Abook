// ------------------------------------------------------------
// © 2010 https://github.com/m-kishi
// ------------------------------------------------------------
namespace AbookTest
{
    using Abook;
    using System;
    using NUnit.Framework;
    using EX  = Abook.AbException.EX;
    using FMT = Abook.AbConstants.FMT;

    /// <summary>
    /// 支出情報テスト
    /// </summary>
    [TestFixture]
    public class AbTestExpense
    {
        /// <summary>引数:日付</summary>
        private string argDate;
        /// <summary>引数:名称</summary>
        private string argName;
        /// <summary>引数:種別</summary>
        private string argType;
        /// <summary>引数:金額</summary>
        private string argCost;
        /// <summary>引数:備考</summary>
        private string argNote;
        /// <summary>対象:支出情報(旧バージョン)</summary>
        private AbExpense abExpenseOld;
        /// <summary>対象:支出情報(新バージョン)</summary>
        private AbExpense abExpenseCur;

        /// <summary>
        /// SetUp
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            argDate = "2011-03-01";
            argName = "おにぎり";
            argType = "食費";
            argCost = "105";
            argNote = "備考";
            abExpenseOld = new AbExpense(argDate, argName, argType, argCost);
            abExpenseCur = new AbExpense(argDate, argName, argType, argCost, argNote);
        }

        /// <summary>
        /// コンストラクタ
        /// 引数:日付のテスト
        /// </summary>
        [Test]
        public void AbExpenseWithDate()
        {
            var expected = DateTime.Parse(argDate);
            Assert.AreEqual(expected, abExpenseOld.Date);
            Assert.AreEqual(expected, abExpenseCur.Date);
        }

        /// <summary>
        /// コンストラクタ
        /// 引数:名称のテスト
        /// </summary>
        [Test]
        public void AbExpenseWithName()
        {
            var expected = argName;
            Assert.AreEqual(expected, abExpenseOld.Name);
            Assert.AreEqual(expected, abExpenseCur.Name);
        }

        /// <summary>
        /// コンストラクタ
        /// 引数:種別のテスト
        /// </summary>
        [Test]
        public void AbExpenseWithType()
        {
            var expected = argType;
            Assert.AreEqual(expected, abExpenseOld.Type);
            Assert.AreEqual(expected, abExpenseCur.Type);
        }

        /// <summary>
        /// コンストラクタ
        /// 引数:金額のテスト
        /// </summary>
        [Test]
        public void AbExpenseWithCost()
        {
            var expected = decimal.Parse(argCost);
            Assert.AreEqual(expected, abExpenseOld.Cost);
            Assert.AreEqual(expected, abExpenseCur.Cost);
        }

        /// <summary>
        /// コンストラクタ
        /// 引数:備考のテスト
        /// </summary>
        [Test]
        public void AbExpenseWithNote()
        {
            var expected = argNote;
            Assert.AreEqual(""      , abExpenseOld.Note);
            Assert.AreEqual(expected, abExpenseCur.Note);
        }

        /// <summary>
        /// コンストラクタ(旧)
        /// 引数:日付がNULL
        /// </summary>
        [Test]
        public void AbExpenseWithNullDateOld()
        {
            argDate = null;
            var ex = Assert.Throws<AbException>(() =>
                new AbExpense(argDate, argName, argType, argCost)
            );
            Assert.AreEqual(EX.DATE_NULL, ex.Message);
        }

        /// <summary>
        /// コンストラクタ(新)
        /// 引数:日付がNULL
        /// </summary>
        [Test]
        public void AbExpenseWithNullDateCur()
        {
            argDate = null;
            var ex = Assert.Throws<AbException>(() =>
                new AbExpense(argDate, argName, argType, argCost, argNote)
            );
            Assert.AreEqual(EX.DATE_NULL, ex.Message);
        }

        /// <summary>
        /// コンストラクタ(旧)
        /// 引数:日付が空文字列
        /// </summary>
        [Test]
        public void AbExpenseWithEmptyDateOld()
        {
            argDate = string.Empty;
            var ex = Assert.Throws<AbException>(() =>
                new AbExpense(argDate, argName, argType, argCost)
            );
            Assert.AreEqual(EX.DATE_NULL, ex.Message);
        }

        /// <summary>
        /// コンストラクタ(新)
        /// 引数:日付が空文字列
        /// </summary>
        [Test]
        public void AbExpenseWithEmptyDateCur()
        {
            argDate = string.Empty;
            var ex = Assert.Throws<AbException>(() =>
                new AbExpense(argDate, argName, argType, argCost, argNote)
            );
            Assert.AreEqual(EX.DATE_NULL, ex.Message);
        }

        /// <summary>
        /// コンストラクタ(旧)
        /// 引数:日付の形式が不正
        /// </summary>
        [Test]
        public void AbExpenseWithInvalidDateOld()
        {
            argDate = "invalid";
            var ex = Assert.Throws<AbException>(() =>
                new AbExpense(argDate, argName, argType, argCost)
            );
            Assert.AreEqual(EX.DATE_FORMAT, ex.Message);
        }

        /// <summary>
        /// コンストラクタ(新)
        /// 引数:日付の形式が不正
        /// </summary>
        [Test]
        public void AbExpenseWithInvalidDateCur()
        {
            argDate = "invalid";
            var ex = Assert.Throws<AbException>(() =>
                new AbExpense(argDate, argName, argType, argCost, argNote)
            );
            Assert.AreEqual(EX.DATE_FORMAT, ex.Message);
        }

        /// <summary>
        /// コンストラクタ(旧)
        /// 引数:名称がNULL
        /// </summary>
        [Test]
        public void AbExpenseWithNullNameOld()
        {
            argName = null;
            var ex = Assert.Throws<AbException>(() =>
                new AbExpense(argDate, argName, argType, argCost)
            );
            Assert.AreEqual(EX.NAME_NULL, ex.Message);
        }

        /// <summary>
        /// コンストラクタ(新)
        /// 引数:名称がNULL
        /// </summary>
        [Test]
        public void AbExpenseWithNullNameCur()
        {
            argName = null;
            var ex = Assert.Throws<AbException>(() =>
                new AbExpense(argDate, argName, argType, argCost, argNote)
            );
            Assert.AreEqual(EX.NAME_NULL, ex.Message);
        }

        /// <summary>
        /// コンストラクタ(旧)
        /// 引数:名称が空文字列
        /// </summary>
        [Test]
        public void AbExpenseWithEmptyNameOld()
        {
            argName = string.Empty;
            var ex = Assert.Throws<AbException>(() =>
                new AbExpense(argDate, argName, argType, argCost)
            );
            Assert.AreEqual(EX.NAME_NULL, ex.Message);
        }

        /// <summary>
        /// コンストラクタ(新)
        /// 引数:名称が空文字列
        /// </summary>
        [Test]
        public void AbExpenseWithEmptyNameCur()
        {
            argName = string.Empty;
            var ex = Assert.Throws<AbException>(() =>
                new AbExpense(argDate, argName, argType, argCost, argNote)
            );
            Assert.AreEqual(EX.NAME_NULL, ex.Message);
        }

        /// <summary>
        /// コンストラクタ(旧)
        /// 引数:種別がNULL
        /// </summary>
        [Test]
        public void AbExpenseWithNullTypeOld()
        {
            argType = null;
            var ex = Assert.Throws<AbException>(() =>
                new AbExpense(argDate, argName, argType, argCost)
            );
            Assert.AreEqual(EX.TYPE_NULL, ex.Message);
        }

        /// <summary>
        /// コンストラクタ(新)
        /// 引数:種別がNULL
        /// </summary>
        [Test]
        public void AbExpenseWithNullTypeCur()
        {
            argType = null;
            var ex = Assert.Throws<AbException>(() =>
                new AbExpense(argDate, argName, argType, argCost, argNote)
            );
            Assert.AreEqual(EX.TYPE_NULL, ex.Message);
        }

        /// <summary>
        /// コンストラクタ(旧)
        /// 引数:種別が空文字列
        /// </summary>
        [Test]
        public void AbExpenseWithEmptyTypeOld()
        {
            argType = string.Empty;
            var ex = Assert.Throws<AbException>(() =>
                new AbExpense(argDate, argName, argType, argCost)
            );
            Assert.AreEqual(EX.TYPE_NULL, ex.Message);
        }

        /// <summary>
        /// コンストラクタ(新)
        /// 引数:種別が空文字列
        /// </summary>
        [Test]
        public void AbExpenseWithEmptyTypeCur()
        {
            argType = string.Empty;
            var ex = Assert.Throws<AbException>(() =>
                new AbExpense(argDate, argName, argType, argCost, argNote)
            );
            Assert.AreEqual(EX.TYPE_NULL, ex.Message);
        }

        /// <summary>
        /// コンストラクタ(旧)
        /// 引数:種別が不正
        /// </summary>
        [Test]
        public void AbExpenseWithWrongTypeOld()
        {
            argType = "wrong";
            var ex = Assert.Throws<AbException>(() =>
                new AbExpense(argDate, argName, argType, argCost)
            );
            Assert.AreEqual(EX.TYPE_WRONG, ex.Message);
        }

        /// <summary>
        /// コンストラクタ(新)
        /// 引数:種別が不正
        /// </summary>
        [Test]
        public void AbExpenseWithWrongTypeCur()
        {
            argType = "wrong";
            var ex = Assert.Throws<AbException>(() =>
                new AbExpense(argDate, argName, argType, argCost, argNote)
            );
            Assert.AreEqual(EX.TYPE_WRONG, ex.Message);
        }

        /// <summary>
        /// コンストラクタ(旧)
        /// 引数:金額がNULL
        /// </summary>
        [Test]
        public void AbExpenseWithNullCostOld()
        {
            argCost = null;
            var ex = Assert.Throws<AbException>(() =>
                new AbExpense(argDate, argName, argType, argCost)
            );
            Assert.AreEqual(EX.COST_NULL, ex.Message);
        }

        /// <summary>
        /// コンストラクタ(新)
        /// 引数:金額がNULL
        /// </summary>
        [Test]
        public void AbExpenseWithNullCostCur()
        {
            argCost = null;
            var ex = Assert.Throws<AbException>(() =>
                new AbExpense(argDate, argName, argType, argCost, argNote)
            );
            Assert.AreEqual(EX.COST_NULL, ex.Message);
        }

        /// <summary>
        /// コンストラクタ(旧)
        /// 引数:金額が空文字列
        /// </summary>
        [Test]
        public void AbExpenseWithEmptyCostOld()
        {
            argCost = string.Empty;
            var ex = Assert.Throws<AbException>(() =>
                new AbExpense(argDate, argName, argType, argCost)
            );
            Assert.AreEqual(EX.COST_NULL, ex.Message);
        }

        /// <summary>
        /// コンストラクタ(新)
        /// 引数:金額が空文字列
        /// </summary>
        [Test]
        public void AbExpenseWithEmptyCostCur()
        {
            argCost = string.Empty;
            var ex = Assert.Throws<AbException>(() =>
                new AbExpense(argDate, argName, argType, argCost, argNote)
            );
            Assert.AreEqual(EX.COST_NULL, ex.Message);
        }

        /// <summary>
        /// コンストラクタ(旧)
        /// 引数:金額の形式が不正
        /// </summary>
        [Test]
        public void AbExpenseWithInvalidCostOld()
        {
            argCost = "invalid";
            var ex = Assert.Throws<AbException>(() =>
                new AbExpense(argDate, argName, argType, argCost)
            );
            Assert.AreEqual(EX.COST_FORMAT, ex.Message);
        }

        /// <summary>
        /// コンストラクタ(新)
        /// 引数:金額の形式が不正
        /// </summary>
        [Test]
        public void AbExpenseWithInvalidCostCur()
        {
            argCost = "invalid";
            var ex = Assert.Throws<AbException>(() =>
                new AbExpense(argDate, argName, argType, argCost, argNote)
            );
            Assert.AreEqual(EX.COST_FORMAT, ex.Message);
        }

        /// <summary>
        /// コンストラクタ(旧)
        /// 引数:金額がマイナス
        /// </summary>
        [Test]
        public void AbExpenseWithMinusCostOld()
        {
            argCost = "-100";
            var ex = Assert.Throws<AbException>(() =>
                new AbExpense(argDate, argName, argType, argCost)
            );
            Assert.AreEqual(EX.COST_MINUS, ex.Message);
        }

        /// <summary>
        /// コンストラクタ(新)
        /// 引数:金額がマイナス
        /// </summary>
        [Test]
        public void AbExpenseWithMinusCostCur()
        {
            argCost = "-100";
            var ex = Assert.Throws<AbException>(() =>
                new AbExpense(argDate, argName, argType, argCost, argNote)
            );
            Assert.AreEqual(EX.COST_MINUS, ex.Message);
        }

        /// <summary>
        /// コンストラクタ(旧)
        /// 引数:金額がオーバーフロー
        /// </summary>
        [Test]
        public void AbExpenseWithOverflowCostOld()
        {
            argCost = Convert.ToString(decimal.MaxValue) + "0";
            var ex = Assert.Throws<AbException>(() =>
                new AbExpense(argDate, argName, argType, argCost)
            );
            Assert.AreEqual(EX.COST_OVERFLOW, ex.Message);
        }

        /// <summary>
        /// コンストラクタ(新)
        /// 引数:金額がオーバーフロー
        /// </summary>
        [Test]
        public void AbExpenseWithOverflowCostCur()
        {
            argCost = Convert.ToString(decimal.MaxValue) + "0";
            var ex = Assert.Throws<AbException>(() =>
                new AbExpense(argDate, argName, argType, argCost, argNote)
            );
            Assert.AreEqual(EX.COST_OVERFLOW, ex.Message);
        }

        /// <summary>
        /// コンストラクタ(新)
        /// 引数:備考がNULL
        /// </summary>
        [Test]
        public void AbExpenseWithNullNoteCur()
        {
            argNote = null;
            var ex = Assert.Throws<AbException>(() =>
                new AbExpense(argDate, argName, argType, argCost, argNote)
            );
            Assert.AreEqual(EX.NOTE_NULL, ex.Message);
        }

        /// <summary>
        /// コンストラクタ(新)
        /// 引数:備考が空文字列
        /// </summary>
        [Test]
        public void AbExpenseWithEmptyNoteCur()
        {
            argNote = string.Empty;
            Assert.DoesNotThrow(() =>
                new AbExpense(argDate, argName, argType, argCost, argNote)
            );
        }

        /// <summary>
        /// CSV形式
        /// </summary>
        [Test]
        public void OldToCSV()
        {
            var expected = string.Format(FMT.CSV, argDate, argName, argType, argCost, "");
            Assert.AreEqual(expected, abExpenseOld.ToCSV());
        }

        /// <summary>
        /// CSV形式
        /// </summary>
        [Test]
        public void CurToCSV()
        {
            var expected = string.Format(FMT.CSV, argDate, argName, argType, argCost, argNote);
            Assert.AreEqual(expected, abExpenseCur.ToCSV());
        }
    }
}
