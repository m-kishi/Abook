using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;

namespace Abook
{
    /// <summary>
    /// 支出データ管理クラス
    /// </summary>
    public class AbExpenseManager
    {
        /// <summary>レコードセット</summary>
        private List<AbExpense> abExpenses;

        /// <summary>集計値</summary>
        private AbSummary abSummary;

        /// <summary>
        /// コンストラクタ(DB ファイル読み込み)
        /// </summary>
        public AbExpenseManager(string file, DateTime today)
        {
            abExpenses = new List<AbExpense>();
            if (System.IO.File.Exists(file) == false)
            {
                System.IO.File.Create(file).Close();
            }

            using (TextFieldParser parser = new TextFieldParser(file))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                try
                {
                    string[] row;
                    while (parser.EndOfData == false)
                    {
                        row = parser.ReadFields();
                        abExpenses.Add(new AbExpense(row[0], row[1], row[2], row[3]));
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            reload(today);
        }

        /// <summary>
        /// コンストラクタ(DataGridView 読み込み)
        /// </summary>
        public AbExpenseManager(DataGridView dgv)
        {
            abExpenses = new List<AbExpense>();
            foreach (DataGridViewRow row in dgv.Rows)
            {
                abExpenses.Add(
                    new AbExpense(
                        row.Cells["colDate" ].Value.ToString(),
                        row.Cells["colName" ].Value.ToString(),
                        row.Cells["colType" ].Value.ToString(),
                        row.Cells["colPrice"].Value.ToString()
                    )
                );
            }
        }

        /// <summary>
        /// 集計値取得
        /// </summary>
        public int GetPrice(string type)
        {
            return abSummary.GetPrice(type);
        }

        /// <summary>
        /// レコードセット書き出し
        /// </summary>
        public void writeDB(string file)
        {
            using (StreamWriter sw = new StreamWriter(file))
            {
                try
                {
                    foreach (AbExpense exp in abExpenses)
                    {
                        sw.WriteLine(
                            "{0},{1},{2},{3}",
                            exp.Date.ToShortDateString(),
                            exp.Name,
                            exp.Type,
                            exp.Price
                        );
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// 集計値の再読み込み
        /// </summary>
        public void reload(DateTime newDay)
        {
            abSummary = new AbSummary(newDay.Year, newDay.Month, abExpenses);
        }

        /// <summary>
        /// レコードセットアクセッサ
        /// </summary>
        public List<AbExpense> AbExpenses
        {
            get { return this.abExpenses; }
        }
    }
}
