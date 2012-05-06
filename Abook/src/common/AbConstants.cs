﻿namespace Abook
{
    using System;

    /// <summary>
    /// 定数クラス
    /// </summary>
    public static class AbConstants
    {
        /// <summary>カラム</summary>
        public static class COL
        {
            /// <summary>日付</summary>
            public const string DATE = "ColDate";
            /// <summary>名称</summary>
            public const string NAME = "ColName";
            /// <summary>種別</summary>
            public const string TYPE = "ColType";
            /// <summary>金額</summary>
            public const string COST = "ColCost";
            /// <summary>年度</summary>
            public const string YEAR = "ColYear";
            /// <summary>収入</summary>
            public const string EARN = "ColEarn";
            /// <summary>支出</summary>
            public const string EXPENSE = "ColExpense";
            /// <summary>特出</summary>
            public const string SPECIAL = "ColSpecial";
            /// <summary>収支</summary>
            public const string BALANCE = "ColBalance";
        }

        /// <summary>CSV</summary>
        public static class CSV
        {
            /// <summary>DB ファイル</summary>
            public const string DB = "Abook.db";
            /// <summary>区切り文字</summary>
            public const string DELIMITER = ",";
            /// <summary>フィールド数</summary>
            public const int FIELD = 4;
        }

        /// <summary>DataGridView</summary>
        public static class DGV
        {
            /// <summary>追加入力行数</summary>
            public const int NEW_ROW_SIZE = 15;
        }

        /// <summary>フォーマット</summary>
        public static class FMT
        {
            /// <summary>CSV("date","name","type","cost")</summary>
            public const string CSV = "\"{0}\",\"{1}\",\"{2}\",\"{3}\"";
            /// <summary>日付"yyyy/MM/dd"</summary>
            public const string DATE = "yyyy-MM-dd";
            /// <summary>月"MM"</summary>
            public const string MONTH = "MM";
            /// <summary>年度開始日(04/01)</summary>
            public const string START_YEAR = "04-01";
            /// <summary>対象年月日(年/月日)</summary>
            public const string TARGET_YEAR = "{0}-{1}";
            /// <summary>通貨:円"{0:c}"</summary>
            public const string YEN = "{0:c}";
            /// <summary>タイトル(yyyy年MM月)</summary>
            public const string TITLE = "yyyy年MM月";
            /// <summary>日別"{0}-01"</summary>
            public const string DAILY_GROUP = "{0}-01";
            /// <summary>月別"yyyy-MM"</summary>
            public const string MONTHLY_GROUP = "yyyy-MM";
        }

        /// <summary>グラフ</summary>
        public static class GRAPH
        {
            /// <summary>描画領域横幅</summary>
            public const decimal WIDTH = 349;
            /// <summary>描画領域縦幅</summary>
            public const decimal HEIGHT = 218;
            /// <summary>表示月数</summary>
            public const decimal DISTANCE = 13;
            /// <summary>支出最大値</summary>
            public const decimal MAX_VALUE = 15000;
            /// <summary>月間隔</summary>
            public const decimal HORIZONTAL = WIDTH / DISTANCE;
            /// <summary>係数</summary>
            public const decimal COEFFICIENT = -HEIGHT / MAX_VALUE;
            /// <summary>描画点サイズ</summary>
            public const int RECTANGLE_SIZE = 6;
            /// <summary>基準線描画値</summary>
            public static readonly int[] LINE_VALUES = { 2500, 5000, 7500, 10000, 12500 };
        }

        /// <summary>名称</summary>
        public static class NAME
        {
            /// <summary>電気代</summary>
            public const string EL = "電気代";
            /// <summary>ガス代</summary>
            public const string GS = "ガス代";
            /// <summary>水道代</summary>
            public const string WT = "水道代";
        }

        /// <summary>種別</summary>
        public static class TYPE
        {
            /// <summary>食費</summary>
            public const string FOOD = "食費";
            /// <summary>外食費</summary>
            public const string OTFD = "外食費";
            /// <summary>雑貨</summary>
            public const string GOOD = "雑貨";
            /// <summary>交際費</summary>
            public const string FRND = "交際費";
            /// <summary>交通費</summary>
            public const string TRFC = "交通費";
            /// <summary>遊行費</summary>
            public const string PLAY = "遊行費";
            /// <summary>家賃</summary>
            public const string HOUS = "家賃";
            /// <summary>光熱費</summary>
            public const string ENGY = "光熱費";
            /// <summary>通信費</summary>
            public const string CNCT = "通信費";
            /// <summary>医療費</summary>
            public const string MEDI = "医療費";
            /// <summary>保険料</summary>
            public const string INSU = "保険料";
            /// <summary>その他</summary>
            public const string OTHR = "その他";
            /// <summary>収入</summary>
            public const string EARN = "収入";
            /// <summary>合計</summary>
            public const string TTAL = "合計";
            /// <summary>残金</summary>
            public const string BLNC = "残金";
            /// <summary>特出</summary>
            public const string SPCL = "特出";
        }
    }
}
