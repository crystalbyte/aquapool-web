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

namespace Aquapool
{
    internal class TransitionTimer
    {
        public delegate void EffectDelegate(UserControl control);
        public static void Launch(TimeSpan duration, EffectDelegate function, UserControl control)
        {
            Storyboard board = new Storyboard();
            board.Duration = duration;
            board.Completed += delegate
            {
                function(control);
            };
            board.Begin();
        }
    }
}
