﻿// ------------------------------------------------------------
// © 2010 https://github.com/m-kishi
// ------------------------------------------------------------
namespace AbookTest
{
    using System;
    using System.IO;
    using System.Windows.Forms;
    using NUnit.Framework;
    using NUnit.Extensions.Forms;
    using FMT = Abook.AbConstants.FMT;

    /// <summary>
    /// 推移タブテスト
    /// </summary>
    [TestFixture]
    public class AbTestTabGraphic : AbTestFormBase
    {
        /// <summary>DBファイル</summary>
        private const string DB_FILE = "AbTestTabGraphic.db";
        /// <summary>タブインデックス</summary>
        private const int TAB_IDX = 2;

        /// <summary>
        /// TestFixtureTearDown
        /// </summary>
        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            if (File.Exists(DB_FILE)) File.Delete(DB_FILE);
        }

        /// <summary>
        /// タイトルテスト
        /// 初期表示:システム年月
        /// </summary>
        [Test]
        public void TitleWithInitial()
        {
            ShowFormMain(DB_FILE, TAB_IDX);

            // 明示的に描画イベントを呼び出し
            var g = CtPboxGraph().CreateGraphics();
            TsPboxGraph().FireEvent("Paint", new PaintEventArgs(g, System.Drawing.Rectangle.Empty));

            var title = DateTime.Now.ToString(FMT.TITLE);
            Assert.AreEqual(title, CtHeadGraphic().Title);
        }

        /// <summary>
        /// タイトルテスト
        /// 前年表示:1年前
        /// </summary>
        [Test]
        public void TitleWithPrevYear_1_Time()
        {
            ShowFormMain(DB_FILE, TAB_IDX);

            TsGraphicBtnPrevYear().Click();

            var title = DateTime.Now.AddYears(-1).ToString(FMT.TITLE);
            Assert.AreEqual(title, CtHeadGraphic().Title);
        }

        /// <summary>
        /// タイトルテスト
        /// 前年表示:2年前
        /// </summary>
        [Test]
        public void TitleWithPrevYear_2_Time()
        {
            ShowFormMain(DB_FILE, TAB_IDX);

            TsGraphicBtnPrevYear().Click();
            TsGraphicBtnPrevYear().Click();

            var title = DateTime.Now.AddYears(-2).ToString(FMT.TITLE);
            Assert.AreEqual(title, CtHeadGraphic().Title);
        }

        /// <summary>
        /// タイトルテスト
        /// 前年表示:3年前
        /// </summary>
        [Test]
        public void TitleWithPrevYear_3_Time()
        {
            ShowFormMain(DB_FILE, TAB_IDX);

            TsGraphicBtnPrevYear().Click();
            TsGraphicBtnPrevYear().Click();
            TsGraphicBtnPrevYear().Click();

            var title = DateTime.Now.AddYears(-3).ToString(FMT.TITLE);
            Assert.AreEqual(title, CtHeadGraphic().Title);
        }

        /// <summary>
        /// タイトルテスト
        /// 前月表示:1ヶ月前
        /// </summary>
        [Test]
        public void TitleWithPrevMonth_1_Time()
        {
            ShowFormMain(DB_FILE, TAB_IDX);

            TsGraphicBtnPrevMonth().Click();

            var title = DateTime.Now.AddMonths(-1).ToString(FMT.TITLE);
            Assert.AreEqual(title, CtHeadGraphic().Title);
        }

        /// <summary>
        /// タイトルテスト
        /// 前月表示:2ヶ月前
        /// </summary>
        [Test]
        public void TitleWithPrevMonth_2_Time()
        {
            ShowFormMain(DB_FILE, TAB_IDX);

            TsGraphicBtnPrevMonth().Click();
            TsGraphicBtnPrevMonth().Click();

            var title = DateTime.Now.AddMonths(-2).ToString(FMT.TITLE);
            Assert.AreEqual(title, CtHeadGraphic().Title);
        }

        /// <summary>
        /// タイトルテスト
        /// 前月表示:3ヶ月前
        /// </summary>
        [Test]
        public void TitleWithPrevMonth_3_Time()
        {
            ShowFormMain(DB_FILE, TAB_IDX);

            TsGraphicBtnPrevMonth().Click();
            TsGraphicBtnPrevMonth().Click();
            TsGraphicBtnPrevMonth().Click();

            var title = DateTime.Now.AddMonths(-3).ToString(FMT.TITLE);
            Assert.AreEqual(title, CtHeadGraphic().Title);
        }

