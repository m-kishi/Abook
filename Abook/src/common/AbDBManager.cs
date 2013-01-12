﻿namespace Abook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using Microsoft.VisualBasic.FileIO;
    using EX  = Abook.AbException.EX;
    using COL = Abook.AbConstants.COL;
    using CSV = Abook.AbConstants.CSV;

    /// <summary>
    /// DB ファイル管理クラス
    /// </summary>
    public static class AbDBManager
    {
        /// <summary>
        /// DB ファイル読み込み
        /// </summary>
        /// <param name="file">DB ファイル名</param>
        /// <returns>支出レコードリスト</returns>
        public static List<AbExpense> Load(string file)
        {
            if (string.IsNullOrEmpty(file))
            {
                AbException.Throw(EX.DB_NULL);
            }

            if (System.IO.File.Exists(file) == false)
            {
                try
                {
                    System.IO.File.Create(file).Close();
                }
                catch
                {
                    AbException.Throw(EX.DB_CREATE);
                }
            }

            var expenses = new List<AbExpense>();
            using (var tp = new TextFieldParser(file, System.Text.Encoding.UTF8))
            {
                var line = 0;
                try
                {
                    tp.SetDelimiters(CSV.DELIMITER);
                    tp.TextFieldType = FieldType.Delimited;

                    while (!tp.EndOfData)
                    {
                        line++;

                        var fields = tp.ReadFields();
                        if (fields.Length < CSV.FIELD) { AbException.Throw(EX.DB_FIELD_LESS); }
                        if (fields.Length > CSV.FIELD) { AbException.Throw(EX.DB_FIELD_MORE); }
                        expenses.Add(new AbExpense(fields[0], fields[1], fields[2], fields[3]));
                    }
                }
                catch (AbException ex)
                {
                    var message = string.Format(EX.DB_LOAD, line, ex.Message);
                    AbException.Throw(message);
                }
            }
            return expenses;
        }

        /// <summary>
        /// DataGridView から読み込み
        /// </summary>
        /// <param name="dgv">DataGridView</param>
        /// <param name="errLine">エラー行参照</param>
        /// <returns>支出レコードリスト</returns>
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
                    var date = Convert.ToString(row.Cells[COL.DATE].Value);
                    var name = Convert.ToString(row.Cells[COL.NAME].Value);
                    var type = Convert.ToString(row.Cells[COL.TYPE].Value);
                    var cost = Convert.ToString(row.Cells[COL.COST].Value);

                    var args = new string[] { date, name, type, cost };
                    if (args.All(arg => !string.IsNullOrEmpty(arg)))
                    {
                        expenses.Add(new AbExpense(date, name, type, cost));
                    }
                }
                catch (AbException ex)
                {
                    var message = string.Format(EX.DB_LOAD, errLine, ex.Message);
                    AbException.Throw(message);
                }
            }
            return expenses;
        }

        /// <summary>
        /// DB ファイル書き出し
        /// </summary>
        /// <param name="file">DB ファイル名</param>
        /// <param name="expenses">支出レコードリスト</param>
        public static void Store(string file, List<AbExpense> expenses)
        {
            if (string.IsNullOrEmpty(file))
            {
                AbException.Throw(EX.DB_NULL);
            }

            if (expenses == null || expenses.Count <= 0)
            {
                AbException.Throw(EX.DB_RECORD_NOTHING);
            }

            using (var sw = new System.IO.StreamWriter(file, false, System.Text.Encoding.UTF8))
            {
                var line = 0;
                try
                {
                    foreach (var exp in expenses)
                    {
                        line++;
                        sw.WriteLine(exp.ToCSV());
                    }
                }
                catch (Exception ex)
                {
                    var message = string.Format(EX.DB_STORE, line, ex.Message);
                    AbException.Throw(message);
                }
            }
        }
    }
}