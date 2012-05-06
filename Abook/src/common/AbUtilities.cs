namespace Abook
{
    using System;
    using FMT = Abook.AbConstants.FMT;

    /// <summary>
    /// ユーティリティクラス
    /// </summary>
    public static class AbUtilities
    {
        /// <summary>
        /// 円通貨形式変換
        /// </summary>
        /// <param name="cost">金額</param>
        /// <returns>円通貨形式文字列</returns>
        public static string ToYen(decimal cost)
        {
            return string.Format(FMT.YEN, cost);
        }
    }
}
