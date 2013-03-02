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

using Crystalbyte.Controls.Transition.Effects;

namespace Aquapool.Effects
{
    internal class FadeOutEffect : FadeEffect
    {
        public FadeOutEffect() : base()
        {
            this.From = 1;
            this.To = 0;
        }
    }
}
