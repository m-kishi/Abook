namespace AbookTest
{
    using Abook;
    using System;
    using System.IO;
    using NUnit.Framework;
    using NUnit.Extensions.Forms;
    using EX = Abook.AbException.EX;

    /// <summary>
    /// メイン画面フォームテスト
    /// </summary>
    [TestFixture]
    public class AbTestFormMain : NUnitFormTest
    {
        /// <summary>引数:DB ファイル</summary>
        private string argDbFile = "AbTestFormMain.db";
        /// <summary>対象:メイン画面フォーム</summary>
        private AbFormMain abFormMain;

        /// <summary>
        /// Setup
        /// </summary>
        public override void Setup()
        {
            base.Setup();
        }

        /// <summary>
        /// TearDown
        /// </summary>
        public override void TearDown()
        {
            try
            {
                var finder = new FormFinder();
                var form = finder.Find(typeof(AbFormMain).Name);
                form.Close();
            }
            catch (NoSuchControlException)
            {
                //すでに閉じられている
            }
            finally
            {
                if (System.IO.File.Exists(argDbFile))
                {
                    System.IO.File.Delete(argDbFile);
                }
            }
            base.TearDown();
        }

        /// <summary>
        /// テストデータ作成
        /// </summary>
        /// <param name="db">DB ファイル名</param>
        private void GenerateDbFile(string db)
        {
            using (StreamWriter sw = new StreamWriter(db, false, System.Text.Encoding.UTF8))
            {
                sw.WriteLine(GenerateWriteLine("2012-01-01", "name1", "type1", 10000));
                sw.WriteLine(GenerateWriteLine("2012-02-30", "name2", "type2", 20000));
                sw.WriteLine(GenerateWriteLine("2012-03-05", "name3", "type3", 30000));
            }
        }

        /// <summary>
        /// 出力用レコード文字列生成
        /// </summary>
        /// <param name="date">日付</param>
        /// <param name="name">名前</param>
        /// <param name="type">種別</param>
        /// <param name="cost">金額</param>
        /// <returns>出力用レコード文字列</returns>
        private string GenerateWriteLine(string date, string name, string type, decimal cost)
        {
            const string TEMPLATE = "\"{0}\",\"{1}\",\"{2}\",\"{3}\"";
            return string.Format(TEMPLATE, date, name, type, cost);
        }

        /// <summary>
        /// Load テスト
        /// 日付の形式が不正
        /// </summary>
        [Test]
        public void LoadWithInvalidDbFile()
        {
            GenerateDbFile(argDbFile);

            //ダイアログの表示テスト
            // Load イベント中でダイアログを表示させている場合、NUnitで検証不可 -> AssertするとNUnitが落ちる？
            // => Assert が成功する場合は落ちないのかも...
            DialogBoxHandler = (name, hWnd) =>
            {
                var messageBox = new MessageBoxTester(hWnd);
                var expected = string.Format(EX.DB_LOAD, 2, EX.DATE_FORMAT);
                Assert.AreEqual("エラー", messageBox.Title);
                Assert.AreEqual(expected, messageBox.Text);
                messageBox.ClickOk();
            };

            abFormMain = new AbFormMain(argDbFile);
            abFormMain.Show();
        }
    }
}
