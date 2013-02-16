namespace AbookTest
{
    using Abook;
    using System;
    using System.IO;
    using System.Windows.Forms;
    using NUnit.Framework;
    using NUnit.Extensions.Forms;
    using FMT  = Abook.AbConstants.FMT;
    using TYPE = Abook.AbConstants.TYPE;

    /// <summary>
    /// 集計タブテスト
    /// </summary>
    public static class AbTestTabSummary
    {
        /// <summary>
        /// ヘッダーコントロール取得
        /// </summary>
        /// <param name="form">フォーム</param>
        /// <returns>ヘッダーコントロール</returns>
        private static AbHeaderControl GetHeaderControl(Form form)
        {
            var finder = new Finder<AbHeaderControl>("HeadSummary", form);
            return finder.Find();
        }

        /// <summary>
        /// ボタンテスター取得
        /// </summary>
        /// <param name="name">ボタン名</param>
        /// <param name="form">フォーム</param>
        /// <returns>ボタンテスター</returns>
        private static ButtonTester GetButtonTester(string name, Form form)
        {
            var btnTester = new ButtonTester(name, form);
            return btnTester;
        }

        /// <summary>
        /// 前年ボタン取得
        /// </summary>
        /// <param name="form">フォーム</param>
        /// <returns>前年ボタン</returns>
        private static ButtonTester GetBtnPrevYear(Form form)
        {
            return GetButtonTester("HeadSummary.BtnPrevYear", form);
        }

        /// <summary>
        /// 前月ボタン取得
        /// </summary>
        /// <param name="form">フォーム</param>
        /// <returns>前月ボタン</returns>
        private static ButtonTester GetBtnPrevMonth(Form form)
        {
            return GetButtonTester("HeadSummary.BtnPrevMonth", form);
        }

        /// <summary>
        /// 翌月ボタン取得
        /// </summary>
        /// <param name="form">フォーム</param>
        /// <returns>翌月ボタン</returns>
        private static ButtonTester GetBtnNextMonth(Form form)
        {
            return GetButtonTester("HeadSummary.BtnNextMonth", form);
        }

        /// <summary>
        /// 翌年ボタン取得
        /// </summary>
        /// <param name="form">フォーム</param>
        /// <returns>翌年ボタン</returns>
        private static ButtonTester GetBtnNextYear(Form form)
        {
            return GetButtonTester("HeadSummary.BtnNextYear", form);
        }

        /// <summary>
        /// タイトルテスト
        /// </summary>
        [TestFixture]
        public class WithTitle : NUnitFormTest
        {
            /// <summary>引数:DB ファイル</summary>
            private string argDB = "AbTestTabSummaryWithTitle.db";
            /// <summary>対象:メイン画面フォーム</summary>
            private AbFormMain abFormMain;

            /// <summary>
            /// Setup
            /// </summary>
            public override void Setup()
            {
                base.Setup();
                abFormMain = new AbFormMain(argDB);
                abFormMain.Show();

                var tabSummary = new TabControlTester("TabControl", abFormMain);
                tabSummary.SelectTab(1);
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
                if (System.IO.File.Exists(argDB))
                {
                    System.IO.File.Delete(argDB);
                }
            }

            /// <summary>
            /// タイトルの検証
            /// </summary>
            /// <param name="expect">期待値</param>
            private void HeaderTitleTest(string expect)
            {
                var headSummary = GetHeaderControl(abFormMain);
                Assert.AreEqual(expect, headSummary.Title);
            }

            /// <summary>
            /// 前年ボタン取得
            /// </summary>
            /// <returns>前年ボタン</returns>
            private ButtonTester GetBtnPrevYear()
            {
                return AbTestTabSummary.GetBtnPrevYear(abFormMain);
            }

            /// <summary>
            /// 前月ボタン取得
            /// </summary>
            /// <returns>前月ボタン</returns>
            private ButtonTester GetBtnPrevMonth()
            {
                return AbTestTabSummary.GetBtnPrevMonth(abFormMain);
            }

            /// <summary>
            /// 翌月ボタン取得
            /// </summary>
            /// <returns>翌月ボタン</returns>
            private ButtonTester GetBtnNextMonth()
            {
                return AbTestTabSummary.GetBtnNextMonth(abFormMain);
            }

            /// <summary>
            /// 翌年ボタン取得
            /// </summary>
            /// <returns>翌年ボタン</returns>
            private ButtonTester GetBtnNextYear()
            {
                return AbTestTabSummary.GetBtnNextYear(abFormMain);
            }

            /// <summary>
            /// タイトルテスト
            /// 初期表示:システム年月
            /// </summary>
            [Test]
            public void TitleWithInitial()
            {
                var date = DateTime.Now;
                HeaderTitleTest(date.ToString(FMT.TITLE));
            }

            /// <summary>
            /// タイトルテスト
            /// 前年表示:1年前
            /// </summary>
            [Test]
            public void TitleWithPrevYear_1_Time()
            {
                var btnPrevYear = GetBtnPrevYear();
                btnPrevYear.Click();

                var date = DateTime.Now.AddYears(-1);
                HeaderTitleTest(date.ToString(FMT.TITLE));
            }

            /// <summary>
            /// タイトルテスト
            /// 前年表示:2年前
            /// </summary>
            [Test]
            public void TitleWithPrevYear_2_Time()
            {
                var btnPrevYear = GetBtnPrevYear();
                btnPrevYear.Click();
                btnPrevYear.Click();

                var date = DateTime.Now.AddYears(-2);
                HeaderTitleTest(date.ToString(FMT.TITLE));
            }

            /// <summary>
            /// タイトルテスト
            /// 前年表示:3年前
            /// </summary>
            [Test]
            public void TitleWithPrevYear_3_Time()
            {
                var btnPrevYear = GetBtnPrevYear();
                btnPrevYear.Click();
                btnPrevYear.Click();
                btnPrevYear.Click();

                var date = DateTime.Now.AddYears(-3);
                HeaderTitleTest(date.ToString(FMT.TITLE));
            }

            /// <summary>
            /// タイトルテスト
            /// 前月表示:1ヶ月前
            /// </summary>
            [Test]
            public void TitleWithPrevMonth_1_Time()
            {
                var btnPrevMonth = GetBtnPrevMonth();
                btnPrevMonth.Click();

                var date = DateTime.Now.AddMonths(-1);
                HeaderTitleTest(date.ToString(FMT.TITLE));
            }

            /// <summary>
            /// タイトルテスト
            /// 前月表示:2ヶ月前
            /// </summary>
            [Test]
            public void TitleWithPrevMonth_2_Time()
            {
                var btnPrevMonth = GetBtnPrevMonth();
                btnPrevMonth.Click();
                btnPrevMonth.Click();

                var date = DateTime.Now.AddMonths(-2);
                HeaderTitleTest(date.ToString(FMT.TITLE));
            }

            /// <summary>
            /// タイトルテスト
            /// 前月表示:3ヶ月前
            /// </summary>
            [Test]
            public void TitleWithPrevMonth_3_Time()
            {
                var btnPrevMonth = GetBtnPrevMonth();
                btnPrevMonth.Click();
                btnPrevMonth.Click();
                btnPrevMonth.Click();

                var date = DateTime.Now.AddMonths(-3);
                HeaderTitleTest(date.ToString(FMT.TITLE));
            }

            /// <summary>
            /// タイトルテスト
            /// 翌月表示:1ヶ月後
            /// </summary>
            [Test]
            public void TitleWithNextMonth_1_Time()
            {
                var btnNextMonth = GetBtnNextMonth();
                btnNextMonth.Click();

                var date = DateTime.Now.AddMonths(1);
                HeaderTitleTest(date.ToString(FMT.TITLE));
            }

            /// <summary>
            /// タイトルテスト
            /// 翌月表示:2ヶ月後
            /// </summary>
            [Test]
            public void TitleWithNextMonth_2_Time()
            {
                var btnNextMonth = GetBtnNextMonth();
                btnNextMonth.Click();
                btnNextMonth.Click();

                var date = DateTime.Now.AddMonths(2);
                HeaderTitleTest(date.ToString(FMT.TITLE));
            }

            /// <summary>
            /// タイトルテスト
            /// 翌月表示:3ヶ月後
            /// </summary>
            [Test]
            public void TitleWithNextMonth_3_Time()
            {
                var btnNextMonth = GetBtnNextMonth();
                btnNextMonth.Click();
                btnNextMonth.Click();
                btnNextMonth.Click();

                var date = DateTime.Now.AddMonths(3);
                HeaderTitleTest(date.ToString(FMT.TITLE));
            }

            /// <summary>
            /// タイトルテスト
            /// 翌年表示:1年後
            /// </summary>
            [Test]
            public void TitleWithNextYear_1_Time()
            {
                var btnNextYear = GetBtnNextYear();
                btnNextYear.Click();

                var date = DateTime.Now.AddYears(1);
                HeaderTitleTest(date.ToString(FMT.TITLE));
            }

            /// <summary>
            /// タイトルテスト
            /// 翌年表示:2年後
            /// </summary>
            [Test]
            public void TitleWithNextYear_2_Time()
            {
                var btnNextYear = GetBtnNextYear();
                btnNextYear.Click();
                btnNextYear.Click();

                var date = DateTime.Now.AddYears(2);
                HeaderTitleTest(date.ToString(FMT.TITLE));
            }

            /// <summary>
            /// タイトルテスト
            /// 翌年表示:3年後
            /// </summary>
            [Test]
            public void TitleWithNextYear_3_Time()
            {
                var btnNextYear = GetBtnNextYear();
                btnNextYear.Click();
                btnNextYear.Click();
                btnNextYear.Click();

                var date = DateTime.Now.AddYears(3);
                HeaderTitleTest(date.ToString(FMT.TITLE));
            }
        }

        /// <summary>
        /// ラベルテスト
        /// </summary>
        [TestFixture]
        public class WithLabel : NUnitFormTest
        {
            /// <summary>引数:DB ファイル</summary>
            private string argDB = "AbTestTabSummaryWithLabel.db";
            /// <summary>対象:メイン画面フォーム</summary>
            private AbFormMain abFormMain;

            /// <summary>
            /// TestFixtureSetUp
            /// </summary>
            [TestFixtureSetUp]
            public void TestFixtureSetUp()
            {
                using (StreamWriter sw = new StreamWriter(argDB, false, System.Text.Encoding.UTF8))
                {
                    var date = DateTime.Now;
                    sw.WriteLine(GenerateWriteLine(date, TYPE.FOOD,  10000));
                    sw.WriteLine(GenerateWriteLine(date, TYPE.OTFD,  15000));
                    sw.WriteLine(GenerateWriteLine(date, TYPE.GOOD,   1200));
                    sw.WriteLine(GenerateWriteLine(date, TYPE.FRND,   5000));
                    sw.WriteLine(GenerateWriteLine(date, TYPE.TRFC,    200));
                    sw.WriteLine(GenerateWriteLine(date, TYPE.PLAY,   3000));
                    sw.WriteLine(GenerateWriteLine(date, TYPE.HOUS,  40000));
                    sw.WriteLine(GenerateWriteLine(date, TYPE.ENGY,   8000));
                    sw.WriteLine(GenerateWriteLine(date, TYPE.CNCT,   2000));
                    sw.WriteLine(GenerateWriteLine(date, TYPE.MEDI,   1700));
                    sw.WriteLine(GenerateWriteLine(date, TYPE.INSU,   2700));
                    sw.WriteLine(GenerateWriteLine(date, TYPE.OTHR,    500));
                    sw.WriteLine(GenerateWriteLine(date, TYPE.EARN, 150000));

                    var dtPrevYear1 = date.AddYears(-1);
                    sw.WriteLine(GenerateWriteLine(dtPrevYear1, TYPE.FOOD,  10100));
                    sw.WriteLine(GenerateWriteLine(dtPrevYear1, TYPE.OTFD,  15100));
                    sw.WriteLine(GenerateWriteLine(dtPrevYear1, TYPE.GOOD,   1300));
                    sw.WriteLine(GenerateWriteLine(dtPrevYear1, TYPE.FRND,   5100));
                    sw.WriteLine(GenerateWriteLine(dtPrevYear1, TYPE.TRFC,    300));
                    sw.WriteLine(GenerateWriteLine(dtPrevYear1, TYPE.PLAY,   3100));
                    sw.WriteLine(GenerateWriteLine(dtPrevYear1, TYPE.HOUS,  40100));
                    sw.WriteLine(GenerateWriteLine(dtPrevYear1, TYPE.ENGY,   8100));
                    sw.WriteLine(GenerateWriteLine(dtPrevYear1, TYPE.CNCT,   2100));
                    sw.WriteLine(GenerateWriteLine(dtPrevYear1, TYPE.MEDI,   1800));
                    sw.WriteLine(GenerateWriteLine(dtPrevYear1, TYPE.INSU,   2800));
                    sw.WriteLine(GenerateWriteLine(dtPrevYear1, TYPE.OTHR,    600));
                    sw.WriteLine(GenerateWriteLine(dtPrevYear1, TYPE.EARN, 150100));

                    var dtPrevYear2 = date.AddYears(-2);
                    sw.WriteLine(GenerateWriteLine(dtPrevYear2, TYPE.FOOD,  10200));
                    sw.WriteLine(GenerateWriteLine(dtPrevYear2, TYPE.OTFD,  15200));
                    sw.WriteLine(GenerateWriteLine(dtPrevYear2, TYPE.GOOD,   1400));
                    sw.WriteLine(GenerateWriteLine(dtPrevYear2, TYPE.FRND,   5200));
                    sw.WriteLine(GenerateWriteLine(dtPrevYear2, TYPE.TRFC,    400));
                    sw.WriteLine(GenerateWriteLine(dtPrevYear2, TYPE.PLAY,   3200));
                    sw.WriteLine(GenerateWriteLine(dtPrevYear2, TYPE.HOUS,  40200));
                    sw.WriteLine(GenerateWriteLine(dtPrevYear2, TYPE.ENGY,   8200));
                    sw.WriteLine(GenerateWriteLine(dtPrevYear2, TYPE.CNCT,   2200));
                    sw.WriteLine(GenerateWriteLine(dtPrevYear2, TYPE.MEDI,   1900));
                    sw.WriteLine(GenerateWriteLine(dtPrevYear2, TYPE.INSU,   2900));
                    sw.WriteLine(GenerateWriteLine(dtPrevYear2, TYPE.OTHR,    700));
                    sw.WriteLine(GenerateWriteLine(dtPrevYear2, TYPE.EARN, 150200));

                    var dtPrevMonth1 = date.AddMonths(-1);
                    sw.WriteLine(GenerateWriteLine(dtPrevMonth1, TYPE.FOOD,  10300));
                    sw.WriteLine(GenerateWriteLine(dtPrevMonth1, TYPE.OTFD,  15300));
                    sw.WriteLine(GenerateWriteLine(dtPrevMonth1, TYPE.GOOD,   1500));
                    sw.WriteLine(GenerateWriteLine(dtPrevMonth1, TYPE.FRND,   5300));
                    sw.WriteLine(GenerateWriteLine(dtPrevMonth1, TYPE.TRFC,    500));
                    sw.WriteLine(GenerateWriteLine(dtPrevMonth1, TYPE.PLAY,   3300));
                    sw.WriteLine(GenerateWriteLine(dtPrevMonth1, TYPE.HOUS,  40300));
                    sw.WriteLine(GenerateWriteLine(dtPrevMonth1, TYPE.ENGY,   8300));
                    sw.WriteLine(GenerateWriteLine(dtPrevMonth1, TYPE.CNCT,   2300));
                    sw.WriteLine(GenerateWriteLine(dtPrevMonth1, TYPE.MEDI,   2000));
                    sw.WriteLine(GenerateWriteLine(dtPrevMonth1, TYPE.INSU,   3000));
                    sw.WriteLine(GenerateWriteLine(dtPrevMonth1, TYPE.OTHR,    800));
                    sw.WriteLine(GenerateWriteLine(dtPrevMonth1, TYPE.EARN, 150300));

                    var dtPrevMonth2 = date.AddMonths(-2);
                    sw.WriteLine(GenerateWriteLine(dtPrevMonth2, TYPE.FOOD,  10400));
                    sw.WriteLine(GenerateWriteLine(dtPrevMonth2, TYPE.OTFD,  15400));
                    sw.WriteLine(GenerateWriteLine(dtPrevMonth2, TYPE.GOOD,   1600));
                    sw.WriteLine(GenerateWriteLine(dtPrevMonth2, TYPE.FRND,   5400));
                    sw.WriteLine(GenerateWriteLine(dtPrevMonth2, TYPE.TRFC,    600));
                    sw.WriteLine(GenerateWriteLine(dtPrevMonth2, TYPE.PLAY,   3400));
                    sw.WriteLine(GenerateWriteLine(dtPrevMonth2, TYPE.HOUS,  40400));
                    sw.WriteLine(GenerateWriteLine(dtPrevMonth2, TYPE.ENGY,   8400));
                    sw.WriteLine(GenerateWriteLine(dtPrevMonth2, TYPE.CNCT,   2400));
                    sw.WriteLine(GenerateWriteLine(dtPrevMonth2, TYPE.MEDI,   2100));
                    sw.WriteLine(GenerateWriteLine(dtPrevMonth2, TYPE.INSU,   3100));
                    sw.WriteLine(GenerateWriteLine(dtPrevMonth2, TYPE.OTHR,    900));
                    sw.WriteLine(GenerateWriteLine(dtPrevMonth2, TYPE.EARN, 150400));

                    var dtNextMonth1 = date.AddMonths(1);
                    sw.WriteLine(GenerateWriteLine(dtNextMonth1, TYPE.FOOD,  10500));
                    sw.WriteLine(GenerateWriteLine(dtNextMonth1, TYPE.OTFD,  15500));
                    sw.WriteLine(GenerateWriteLine(dtNextMonth1, TYPE.GOOD,   1700));
                    sw.WriteLine(GenerateWriteLine(dtNextMonth1, TYPE.FRND,   5500));
                    sw.WriteLine(GenerateWriteLine(dtNextMonth1, TYPE.TRFC,    700));
                    sw.WriteLine(GenerateWriteLine(dtNextMonth1, TYPE.PLAY,   3500));
                    sw.WriteLine(GenerateWriteLine(dtNextMonth1, TYPE.HOUS,  40500));
                    sw.WriteLine(GenerateWriteLine(dtNextMonth1, TYPE.ENGY,   8500));
                    sw.WriteLine(GenerateWriteLine(dtNextMonth1, TYPE.CNCT,   2500));
                    sw.WriteLine(GenerateWriteLine(dtNextMonth1, TYPE.MEDI,   2200));
                    sw.WriteLine(GenerateWriteLine(dtNextMonth1, TYPE.INSU,   3200));
                    sw.WriteLine(GenerateWriteLine(dtNextMonth1, TYPE.OTHR,   1000));
                    sw.WriteLine(GenerateWriteLine(dtNextMonth1, TYPE.EARN, 150500));

                    var dtNextMonth2 = date.AddMonths(2);
                    sw.WriteLine(GenerateWriteLine(dtNextMonth2, TYPE.FOOD,  10600));
                    sw.WriteLine(GenerateWriteLine(dtNextMonth2, TYPE.OTFD,  15600));
                    sw.WriteLine(GenerateWriteLine(dtNextMonth2, TYPE.GOOD,   1800));
                    sw.WriteLine(GenerateWriteLine(dtNextMonth2, TYPE.FRND,   5600));
                    sw.WriteLine(GenerateWriteLine(dtNextMonth2, TYPE.TRFC,    800));
                    sw.WriteLine(GenerateWriteLine(dtNextMonth2, TYPE.PLAY,   3600));
                    sw.WriteLine(GenerateWriteLine(dtNextMonth2, TYPE.HOUS,  40600));
                    sw.WriteLine(GenerateWriteLine(dtNextMonth2, TYPE.ENGY,   8600));
                    sw.WriteLine(GenerateWriteLine(dtNextMonth2, TYPE.CNCT,   2600));
                    sw.WriteLine(GenerateWriteLine(dtNextMonth2, TYPE.MEDI,   2300));
                    sw.WriteLine(GenerateWriteLine(dtNextMonth2, TYPE.INSU,   3300));
                    sw.WriteLine(GenerateWriteLine(dtNextMonth2, TYPE.OTHR,   1100));
                    sw.WriteLine(GenerateWriteLine(dtNextMonth2, TYPE.EARN, 150600));

                    var dtNextYear1 = date.AddYears(1);
                    sw.WriteLine(GenerateWriteLine(dtNextYear1, TYPE.FOOD,  10700));
                    sw.WriteLine(GenerateWriteLine(dtNextYear1, TYPE.OTFD,  15700));
                    sw.WriteLine(GenerateWriteLine(dtNextYear1, TYPE.GOOD,   1900));
                    sw.WriteLine(GenerateWriteLine(dtNextYear1, TYPE.FRND,   5700));
                    sw.WriteLine(GenerateWriteLine(dtNextYear1, TYPE.TRFC,    900));
                    sw.WriteLine(GenerateWriteLine(dtNextYear1, TYPE.PLAY,   3700));
                    sw.WriteLine(GenerateWriteLine(dtNextYear1, TYPE.HOUS,  40700));
                    sw.WriteLine(GenerateWriteLine(dtNextYear1, TYPE.ENGY,   8700));
                    sw.WriteLine(GenerateWriteLine(dtNextYear1, TYPE.CNCT,   2700));
                    sw.WriteLine(GenerateWriteLine(dtNextYear1, TYPE.MEDI,   2400));
                    sw.WriteLine(GenerateWriteLine(dtNextYear1, TYPE.INSU,   3400));
                    sw.WriteLine(GenerateWriteLine(dtNextYear1, TYPE.OTHR,   1200));
                    sw.WriteLine(GenerateWriteLine(dtNextYear1, TYPE.EARN, 150700));

                    var dtNextYear2 = date.AddYears(2);
                    sw.WriteLine(GenerateWriteLine(dtNextYear2, TYPE.FOOD,  10800));
                    sw.WriteLine(GenerateWriteLine(dtNextYear2, TYPE.OTFD,  15800));
                    sw.WriteLine(GenerateWriteLine(dtNextYear2, TYPE.GOOD,   2000));
                    sw.WriteLine(GenerateWriteLine(dtNextYear2, TYPE.FRND,   5800));
                    sw.WriteLine(GenerateWriteLine(dtNextYear2, TYPE.TRFC,   1000));
                    sw.WriteLine(GenerateWriteLine(dtNextYear2, TYPE.PLAY,   3800));
                    sw.WriteLine(GenerateWriteLine(dtNextYear2, TYPE.HOUS,  40800));
                    sw.WriteLine(GenerateWriteLine(dtNextYear2, TYPE.ENGY,   8800));
                    sw.WriteLine(GenerateWriteLine(dtNextYear2, TYPE.CNCT,   2800));
                    sw.WriteLine(GenerateWriteLine(dtNextYear2, TYPE.MEDI,   2500));
                    sw.WriteLine(GenerateWriteLine(dtNextYear2, TYPE.INSU,   3500));
                    sw.WriteLine(GenerateWriteLine(dtNextYear2, TYPE.OTHR,   1300));
                    sw.WriteLine(GenerateWriteLine(dtNextYear2, TYPE.EARN, 150800));
                }
            }

            /// <summary>
            /// Setup
            /// </summary>
            public override void Setup()
            {
                base.Setup();
                abFormMain = new AbFormMain(argDB);
                abFormMain.Show();

                var tabSummary = new TabControlTester("TabControl", abFormMain);
                tabSummary.SelectTab(1);
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
                if (System.IO.File.Exists(argDB))
                {
                    System.IO.File.Delete(argDB);
                }
            }

            /// <summary>GenerateWriteLine メソッド用テンプレ</summary>
            private const string TEMPLATE = "\"{0}\",\"name\",\"{1}\",\"{2}\"";

            /// <summary>
            /// 出力用レコード文字列生成
            /// </summary>
            /// <param name="date">日付</param>
            /// <param name="type">種別</param>
            /// <param name="cost">金額</param>
            /// <returns>出力用レコード文字列</returns>
            private string GenerateWriteLine(DateTime date, string type, decimal cost)
            {
                return string.Format(TEMPLATE, date.ToString(FMT.DATE), type, cost);
            }

            /// <summary>
            /// 前年ボタン取得
            /// </summary>
            /// <returns>前年ボタン</returns>
            private ButtonTester GetBtnPrevYear()
            {
                return AbTestTabSummary.GetBtnPrevYear(abFormMain);
            }

            /// <summary>
            /// 前月ボタン取得
            /// </summary>
            /// <returns>前月ボタン</returns>
            private ButtonTester GetBtnPrevMonth()
            {
                return AbTestTabSummary.GetBtnPrevMonth(abFormMain);
            }

            /// <summary>
            /// 翌月ボタン取得
            /// </summary>
            /// <returns>翌月ボタン</returns>
            private ButtonTester GetBtnNextMonth()
            {
                return AbTestTabSummary.GetBtnNextMonth(abFormMain);
            }

            /// <summary>
            /// 翌年ボタン取得
            /// </summary>
            /// <returns>翌年ボタン</returns>
            private ButtonTester GetBtnNextYear()
            {
                return AbTestTabSummary.GetBtnNextYear(abFormMain);
            }

            /// <summary>
            /// ラベルコントロールの金額検証
            /// </summary>
            /// <param name="costs">金額配列</param>
            private void LabelControlTest(decimal[] costs)
            {
                LabelControlTest("LblFood", costs[0]);
                LabelControlTest("LblOtfd", costs[1]);
                LabelControlTest("LblGood", costs[2]);
                LabelControlTest("LblFrnd", costs[3]);
                LabelControlTest("LblTrfc", costs[4]);
                LabelControlTest("LblPlay", costs[5]);
                LabelControlTest("LblHous", costs[6]);
                LabelControlTest("LblEngy", costs[7]);
                LabelControlTest("LblCnct", costs[8]);
                LabelControlTest("LblMedi", costs[9]);
                LabelControlTest("LblInsu", costs[10]);
                LabelControlTest("LblOthr", costs[11]);
                LabelControlTest("LblTtal", costs[12]);
                LabelControlTest("LblBlnc", costs[13]);
            }

            /// <summary>
            /// ラベルコントロールの金額検証
            /// </summary>
            /// <param name="lblName">ラベルコントロール名</param>
            /// <param name="expected">金額</param>
            private void LabelControlTest(string lblName, decimal expected)
            {
                var finder = new Finder<AbLabelControl>(lblName, abFormMain);
                var labelControl = finder.Find();
                Assert.AreEqual(expected, labelControl.Cost);
            }

            /// <summary>
            /// ラベルテスト
            /// 初期表示
            /// </summary>
            [Test]
            public void LabelControlInitial()
            {
                LabelControlTest(
                    new decimal[] { 10000, 15000, 1200, 5000, 200, 3000, 40000, 8000, 2000, 1700, 2700, 500, 89300, 60700 }
                );
            }

            /// <summary>
            /// ラベルテスト
            /// 前年表示:1年前
            /// </summary>
            [Test]
            public void LabelControlPrevYear_1_Time()
            {
                var btnPrevYear = GetBtnPrevYear();
                btnPrevYear.Click();

                LabelControlTest(
                    new decimal[] { 10100, 15100, 1300, 5100, 300, 3100, 40100, 8100, 2100, 1800, 2800, 600, 90500, 59600 }
                );
            }

            /// <summary>
            /// ラベルテスト
            /// 前年表示:2年前
            /// </summary>
            [Test]
            public void LabelControlPrevYear_2_Time()
            {
                var btnPrevYear = GetBtnPrevYear();
                btnPrevYear.Click();
                btnPrevYear.Click();

                LabelControlTest(
                    new decimal[] { 10200, 15200, 1400, 5200, 400, 3200, 40200, 8200, 2200, 1900, 2900, 700, 91700, 58500 }
                );
            }

            /// <summary>
            /// ラベルテスト
            /// 前年表示:3年前
            /// </summary>
            [Test]
            public void LabelControlPrevYear_3_Time()
            {
                var btnPrevYear = GetBtnPrevYear();
                btnPrevYear.Click();
                btnPrevYear.Click();
                btnPrevYear.Click();

                LabelControlTest(
                    new decimal[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                );
            }

            /// <summary>
            /// ラベルテスト
            /// 前月表示:1ヶ月前
            /// </summary>
            [Test]
            public void LabelControlPrevMonth_1_Time()
            {
                var btnPrevMonth = GetBtnPrevMonth();
                btnPrevMonth.Click();

                LabelControlTest(
                    new decimal[] { 10300, 15300, 1500, 5300, 500, 3300, 40300, 8300, 2300, 2000, 3000, 800, 92900, 57400 }
                );
            }

            /// <summary>
            /// ラベルテスト
            /// 前月表示:2ヶ月前
            /// </summary>
            [Test]
            public void LabelControlPrevMonth_2_Time()
            {
                var btnPrevMonth = GetBtnPrevMonth();
                btnPrevMonth.Click();
                btnPrevMonth.Click();

                LabelControlTest(
                    new decimal[] { 10400, 15400, 1600, 5400, 600, 3400, 40400, 8400, 2400, 2100, 3100, 900, 94100, 56300 }
                );
            }

            /// <summary>
            /// ラベルテスト
            /// 前月表示:3ヶ月前
            /// </summary>
            [Test]
            public void LabelControlPrevMonth_3_Time()
            {
                var btnPrevMonth = GetBtnPrevMonth();
                btnPrevMonth.Click();
                btnPrevMonth.Click();
                btnPrevMonth.Click();

                LabelControlTest(
                    new decimal[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                );
            }

            /// <summary>
            /// ラベルテスト
            /// 翌月表示:1ヶ月後
            /// </summary>
            [Test]
            public void LabelControlNextMonth_1_Time()
            {
                var btnNextMonth = GetBtnNextMonth();
                btnNextMonth.Click();

                LabelControlTest(
                    new decimal[] { 10500, 15500, 1700, 5500, 700, 3500, 40500, 8500, 2500, 2200, 3200, 1000, 95300, 55200 }
                );
            }

            /// <summary>
            /// ラベルテスト
            /// 翌月表示:2ヶ月後
            /// </summary>
            [Test]
            public void LabelControlNextMonth_2_Time()
            {
                var btnNextMonth = GetBtnNextMonth();
                btnNextMonth.Click();
                btnNextMonth.Click();

                LabelControlTest(
                    new decimal[] { 10600, 15600, 1800, 5600, 800, 3600, 40600, 8600, 2600, 2300, 3300, 1100, 96500, 54100 }
                );
            }

            /// <summary>
            /// ラベルテスト
            /// 翌月表示:3ヶ月後
            /// </summary>
            [Test]
            public void LabelControlNextMonth_3_Time()
            {
                var btnNextMonth = GetBtnNextMonth();
                btnNextMonth.Click();
                btnNextMonth.Click();
                btnNextMonth.Click();

                LabelControlTest(
                    new decimal[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                );
            }

            /// <summary>
            /// ラベルテスト
            /// 翌年表示:1年後
            /// </summary>
            [Test]
            public void LabelControlNextYear_1_Time()
            {
                var btnNextYear = GetBtnNextYear();
                btnNextYear.Click();

                LabelControlTest(
                    new decimal[] { 10700, 15700, 1900, 5700, 900, 3700, 40700, 8700, 2700, 2400, 3400, 1200, 97700, 53000 }
                );
            }

            /// <summary>
            /// ラベルテスト
            /// 翌年表示:2年後
            /// </summary>
            [Test]
            public void LabelControlNextYear_2_Time()
            {
                var btnNextYear = GetBtnNextYear();
                btnNextYear.Click();
                btnNextYear.Click();

                LabelControlTest(
                    new decimal[] { 10800, 15800, 2000, 5800, 1000, 3800, 40800, 8800, 2800, 2500, 3500, 1300, 98900, 51900 }
                );
            }

            /// <summary>
            /// ラベルテスト
            /// 翌年表示:3年後
            /// </summary>
            [Test]
            public void LabelControlNextYear_3_Time()
            {
                var btnNextYear = GetBtnNextYear();
                btnNextYear.Click();
                btnNextYear.Click();
                btnNextYear.Click();

                LabelControlTest(
                    new decimal[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                );
            }
        }

        /// <summary>
        /// ラベルテスト(データなし)
        /// </summary>
        [TestFixture]
        public class WithLabelWithEmptyData : NUnitFormTest
        {
            /// <summary>引数:DB ファイル</summary>
            private string argDB = "AbTestTabSummaryWithLabelWithEmptyData.db";
            /// <summary>対象:メイン画面フォーム</summary>
            private AbFormMain abFormMain;

            /// <summary>
            /// Setup
            /// </summary>
            public override void Setup()
            {
                base.Setup();
                abFormMain = new AbFormMain(argDB);
                abFormMain.Show();

                var tabSummary = new TabControlTester("TabControl", abFormMain);
                tabSummary.SelectTab(1);
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
                if (System.IO.File.Exists(argDB))
                {
                    System.IO.File.Delete(argDB);
                }
            }

            /// <summary>
            /// 前年ボタン取得
            /// </summary>
            /// <returns>前年ボタン</returns>
            private ButtonTester GetBtnPrevYear()
            {
                return AbTestTabSummary.GetBtnPrevYear(abFormMain);
            }

            /// <summary>
            /// 前月ボタン取得
            /// </summary>
            /// <returns>前月ボタン</returns>
            private ButtonTester GetBtnPrevMonth()
            {
                return AbTestTabSummary.GetBtnPrevMonth(abFormMain);
            }

            /// <summary>
            /// 翌月ボタン取得
            /// </summary>
            /// <returns>翌月ボタン</returns>
            private ButtonTester GetBtnNextMonth()
            {
                return AbTestTabSummary.GetBtnNextMonth(abFormMain);
            }

            /// <summary>
            /// 翌年ボタン取得
            /// </summary>
            /// <returns>翌年ボタン</returns>
            private ButtonTester GetBtnNextYear()
            {
                return AbTestTabSummary.GetBtnNextYear(abFormMain);
            }

            /// <summary>
            /// ラベルコントロールの金額検証
            /// </summary>
            /// <param name="costs">金額配列</param>
            private void LabelControlTest(decimal[] costs)
            {
                LabelControlTest("LblFood", costs[0]);
                LabelControlTest("LblOtfd", costs[1]);
                LabelControlTest("LblGood", costs[2]);
                LabelControlTest("LblFrnd", costs[3]);
                LabelControlTest("LblTrfc", costs[4]);
                LabelControlTest("LblPlay", costs[5]);
                LabelControlTest("LblHous", costs[6]);
                LabelControlTest("LblEngy", costs[7]);
                LabelControlTest("LblCnct", costs[8]);
                LabelControlTest("LblMedi", costs[9]);
                LabelControlTest("LblInsu", costs[10]);
                LabelControlTest("LblOthr", costs[11]);
                LabelControlTest("LblTtal", costs[12]);
                LabelControlTest("LblBlnc", costs[13]);
            }

            /// <summary>
            /// ラベルコントロールの金額検証
            /// </summary>
            /// <param name="lblName">ラベルコントロール名</param>
            /// <param name="expected">金額</param>
            private void LabelControlTest(string lblName, decimal expected)
            {
                var finder = new Finder<AbLabelControl>(lblName, abFormMain);
                var labelControl = finder.Find();
                Assert.AreEqual(expected, labelControl.Cost);
            }

            /// <summary>
            /// ラベルテスト
            /// 初期表示
            /// </summary>
            [Test]
            public void LabelControlInitial()
            {
                LabelControlTest(
                    new decimal[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                );
            }

            /// <summary>
            /// ラベルテスト
            /// 前年表示:1年前
            /// </summary>
            [Test]
            public void LabelControlPrevYear_1_Time()
            {
                var btnPrevYear = GetBtnPrevYear();
                btnPrevYear.Click();

                LabelControlTest(
                    new decimal[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                );
            }

            /// <summary>
            /// ラベルテスト
            /// 前年表示:2年前
            /// </summary>
            [Test]
            public void LabelControlPrevYear_2_Time()
            {
                var btnPrevYear = GetBtnPrevYear();
                btnPrevYear.Click();
                btnPrevYear.Click();

                LabelControlTest(
                    new decimal[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                );
            }

            /// <summary>
            /// ラベルテスト
            /// 前年表示:3年前
            /// </summary>
            [Test]
            public void LabelControlPrevYear_3_Time()
            {
                var btnPrevYear = GetBtnPrevYear();
                btnPrevYear.Click();
                btnPrevYear.Click();
                btnPrevYear.Click();

                LabelControlTest(
                    new decimal[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                );
            }

            /// <summary>
            /// ラベルテスト
            /// 前月表示:1ヶ月前
            /// </summary>
            [Test]
            public void LabelControlPrevMonth_1_Time()
            {
                var btnPrevMonth = GetBtnPrevMonth();
                btnPrevMonth.Click();

                LabelControlTest(
                    new decimal[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                );
            }

            /// <summary>
            /// ラベルテスト
            /// 前月表示:2ヶ月前
            /// </summary>
            [Test]
            public void LabelControlPrevMonth_2_Time()
            {
                var btnPrevMonth = GetBtnPrevMonth();
                btnPrevMonth.Click();
                btnPrevMonth.Click();

                LabelControlTest(
                    new decimal[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                );
            }

            /// <summary>
            /// ラベルテスト
            /// 前月表示:3ヶ月前
            /// </summary>
            [Test]
            public void LabelControlPrevMonth_3_Time()
            {
                var btnPrevMonth = GetBtnPrevMonth();
                btnPrevMonth.Click();
                btnPrevMonth.Click();
                btnPrevMonth.Click();

                LabelControlTest(
                    new decimal[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                );
            }

            /// <summary>
            /// ラベルテスト
            /// 翌月表示:1ヶ月後
            /// </summary>
            [Test]
            public void LabelControlNextMonth_1_Time()
            {
                var btnNextMonth = GetBtnNextMonth();
                btnNextMonth.Click();

                LabelControlTest(
                    new decimal[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                );
            }

            /// <summary>
            /// ラベルテスト
            /// 翌月表示:2ヶ月後
            /// </summary>
            [Test]
            public void LabelControlNextMonth_2_Time()
            {
                var btnNextMonth = GetBtnNextMonth();
                btnNextMonth.Click();
                btnNextMonth.Click();

                LabelControlTest(
                    new decimal[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                );
            }

            /// <summary>
            /// ラベルテスト
            /// 翌月表示:3ヶ月後
            /// </summary>
            [Test]
            public void LabelControlNextMonth_3_Time()
            {
                var btnNextMonth = GetBtnNextMonth();
                btnNextMonth.Click();
                btnNextMonth.Click();
                btnNextMonth.Click();

                LabelControlTest(
                    new decimal[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                );
            }

            /// <summary>
            /// ラベルテスト
            /// 翌年表示:1年後
            /// </summary>
            [Test]
            public void LabelControlNextYear_1_Time()
            {
                var btnNextYear = GetBtnNextYear();
                btnNextYear.Click();

                LabelControlTest(
                    new decimal[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                );
            }

            /// <summary>
            /// ラベルテスト
            /// 翌年表示:2年後
            /// </summary>
            [Test]
            public void LabelControlNextYear_2_Time()
            {
                var btnNextYear = GetBtnNextYear();
                btnNextYear.Click();
                btnNextYear.Click();

                LabelControlTest(
                    new decimal[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                );
            }

            /// <summary>
            /// ラベルテスト
            /// 翌年表示:3年後
            /// </summary>
            [Test]
            public void LabelControlNextYear_3_Time()
            {
                var btnNextYear = GetBtnNextYear();
                btnNextYear.Click();
                btnNextYear.Click();
                btnNextYear.Click();

                LabelControlTest(
                    new decimal[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                );
            }
        }
    }
}
