namespace Abook
{
    using System;
    using EX = Abook.AbException.EX;
    using FMT = Abook.AbConstants.FMT;
    using TYPE = Abook.AbConstants.TYPE;

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

        /// <summary>
        /// 種別IDへの変換
        /// </summary>
        /// <param name="type">種別</param>
        /// <returns>種別ID</returns>
        public static string ToTypeId(string type)
        {
            if (string.IsNullOrEmpty(type)) { AbException.Throw(EX.TYPE_NULL ); }
            if (!TYPE.ID.ContainsKey(type)) { AbException.Throw(EX.TYPE_WRONG); }
            return TYPE.ID[type];
        }
    }
}
