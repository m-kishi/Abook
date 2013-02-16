namespace AbookTest
{
    using Abook;
    using System;
    using System.Windows.Forms;
    using NUnit.Framework;
    using NUnit.Extensions.Forms;
    using FMT = Abook.AbConstants.FMT;

    /// <summary>
    /// グラフタブテスト
    /// </summary>
    [TestFixture]
    public class AbTestTabGraphic : NUnitFormTest
    {
        /// <summary>引数:DB ファイル</summary>
        private string argDB = "AbTestTabGraphic.db";
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
            tabSummary.SelectTab(2);
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
        /// ヘッダーコントロール取得
        /// </summary>
        /// <param name="form">フォーム</param>
        /// <returns>ヘッダーコントロール</returns>
        private AbHeaderControl GetHeaderControl(Form form)
        {
            var finder = new Finder<AbHeaderControl>("HeadGraphic", form);
            return finder.Find();
        }

        /// <summary>
        /// 前年ボタン取得
        /// </summary>
        /// <returns>前年ボタン</returns>
        private ButtonTester GetBtnPrevYear()
        {
            var btnPrevYear = new ButtonTester("HeadGraphic.BtnPrevYear", abFormMain);
            return btnPrevYear;
        }

        /// <summary>
        /// 前月ボタン取得
        /// </summary>
        /// <returns>前月ボタン</returns>
        private ButtonTester GetBtnPrevMonth()
        {
            var btnPrevMonth = new ButtonTester("HeadGraphic.BtnPrevMonth", abFormMain);
            return btnPrevMonth;
        }

        /// <summary>
        /// 翌月ボタン取得
        /// </summary>
        /// <returns>翌月ボタン</returns>
        private ButtonTester GetBtnNextMonth()
        {
            var btnNextMonth = new ButtonTester("HeadGraphic.BtnNextMonth", abFormMain);
            return btnNextMonth;
        }

        /// <summary>
        /// 翌年ボタン取得
        /// </summary>
        /// <returns>翌年ボタン</returns>
        private ButtonTester GetBtnNextYear()
        {
            var btnNextYear = new ButtonTester("HeadGraphic.BtnNextYear", abFormMain);
            return btnNextYear;
        }

        /// <summary>
        /// タイトルの検証
        /// </summary>
        /// <param name="expect">期待値</param>
        private void HeaderTitleTest(string expect)
        {
            var headGraphic = GetHeaderControl(abFormMain);
            Assert.AreEqual(expect, headGraphic.Title);
        }

        /// <summary>
        /// グラフラベルの検証
        /// </summary>
        /// <param name="date">日付</param>
        private void GraphicLabelTest(DateTime date)
        {
            foreach (var label in new string[] { "LblX6", "LblX5", "LblX4", "LblX3", "LblX2", "LblX1" })
            {
                var lblX = new LabelTester(label, abFormMain);
                Assert.AreEqual(date.ToString(FMT.MONTH), lblX.Text, label);

                date = date.AddMonths(-2);
            }
        }

        /// <summary>
        /// タイトルテスト
        /// 初期表示:システム年月
        /// </summary>
        [Test]
        public void TitleAndGraphWithInitial()
        {
            //明示的に描画イベントを呼び出し
            var pboxGraph = new ControlTester("PboxGraph", abFormMain);
            var g = ((new Finder<PictureBox>("PboxGraph", abFormMain)).Find()).CreateGraphics();
            pboxGraph.FireEvent("Paint", new PaintEventArgs(g, System.Drawing.Rectangle.Empty));

            var date = DateTime.Now;
            HeaderTitleTest(date.ToString(FMT.TITLE));
            GraphicLabelTest(date);
        }

        /// <summary>
        /// タイトルテスト
        /// 前年表示:1年前
        /// </summary>
        [Test]
        public void TitleAndGraphWithPrevYear_1_Time()
        {
            var btnPrevYear = GetBtnPrevYear();
            btnPrevYear.Click();

            var date = DateTime.Now.AddYears(-1);
            HeaderTitleTest(date.ToString(FMT.TITLE));
            GraphicLabelTest(date);
        }

        /// <summary>
        /// タイトルテスト
        /// 前年表示:2年前
        /// </summary>
        [Test]
        public void TitleAndGraphWithPrevYear_2_Time()
        {
            var btnPrevYear = GetBtnPrevYear();
            btnPrevYear.Click();
            btnPrevYear.Click();

            var date = DateTime.Now.AddYears(-2);
            HeaderTitleTest(date.ToString(FMT.TITLE));
            GraphicLabelTest(date);
        }

        /// <summary>
        /// タイトルテスト
        /// 前年表示:3年前
        /// </summary>
        [Test]
        public void TitleAndGraphWithPrevYear_3_Time()
        {
            var btnPrevYear = GetBtnPrevYear();
            btnPrevYear.Click();
            btnPrevYear.Click();
            btnPrevYear.Click();

            var date = DateTime.Now.AddYears(-3);
            HeaderTitleTest(date.ToString(FMT.TITLE));
            GraphicLabelTest(date);
        }

        /// <summary>
        /// タイトルテスト
        /// 前月表示:1ヶ月前
        /// </summary>
        [Test]
        public void TitleAndGraphWithPrevMonth_1_Time()
        {
            var btnPrevMonth = GetBtnPrevMonth();
            btnPrevMonth.Click();

            var date = DateTime.Now.AddMonths(-1);
            HeaderTitleTest(date.ToString(FMT.TITLE));
            GraphicLabelTest(date);
        }

        /// <summary>
        /// タイトルテスト
        /// 前月表示:2ヶ月前
        /// </summary>
        [Test]
        public void TitleAndGraphWithPrevMonth_2_Time()
        {
            var btnPrevMonth = GetBtnPrevMonth();
            btnPrevMonth.Click();
            btnPrevMonth.Click();

            var date = DateTime.Now.AddMonths(-2);
            HeaderTitleTest(date.ToString(FMT.TITLE));
            GraphicLabelTest(date);
        }

        /// <summary>
        /// タイトルテスト
        /// 前月表示:3ヶ月前
        /// </summary>
        [Test]
        public void TitleAndGraphWithPrevMonth_3_Time()
        {
            var btnPrevMonth = GetBtnPrevMonth();
            btnPrevMonth.Click();
            btnPrevMonth.Click();
            btnPrevMonth.Click();

            var date = DateTime.Now.AddMonths(-3);
            HeaderTitleTest(date.ToString(FMT.TITLE));
            GraphicLabelTest(date);
        }

        /// <summary>
        /// タイトルテスト
        /// 翌月表示:1ヶ月後
        /// </summary>
        [Test]
        public void TitleAndGraphWithNextMonth_1_Time()
        {
            var btnNextMonth = GetBtnNextMonth();
            btnNextMonth.Click();

            var date = DateTime.Now.AddMonths(1);
            HeaderTitleTest(date.ToString(FMT.TITLE));
            GraphicLabelTest(date);
        }

        /// <summary>
        /// タイトルテスト
        /// 翌月表示:2ヶ月後
        /// </summary>
        [Test]
        public void TitleAndGraphWithNextMonth_2_Time()
        {
            var btnNextMonth = GetBtnNextMonth();
            btnNextMonth.Click();
            btnNextMonth.Click();

            var date = DateTime.Now.AddMonths(2);
            HeaderTitleTest(date.ToString(FMT.TITLE));
            GraphicLabelTest(date);
        }

        /// <summary>
        /// タイトルテスト
        /// 翌月表示:3ヶ月後
        /// </summary>
        [Test]
        public void TitleAndGraphWithNextMonth_3_Time()
        {
            var btnNextMonth = GetBtnNextMonth();
            btnNextMonth.Click();
            btnNextMonth.Click();
            btnNextMonth.Click();

            var date = DateTime.Now.AddMonths(3);
            HeaderTitleTest(date.ToString(FMT.TITLE));
            GraphicLabelTest(date);
        }

        /// <summary>
        /// タイトルテスト
        /// 翌年表示:1年後
        /// </summary>
        [Test]
        public void TitleAndGraphWithNextYear_1_Time()
        {
            var btnNextYear = GetBtnNextYear();
            btnNextYear.Click();

            var date = DateTime.Now.AddYears(1);
            HeaderTitleTest(date.ToString(FMT.TITLE));
            GraphicLabelTest(date);
        }

        /// <summary>
        /// タイトルテスト
        /// 翌年表示:2年後
        /// </summary>
        [Test]
        public void TitleAndGraphWithNextYear_2_Time()
        {
            var btnNextYear = GetBtnNextYear();
            btnNextYear.Click();
            btnNextYear.Click();

            var date = DateTime.Now.AddYears(2);
            HeaderTitleTest(date.ToString(FMT.TITLE));
            GraphicLabelTest(date);
        }

        /// <summary>
        /// タイトルテスト
        /// 翌年表示:3年後
        /// </summary>
        [Test]
        public void TitleAndGraphWithNextYear_3_Time()
        {
            var btnNextYear = GetBtnNextYear();
            btnNextYear.Click();
            btnNextYear.Click();
            btnNextYear.Click();

            var date = DateTime.Now.AddYears(3);
            HeaderTitleTest(date.ToString(FMT.TITLE));
            GraphicLabelTest(date);
        }
    }
}
