namespace AbookTest
{
    using Abook;
    using System;
    using NUnit.Framework;

    /// <summary>
    /// ユーティリティテスト
    /// </summary>
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
            //\u00a5は円の通貨記号
            var actual = AbUtilities.ToYen(cost);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 種別IDへの変換
        /// </summary>
        /// <param name="type">種別</param>
        /// <param name="expected">期待値</param>
        [TestCase("食費"  , "FOOD")]
        [TestCase("外食費", "OTFD")]
        [TestCase("雑貨"  , "GOOD")]
        [TestCase("交際費", "FRND")]
        [TestCase("交通費", "TRFC")]
        [TestCase("遊行費", "PLAY")]
        [TestCase("家賃"  , "HOUS")]
        [TestCase("光熱費", "ENGY")]
        [TestCase("通信費", "CNCT")]
        [TestCase("医療費", "MEDI")]
        [TestCase("保険料", "INSU")]
        [TestCase("その他", "OTHR")]
        [TestCase("収入"  , "EARN")]
        [TestCase("合計"  , "TTAL")]
        [TestCase("収支"  , "BLNC")]
        [TestCase("特入"  , "BNUS")]
        [TestCase("特出"  , "SPCL")]
        [TestCase("秘密入", "PRVI")]
        [TestCase("秘密出", "PRVO")]
        public void ToTypeId(string type, string expected)
        {
            var actual = AbUtilities.ToTypeId(type);
            Assert.AreEqual(expected, actual);
        }
    }
}
