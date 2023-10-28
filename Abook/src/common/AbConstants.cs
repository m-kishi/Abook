// ------------------------------------------------------------
// © 2010 https://github.com/m-kishi
// ------------------------------------------------------------
namespace Abook
{
    using System;
    using System.Collections.Generic;
    using System.Text;

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
            /// <summary>備考</summary>
            public const string NOTE = "ColNote";
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

            /// <summary>秘密収支</summary>
            public static class PRIVATE
            {
                /// <summary>年月</summary>
                public const string DATE = "ColPrvDate";
                /// <summary>名称</summary>
                public const string NAME = "ColPrvName";
                /// <summary>金額</summary>
                public const string COST = "ColPrvCost";
                /// <summary>収支</summary>
                public const string BLNC = "ColPrvBlnc";
            }
        }

        /// <summary>CSV</summary>
        public static class CSV
        {
            /// <summary>CSVファイル</summary>
            public const string FILE = "Abook.db";
            /// <summary>区切り文字</summary>
            public const string DELIMITER = ",";
            /// <summary>フィールド数(旧)</summary>
            public const int OLD_FIELD = 4;
            /// <summary>フィールド数(新)</summary>
            public const int CUR_FIELD = 5;
            /// <summary>改行文字(LF)</summary>
            public const string LF = "\n";
            /// <summary>文字コード(UTF-8 BOM無し)</summary>
            public static readonly Encoding ENCODING = new UTF8Encoding(false);
        }

        /// <summary>DataGridView</summary>
        public static class DGV
        {
            /// <summary>追加入力行数</summary>
            public const int NEW_ROW_SIZE = 30;
        }

        /// <summary>フォーマット</summary>
        public static class FMT
        {
            /// <summary>CSV("date","name","type","cost","note")</summary>
            public const string CSV = "\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\"";
            /// <summary>日付"yyyy-MM-dd"</summary>
            public const string DATE = "yyyy-MM-dd";
            /// <summary>月"MM"</summary>
            public const string MONTH = "MM";
            /// <summary>通貨:円"{0:c}"</summary>
            public const string YEN = "{0:c}";
            /// <summary>カンマ編集</summary>
            public const string COMMA = "{0:#,0}";
            /// <summary>タイトル(yyyy年MM月)</summary>
            public const string TITLE = "yyyy年MM月";
            /// <summary>日別"{0}-01"</summary>
            public const string DAILY_GROUP = "{0}-01";
            /// <summary>月別"yyyy-MM"</summary>
            public const string MONTHLY_GROUP = "yyyy-MM";
            /// <summary>年月"yyyy-MM"</summary>
            public const string YEAR_MONTH = "yyyy-MM";
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

            /// <summary>光熱費に属する名称</summary>
            public static readonly string[] ENERGY = { EL, GS, WT };
        }

        /// <summary>汎用</summary>
        public static class CMM
        {
            /// <summary>金額自動補完の候補数</summary>
            public const int MAX_COST_CANDIDATE = 3;
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
            /// <summary>収支</summary>
            public const string BLNC = "収支";
            /// <summary>特入</summary>
            public const string BNUS = "特入";
            /// <summary>特出</summary>
            public const string SPCL = "特出";
            /// <summary>秘密入</summary>
            public const string PRVI = "秘密入";
            /// <summary>秘密出</summary>
            public const string PRVO = "秘密出";

            /// <summary>
            /// 支出情報として指定可能な種別
            /// </summary>
            public static readonly string[] EXPENCE =
            {
                TYPE.FOOD, TYPE.OTFD, TYPE.GOOD, TYPE.FRND, TYPE.TRFC, TYPE.PLAY,
                TYPE.HOUS, TYPE.ENGY, TYPE.CNCT, TYPE.MEDI, TYPE.INSU, TYPE.OTHR,
                TYPE.EARN, TYPE.BNUS, TYPE.SPCL, TYPE.PRVI, TYPE.PRVO,
            };

            /// <summary>秘密収支に属する種別</summary>
            public static readonly string[] PRIVATE = { TYPE.PRVI, TYPE.PRVO };

            /// <summary>月次タブ</summary>
            public static class SUMMARY
            {
                /// <summary>月次タブでの支出対象</summary>
                public static readonly string[] EXPE =
                {
                    TYPE.FOOD, TYPE.OTFD, TYPE.GOOD, TYPE.FRND, TYPE.TRFC, TYPE.PLAY,
                    TYPE.HOUS, TYPE.ENGY, TYPE.CNCT, TYPE.MEDI, TYPE.INSU, TYPE.OTHR,
                };
            }

            /// <summary>収支タブ</summary>
            public static class BALANCE
            {
                /// <summary>収支タブでの収入対象</summary>
                public static readonly string[] EARN = { TYPE.EARN, TYPE.BNUS, };

                /// <summary>収支タブでの支出対象</summary>
                public static readonly string[] EXPE =
                {
                    TYPE.FOOD, TYPE.OTFD, TYPE.GOOD, TYPE.FRND, TYPE.TRFC, TYPE.PLAY,
                    TYPE.HOUS, TYPE.ENGY, TYPE.CNCT, TYPE.MEDI, TYPE.INSU, TYPE.OTHR,
                };
            }
        }
    }
}
