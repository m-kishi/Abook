namespace AbookTest
{
    using System;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Threading;
    using System.Web;

    /// <summary>
    /// テスト用のWEBサーバ
    /// </summary>
    public static class AbWebServer
    {
        /// <summary>URL</summary>
        private const string URI_PREFIX  = "http://*:9999/";

        /// <summary>ログインURL</summary>
        public const string URL_LOGIN                      = "http://localhost:9999/LOGIN_OK";
        /// <summary>ログインURL(ログイン失敗)</summary>
        public const string URL_LOGIN_FAILED               = "http://localhost:9999/LOGIN_NG";
        /// <summary>ログインURL(アクセストークンエラー)</summary>
        public const string URL_LOGIN_INVALID_ACCESS_TOKEN = "http://localhost:9999/INVALID_ACCESS_TOKEN";
        /// <summary>アップロードURL</summary>
        public const string URL_UPLOAD                     = "http://localhost:9999/UPLOAD_OK";
        /// <summary>アップロードURL(アップロード失敗)</summary>
        public const string URL_UPLOAD_FAILED              = "http://localhost:9999/UPLOAD_NG";

        /// <summary>メール</summary>
        public const string MAIL = "mail=text@example.com";
        /// <summary>パスワード</summary>
        public const string PASS = "pass=secret_passwords";
        /// <summary>アクセストークン</summary>
        private const string ACCESS_TOKEN = "5c89c2e8f26f535719169eefaa14e20b";

        /// <summary>スレッド継続判定</summary>
        private static bool running;
        /// <summary>リスナー用の別スレッド</summary>
        private static Thread thread;
        /// <summary>リスナー</summary>
        private static HttpListener listener;

        /// <summary>
        /// サーバ起動
        /// </summary>
        public static void Start()
        {
            running = true;
            try
            {
                listener = new HttpListener();
                listener.Prefixes.Add(URI_PREFIX);  //URI_PREFIX末尾にスラッシュ必須
                listener.Start();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            thread = new Thread(new ThreadStart(() =>
            {
                while (running)
                {
                    var context = listener.GetContext();
                    var req = context.Request;
                    var res = context.Response;
                    if (req.RawUrl.Contains("LOGIN_OK"))
                    {
                        res.StatusCode = 404;
                        if (req.HasEntityBody)
                        {
                            var data = ReadBodyData(req);
                            if (data.Contains(MAIL) && data.Contains(PASS))
                            {
                                res.StatusCode = 200;
                                var buffer = Encoding.UTF8.GetBytes(ACCESS_TOKEN);
                                res.OutputStream.Write(buffer, 0, buffer.Length);
                            }
                        }
                    }
                    if (req.RawUrl.Contains("LOGIN_NG"))
                    {
                        res.StatusCode = 404;
                    }
                    if (req.RawUrl.Contains("INVALID_ACCESS_TOKEN"))
                    {
                        res.StatusCode = 200;
                        var buffer = Encoding.UTF8.GetBytes("INVALID-ACCESS-TOKEN");
                        res.OutputStream.Write(buffer, 0, buffer.Length);
                    }
                    if (req.RawUrl.Contains("UPLOAD_OK"))
                    {
                        res.StatusCode = 500;
                        var token = req.Headers["ACCESS_TOKEN"];
                        if (token == ACCESS_TOKEN && req.HasEntityBody)
                        {
                            res.StatusCode = 200;
                        }
                    }
                    if (req.RawUrl.Contains("UPLOAD_NG"))
                    {
                        res.StatusCode = 500;
                    }

                    //0.5秒程待機
                    //AbTestSubUploadでバックグラウンドの処理が早すぎて
                    //コントロールの表示切替が失敗することがあるため
                    Thread.Sleep(500);

                    res.Close();
                }
            }));
            thread.Start();
        }

        /// <summary>
        /// 送信データを読み取り
        /// </summary>
        /// <param name="req">リクエスト</param>
        /// <returns>受信データ</returns>
        private static string ReadBodyData(HttpListenerRequest req)
        {
            var data = "";
            using (var st = req.InputStream)
            {
                using (var sr = new StreamReader(st, req.ContentEncoding))
                {
                    //URLデコードして取得
                    data = HttpUtility.UrlDecode(sr.ReadToEnd(), Encoding.UTF8);
                }
            }
            return data;
        }

        /// <summary>
        /// サーバ終了
        /// </summary>
        public static void Finish()
        {
            running = false;
            if (thread   != null) { thread  .Abort(); thread   = null; }
            if (listener != null) { listener.Close(); listener = null; }
        }
    }
}
