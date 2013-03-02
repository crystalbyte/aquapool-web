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
    internal class ClearEffect : EffectBase
    {
        public override void Begin()
        {
            this.OnEffectCompleted(this, EventArgs.Empty);
        }

        public override void Initialize(UserControl control)
        {
            control.Opacity = 0;
        }

        protected override void OnEffectCompleted(object sender, EventArgs e)
        {
            base.OnEffectCompleted(sender, e);
        }
    }
}