        /// <summary>
        /// タイトルテスト
        /// 翌月表示:1ヶ月後
        /// </summary>
        [Test]
        public void TitleWithNextMonth_1_Time()
        {
            ShowFormMain(DB_FILE, TAB_IDX);

            TsGraphicBtnNextMonth().Click();

            var title = DateTime.Now.AddMonths(1).ToString(FMT.TITLE);
            Assert.AreEqual(title, CtHeadGraphic().Title);
        }

        /// <summary>
        /// タイトルテスト
        /// 翌月表示:2ヶ月後
        /// </summary>
        [Test]
        public void TitleWithNextMonth_2_Time()
        {
            ShowFormMain(DB_FILE, TAB_IDX);

            TsGraphicBtnNextMonth().Click();
            TsGraphicBtnNextMonth().Click();

            var title = DateTime.Now.AddMonths(2).ToString(FMT.TITLE);
            Assert.AreEqual(title, CtHeadGraphic().Title);
        }

        /// <summary>
        /// タイトルテスト
        /// 翌月表示:3ヶ月後
        /// </summary>
        [Test]
        public void TitleWithNextMonth_3_Time()
        {
            ShowFormMain(DB_FILE, TAB_IDX);

            TsGraphicBtnNextMonth().Click();
            TsGraphicBtnNextMonth().Click();
            TsGraphicBtnNextMonth().Click();

            var title = DateTime.Now.AddMonths(3).ToString(FMT.TITLE);
            Assert.AreEqual(title, CtHeadGraphic().Title);
        }

        /// <summary>
        /// タイトルテスト
        /// 翌年表示:1年後
        /// </summary>
        [Test]
        public void TitleWithNextYear_1_Time()
        {
            ShowFormMain(DB_FILE, TAB_IDX);

            TsGraphicBtnNextYear().Click();

            var title = DateTime.Now.AddYears(1).ToString(FMT.TITLE);
            Assert.AreEqual(title, CtHeadGraphic().Title);
        }

        /// <summary>
        /// タイトルテスト
        /// 翌年表示:2年後
        /// </summary>
        [Test]
        public void TitleWithNextYear_2_Time()
        {
            ShowFormMain(DB_FILE, TAB_IDX);

            TsGraphicBtnNextYear().Click();
            TsGraphicBtnNextYear().Click();

            var title = DateTime.Now.AddYears(2).ToString(FMT.TITLE);
            Assert.AreEqual(title, CtHeadGraphic().Title);
        }

        /// <summary>
        /// タイトルテスト
        /// 翌年表示:3年後
        /// </summary>
        [Test]
        public void TitleWithNextYear_3_Time()
        {
            ShowFormMain(DB_FILE, TAB_IDX);

            TsGraphicBtnNextYear().Click();
            TsGraphicBtnNextYear().Click();
            TsGraphicBtnNextYear().Click();

            var title = DateTime.Now.AddYears(3).ToString(FMT.TITLE);
            Assert.AreEqual(title, CtHeadGraphic().Title);
        }

        /// <summary>
        /// ラベルのテスト
        /// </summary>
        /// <param name="date">日付</param>
        private void TestGraphicLabel(DateTime date)
        {
            var now = date.AddMonths(2);
            foreach (var label in new string[] { "LblX6", "LblX5", "LblX4", "LblX3", "LblX2", "LblX1" })
            {
                var lblX = new LabelTester(label, form);
                Assert.AreEqual((now = now.AddMonths(-2)).ToString(FMT.MONTH), lblX.Text, label);
            }
        }

        /// <summary>
        /// ラベルテスト
        /// 初期表示:システム年月
        /// </summary>
        [Test]
        public void LabelWithInitial()
        {
            ShowFormMain(DB_FILE, TAB_IDX);

            // 明示的に描画イベントを呼び出し
            var g = CtPboxGraph().CreateGraphics();
            TsPboxGraph().FireEvent("Paint", new PaintEventArgs(g, System.Drawing.Rectangle.Empty));

            TestGraphicLabel(DateTime.Now);
        }

        /// <summary>
        /// ラベルテスト
        /// 前年表示:1年前
        /// </summary>
        [Test]
        public void LabelWithPrevYear_1_Time()
        {
            ShowFormMain(DB_FILE, TAB_IDX);

            TsGraphicBtnPrevYear().Click();

            TestGraphicLabel(DateTime.Now.AddYears(-1));
        }

