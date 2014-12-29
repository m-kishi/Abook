namespace Abook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using EX   = Abook.AbException.EX;
    using FMT  = Abook.AbConstants.FMT;
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
            CHK.ChkTypeNull(type);
            CHK.ChkTypeIdWrong(type);
            return TYPE.ID[type];
        }

        /// <summary>
        /// チェックユーティリティ
        /// </summary>
        public static class CHK
        {
            /// <summary>
            /// NULLチェック(日付)
            /// </summary>
            /// <param name="date">日付</param>
            public static void ChkDateNull(string date)
            {
                if (string.IsNullOrEmpty(date)) AbException.Throw(EX.DATE_NULL);
            }

            /// <summary>
            /// NULLチェック(名称)
            /// </summary>
            /// <param name="name">名称</param>
            public static void ChkNameNull(string name)
            {
                if (string.IsNullOrEmpty(name)) AbException.Throw(EX.NAME_NULL);
            }

            /// <summary>
            /// NULLチェック(種別)
            /// </summary>
            /// <param name="type">種別</param>
            public static void ChkTypeNull(string type)
            {
                if (string.IsNullOrEmpty(type)) AbException.Throw(EX.TYPE_NULL);
            }

            /// <summary>
            /// 種別チェック
            /// </summary>
            /// <param name="type">種別</param>
            public static void ChkTypeWrong(string type)
            {
                if (!TYPE.EXPENCE.Contains(type)) AbException.Throw(EX.TYPE_WRONG);
            }

            /// <summary>
            /// 種別チェック
            /// </summary>
            /// <param name="type">種別</param>
            public static void ChkTypeIdWrong(string type)
            {
                if (!TYPE.ID.ContainsKey(type)) AbException.Throw(EX.TYPE_WRONG);
            }

            /// <summary>
            /// NULLチェック(金額)
            /// </summary>
            /// <param name="cost">金額</param>
            public static void ChkCostNull(string cost)
            {
                if (string.IsNullOrEmpty(cost)) AbException.Throw(EX.COST_NULL);
            }

            /// <summary>
            /// NULLチェック(CSVファイル名)
            /// </summary>
            /// <param name="csv">CSVファイル名</param>
            public static void ChkCsvNull(string csv)
            {
                if (string.IsNullOrEmpty(csv)) AbException.Throw(EX.DB_NULL);
            }

            /// <summary>
            /// NULLチェック(支出情報)
            /// </summary>
            /// <param name="exp">支出情報</param>
            public static void ChkExpNull(AbExpense exp)
            {
                if (exp == null) AbException.Throw(EX.EXPENSE_NULL);
            }

            /// <summary>
            /// NULLチェック(支出情報リスト)
            /// </summary>
            /// <param name="exp">支出情報リスト</param>
            public static void ChkExpNull(List<AbExpense> exp)
            {
                if (exp == null) AbException.Throw(EX.EXPENSES_NULL);
            }

            /// <summary>
            /// 件数チェック(支出情報リスト)
            /// </summary>
            /// <param name="exp">支出情報リスト</param>
            public static void ChkExpCount(List<AbExpense> exp)
            {
                if (exp == null || exp.Count <= 0) AbException.Throw(EX.DB_RECORD_NOTHING);
            }

            /// <summary>
            /// NULLチェック(集計値リスト)
            /// </summary>
            /// <param name="sum">集計値リスト</param>
            public static void ChkSumNull(List<AbSummary> sum)
            {
                if (sum == null) AbException.Throw(EX.SUMMARIES_NULL);
            }

            /// <summary>
            /// マイナスチェック(年度)
            /// </summary>
            /// <param name="year">年度</param>
            public static void YearMinus(int year)
            {
                if (year < 0) AbException.Throw(EX.YEAR_MINUS);
            }

            /// <summary>
            /// マイナスチェック(収入)
            /// </summary>
            /// <param name="earn">収入</param>
            public static void EarnMinus(decimal earn)
            {
                if (earn < 0) AbException.Throw(EX.EARN_MINUS);
            }

            /// <summary>
            /// マイナスチェック(支出)
            /// </summary>
            /// <param name="expense">支出</param>
            public static void ExpenseMinus(decimal expense)
            {
                if (expense < 0) AbException.Throw(EX.EXPENSE_MINUS);
            }

            /// <summary>
            /// マイナスチェック(特出)
            /// </summary>
            /// <param name="special">特出</param>
            public static void SpecialMinus(decimal special)
            {
                if (special < 0) AbException.Throw(EX.SPECIAL_MINUS);
            }

            /// <summary>
            /// 整合性チェック(収支)
            /// </summary>
            /// <param name="ern">収入</param>
            /// <param name="exp">支出</param>
            /// <param name="spc">特出</param>
            /// <param name="bln">収支</param>
            public static void BalanceIncorrect(decimal ern, decimal exp, decimal spc, decimal bln)
            {
                var expected = ern - (exp + spc);
                if (bln != expected) AbException.Throw(EX.BALANCE_INCORRECT);
            }

            /// <summary>
            /// NULLチェック(リクエストURL)
            /// </summary>
            /// <param name="url">リクエストURL</param>
            public static void ChkUrlNull(string url)
            {
                if (string.IsNullOrEmpty(url)) AbException.Throw(EX.URL_NULL);
            }

            /// <summary>
            /// NULLチェック(UPDファイル名)
            /// </summary>
            /// <param name="upd">UPDファイル名</param>
            public static void ChkUpdNull(string upd)
            {
                if (string.IsNullOrEmpty(upd)) AbException.Throw(EX.UPD_NULL);
            }

            /// <summary>
            /// 存在チェック(UPDファイル名)
            /// </summary>
            /// <param name="upd">UPDファイル名</param>
            public static void ChkUpdExist(string upd)
            {
                if (!System.IO.File.Exists(upd)) AbException.Throw(EX.UPD_DOES_NOT_EXIST);
            }

            /// <summary>
            /// 件数チェック(支出情報リスト)
            /// </summary>
            /// <param name="exp">支出情報リスト</param>
            public static void ChkUpdCount(List<AbExpense> exp)
            {
                if (exp == null || exp.Count <= 0) AbException.Throw(EX.UPD_RECORD_NOTHING);
            }
        }
    }
}
