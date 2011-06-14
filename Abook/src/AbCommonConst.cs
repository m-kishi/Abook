namespace Abook
{
    using System;

    /// <summary>
    /// 定数クラス
    /// </summary>
    public static class AbCommonConst
    {
        /// <summary>DB ファイル名</summary>
        public const string DB_NAME = "Abook.db";

        /// <summary>新規追加行数</summary>
        public const int ADD_ROW_SIZE = 15;

        /// <summary>描画領域横幅</summary>
        public const float WIDTH = 349f;

        /// <summary>描画領域縦幅</summary>
        public const float HEIGHT = 218f;

        /// <summary>表示月数</summary>
        public const float DISTANCE = 13f;

        /// <summary>支出最大値</summary>
        public const float MAX_VALUE = 15000f;

        /// <summary>月間隔</summary>
        public const float HORIZONTAL = WIDTH / DISTANCE;

        /// <summary>係数</summary>
        public const float COEFFICIENT = -HEIGHT / MAX_VALUE;

        /// <summary>描画点サイズ</summary>
        public const int RECTANGLE_SIZE = 6;

        /// <summary>基準線描画値</summary>
        public static readonly int[] LINE_VALUES = { 2500, 5000, 7500, 10000, 12500 };
    }
}
