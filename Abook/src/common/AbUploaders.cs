﻿namespace Abook
{
    using System;
    using System.Collections.Generic;
    using EX  = Abook.AbException.EX;
    using UPD = Abook.AbConstants.UPD;

    /// <summary>
    /// アップロードクラス
    /// </summary>
    public static class AbUploaders
    {
        /// <summary>
        /// アップロード
        /// </summary>
        /// <param name="url">リクエストURL</param>
        /// <param name="file">UPDファイル名</param>
        /// <returns>サーバからの応答</returns>
        public static string SendUploadRequest(string url, string file)
        {
            if (string.IsNullOrEmpty(url )) { AbException.Throw(EX.URL_NULL); }
            if (string.IsNullOrEmpty(file)) { AbException.Throw(EX.UPD_NULL); }
            if (!System.IO.File.Exists(file)) { AbException.Throw(EX.UPD_DOES_NOT_EXIST); }

            string result = string.Empty;
            using (var wc = new System.Net.WebClient())
            {
                try
                {
                    var res = wc.UploadFile(url, file);
                    result = System.Text.Encoding.UTF8.GetString(res);
                }
                catch (System.Net.WebException ex)
                {
                    var message = string.Format("{0}:\r\n{1}", EX.UPD_REQ_FAILED, ex.Message);
                    AbException.Throw(message);
                }
                catch (Exception ex)
                {
                    var message = string.Format("{0}:\r\n{1}", EX.UPD_RES_FAILED, ex.Message);
                    AbException.Throw(message);
                }
                finally
                {
                    try { System.IO.File.Delete(file); } catch { }
                }
            }
            return result;
        }

        /// <summary>
        /// UPDファイル書き出し
        /// </summary>
        /// <param name="file">UPDファイル名</param>
        /// <param name="expenses">支出情報リスト</param>
        public static void Prepare(string file, List<AbExpense> expenses)
        {
            if (string.IsNullOrEmpty(file)) { AbException.Throw(EX.UPD_NULL); }
            if (expenses == null || expenses.Count <= 0) { AbException.Throw(EX.UPD_RECORD_NOTHING); }

            try
            {
                System.IO.File.Delete(file);
                System.IO.File.Create(file).Close();
            }
            catch (Exception ex)
            {
                var message = string.Format(EX.UPD_CREATE, ex.Message);
                AbException.Throw(message);
            }

            using (var sw = new System.IO.StreamWriter(file, false, UPD.ENCODING))
            {
                var line = 0;
                try
                {
                    sw.NewLine = UPD.LF;
                    foreach (var exp in expenses)
                    {
                        line++;
                        sw.WriteLine(exp.ToSQL());
                    }
                    sw.Close();
                }
                catch (Exception ex)
                {
                    var message = string.Format(EX.UPD_PREPARE, line, ex.Message);
                    AbException.Throw(message);
                }
            }
        }
    }
}
