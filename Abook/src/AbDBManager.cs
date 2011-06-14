namespace Abook
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;
    using Microsoft.VisualBasic.FileIO;

    /// <summary>
    /// DB ファイル管理クラス
    /// </summary>
    public static class AbDBManager
    {
        /// <summary>
        /// DB ファイル読み込み
        /// </summary>
        public static List<AbExpense> LoadFromFile(string file)
        {
            if (string.IsNullOrEmpty(file))
            {
                throw new ArgumentException("DB ファイルを指定してください。");
            }

            if (File.Exists(file) == false)
            {
                File.Create(file).Close();
            }

            var abExpenses = new List<AbExpense>();
            using (var tp = new TextFieldParser(file, Encoding.UTF8))
            {
                try
                {
                    tp.SetDelimiters(",");
                    tp.TextFieldType = FieldType.Delimited;

                    while (tp.EndOfData == false)
                    {
                        var row = tp.ReadFields();
                        abExpenses.Add(new AbExpense(row[0], row[1], row[2], row[3]));
                    }
                }
                catch
                {
                    throw new Exception("DB ファイル読み込みに失敗しました。");
                }
            }

            return abExpenses;
        }

        /// <summary>
        /// DB ファイル書き出し
        /// </summary>
        public static List<AbExpense> StoreToFile(string file, DataGridView dgv)
        {
            if (string.IsNullOrEmpty(file))
            {
                throw new ArgumentException("DB ファイルが指定されませんでした。");
            }

            if (dgv.Rows.Count == 0)
            {
                throw new ArgumentException("データがありません。");
            }

            var abExpenses = new List<AbExpense>();
            using (var sw = new StreamWriter(file, false, Encoding.UTF8))
            {
                try
                {
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        var exp = new AbExpense(
                            row.Cells["colDate"].Value.ToString(),
                            row.Cells["colName"].Value.ToString(),
                            row.Cells["colType"].Value.ToString(),
                            row.Cells["colPrice"].Value.ToString()
                        );

                        abExpenses.Add(exp);
                        sw.WriteLine(exp.ToCSVFormat());
                    }
                }
                catch
                {
                    throw new Exception("DB ファイル書き出しに失敗しました。");
                }
            }

            return abExpenses;
        }
    }
}
