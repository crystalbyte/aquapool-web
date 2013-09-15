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

namespace Aquapool.Lobby
{
	public partial class MenuButtonUpper : UserControl
	{
		public MenuButtonUpper()
		{
			// Required to initialize variables
			InitializeComponent();
		}

        private void ButtonIng_Click(object sender, RoutedEventArgs e)
        {
            HtmlPage.Window.Navigate(new Uri("Abtiwa?key=abtiwa",UriKind.Relative)); 
        }
	}
}