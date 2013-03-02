using System;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Aquapool {
    internal class TransitionProvider {
        private static readonly HashSet<Storyboard> Boards = new HashSet<Storyboard>();
        public delegate void EffectDelegate(UserControl control);
        public static void Launch(TimeSpan duration, EffectDelegate function, UserControl control) {

            var board = new Storyboard { Duration = duration };
            board.Completed += delegate {
                function(control);
                lock (Boards) {
                    Boards.Remove(board);
                }
            };
            lock (Boards) {
                Boards.Add(board);
            }
            board.Begin();
        }
    }
}
