using System.Runtime.InteropServices;

namespace Services.Helpers
{
    public static class ControlExtensions
    {
        private const int WM_SETREDRAW = 0x000B;

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        public static void SuspendDrawing(this Control ctrl)
        {
            SendMessage(ctrl.Handle, WM_SETREDRAW, IntPtr.Zero, IntPtr.Zero);
        }

        public static void ResumeDrawing(this Control ctrl)
        {
            SendMessage(ctrl.Handle, WM_SETREDRAW, new IntPtr(1), IntPtr.Zero);
            ctrl.Invalidate();
        }
    }
}
