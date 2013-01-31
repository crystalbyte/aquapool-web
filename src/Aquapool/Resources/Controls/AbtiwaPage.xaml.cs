using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Aquapool
{
    public partial class AbtiwaPage : UserControl
    {
        public AbtiwaPage()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(AbtiwaPage_Loaded);
        }

        void AbtiwaPage_Loaded(object sender, RoutedEventArgs e)
        {
            Page.Instance.TransitionCornerBoxContent.PerformTransition(new CornerBoxContentAbtiwa());
            this.Loaded -= new RoutedEventHandler(AbtiwaPage_Loaded);
        }
    }
}
