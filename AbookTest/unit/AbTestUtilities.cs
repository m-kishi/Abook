﻿// ------------------------------------------------------------
// © 2010 https://github.com/m-kishi
// ------------------------------------------------------------
namespace AbookTest
{
    using Abook;
    using System.Collections.Generic;
    using System.IO;
    using NUnit.Framework;
    using EX   = Abook.AbException.EX;
    using CHK  = Abook.AbUtilities.CHK;
    using TYPE = Abook.AbConstants.TYPE;

    /// <summary>
    /// ユーティリティテスト
    /// </summary>
    [TestFixture]
    public class AbTestUtilities
    {
        /// <summary>
        /// 円通貨形式変換
        /// </summary>
        /// <param name="cost">金額</param>
        /// <param name="expected">期待値</param>
        [TestCase(       0,          "\u00a50")]
        [TestCase( 9999999,  "\u00a59,999,999")]
        [TestCase(-9999999, "-\u00a59,999,999")]
        public void ToYen(decimal cost, string expected)
        {
            // \u00a5は円の通貨記号
            var actual = AbUtilities.ToYen(cost);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 金額変換
        /// </summary>
        /// <param name="cost">金額</param>
        /// <param name="expected">期待値</param>
        [TestCase(         null,        0)]
        [TestCase(          "0",        0)]
        [TestCase(        "100",      100)]
        [TestCase(       "-100",     -100)]
        [TestCase(  "9,999,999",  9999999)]
        [TestCase( "-9,999,999", -9999999)]
        [TestCase(            0,        0)]
        [TestCase(          100,      100)]
        [TestCase(         -100,     -100)]
        [TestCase(      9999999,  9999999)]
        [TestCase(     -9999999, -9999999)]
        [TestCase("not decimal",        0)]
        public void ToCost(object cost, decimal expected)
        {
            var actual = AbUtilities.ToCost(cost);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 金額のカンマ編集
        /// </summary>
        /// <param name="cost">金額</param>
        /// <param name="expected">期待値</param>
        [TestCase(         0,             "0")]
        [TestCase(       999,           "999")]
        [TestCase(      1000,         "1,000")]
        [TestCase(      9999,         "9,999")]
        [TestCase(     10000,        "10,000")]
        [TestCase(   1000000,     "1,000,000")]
        [TestCase(1000000000, "1,000,000,000")]
        [TestCase("", "")]
        [TestCase(null, "")]
        [TestCase("not number char", "")]
        [TestCase("99999999999999999999999999999", "")]
        public void ToComma(object cost, string expected)
        {
            var actual = AbUtilities.ToComma(cost);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 金額判定
        /// </summary>
        /// <param name="cost">金額</param>
        /// <param name="expected">期待値</param>
        [TestCase(         null, false)]
        [TestCase(          "0",  true)]
        [TestCase(        "100",  true)]
        [TestCase(       "-100",  true)]
        [TestCase(  "9,999,999",  true)]
        [TestCase( "-9,999,999",  true)]
        [TestCase(            0,  true)]
        [TestCase(          100,  true)]
        [TestCase(         -100,  true)]
        [TestCase(      9999999,  true)]
        [TestCase(     -9999999,  true)]
        [TestCase("not decimal", false)]
        public void IsCost(object cost, bool expected)
        {
            var actual = AbUtilities.IsCost(cost);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 消費税計算(8%)
        /// </summary>
        /// <param name="cost">金額</param>
        /// <param name="expected">期待値</param>
        [TestCase(         null,   0)]
        [TestCase(           78,  84)]
        [TestCase(           98, 106)]
        [TestCase(          100, 108)]
        [TestCase("not decimal",   0)]
        public void Tax8(object cost, decimal expected)
        {
            var actual = AbUtilities.Tax8(cost);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 消費税計算(10%)
        /// </summary>
        /// <param name="cost">金額</param>
        /// <param name="expected">期待値</param>
        [TestCase(         null,   0)]
        [TestCase(           64,  70)]
        [TestCase(           98, 108)]
        [TestCase(          100, 110)]
        [TestCase("not decimal",   0)]
        public void Tax10(object cost, decimal expected)
        {
            var actual = AbUtilities.Tax10(cost);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// チェックユーティリティテスト
        /// </summary>
        [TestFixture]
        public class ChkTest
        {
            /// <summary>DBファイル</summary>
            private const string DB_FILE = "AbookTest.db";

            /// <summary>
            /// TestFixtureSetUp
            /// </summary>
            [TestFixtureSetUp]
            public void TestFixtureSetUp()
            {
                if (!File.Exists(DB_FILE)) File.Create(DB_FILE).Close();
            }

            /// <summary>
            /// TestFixtureTearDown
            /// </summary>
            [TestFixtureTearDown]
            public void TestFixtureTearDown()
            {
                if (File.Exists(DB_FILE)) File.Delete(DB_FILE);
            }

            /// <summary>
            /// NULLチェック(日付)
            /// </summary>
            [Test]
            public void DateNull()
            {
                var argDate = "2015-01-01";
                Assert.DoesNotThrow(() => CHK.DateNull(argDate));
            }

            /// <summary>
            /// NULLチェック(日付)
            /// 引数:日付がNULL
            /// </summary>
            [Test]
            public void DateNullWithNullDate()
            {
                string argDate = null;
                var ex = Assert.Throws<AbException>(() =>
                    CHK.DateNull(argDate)
                );
                Assert.AreEqual(EX.DATE_NULL, ex.Message);
            }

            /// <summary>
            /// NULLチェック(日付)
            /// 引数:日付が空文字列
            /// </summary>
            [Test]
            public void DateNullWithEmptyDate()
            {
                var argDate = string.Empty;
                var ex = Assert.Throws<AbException>(() =>
                    CHK.DateNull(argDate)
                );
                Assert.AreEqual(EX.DATE_NULL, ex.Message);
            }

            /// <summary>
            /// NULLチェック(名称)
            /// </summary>
            [Test]
            public void NameNull()
            {
                var argName = "おにぎり";
                Assert.DoesNotThrow(() => CHK.NameNull(argName));
            }

            /// <summary>
            /// NULLチェック(名称)
            /// 引数:名称がNULL
            /// </summary>
            [Test]
            public void NameNullWithNullName()
            {
                string argName = null;
                var ex = Assert.Throws<AbException>(() =>
                    CHK.NameNull(argName)
                );
                Assert.AreEqual(EX.NAME_NULL, ex.Message);
            }

            /// <summary>
            /// NULLチェック(名称)
            /// 引数:名称が空文字列
            /// </summary>
            [Test]
            public void NameNullWithEmptyName()
            {
                var argName = string.Empty;
                var ex = Assert.Throws<AbException>(() =>
                    CHK.NameNull(argName)
                );
                Assert.AreEqual(EX.NAME_NULL, ex.Message);
            }

            /// <summary>
            /// NULLチェック(種別)
            /// </summary>
            [Test]
            public void TypeNull()
            {
                var argType = TYPE.FOOD;
                Assert.DoesNotThrow(() => CHK.TypeNull(argType));
            }

            /// <summary>
            /// NULLチェック(種別)
            /// 引数:種別がNULL
            /// </summary>
            [Test]
            public void TypeNullWithNullType()
            {
                string argType = null;
                var ex = Assert.Throws<AbException>(() =>
                    CHK.TypeNull(argType)
                );
                Assert.AreEqual(EX.TYPE_NULL, ex.Message);
            }

            /// <summary>
            /// NULLチェック(種別)
            /// 引数:種別が空文字列
            /// </summary>
            [Test]
            public void TypeNullWithEmptyType()
            {
                var argType = string.Empty;
                var ex = Assert.Throws<AbException>(() =>
                    CHK.TypeNull(argType)
                );
                Assert.AreEqual(EX.TYPE_NULL, ex.Message);
            }

            /// <summary>
            /// 種別チェック
            /// </summary>
            /// <param name="type">種別</param>
            /// <param name="isError">true: エラー、false: OK</param>
            [TestCase(TYPE.FOOD, false)]
            [TestCase(TYPE.OTFD, false)]
            [TestCase(TYPE.GOOD, false)]
            [TestCase(TYPE.FRND, false)]
            [TestCase(TYPE.TRFC, false)]
            [TestCase(TYPE.PLAY, false)]
            [TestCase(TYPE.HOUS, false)]
            [TestCase(TYPE.ENGY, false)]
            [TestCase(TYPE.CNCT, false)]
            [TestCase(TYPE.MEDI, false)]
            [TestCase(TYPE.INSU, false)]
            [TestCase(TYPE.OTHR, false)]
            [TestCase(TYPE.EARN, false)]
            [TestCase(TYPE.TTAL,  true)]
            [TestCase(TYPE.BLNC,  true)]
            [TestCase(TYPE.BNUS, false)]
            [TestCase(TYPE.SPCL, false)]
            [TestCase(TYPE.PRVI, false)]
            [TestCase(TYPE.PRVO, false)]
            [TestCase(TYPE.FNCE, false)]
            public void TypeWrong(string type, bool isError)
            {
                if (isError)
                {
                    var ex = Assert.Throws<AbException>(() =>
                        CHK.TypeWrong(type)
                    );
                    Assert.AreEqual(EX.TYPE_WRONG, ex.Message);
                }
                else
                {
                    Assert.DoesNotThrow(() => CHK.TypeWrong(type));
                }
            }

            /// <summary>
            /// NULLチェック(金額)
            /// </summary>
            [Test]
            public void CostNull()
            {
                var argCost = "999999";
                Assert.DoesNotThrow(() => CHK.CostNull(argCost));
            }

            /// <summary>
            /// NULLチェック(金額)
            /// 引数:金額がNULL
            /// </summary>
            [Test]
            public void CostNullWithNullCost()
            {
                string argCost = null;
                var ex = Assert.Throws<AbException>(() =>
                    CHK.CostNull(argCost)
                );
                Assert.AreEqual(EX.COST_NULL, ex.Message);
            }

            /// <summary>
            /// NULLチェック(金額)
            /// 引数:金額が空文字列
            /// </summary>
            [Test]
            public void CostNullWithEmptyCost()
            {
                var argCost = string.Empty;
                var ex = Assert.Throws<AbException>(() =>
                    CHK.CostNull(argCost)
                );
                Assert.AreEqual(EX.COST_NULL, ex.Message);
            }

            /// <summary>
            /// NULLチェック(備考)
            /// </summary>
            [Test]
            public void NoteNull()
            {
                var argNote = "付帯情報";
                Assert.DoesNotThrow(() => CHK.NoteNull(argNote));
            }

            /// <summary>
            /// NULLチェック(備考)
            /// 引数:備考がNULL
            /// </summary>
            [Test]
            public void NoteNullWithNullNote()
            {
                string argNote = null;
                var ex = Assert.Throws<AbException>(() =>
                    CHK.NoteNull(argNote)
                );
                Assert.AreEqual(EX.NOTE_NULL, ex.Message);
            }

            /// <summary>
            /// NULLチェック(備考)
            /// 引数:備考が空文字列
            /// </summary>
            [Test]
            public void NoteNullWithEmptyNote()
            {
                var argNote = string.Empty;
                Assert.DoesNotThrow(() => CHK.NoteNull(argNote));
            }

            /// <summary>
            /// NULLチェック(DBファイル)
            /// </summary>
            [Test]
            public void DBFileNull()
            {
                var argDBFile = "999999";
                Assert.DoesNotThrow(() => CHK.DBFileNull(argDBFile));
            }

            /// <summary>
            /// NULLチェック(DBファイル)
            /// 引数:DBファイルがNULL
            /// </summary>
            [Test]
            public void DBFileNullWithNullDBFile()
            {
                string argDBFile = null;
                var ex = Assert.Throws<AbException>(() =>
                    CHK.DBFileNull(argDBFile)
                );
                Assert.AreEqual(EX.DB_FILE_NULL, ex.Message);
            }

            /// <summary>
            /// NULLチェック(DBファイル)
            /// 引数:DBファイルが空文字列
            /// </summary>
            [Test]
            public void DBFileNullWithEmptyDBFile()
            {
                var argDBFile = string.Empty;
                var ex = Assert.Throws<AbException>(() =>
                    CHK.DBFileNull(argDBFile)
                );
                Assert.AreEqual(EX.DB_FILE_NULL, ex.Message);
            }

            /// <summary>
            /// NULLチェック(支出情報)
            /// </summary>
            [Test]
            public void ExpNull()
            {
                var argExp = new AbExpense("2015-01-01", "おにぎり", TYPE.FOOD, "108");
                Assert.DoesNotThrow(() => CHK.ExpNull(argExp));
            }

            /// <summary>
            /// NULLチェック(支出情報)
            /// 引数:支出情報がNULL
            /// </summary>
            [Test]
            public void ExpNullWithNullExp()
            {
                AbExpense argExp = null;
                var ex = Assert.Throws<AbException>(() =>
                    CHK.ExpNull(argExp)
                );
                Assert.AreEqual(EX.EXPENSE_NULL, ex.Message);
            }

            /// <summary>
            /// NULLチェック(支出情報リスト)
            /// </summary>
            [Test]
            public void ExpNullWithExpenses()
            {
                var argExpenses = new List<AbExpense>();
                argExpenses.Add(new AbExpense("2015-01-01", "name01", TYPE.FOOD, "100"));
                argExpenses.Add(new AbExpense("2015-01-02", "name02", TYPE.OTFD, "200"));
                argExpenses.Add(new AbExpense("2015-01-03", "name03", TYPE.GOOD, "300"));
                Assert.DoesNotThrow(() => CHK.ExpNull(argExpenses));
            }

            /// <summary>
            /// NULLチェック(支出情報リスト)
            /// 引数:支出情報リストがNULL
            /// </summary>
            [Test]
            public void ExpNullWithNullExpenses()
            {
                List<AbExpense> argExpenses = null;
                var ex = Assert.Throws<AbException>(() =>
                    CHK.ExpNull(argExpenses)
                );
                Assert.AreEqual(EX.EXPENSES_NULL, ex.Message);
            }

            /// <summary>
            /// 件数チェック(支出情報リスト)
            /// </summary>
            [Test]
            public void ExpCount()
            {
                var argExpenses = new List<AbExpense>();
                argExpenses.Add(new AbExpense("2015-01-01", "name01", TYPE.FOOD, "100"));
                argExpenses.Add(new AbExpense("2015-01-02", "name02", TYPE.OTFD, "200"));
                argExpenses.Add(new AbExpense("2015-01-03", "name03", TYPE.GOOD, "300"));
                Assert.DoesNotThrow(() => CHK.ExpCount(argExpenses));
            }

            /// <summary>
            /// 件数チェック(支出情報リスト)
            /// 引数:支出情報リストがNULL
            /// </summary>
            [Test]
            public void ExpCountWithNullExpenses()
            {
                List<AbExpense> argExpenses = null;
                var ex = Assert.Throws<AbException>(() =>
                    CHK.ExpCount(argExpenses)
                );
                Assert.AreEqual(EX.DB_FILE_RECORD_NOTHING, ex.Message);
            }

            /// <summary>
            /// 件数チェック(支出情報リスト)
            /// 引数:支出情報リストが空リスト
            /// </summary>
            [Test]
            public void ExpCountWithEmptyExpenses()
            {
                var argExpenses = new List<AbExpense>();
                var ex = Assert.Throws<AbException>(() =>
                    CHK.ExpCount(argExpenses)
                );
                Assert.AreEqual(EX.DB_FILE_RECORD_NOTHING, ex.Message);
            }

            /// <summary>
            /// NULLチェック(月次情報)
            /// </summary>
            [Test]
            public void SumNull()
            {
                var argSum = AbSummary.GetSummaries(new List<AbExpense>()
                {
                    new AbExpense("2015-01-01", "おにぎり", TYPE.FOOD, "108"),
                });
                Assert.DoesNotThrow(() => CHK.SumNull(argSum));
            }

            /// <summary>
            /// NULLチェック(月次情報リスト)
            /// 引数:月次情報リストがNULL
            /// </summary>
            [Test]
            public void SumNullWithNullSum()
            {
                List<AbSummary> argSumarries = null;
                var ex = Assert.Throws<AbException>(() =>
                    CHK.SumNull(argSumarries)
                );
                Assert.AreEqual(EX.SUMMARIES_NULL, ex.Message);
            }

            /// <summary>
            /// マイナスチェック(年度)
            /// </summary>
            [Test]
            public void YearMinus()
            {
                var argYear = 9999;
                Assert.DoesNotThrow(() => CHK.YearMinus(argYear));
            }

            /// <summary>
            /// マイナスチェック(年度)
            /// 引数:年度がマイナス
            /// </summary>
            [Test]
            public void YearMinusWithMinusYear()
            {
                var argYear = -1;
                var ex = Assert.Throws<AbException>(() =>
                    CHK.YearMinus(argYear)
                );
                Assert.AreEqual(EX.YEAR_MINUS, ex.Message);
            }

            /// <summary>
            /// マイナスチェック(収入)
            /// </summary>
            [Test]
            public void EarnMinus()
            {
                var argEarn = 9999;
                Assert.DoesNotThrow(() => CHK.EarnMinus(argEarn));
            }

            /// <summary>
            /// マイナスチェック(収入)
            /// 引数:収入がマイナス
            /// </summary>
            [Test]
            public void EarnMinusWithMinusEarn()
            {
                var argEarn = -1;
                var ex = Assert.Throws<AbException>(() =>
                    CHK.EarnMinus(argEarn)
                );
                Assert.AreEqual(EX.EARN_MINUS, ex.Message);
            }

            /// <summary>
            /// マイナスチェック(支出)
            /// </summary>
            [Test]
            public void ExpenseMinus()
            {
                var argExpense = 9999;
                Assert.DoesNotThrow(() => CHK.ExpenseMinus(argExpense));
            }

            /// <summary>
            /// マイナスチェック(支出)
            /// 引数:支出がマイナス
            /// </summary>
            [Test]
            public void ExpenseMinusWithMinusExpense()
            {
                var argExpense = -1;
                var ex = Assert.Throws<AbException>(() =>
                    CHK.ExpenseMinus(argExpense)
                );
                Assert.AreEqual(EX.EXPENSE_MINUS, ex.Message);
            }

            /// <summary>
            /// マイナスチェック(特出)
            /// </summary>
            [Test]
            public void SpecialMinus()
            {
                var argSpecial = 9999;
                Assert.DoesNotThrow(() => CHK.SpecialMinus(argSpecial));
            }

            /// <summary>
            /// マイナスチェック(特出)
            /// 引数:特出がマイナス
            /// </summary>
            [Test]
            public void SpecialMinusWithMinusSpecial()
            {
                var argSpecial = -1;
                var ex = Assert.Throws<AbException>(() =>
                    CHK.SpecialMinus(argSpecial)
                );
                Assert.AreEqual(EX.SPECIAL_MINUS, ex.Message);
            }

            /// <summary>
            /// 整合性チェック(収支)
            /// </summary>
            [Test]
            public void BalanceIncorrect()
            {
                var argErn = 90000m;
                var argExp = 20000m;
                var argSpc = 10000m;
                var argBln = 60000m;
                Assert.DoesNotThrow(() => CHK.BalanceIncorrect(argErn, argExp, argSpc, argBln));
            }

            /// <summary>
            /// 整合性チェック(収支)
            /// 収支が合わない
            /// </summary>
            [Test]
            public void BalanceIncorrectWithIncorrect()
            {
                var argErn = 50000m;
                var argExp = 10000m;
                var argSpc = 20000m;
                var argBln = 30000m;
                var ex = Assert.Throws<AbException>(() =>
                    CHK.BalanceIncorrect(argErn, argExp, argSpc, argBln)
                );
                Assert.AreEqual(EX.BALANCE_INCORRECT, ex.Message);
            }

            /// <summary>
            /// マイナスチェック(投資)
            /// </summary>
            [Test]
            public void FinanceMinus()
            {
                var argFinance = 9999;
                Assert.DoesNotThrow(() => CHK.FinanceMinus(argFinance));
            }

            /// <summary>
            /// マイナスチェック(投資)
            /// 引数:投資がマイナス
            /// </summary>
            [Test]
            public void FinanceMinusWithMinusFinance()
            {
                var argFinance = -1;
                var ex = Assert.Throws<AbException>(() =>
                    CHK.FinanceMinus(argFinance)
                );
                Assert.AreEqual(EX.FINANCE_MINUS, ex.Message);
            }
        }
    }
}
