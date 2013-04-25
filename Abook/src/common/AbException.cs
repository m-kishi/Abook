﻿namespace Abook
{
    using System;

    /// <summary>
    /// 例外クラス
    /// </summary>
    public class AbException : Exception
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="message">メッセージ</param>
        private AbException(string message) : base(message)
        {
            //外部から new 不可
        }

        /// <summary>
        /// 例外スロー
        /// </summary>
        /// <param name="message">メッセージ</param>
        public static void Throw(string message)
        {
            throw new AbException(message);
        }

        /// <summary>例外メッセージ</summary>
        public static class EX
        {
            /// <summary>日付がありません。</summary>
            public const string DATE_NULL = "日付がありません。";
            /// <summary>名称がありません。</summary>
            public const string NAME_NULL = "名称がありません。";
            /// <summary>種別がありません。</summary>
            public const string TYPE_NULL = "種別がありません。";
            /// <summary>金額がありません。</summary>
            public const string COST_NULL = "金額がありません。";
            /// <summary>金額がマイナスです。</summary>
            public const string COST_MINUS = "金額がマイナスです。";
            /// <summary>日付が正しくありません。</summary>
            public const string DATE_FORMAT = "日付が正しくありません。";
            /// <summary>金額が正しくありません。</summary>
            public const string COST_FORMAT = "金額が正しくありません。";
            /// <summary>金額が大き過ぎます。</summary>
            public const string COST_OVERFLOW = "金額が大き過ぎます。";

            /// <summary>DB ファイルがありません。</summary>
            public const string DB_NULL = "DB ファイルがありません。";
            /// <summary>{0} 行目: {1}</summary>
            public const string DB_LOAD = "{0} 行目: {1}";
            /// <summary>{0} 行目: {1}</summary>
            public const string DB_STORE = "{0} 行目: {1}";
            /// <summary>DB ファイルの作成に失敗しました。</summary>
            public const string DB_CREATE = "DB ファイルの作成に失敗しました。";
            /// <summary>フィールド数が少ないです。</summary>
            public const string DB_FIELD_LESS = "フィールド数が少ないです。";
            /// <summary>フィールド数が多いです。</summary>
            public const string DB_FIELD_MORE = "フィールド数が多いです。";
            /// <summary>登録するデータがありません。</summary>
            public const string DB_RECORD_NOTHING = "登録するデータがありません。";

            /// <summary>支出情報がありません。</summary>
            public const string EXPENSE_NULL = "支出情報がありません。";
            /// <summary>支出情報リストがありません。</summary>
            public const string EXPENSES_NULL = "支出情報リストがありません。";
            /// <summary>集計値リストがありません。</summary>
            public const string SUMMARIES_NULL = "集計値リストがありません。";

            /// <summary>年度がマイナスです。</summary>
            public const string YEAR_MINUS = "年度がマイナスです。";
            /// <summary>収入がマイナスです。</summary>
            public const string EARN_MINUS = "収入がマイナスです。";
            /// <summary>支出がマイナスです。</summary>
            public const string EXPENSE_MINUS = "支出がマイナスです。";
            /// <summary>特出がマイナスです。</summary>
            public const string SPECIAL_MINUS = "特出がマイナスです。";
            /// <summary>収支が合いません。</summary>
            public const string BALANCE_INCORRECT = "収支が合いません。";

            /// <summary>種別が正しくありません。</summary>
            public const string TYPE_PRIVATE_ERR = "種別が正しくありません。";
        }
    }
}
