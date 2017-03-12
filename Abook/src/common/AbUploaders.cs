// ------------------------------------------------------------
// Copyright (C) 2010-2017 Masaaki Kishi. All rights reserved.
// Author: Masaaki Kishi <m.kishi.5@gmail.com>
// ------------------------------------------------------------
namespace Abook
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Net;
    using System.IO;
    using System.Text;
    using EX   = Abook.AbException.EX;
    using CHK  = Abook.AbUtilities.CHK;
    using UPD  = Abook.AbConstants.UPD;
    using HTTP = Abook.AbConstants.HTTP;

    /// <summary>
    /// アップロードクラス
    /// </summary>
    public static class AbUploaders
    {
        /// <summary>
        /// アップロード
        /// </summary>
        /// <param name="file">ファイル       </param>
        /// <param name="mail">メール         </param>
        /// <param name="pass">パスワード     </param>
        /// <param name="login">ログインURL    </param>
        /// <param name="upload">アップロードURL</param>
        /// <returns>サーバからの応答</returns>
        public static string SendUploadRequest(string file, string mail, string pass, string login, string upload)
        {
            CHK.DbExist(file);
            CHK.MailNull(mail);
            CHK.PassNull(pass);
            CHK.LoginNull(login);
            CHK.UploadNull(upload);
            CHK.UpdCount(AbDBManager.Load(file));

            var result = "";
            using (var wc = new WebClient())
            {
                var token = "";
                byte[] res = null;
                try
                {
                    // 認証
                    var ps = new NameValueCollection();
                    ps.Add(HTTP.PARAMETER.MAIL, mail);
                    ps.Add(HTTP.PARAMETER.PASS, pass);
                    res = wc.UploadValues(login, ps);
                    token = Encoding.UTF8.GetString(res);

                    // アップロード
                    wc.Headers.Add(HTTP.HEADER.TOKEN, token);
                    res = wc.UploadFile(upload, file);
                    result = Encoding.UTF8.GetString(res);
                }
                catch (WebException ex)
                {
                    var message = string.Format("{0}\r\n{1}", EX.UPD_REQ_FAILED, ex.Message);
                    if (ex.Status == WebExceptionStatus.ProtocolError)
                    {
                        var errors = (HttpWebResponse)ex.Response;
                        message = string.Format(
                            "{0}\r\n\r\n{1}\r\n\r\n{2} {3}",
                            EX.UPD_REQ_FAILED,
                            errors.ResponseUri.ToString(),
                            (int)errors.StatusCode,
                            errors.StatusDescription
                        );
                    }
                    AbException.Throw(message);
                }
                catch (Exception ex)
                {
                    var message = string.Format("{0}\r\n{1}", EX.UPD_REQ_FAILED, ex.Message);
                    AbException.Throw(message);
                }
            }
            return result;
        }
    }
}
