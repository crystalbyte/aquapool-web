using System;
using System.Windows;
using System.Windows.Controls;

namespace Aquapool.Nbw
{
    public partial class RedDot : UserControl
    {
        public RedDot()
        {
            // Required to initialize variables
            InitializeComponent();
            Loaded += RedDot_Loaded;
        }

        private void RedDot_Loaded(object sender, RoutedEventArgs e)
        {
            StoryboardImpulse.BeginTime = TimeSpan.FromMilliseconds(500);
            StoryboardImpulse.Begin();
        }
    }
}
