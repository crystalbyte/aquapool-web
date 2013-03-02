using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Nbw
{
    internal static class Utility
    {
        public static void Launch(TimeSpan time, Storyboard board)
        {
            var sb = new Storyboard();
            sb.Duration = time;
            sb.Completed += delegate(object sender, EventArgs e)
            {
                board.Begin();
            };

            sb.Begin();
        }
    }
}
