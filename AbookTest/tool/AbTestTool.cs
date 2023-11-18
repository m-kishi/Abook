// ------------------------------------------------------------
// © 2010 https://github.com/m-kishi
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
        /// DBファイル形式生成
        /// </summary>
        /// <param name="date">日付</param>
        /// <param name="name">名称</param>
        /// <param name="type">種別</param>
        /// <param name="cost">金額</param>
        /// <returns>DBファイル形式</returns>
        public static string ToDBFileFormat(string date, string name, string type, string cost)
        {
            const string TEMPLATE = "\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"\"";
            return string.Format(TEMPLATE, date, name, type, cost);
        }

        /// <summary>
        /// DBファイル形式生成
        /// </summary>
        /// <param name="date">日付</param>
        /// <param name="name">名称</param>
        /// <param name="type">種別</param>
        /// <param name="cost">金額</param>
        /// <param name="note">備考</param>
        /// <returns>DBファイル形式生成</returns>
        public static string ToDBFileFormat(string date, string name, string type, string cost, string note)
        {
            const string TEMPLATE = "\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\"";
            return string.Format(TEMPLATE, date, name, type, cost, note);
        }
    }
}
