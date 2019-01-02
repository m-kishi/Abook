// ------------------------------------------------------------
// Copyright (C) 2010-2017 Masaaki Kishi. All rights reserved.
// Author: Masaaki Kishi <m.kishi.5@gmail.com>
// ------------------------------------------------------------
namespace AbookTest
{
    using System;

    /// <summary>
    /// テストツールクラス
    /// </summary>
    public static class AbTestTool
    {
        /// <summary>
        /// 支出情報CSV生成
        /// </summary>
        /// <param name="date">日付</param>
        /// <param name="name">名前</param>
        /// <param name="type">種別</param>
        /// <param name="cost">金額</param>
        /// <returns>支出情報CSV</returns>
        public static string ToCSV(string date, string name, string type, string cost)
        {
            const string TEMPLATE = "\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"\"";
            return string.Format(TEMPLATE, date, name, type, cost);
        }

        /// <summary>
        /// 支出情報CSV生成
        /// </summary>
        /// <param name="date">日付</param>
        /// <param name="name">名前</param>
        /// <param name="type">種別</param>
        /// <param name="cost">金額</param>
        /// <param name="note">備考</param>
        /// <returns>支出情報CSV</returns>
        public static string ToCSV(string date, string name, string type, string cost, string note)
        {
            const string TEMPLATE = "\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\"";
            return string.Format(TEMPLATE, date, name, type, cost, note);
        }
    }
}
