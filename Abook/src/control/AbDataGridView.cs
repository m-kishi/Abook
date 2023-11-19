// ------------------------------------------------------------
// © 2010 https://github.com/m-kishi
// ------------------------------------------------------------
namespace Abook
{
    using System.Windows.Forms;

    /// <summary>
    /// 支出情報入力のためのDataGridView
    /// </summary>
    public class AbDataGridView : DataGridView
    {
        /// <summary>
        /// キーが押されているかの判定
        /// </summary>
        /// <param name="keyData">キー入力</param>
        /// <param name="keyList">判定したいキー</param>
        /// <returns>true:押されている false:押されていない</returns>
        private bool Pressed(Keys keyData, params Keys[] keyList)
        {
            Keys mask = Keys.None;
            foreach (Keys key in keyList)
            {
                mask |= key;
            }

            foreach (Keys key in keyList)
            {
                if ((keyData & mask) == key)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// NULL値入力(Ctrl + 0)を抑制する
        /// </summary>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Pressed(keyData, Keys.Control) && Pressed(keyData, Keys.D0, Keys.NumPad0)) {
                return true;
            }

            return base.ProcessDialogKey(keyData);
        }

        /// <summary>
        /// NULL値入力(Ctrl + 0)を抑制する
        /// </summary>
        protected override bool ProcessDataGridViewKey(KeyEventArgs e)
        {
            if (e.Control && Pressed(e.KeyCode, Keys.D0, Keys.NumPad0))
            {
                return true;
            }

            return base.ProcessDataGridViewKey(e);
        }
    }
}
