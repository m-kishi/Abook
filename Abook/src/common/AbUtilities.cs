// ------------------------------------------------------------
// Copyright (C) 2010-2017 Masaaki Kishi. All rights reserved.
// Author: Masaaki Kishi <m.kishi.5@gmail.com>
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
        /// 種別IDへの変換
        /// </summary>
        /// <param name="type">種別</param>
        /// <returns>種別ID</returns>
        public static string ToTypeId(string type)
        {
            CHK.TypeNull(type);
            CHK.TypeIdWrong(type);
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
            /// 種別チェック
            /// </summary>
            /// <param name="type">種別</param>
            public static void TypeIdWrong(string type)
            {
                if (!TYPE.ID.ContainsKey(type)) AbException.Throw(EX.TYPE_WRONG);
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
            /// NULLチェック(CSVファイル名)
            /// </summary>
            /// <param name="csv">CSVファイル名</param>
            public static void CsvNull(string csv)
            {
                if (string.IsNullOrEmpty(csv)) AbException.Throw(EX.CSV_NULL);
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
                if (exp == null || exp.Count <= 0) AbException.Throw(EX.CSV_RECORD_NOTHING);
            }

            /// <summary>
            /// NULLチェック(集計値リスト)
            /// </summary>
            /// <param name="sum">集計値リスト</param>
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

            /// <summary>
            /// NULLチェック(ログインURL)
            /// </summary>
            /// <param name="login">ログインURL</param>
            public static void LoginNull(string login)
            {
                if (string.IsNullOrEmpty(login)) AbException.Throw(EX.LOGIN_NULL);
            }

            /// <summary>
            /// NULLチェック(アップロードURL)
            /// </summary>
            /// <param name="upload">アップロードURL</param>
            public static void UploadNull(string upload)
            {
                if (string.IsNullOrEmpty(upload)) AbException.Throw(EX.UPLOAD_NULL);
            }

            /// <summary>
            /// NULLチェック(メール)
            /// </summary>
            /// <param name="mail">メール</param>
            public static void MailNull(string mail)
            {
                if (string.IsNullOrEmpty(mail)) AbException.Throw(EX.MAIL_NULL);
            }

            /// <summary>
            /// NULLチェック(パスワード)
            /// </summary>
            /// <param name="pass">パスワード</param>
            public static void PassNull(string pass)
            {
                if (string.IsNullOrEmpty(pass)) AbException.Throw(EX.PASS_NULL);
            }

            /// <summary>
            /// 存在チェック(Abook.db)
            /// </summary>
            /// <param name="upd">DBファイル名</param>
            public static void DbExist(string db)
            {
                if (!File.Exists(db)) AbException.Throw(EX.DB_DOES_NOT_EXIST);
            }

            /// <summary>
            /// 件数チェック(支出情報リスト)
            /// </summary>
            /// <param name="exp">支出情報リスト</param>
            public static void UpdCount(List<AbExpense> exp)
            {
                if (exp == null || exp.Count <= 0) AbException.Throw(EX.UPD_RECORD_NOTHING);
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
