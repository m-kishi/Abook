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
    using Microsoft.VisualBasic.FileIO;
    using EX  = Abook.AbException.EX;
    using DB  = Abook.AbConstants.DB;
    using CHK = Abook.AbUtilities.CHK;
    using COL = Abook.AbConstants.COL.EXPENSE;
    using UTL = Abook.AbUtilities;

    /// <summary>
    /// DBファイル管理クラス
    /// </summary>
    public static class AbDBManager
    {
        /// <summary>
        /// DBファイル読み込み
        /// </summary>
        /// <param name="dbFile">DBファイル</param>
        /// <returns>支出情報リスト</returns>
        public static List<AbExpense> Load(string dbFile)
        {
            CHK.DBFileNull(dbFile);

            if (!File.Exists(dbFile))
            {
                try
                {
                    File.Create(dbFile).Close();
                }
                catch
                {
                    AbException.Throw(EX.DB_FILE_CREATE);
                }
            }

            var expenses = new List<AbExpense>();
            using (var tp = new TextFieldParser(dbFile, DB.ENCODING))
            {
                var line = 0;
                try
                {
                    tp.SetDelimiters(DB.DELIMITER);
                    tp.TextFieldType = FieldType.Delimited;

                    while (!tp.EndOfData)
                    {
                        line++;

                        var fields = tp.ReadFields();
                        if (fields.Length < DB.OLD_FIELD) AbException.Throw(EX.DB_FILE_FIELD_LESS);
                        if (fields.Length > DB.CUR_FIELD) AbException.Throw(EX.DB_FILE_FIELD_MORE);
                        expenses.Add(
                            fields.Length == DB.OLD_FIELD ?
                            new AbExpense(fields[0], fields[1], fields[2], fields[3]) :
                            new AbExpense(fields[0], fields[1], fields[2], fields[3], fields[4])
                        );
                    }
                }
                catch (AbException ex)
                {
                    var message = string.Format(EX.DB_FILE_LOAD, line, ex.Message);
                    AbException.Throw(message);
                }
            }
            return expenses;
        }

        /// <summary>
        /// DataGridViewから読み込み
        /// </summary>
        /// <param name="dgv">DataGridView</param>
        /// <param name="errLine">エラー行参照</param>
        /// <returns>支出情報リスト</returns>
        public static List<AbExpense> Load(DataGridView dgv, out int errLine)
        {
            errLine = 0;
            if (dgv == null || dgv.Rows.Count <= 0)
            {
                return new List<AbExpense>();
            }

            var expenses = new List<AbExpense>();
            foreach (DataGridViewRow row in dgv.Rows)
            {
                errLine++;
                try
                {
                    var date = UTL.ToStr(row.Cells[COL.DATE].Value);
                    var name = UTL.ToStr(row.Cells[COL.NAME].Value);
                    var type = UTL.ToStr(row.Cells[COL.TYPE].Value);
                    var cost = UTL.ToStr(row.Cells[COL.COST].Value);
                    var note = UTL.ToStr(row.Cells[COL.NOTE].Value);

                    var args = new string[] { date, name, type, cost };
                    if (args.All(arg => !string.IsNullOrEmpty(arg)))
                    {
                        expenses.Add(new AbExpense(date, name, type, cost, note));
                    }
                }
                catch (AbException ex)
                {
                    var message = string.Format(EX.DB_FILE_LOAD, errLine, ex.Message);
                    AbException.Throw(message);
                }
            }
            return expenses;
        }

        /// <summary>
        /// DBファイル書き出し
        /// </summary>
        /// <param name="dbFile">DBファイル</param>
        /// <param name="expenses">支出情報リスト</param>
        public static void Store(string dbFile, List<AbExpense> expenses)
        {
            CHK.DBFileNull(dbFile);
            CHK.ExpCount(expenses);

            using (var sw = new StreamWriter(dbFile, false, DB.ENCODING))
            {
                var line = 0;
                try
                {
                    sw.NewLine = DB.LF;
                    foreach (var exp in expenses)
                    {
                        line++;
                        sw.WriteLine(exp.ToDBFileFormat());
                    }
                    sw.Close();
                }
                catch (Exception ex)
                {
                    var message = string.Format(EX.DB_FILE_STORE, line, ex.Message);
                    AbException.Throw(message);
                }
            }
        }
    }
}
