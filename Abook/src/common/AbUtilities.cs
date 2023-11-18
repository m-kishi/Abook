// ------------------------------------------------------------
// © 2010 https://github.com/m-kishi
// ------------------------------------------------------------
namespace Abook
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using EX   = Abook.AbException.EX;
    using FMT  = Abook.AbConstants.FMT;
    using TYPE = Abook.AbConstants.TYPE;

    /// <summary>
    /// ユーティリティクラス
    /// </summary>
    public static class AbUtilities
    {
        /// <summary>
        /// 文字列型への変換
        /// </summary>
        /// <param name="obj">対象</param>
        /// <returns>変換した文字列</returns>
        public static string ToStr(object obj)
        {
            return Convert.ToString(obj);
        }

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
        /// 金額変換
        /// </summary>
        /// <param name="cost">金額</param>
        /// <returns>金額(金額に変換できないときは0)</returns>
        public static decimal ToCost(object cost)
        {
            if (!IsCost(cost)) return 0m;
            return decimal.Parse(ToStr(cost));
        }

        /// <summary>
        /// 金額のカンマ編集
        /// </summary>
        /// <param name="cost">金額</param>
        /// <returns>カンマ編集後文字列</returns>
        public static string ToComma(object cost)
        {
            var value = 0m;
            if (cost != null && decimal.TryParse(cost.ToString(), out value))
            {
                return string.Format(FMT.COMMA, value);
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 空文字判定
        /// </summary>
        /// <param name="text">文字列</param>
        /// <returns>true:Null or Empty false:空白でない</returns>
        public static bool IsEmpty(string text)
        {
            return string.IsNullOrEmpty(text);
        }

        /// <summary>
        /// 金額判定
        /// </summary>
        /// <param name="cost">金額</param>
        /// <returns>true:decimal false:decimalでない</returns>
        public static bool IsCost(object cost)
        {
            var value = 0m;
            return decimal.TryParse(ToStr(cost), out value);
        }

        /// <summary>
        /// 消費税計算(8%)
        /// </summary>
        /// <param name="cost">金額</param>
        /// <returns>税込金額(小数点以下四捨五入)</returns>
        public static decimal Tax8(object cost)
        {
            var value = ToCost(cost);
            return Math.Round(value * 1.08m, 0, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// 消費税計算(10%)
        /// </summary>
        /// <param name="cost">金額</param>
        /// <returns>税込金額(小数点以下四捨五入)</returns>
        public static decimal Tax10(object cost)
        {
            var value = ToCost(cost);
            return Math.Round(value * 1.1m, 0, MidpointRounding.AwayFromZero);
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
            public static void DateNull(string date)
            {
                if (string.IsNullOrEmpty(date)) AbException.Throw(EX.DATE_NULL);
            }

            /// <summary>
            /// NULLチェック(名称)
            /// </summary>
            /// <param name="name">名称</param>
            public static void NameNull(string name)
            {
                if (string.IsNullOrEmpty(name)) AbException.Throw(EX.NAME_NULL);
            }

            /// <summary>
            /// NULLチェック(種別)
            /// </summary>
            /// <param name="type">種別</param>
            public static void TypeNull(string type)
            {
                if (string.IsNullOrEmpty(type)) AbException.Throw(EX.TYPE_NULL);
            }

            /// <summary>
            /// 種別チェック
            /// </summary>
            /// <param name="type">種別</param>
            public static void TypeWrong(string type)
            {
                if (!TYPE.EXPENCE.Contains(type)) AbException.Throw(EX.TYPE_WRONG);
            }

            /// <summary>
            /// NULLチェック(金額)
            /// </summary>
            /// <param name="cost">金額</param>
            public static void CostNull(string cost)
            {
                if (string.IsNullOrEmpty(cost)) AbException.Throw(EX.COST_NULL);
            }

            /// <summary>
            /// NULLチェック(備考)
            /// </summary>
            /// <param name="note">備考</param>
            public static void NoteNull(string note)
            {
                if (note == null) AbException.Throw(EX.NOTE_NULL);
            }

            /// <summary>
            /// NULLチェック(DBファイル)
            /// </summary>
            /// <param name="dbFile">DBファイル</param>
            public static void DBFileNull(string dbFile)
            {
                if (string.IsNullOrEmpty(dbFile)) AbException.Throw(EX.DB_FILE_NULL);
            }

            /// <summary>
            /// NULLチェック(支出情報)
            /// </summary>
            /// <param name="exp">支出情報</param>
            public static void ExpNull(AbExpense exp)
            {
                if (exp == null) AbException.Throw(EX.EXPENSE_NULL);
            }

            /// <summary>
            /// NULLチェック(支出情報リスト)
            /// </summary>
            /// <param name="exp">支出情報リスト</param>
            public static void ExpNull(List<AbExpense> exp)
            {
                if (exp == null) AbException.Throw(EX.EXPENSES_NULL);
            }

            /// <summary>
            /// 件数チェック(支出情報リスト)
            /// </summary>
            /// <param name="exp">支出情報リスト</param>
            public static void ExpCount(List<AbExpense> exp)
            {
                if (exp == null || exp.Count <= 0) AbException.Throw(EX.DB_FILE_RECORD_NOTHING);
            }

            /// <summary>
            /// NULLチェック(月次情報リスト)
            /// </summary>
            /// <param name="sum">月次情報リスト</param>
            public static void SumNull(List<AbSummary> sum)
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
        }

        /// <summary>
        /// メッセージボックス
        /// </summary>
        public static class MSG
        {
            /// <summary>
            /// OKダイアログ
            /// </summary>
            /// <param name="title">タイトル</param>
            /// <param name="message">メッセージ</param>
            /// <returns>ダイアログリザルト</returns>
            public static DialogResult OK(string title, string message)
            {
                AbDialogHook.Hook();
                return MessageBox.Show(
                    message,
                    title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk
                );
            }

            /// <summary>
            /// システムエラーダイアログ
            /// </summary>
            /// <param name="message">メッセージ</param>
            /// <returns>ダイアログリザルト</returns>
            public static DialogResult Abort(string message)
            {
                // フックは無し
                return MessageBox.Show(
                    message,
                    "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            /// <summary>
            /// エラーダイアログ
            /// </summary>
            /// <param name="message">メッセージ</param>
            /// <returns>ダイアログリザルト</returns>
            public static DialogResult Error(string message)
            {
                AbDialogHook.Hook();
                return MessageBox.Show(
                    message,
                    "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            /// <summary>
            /// 警告ダイアログ
            /// </summary>
            /// <param name="title">タイトル</param>
            /// <param name="message">メッセージ</param>
            /// <returns>ダイアログリザルト</returns>
            public static DialogResult Warning(string title, string message)
            {
                AbDialogHook.Hook();
                return MessageBox.Show(
                    message,
                    title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }
    }
}
