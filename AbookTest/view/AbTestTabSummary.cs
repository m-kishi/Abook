﻿namespace AbookTest
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
    [TestFixture]
    public class AbTestTabSummary : AbTestFormBase
    {
        /// <summary>DB ファイル</summary>
        private const string DB_EXIST = "AbTestTabSummaryExist.db";
        /// <summary>DB ファイル</summary>
        private const string DB_EMPTY = "AbTestTabSummaryEmpty.db";
        /// <summary>タブインデックス</summary>
        private const int TAB_IDX = 1;

        /// <summary>
        /// TestFixtureSetUp
        /// </summary>
        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            using (StreamWriter sw = new StreamWriter(DB_EXIST, false, System.Text.Encoding.UTF8))
            {
                var dtNow = DateTime.Now.ToString(FMT.DATE);
                sw.WriteLine(ToCSV(dtNow, "name", TYPE.FOOD,  "10000"));
                sw.WriteLine(ToCSV(dtNow, "name", TYPE.OTFD,  "15000"));
                sw.WriteLine(ToCSV(dtNow, "name", TYPE.GOOD,   "1200"));
                sw.WriteLine(ToCSV(dtNow, "name", TYPE.FRND,   "5000"));
                sw.WriteLine(ToCSV(dtNow, "name", TYPE.TRFC,    "200"));
                sw.WriteLine(ToCSV(dtNow, "name", TYPE.PLAY,   "3000"));
                sw.WriteLine(ToCSV(dtNow, "name", TYPE.HOUS,  "40000"));
                sw.WriteLine(ToCSV(dtNow, "name", TYPE.ENGY,   "8000"));
                sw.WriteLine(ToCSV(dtNow, "name", TYPE.CNCT,   "2000"));
                sw.WriteLine(ToCSV(dtNow, "name", TYPE.MEDI,   "1700"));
                sw.WriteLine(ToCSV(dtNow, "name", TYPE.INSU,   "2700"));
                sw.WriteLine(ToCSV(dtNow, "name", TYPE.OTHR,    "500"));
                sw.WriteLine(ToCSV(dtNow, "name", TYPE.EARN, "150000"));

                var dtPrevYear1 = DateTime.Now.AddYears(-1).ToString(FMT.DATE);
                sw.WriteLine(ToCSV(dtPrevYear1, "name", TYPE.FOOD,  "10100"));
                sw.WriteLine(ToCSV(dtPrevYear1, "name", TYPE.OTFD,  "15100"));
                sw.WriteLine(ToCSV(dtPrevYear1, "name", TYPE.GOOD,   "1300"));
                sw.WriteLine(ToCSV(dtPrevYear1, "name", TYPE.FRND,   "5100"));
                sw.WriteLine(ToCSV(dtPrevYear1, "name", TYPE.TRFC,    "300"));
                sw.WriteLine(ToCSV(dtPrevYear1, "name", TYPE.PLAY,   "3100"));
                sw.WriteLine(ToCSV(dtPrevYear1, "name", TYPE.HOUS,  "40100"));
                sw.WriteLine(ToCSV(dtPrevYear1, "name", TYPE.ENGY,   "8100"));
                sw.WriteLine(ToCSV(dtPrevYear1, "name", TYPE.CNCT,   "2100"));
                sw.WriteLine(ToCSV(dtPrevYear1, "name", TYPE.MEDI,   "1800"));
                sw.WriteLine(ToCSV(dtPrevYear1, "name", TYPE.INSU,   "2800"));
                sw.WriteLine(ToCSV(dtPrevYear1, "name", TYPE.OTHR,    "600"));
                sw.WriteLine(ToCSV(dtPrevYear1, "name", TYPE.EARN, "150100"));

                var dtPrevYear2 = DateTime.Now.AddYears(-2).ToString(FMT.DATE);
                sw.WriteLine(ToCSV(dtPrevYear2, "name", TYPE.FOOD,  "10200"));
                sw.WriteLine(ToCSV(dtPrevYear2, "name", TYPE.OTFD,  "15200"));
                sw.WriteLine(ToCSV(dtPrevYear2, "name", TYPE.GOOD,   "1400"));
                sw.WriteLine(ToCSV(dtPrevYear2, "name", TYPE.FRND,   "5200"));
                sw.WriteLine(ToCSV(dtPrevYear2, "name", TYPE.TRFC,    "400"));
                sw.WriteLine(ToCSV(dtPrevYear2, "name", TYPE.PLAY,   "3200"));
                sw.WriteLine(ToCSV(dtPrevYear2, "name", TYPE.HOUS,  "40200"));
                sw.WriteLine(ToCSV(dtPrevYear2, "name", TYPE.ENGY,   "8200"));
                sw.WriteLine(ToCSV(dtPrevYear2, "name", TYPE.CNCT,   "2200"));
                sw.WriteLine(ToCSV(dtPrevYear2, "name", TYPE.MEDI,   "1900"));
                sw.WriteLine(ToCSV(dtPrevYear2, "name", TYPE.INSU,   "2900"));
                sw.WriteLine(ToCSV(dtPrevYear2, "name", TYPE.OTHR,    "700"));
                sw.WriteLine(ToCSV(dtPrevYear2, "name", TYPE.EARN, "150200"));

                var dtPrevMonth1 = DateTime.Now.AddMonths(-1).ToString(FMT.DATE);
                sw.WriteLine(ToCSV(dtPrevMonth1, "name", TYPE.FOOD,  "10300"));
                sw.WriteLine(ToCSV(dtPrevMonth1, "name", TYPE.OTFD,  "15300"));
                sw.WriteLine(ToCSV(dtPrevMonth1, "name", TYPE.GOOD,   "1500"));
                sw.WriteLine(ToCSV(dtPrevMonth1, "name", TYPE.FRND,   "5300"));
                sw.WriteLine(ToCSV(dtPrevMonth1, "name", TYPE.TRFC,    "500"));
                sw.WriteLine(ToCSV(dtPrevMonth1, "name", TYPE.PLAY,   "3300"));
                sw.WriteLine(ToCSV(dtPrevMonth1, "name", TYPE.HOUS,  "40300"));
                sw.WriteLine(ToCSV(dtPrevMonth1, "name", TYPE.ENGY,   "8300"));
                sw.WriteLine(ToCSV(dtPrevMonth1, "name", TYPE.CNCT,   "2300"));
                sw.WriteLine(ToCSV(dtPrevMonth1, "name", TYPE.MEDI,   "2000"));
                sw.WriteLine(ToCSV(dtPrevMonth1, "name", TYPE.INSU,   "3000"));
                sw.WriteLine(ToCSV(dtPrevMonth1, "name", TYPE.OTHR,    "800"));
                sw.WriteLine(ToCSV(dtPrevMonth1, "name", TYPE.EARN, "150300"));

                var dtPrevMonth2 = DateTime.Now.AddMonths(-2).ToString(FMT.DATE);
                sw.WriteLine(ToCSV(dtPrevMonth2, "name", TYPE.FOOD,  "10400"));
                sw.WriteLine(ToCSV(dtPrevMonth2, "name", TYPE.OTFD,  "15400"));
                sw.WriteLine(ToCSV(dtPrevMonth2, "name", TYPE.GOOD,   "1600"));
                sw.WriteLine(ToCSV(dtPrevMonth2, "name", TYPE.FRND,   "5400"));
                sw.WriteLine(ToCSV(dtPrevMonth2, "name", TYPE.TRFC,    "600"));
                sw.WriteLine(ToCSV(dtPrevMonth2, "name", TYPE.PLAY,   "3400"));
                sw.WriteLine(ToCSV(dtPrevMonth2, "name", TYPE.HOUS,  "40400"));
                sw.WriteLine(ToCSV(dtPrevMonth2, "name", TYPE.ENGY,   "8400"));
                sw.WriteLine(ToCSV(dtPrevMonth2, "name", TYPE.CNCT,   "2400"));
                sw.WriteLine(ToCSV(dtPrevMonth2, "name", TYPE.MEDI,   "2100"));
                sw.WriteLine(ToCSV(dtPrevMonth2, "name", TYPE.INSU,   "3100"));
                sw.WriteLine(ToCSV(dtPrevMonth2, "name", TYPE.OTHR,    "900"));
                sw.WriteLine(ToCSV(dtPrevMonth2, "name", TYPE.EARN, "150400"));

                var dtNextMonth1 = DateTime.Now.AddMonths(1).ToString(FMT.DATE);
                sw.WriteLine(ToCSV(dtNextMonth1, "name", TYPE.FOOD,  "10500"));
                sw.WriteLine(ToCSV(dtNextMonth1, "name", TYPE.OTFD,  "15500"));
                sw.WriteLine(ToCSV(dtNextMonth1, "name", TYPE.GOOD,   "1700"));
                sw.WriteLine(ToCSV(dtNextMonth1, "name", TYPE.FRND,   "5500"));
                sw.WriteLine(ToCSV(dtNextMonth1, "name", TYPE.TRFC,    "700"));
                sw.WriteLine(ToCSV(dtNextMonth1, "name", TYPE.PLAY,   "3500"));
                sw.WriteLine(ToCSV(dtNextMonth1, "name", TYPE.HOUS,  "40500"));
                sw.WriteLine(ToCSV(dtNextMonth1, "name", TYPE.ENGY,   "8500"));
                sw.WriteLine(ToCSV(dtNextMonth1, "name", TYPE.CNCT,   "2500"));
                sw.WriteLine(ToCSV(dtNextMonth1, "name", TYPE.MEDI,   "2200"));
                sw.WriteLine(ToCSV(dtNextMonth1, "name", TYPE.INSU,   "3200"));
                sw.WriteLine(ToCSV(dtNextMonth1, "name", TYPE.OTHR,   "1000"));
                sw.WriteLine(ToCSV(dtNextMonth1, "name", TYPE.EARN, "150500"));

                var dtNextMonth2 = DateTime.Now.AddMonths(2).ToString(FMT.DATE);
                sw.WriteLine(ToCSV(dtNextMonth2, "name", TYPE.FOOD,  "10600"));
                sw.WriteLine(ToCSV(dtNextMonth2, "name", TYPE.OTFD,  "15600"));
                sw.WriteLine(ToCSV(dtNextMonth2, "name", TYPE.GOOD,   "1800"));
                sw.WriteLine(ToCSV(dtNextMonth2, "name", TYPE.FRND,   "5600"));
                sw.WriteLine(ToCSV(dtNextMonth2, "name", TYPE.TRFC,    "800"));
                sw.WriteLine(ToCSV(dtNextMonth2, "name", TYPE.PLAY,   "3600"));
                sw.WriteLine(ToCSV(dtNextMonth2, "name", TYPE.HOUS,  "40600"));
                sw.WriteLine(ToCSV(dtNextMonth2, "name", TYPE.ENGY,   "8600"));
                sw.WriteLine(ToCSV(dtNextMonth2, "name", TYPE.CNCT,   "2600"));
                sw.WriteLine(ToCSV(dtNextMonth2, "name", TYPE.MEDI,   "2300"));
                sw.WriteLine(ToCSV(dtNextMonth2, "name", TYPE.INSU,   "3300"));
                sw.WriteLine(ToCSV(dtNextMonth2, "name", TYPE.OTHR,   "1100"));
                sw.WriteLine(ToCSV(dtNextMonth2, "name", TYPE.EARN, "150600"));

                var dtNextYear1 = DateTime.Now.AddYears(1).ToString(FMT.DATE);
                sw.WriteLine(ToCSV(dtNextYear1, "name", TYPE.FOOD,  "10700"));
                sw.WriteLine(ToCSV(dtNextYear1, "name", TYPE.OTFD,  "15700"));
                sw.WriteLine(ToCSV(dtNextYear1, "name", TYPE.GOOD,   "1900"));
                sw.WriteLine(ToCSV(dtNextYear1, "name", TYPE.FRND,   "5700"));
                sw.WriteLine(ToCSV(dtNextYear1, "name", TYPE.TRFC,    "900"));
                sw.WriteLine(ToCSV(dtNextYear1, "name", TYPE.PLAY,   "3700"));
                sw.WriteLine(ToCSV(dtNextYear1, "name", TYPE.HOUS,  "40700"));
                sw.WriteLine(ToCSV(dtNextYear1, "name", TYPE.ENGY,   "8700"));
                sw.WriteLine(ToCSV(dtNextYear1, "name", TYPE.CNCT,   "2700"));
                sw.WriteLine(ToCSV(dtNextYear1, "name", TYPE.MEDI,   "2400"));
                sw.WriteLine(ToCSV(dtNextYear1, "name", TYPE.INSU,   "3400"));
                sw.WriteLine(ToCSV(dtNextYear1, "name", TYPE.OTHR,   "1200"));
                sw.WriteLine(ToCSV(dtNextYear1, "name", TYPE.EARN, "150700"));

                var dtNextYear2 = DateTime.Now.AddYears(2).ToString(FMT.DATE);
                sw.WriteLine(ToCSV(dtNextYear2, "name", TYPE.FOOD,  "10800"));
                sw.WriteLine(ToCSV(dtNextYear2, "name", TYPE.OTFD,  "15800"));
                sw.WriteLine(ToCSV(dtNextYear2, "name", TYPE.GOOD,   "2000"));
                sw.WriteLine(ToCSV(dtNextYear2, "name", TYPE.FRND,   "5800"));
                sw.WriteLine(ToCSV(dtNextYear2, "name", TYPE.TRFC,   "1000"));
                sw.WriteLine(ToCSV(dtNextYear2, "name", TYPE.PLAY,   "3800"));
                sw.WriteLine(ToCSV(dtNextYear2, "name", TYPE.HOUS,  "40800"));
                sw.WriteLine(ToCSV(dtNextYear2, "name", TYPE.ENGY,   "8800"));
                sw.WriteLine(ToCSV(dtNextYear2, "name", TYPE.CNCT,   "2800"));
                sw.WriteLine(ToCSV(dtNextYear2, "name", TYPE.MEDI,   "2500"));
                sw.WriteLine(ToCSV(dtNextYear2, "name", TYPE.INSU,   "3500"));
                sw.WriteLine(ToCSV(dtNextYear2, "name", TYPE.OTHR,   "1300"));
                sw.WriteLine(ToCSV(dtNextYear2, "name", TYPE.EARN, "150800"));
            }
        }

        /// <summary>
        /// TestFixtureTearDown
        /// </summary>
        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            if (System.IO.File.Exists(DB_EXIST)) System.IO.File.Delete(DB_EXIST);
            if (System.IO.File.Exists(DB_EMPTY)) System.IO.File.Delete(DB_EMPTY);
        }

        /// <summary>
        /// タイトルテスト
        /// 初期表示:システム年月
        /// </summary>
        [Test]
        public void TitleWithInitial()
        {
            ShowFormMain(DB_EXIST, TAB_IDX);

            var title = DateTime.Now.ToString(FMT.TITLE);
            Assert.AreEqual(title, CtHeadSummary().Title);
        }

        /// <summary>
        /// タイトルテスト
        /// 前年表示:1年前
        /// </summary>
        [Test]
        public void TitleWithPrevYear_1_Time()
        {
            ShowFormMain(DB_EXIST, TAB_IDX);

            TsSummaryBtnPrevYear().Click();

            var title = DateTime.Now.AddYears(-1).ToString(FMT.TITLE);
            Assert.AreEqual(title, CtHeadSummary().Title);
        }

        /// <summary>
        /// タイトルテスト
        /// 前年表示:2年前
        /// </summary>
        [Test]
        public void TitleWithPrevYear_2_Time()
        {
            ShowFormMain(DB_EXIST, TAB_IDX);

            TsSummaryBtnPrevYear().Click();
            TsSummaryBtnPrevYear().Click();

            var title = DateTime.Now.AddYears(-2).ToString(FMT.TITLE);
            Assert.AreEqual(title, CtHeadSummary().Title);
        }

        /// <summary>
        /// タイトルテスト
        /// 前年表示:3年前
        /// </summary>
        [Test]
        public void TitleWithPrevYear_3_Time()
        {
            ShowFormMain(DB_EXIST, TAB_IDX);

            TsSummaryBtnPrevYear().Click();
            TsSummaryBtnPrevYear().Click();
            TsSummaryBtnPrevYear().Click();

            var title = DateTime.Now.AddYears(-3).ToString(FMT.TITLE);
            Assert.AreEqual(title, CtHeadSummary().Title);
        }

        /// <summary>
        /// タイトルテスト
        /// 前月表示:1ヶ月前
        /// </summary>
        [Test]
        public void TitleWithPrevMonth_1_Time()
        {
            ShowFormMain(DB_EXIST, TAB_IDX);

            TsSummaryBtnPrevMonth().Click();

            var title = DateTime.Now.AddMonths(-1).ToString(FMT.TITLE);
            Assert.AreEqual(title, CtHeadSummary().Title);
        }

        /// <summary>
        /// タイトルテスト
        /// 前月表示:2ヶ月前
        /// </summary>
        [Test]
        public void TitleWithPrevMonth_2_Time()
        {
            ShowFormMain(DB_EXIST, TAB_IDX);

            TsSummaryBtnPrevMonth().Click();
            TsSummaryBtnPrevMonth().Click();

            var title = DateTime.Now.AddMonths(-2).ToString(FMT.TITLE);
            Assert.AreEqual(title, CtHeadSummary().Title);
        }

        /// <summary>
        /// タイトルテスト
        /// 前月表示:3ヶ月前
        /// </summary>
        [Test]
        public void TitleWithPrevMonth_3_Time()
        {
            ShowFormMain(DB_EXIST, TAB_IDX);

            TsSummaryBtnPrevMonth().Click();
            TsSummaryBtnPrevMonth().Click();
            TsSummaryBtnPrevMonth().Click();

            var title = DateTime.Now.AddMonths(-3).ToString(FMT.TITLE);
            Assert.AreEqual(title, CtHeadSummary().Title);
        }

        /// <summary>
        /// タイトルテスト
        /// 翌月表示:1ヶ月後
        /// </summary>
        [Test]
        public void TitleWithNextMonth_1_Time()
        {
            ShowFormMain(DB_EXIST, TAB_IDX);

            TsSummaryBtnNextMonth().Click();

            var title = DateTime.Now.AddMonths(1).ToString(FMT.TITLE);
            Assert.AreEqual(title, CtHeadSummary().Title);
        }

        /// <summary>
        /// タイトルテスト
        /// 翌月表示:2ヶ月後
        /// </summary>
        [Test]
        public void TitleWithNextMonth_2_Time()
        {
            ShowFormMain(DB_EXIST, TAB_IDX);

            TsSummaryBtnNextMonth().Click();
            TsSummaryBtnNextMonth().Click();

            var title = DateTime.Now.AddMonths(2).ToString(FMT.TITLE);
            Assert.AreEqual(title, CtHeadSummary().Title);
        }

        /// <summary>
        /// タイトルテスト
        /// 翌月表示:3ヶ月後
        /// </summary>
        [Test]
        public void TitleWithNextMonth_3_Time()
        {
            ShowFormMain(DB_EXIST, TAB_IDX);

            TsSummaryBtnNextMonth().Click();
            TsSummaryBtnNextMonth().Click();
            TsSummaryBtnNextMonth().Click();

            var title = DateTime.Now.AddMonths(3).ToString(FMT.TITLE);
            Assert.AreEqual(title, CtHeadSummary().Title);
        }

        /// <summary>
        /// タイトルテスト
        /// 翌年表示:1年後
        /// </summary>
        [Test]
        public void TitleWithNextYear_1_Time()
        {
            ShowFormMain(DB_EXIST, TAB_IDX);

            TsSummaryBtnNextYear().Click();

            var title = DateTime.Now.AddYears(1).ToString(FMT.TITLE);
            Assert.AreEqual(title, CtHeadSummary().Title);
        }

        /// <summary>
        /// タイトルテスト
        /// 翌年表示:2年後
        /// </summary>
        [Test]
        public void TitleWithNextYear_2_Time()
        {
            ShowFormMain(DB_EXIST, TAB_IDX);

            TsSummaryBtnNextYear().Click();
            TsSummaryBtnNextYear().Click();

            var title = DateTime.Now.AddYears(2).ToString(FMT.TITLE);
            Assert.AreEqual(title, CtHeadSummary().Title);
        }

        /// <summary>
        /// タイトルテスト
        /// 翌年表示:3年後
        /// </summary>
        [Test]
        public void TitleWithNextYear_3_Time()
        {
            ShowFormMain(DB_EXIST, TAB_IDX);

            TsSummaryBtnNextYear().Click();
            TsSummaryBtnNextYear().Click();
            TsSummaryBtnNextYear().Click();

            var title = DateTime.Now.AddYears(3).ToString(FMT.TITLE);
            Assert.AreEqual(title, CtHeadSummary().Title);
        }

        /// <summary>
        /// ラベルコントロールの金額テスト
        /// </summary>
        /// <param name="costs">金額配列</param>
        private void LabelControlTest(decimal[] costs)
        {
            Assert.AreEqual(costs[ 0], CtAbLabel("LblFood").Cost, "LblFood");
            Assert.AreEqual(costs[ 1], CtAbLabel("LblOtfd").Cost, "LblOtfd");
            Assert.AreEqual(costs[ 2], CtAbLabel("LblGood").Cost, "LblGood");
            Assert.AreEqual(costs[ 3], CtAbLabel("LblFrnd").Cost, "LblFrnd");
            Assert.AreEqual(costs[ 4], CtAbLabel("LblTrfc").Cost, "LblTrfc");
            Assert.AreEqual(costs[ 5], CtAbLabel("LblPlay").Cost, "LblPlay");
            Assert.AreEqual(costs[ 6], CtAbLabel("LblHous").Cost, "LblHous");
            Assert.AreEqual(costs[ 7], CtAbLabel("LblEngy").Cost, "LblEngy");
            Assert.AreEqual(costs[ 8], CtAbLabel("LblCnct").Cost, "LblCnct");
            Assert.AreEqual(costs[ 9], CtAbLabel("LblMedi").Cost, "LblMedi");
            Assert.AreEqual(costs[10], CtAbLabel("LblInsu").Cost, "LblInsu");
            Assert.AreEqual(costs[11], CtAbLabel("LblOthr").Cost, "LblOthr");
            Assert.AreEqual(costs[12], CtAbLabel("LblTtal").Cost, "LblTtal");
            Assert.AreEqual(costs[13], CtAbLabel("LblBlnc").Cost, "LblBlnc");
        }

        /// <summary>
        /// ラベルテスト
        /// 初期表示
        /// </summary>
        [Test]
        public void LabelWithInitial()
        {
            ShowFormMain(DB_EXIST, TAB_IDX);

            LabelControlTest(
                new decimal[] { 10000, 15000, 1200, 5000, 200, 3000, 40000, 8000, 2000, 1700, 2700, 500, 89300, 60700 }
            );
        }

        /// <summary>
        /// ラベルテスト
        /// 前年表示:1年前
        /// </summary>
        [Test]
        public void LabelWithPrevYear_1_Time()
        {
            ShowFormMain(DB_EXIST, TAB_IDX);

            TsSummaryBtnPrevYear().Click();

            LabelControlTest(
                new decimal[] { 10100, 15100, 1300, 5100, 300, 3100, 40100, 8100, 2100, 1800, 2800, 600, 90500, 59600 }
            );
        }

        /// <summary>
        /// ラベルテスト
        /// 前年表示:2年前
        /// </summary>
        [Test]
        public void LabelWithPrevYear_2_Time()
        {
            ShowFormMain(DB_EXIST, TAB_IDX);

            TsSummaryBtnPrevYear().Click();
            TsSummaryBtnPrevYear().Click();

            LabelControlTest(
                new decimal[] { 10200, 15200, 1400, 5200, 400, 3200, 40200, 8200, 2200, 1900, 2900, 700, 91700, 58500 }
            );
        }

        /// <summary>
        /// ラベルテスト
        /// 前年表示:3年前
        /// </summary>
        [Test]
        public void LabelWithPrevYear_3_Time()
        {
            ShowFormMain(DB_EXIST, TAB_IDX);

            TsSummaryBtnPrevYear().Click();
            TsSummaryBtnPrevYear().Click();
            TsSummaryBtnPrevYear().Click();

            LabelControlTest(
                new decimal[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            );
        }

        /// <summary>
        /// ラベルテスト
        /// 前月表示:1ヶ月前
        /// </summary>
        [Test]
        public void LabelWithPrevMonth_1_Time()
        {
            ShowFormMain(DB_EXIST, TAB_IDX);

            TsSummaryBtnPrevMonth().Click();

            LabelControlTest(
                new decimal[] { 10300, 15300, 1500, 5300, 500, 3300, 40300, 8300, 2300, 2000, 3000, 800, 92900, 57400 }
            );
        }

        /// <summary>
        /// ラベルテスト
        /// 前月表示:2ヶ月前
        /// </summary>
        [Test]
        public void LabelWithPrevMonth_2_Time()
        {
            ShowFormMain(DB_EXIST, TAB_IDX);

            TsSummaryBtnPrevMonth().Click();
            TsSummaryBtnPrevMonth().Click();

            LabelControlTest(
                new decimal[] { 10400, 15400, 1600, 5400, 600, 3400, 40400, 8400, 2400, 2100, 3100, 900, 94100, 56300 }
            );
        }

        /// <summary>
        /// ラベルテスト
        /// 前月表示:3ヶ月前
        /// </summary>
        [Test]
        public void LabelWithPrevMonth_3_Time()
        {
            ShowFormMain(DB_EXIST, TAB_IDX);

            TsSummaryBtnPrevMonth().Click();
            TsSummaryBtnPrevMonth().Click();
            TsSummaryBtnPrevMonth().Click();

            LabelControlTest(
                new decimal[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            );
        }

        /// <summary>
        /// ラベルテスト
        /// 翌月表示:1ヶ月後
        /// </summary>
        [Test]
        public void LabelWithNextMonth_1_Time()
        {
            ShowFormMain(DB_EXIST, TAB_IDX);

            TsSummaryBtnNextMonth().Click();

            LabelControlTest(
                new decimal[] { 10500, 15500, 1700, 5500, 700, 3500, 40500, 8500, 2500, 2200, 3200, 1000, 95300, 55200 }
            );
        }

        /// <summary>
        /// ラベルテスト
        /// 翌月表示:2ヶ月後
        /// </summary>
        [Test]
        public void LabelWithNextMonth_2_Time()
        {
            ShowFormMain(DB_EXIST, TAB_IDX);

            TsSummaryBtnNextMonth().Click();
            TsSummaryBtnNextMonth().Click();

            LabelControlTest(
                new decimal[] { 10600, 15600, 1800, 5600, 800, 3600, 40600, 8600, 2600, 2300, 3300, 1100, 96500, 54100 }
            );
        }

        /// <summary>
        /// ラベルテスト
        /// 翌月表示:3ヶ月後
        /// </summary>
        [Test]
        public void LabelWithNextMonth_3_Time()
        {
            ShowFormMain(DB_EXIST, TAB_IDX);

            TsSummaryBtnNextMonth().Click();
            TsSummaryBtnNextMonth().Click();
            TsSummaryBtnNextMonth().Click();

            LabelControlTest(
                new decimal[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            );
        }

        /// <summary>
        /// ラベルテスト
        /// 翌年表示:1年後
        /// </summary>
        [Test]
        public void LabelWithNextYear_1_Time()
        {
            ShowFormMain(DB_EXIST, TAB_IDX);

            TsSummaryBtnNextYear().Click();

            LabelControlTest(
                new decimal[] { 10700, 15700, 1900, 5700, 900, 3700, 40700, 8700, 2700, 2400, 3400, 1200, 97700, 53000 }
            );
        }

        /// <summary>
        /// ラベルテスト
        /// 翌年表示:2年後
        /// </summary>
        [Test]
        public void LabelWithNextYear_2_Time()
        {
            ShowFormMain(DB_EXIST, TAB_IDX);

            TsSummaryBtnNextYear().Click();
            TsSummaryBtnNextYear().Click();

            LabelControlTest(
                new decimal[] { 10800, 15800, 2000, 5800, 1000, 3800, 40800, 8800, 2800, 2500, 3500, 1300, 98900, 51900 }
            );
        }

        /// <summary>
        /// ラベルテスト
        /// 翌年表示:3年後
        /// </summary>
        [Test]
        public void LabelWithNextYear_3_Time()
        {
            ShowFormMain(DB_EXIST, TAB_IDX);

            TsSummaryBtnNextYear().Click();
            TsSummaryBtnNextYear().Click();
            TsSummaryBtnNextYear().Click();

            LabelControlTest(
                new decimal[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            );
        }

        /// <summary>
        /// ラベルテスト(データなし)
        /// 初期表示
        /// </summary>
        [Test]
        public void LabelWithEmptyWithInitial()
        {
            ShowFormMain(DB_EMPTY, TAB_IDX);

            LabelControlTest(
                new decimal[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            );
        }

        /// <summary>
        /// ラベルテスト(データなし)
        /// 前年表示:1年前
        /// </summary>
        [Test]
        public void LabelWithEmptyWithPrevYear_1_Time()
        {
            ShowFormMain(DB_EMPTY, TAB_IDX);

            TsSummaryBtnPrevYear().Click();

            LabelControlTest(
                new decimal[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            );
        }

        /// <summary>
        /// ラベルテスト(データなし)
        /// 前年表示:2年前
        /// </summary>
        [Test]
        public void LabelWithEmptyWithPrevYear_2_Time()
        {
            ShowFormMain(DB_EMPTY, TAB_IDX);

            TsSummaryBtnPrevYear().Click();
            TsSummaryBtnPrevYear().Click();

            LabelControlTest(
                new decimal[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            );
        }

        /// <summary>
        /// ラベルテスト(データなし)
        /// 前年表示:3年前
        /// </summary>
        [Test]
        public void LabelWithEmptyWithPrevYear_3_Time()
        {
            ShowFormMain(DB_EMPTY, TAB_IDX);

            TsSummaryBtnPrevYear().Click();
            TsSummaryBtnPrevYear().Click();
            TsSummaryBtnPrevYear().Click();

            LabelControlTest(
                new decimal[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            );
        }

        /// <summary>
        /// ラベルテスト(データなし)
        /// 前月表示:1ヶ月前
        /// </summary>
        [Test]
        public void LabelWithEmptyWithPrevMonth_1_Time()
        {
            ShowFormMain(DB_EMPTY, TAB_IDX);

            TsSummaryBtnPrevMonth().Click();

            LabelControlTest(
                new decimal[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            );
        }

        /// <summary>
        /// ラベルテスト(データなし)
        /// 前月表示:2ヶ月前
        /// </summary>
        [Test]
        public void LabelWithEmptyWithPrevMonth_2_Time()
        {
            ShowFormMain(DB_EMPTY, TAB_IDX);

            TsSummaryBtnPrevMonth().Click();
            TsSummaryBtnPrevMonth().Click();

            LabelControlTest(
                new decimal[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            );
        }

        /// <summary>
        /// ラベルテスト(データなし)
        /// 前月表示:3ヶ月前
        /// </summary>
        [Test]
        public void LabelWithEmptyWithPrevMonth_3_Time()
        {
            ShowFormMain(DB_EMPTY, TAB_IDX);

            TsSummaryBtnPrevMonth().Click();
            TsSummaryBtnPrevMonth().Click();
            TsSummaryBtnPrevMonth().Click();

            LabelControlTest(
                new decimal[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            );
        }

        /// <summary>
        /// ラベルテスト(データなし)
        /// 翌月表示:1ヶ月後
        /// </summary>
        [Test]
        public void LabelWithEmptyWithNextMonth_1_Time()
        {
            ShowFormMain(DB_EMPTY, TAB_IDX);

            TsSummaryBtnNextMonth().Click();

            LabelControlTest(
                new decimal[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            );
        }

        /// <summary>
        /// ラベルテスト(データなし)
        /// 翌月表示:2ヶ月後
        /// </summary>
        [Test]
        public void LabelWithEmptyWithNextMonth_2_Time()
        {
            ShowFormMain(DB_EMPTY, TAB_IDX);

            TsSummaryBtnNextMonth().Click();
            TsSummaryBtnNextMonth().Click();

            LabelControlTest(
                new decimal[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            );
        }

        /// <summary>
        /// ラベルテスト(データなし)
        /// 翌月表示:3ヶ月後
        /// </summary>
        [Test]
        public void LabelWithEmptyWithNextMonth_3_Time()
        {
            ShowFormMain(DB_EMPTY, TAB_IDX);

            TsSummaryBtnNextMonth().Click();
            TsSummaryBtnNextMonth().Click();
            TsSummaryBtnNextMonth().Click();

            LabelControlTest(
                new decimal[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            );
        }

        /// <summary>
        /// ラベルテスト(データなし)
        /// 翌年表示:1年後
        /// </summary>
        [Test]
        public void LabelWithEmptyWithNextYear_1_Time()
        {
            ShowFormMain(DB_EMPTY, TAB_IDX);

            TsSummaryBtnNextYear().Click();

            LabelControlTest(
                new decimal[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            );
        }

        /// <summary>
        /// ラベルテスト(データなし)
        /// 翌年表示:2年後
        /// </summary>
        [Test]
        public void LabelWithEmptyWithNextYear_2_Time()
        {
            ShowFormMain(DB_EMPTY, TAB_IDX);

            TsSummaryBtnNextYear().Click();
            TsSummaryBtnNextYear().Click();

            LabelControlTest(
                new decimal[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            );
        }

        /// <summary>
        /// ラベルテスト(データなし)
        /// 翌年表示:3年後
        /// </summary>
        [Test]
        public void LabelWithEmptyWithNextYear_3_Time()
        {
            ShowFormMain(DB_EMPTY, TAB_IDX);

            TsSummaryBtnNextYear().Click();
            TsSummaryBtnNextYear().Click();
            TsSummaryBtnNextYear().Click();

            LabelControlTest(
                new decimal[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            );
        }
    }
}