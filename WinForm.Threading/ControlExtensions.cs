using System;
using System.Windows.Forms;

namespace WinForm.Threading
{
    /// <summary>
    /// Extension method that enables to communicate to the UI thread
    /// </summary>
    public static class ControlExtensions
    {
        public static void InvokeRequired<T>(this T c, Action<T> action) where T : Control
        {
            if (c.InvokeRequired)
            {
                c.Invoke(new Action(() => action(c)));
            }
            else
            {
                action(c);
            }
        }
    }
}
