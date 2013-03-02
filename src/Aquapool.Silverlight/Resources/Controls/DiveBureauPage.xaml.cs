using System;
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
	public partial class DiveBureauPage : UserControl
	{
		public DiveBureauPage()
		{
			// Required to initialize variables
			InitializeComponent();
            this.Loaded += new RoutedEventHandler(DiveBureauPage_Loaded);
		}

        void DiveBureauPage_Loaded(object sender, RoutedEventArgs e)
        {
            Page.Instance.TransitionCornerBoxContent.PerformTransition(new CornerBoxContentDiveBureau());
            this.Loaded -= new RoutedEventHandler(DiveBureauPage_Loaded);
        }
	}
}