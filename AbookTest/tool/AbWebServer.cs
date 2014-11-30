﻿namespace AbookTest
{
    using System;
    using System.Net;
    using System.Threading;

    /// <summary>
    /// テスト用のWEBサーバ
    /// </summary>
    public static class AbWebServer
    {
        /// <summary>URL</summary>
        private const string uriPrefix = "http://*:9999/";
        /// <summary>成功用 URL</summary>
        public const string URL_SUCCESS = "http://localhost:9999/SUCCESS";
        /// <summary>失敗用 URL</summary>
        public const string URL_FAILURE = "http://localhost:9999/FAILURE";

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
                listener.Prefixes.Add(uriPrefix);
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
                    if (req.RawUrl.Contains("SUCCESS"))
                    {
                        res.StatusCode = 200;
                        var buffer = System.Text.UTF8Encoding.UTF8.GetBytes("200");
                        res.OutputStream.Write(buffer, 0, buffer.Length);
                    }
                    if (req.RawUrl.Contains("FAILURE"))
                    {
                        res.StatusCode = 500;
                        var buffer = System.Text.Encoding.UTF8.GetBytes("AbWebServer Internal Error");
                        res.OutputStream.Write(buffer, 0, buffer.Length);
                    }
                    res.Close();
                }
            }));
            thread.Start();
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

        /// <summary>
        /// サーバ状態
        /// </summary>
        /// <returns>true:起動中、false:停止中</returns>
        public static bool IsRunning()
        {
            return running;
        }
    }
}