        /// <summary>
        /// ラベルテスト
        /// 前年表示:2年前
        /// </summary>
        [Test]
        public void LabelWithPrevYear_2_Time()
        {
            ShowFormMain(DB_FILE, TAB_IDX);

            TsGraphicBtnPrevYear().Click();
            TsGraphicBtnPrevYear().Click();

            TestGraphicLabel(DateTime.Now.AddYears(-2));
        }

        /// <summary>
        /// ラベルテスト
        /// 前年表示:3年前
        /// </summary>
        [Test]
        public void LabelWithPrevYear_3_Time()
        {
            ShowFormMain(DB_FILE, TAB_IDX);

            TsGraphicBtnPrevYear().Click();
            TsGraphicBtnPrevYear().Click();
            TsGraphicBtnPrevYear().Click();

            TestGraphicLabel(DateTime.Now.AddYears(-3));
        }

        /// <summary>
        /// ラベルテスト
        /// 前月表示:1ヶ月前
        /// </summary>
        [Test]
        public void LabelWithPrevMonth_1_Time()
        {
            ShowFormMain(DB_FILE, TAB_IDX);

            TsGraphicBtnPrevMonth().Click();

            TestGraphicLabel(DateTime.Now.AddMonths(-1));
        }

        /// <summary>
        /// ラベルテスト
        /// 前月表示:2ヶ月前
        /// </summary>
        [Test]
        public void LabelWithPrevMonth_2_Time()
        {
            ShowFormMain(DB_FILE, TAB_IDX);

            TsGraphicBtnPrevMonth().Click();
            TsGraphicBtnPrevMonth().Click();

            TestGraphicLabel(DateTime.Now.AddMonths(-2));
        }

        /// <summary>
        /// ラベルテスト
        /// 前月表示:3ヶ月前
        /// </summary>
        [Test]
        public void LabelWithPrevMonth_3_Time()
        {
            ShowFormMain(DB_FILE, TAB_IDX);

            TsGraphicBtnPrevMonth().Click();
            TsGraphicBtnPrevMonth().Click();
            TsGraphicBtnPrevMonth().Click();

            TestGraphicLabel(DateTime.Now.AddMonths(-3));
        }

        /// <summary>
        /// ラベルテスト
        /// 翌月表示:1ヶ月後
        /// </summary>
        [Test]
        public void LabelWithNextMonth_1_Time()
        {
            ShowFormMain(DB_FILE, TAB_IDX);

            TsGraphicBtnNextMonth().Click();

            TestGraphicLabel(DateTime.Now.AddMonths(1));
        }

        /// <summary>
        /// ラベルテスト
        /// 翌月表示:2ヶ月後
        /// </summary>
        [Test]
        public void LabelWithNextMonth_2_Time()
        {
            ShowFormMain(DB_FILE, TAB_IDX);

            TsGraphicBtnNextMonth().Click();
            TsGraphicBtnNextMonth().Click();

            TestGraphicLabel(DateTime.Now.AddMonths(2));
        }

        /// <summary>
        /// ラベルテスト
        /// 翌月表示:3ヶ月後
        /// </summary>
        [Test]
        public void LabelWithNextMonth_3_Time()
        {
            ShowFormMain(DB_FILE, TAB_IDX);

            TsGraphicBtnNextMonth().Click();
            TsGraphicBtnNextMonth().Click();
            TsGraphicBtnNextMonth().Click();

            TestGraphicLabel(DateTime.Now.AddMonths(3));
        }

        /// <summary>
        /// ラベルテスト
        /// 翌年表示:1年後
        /// </summary>
        [Test]
        public void LabelWithNextYear_1_Time()
        {
            ShowFormMain(DB_FILE, TAB_IDX);

            TsGraphicBtnNextYear().Click();

            TestGraphicLabel(DateTime.Now.AddYears(1));
        }

        /// <summary>
        /// ラベルテスト
        /// 翌年表示:2年後
        /// </summary>
        [Test]
        public void LabelWithNextYear_2_Time()
        {
            ShowFormMain(DB_FILE, TAB_IDX);

            TsGraphicBtnNextYear().Click();
            TsGraphicBtnNextYear().Click();

            TestGraphicLabel(DateTime.Now.AddYears(2));
        }

        /// <summary>
        /// ラベルテスト
        /// 翌年表示:3年後
        /// </summary>
        [Test]
        public void LabelWithNextYear_3_Time()
        {
            ShowFormMain(DB_FILE, TAB_IDX);

            TsGraphicBtnNextYear().Click();
            TsGraphicBtnNextYear().Click();
            TsGraphicBtnNextYear().Click();

            TestGraphicLabel(DateTime.Now.AddYears(3));
        }
    }
}
