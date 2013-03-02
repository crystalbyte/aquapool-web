using System;
using System.Windows.Media.Animation;

namespace Aquapool.Nbw
{
    internal static class Utility
    {
        public static void Launch(TimeSpan time, Storyboard board)
        {
            var sb = new Storyboard();
            sb.Duration = time;
            sb.Completed += delegate { board.Begin(); };

            sb.Begin();
        }
    }
}
