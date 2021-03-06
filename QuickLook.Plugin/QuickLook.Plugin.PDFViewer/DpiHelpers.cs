using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace QuickLook.Plugin.PDFViewer
{
    internal static class DpiHelper
    {
        public enum DeviceCap
        {
            /// <summary>
            ///     Logical pixels inch in X
            /// </summary>
            LOGPIXELSX = 88,
            /// <summary>
            ///     Logical pixels inch in Y
            /// </summary>
            LOGPIXELSY = 90
        }

        public const float DEFAULT_DPI = 96;

        public static Dpi GetCurrentDpi()
        {
            var g = Graphics.FromHwnd(IntPtr.Zero);
            var desktop = g.GetHdc();

            var dpi = new Dpi
            {
                HorizontalDpi = GetDeviceCaps(desktop, (int) DeviceCap.LOGPIXELSX),
                VerticalDpi = GetDeviceCaps(desktop, (int) DeviceCap.LOGPIXELSY)
            };

            return dpi;
        }

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern int GetDeviceCaps(IntPtr hDC, int nIndex);
    }

    internal class Dpi
    {
        public float HorizontalDpi { get; set; }
        public float VerticalDpi { get; set; }
    }
}