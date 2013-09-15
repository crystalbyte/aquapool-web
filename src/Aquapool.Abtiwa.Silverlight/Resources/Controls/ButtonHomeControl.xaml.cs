using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Browser;

namespace Aquapool
{
	public partial class ButtonHomeControl : UserControl
	{
		public ButtonHomeControl()
		{
			// Required to initialize variables
			InitializeComponent();
            this.IsActive = false;
		}

        private void ButtonHome_Click(object sender, RoutedEventArgs e)
        {
            HtmlPage.Window.Navigate(new Uri("Abtiwa", UriKind.Relative));
        }

        public bool IsActive { get; set; }
	}
}