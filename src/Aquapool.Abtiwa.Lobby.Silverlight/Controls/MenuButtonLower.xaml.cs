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
using System.Windows.Browser;

namespace Aquapool.Lobby
{
    public partial class MenuButtonLower : UserControl
    {
        public MenuButtonLower()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HtmlPage.Window.Navigate(new Uri("Abtiwa?key=dive", UriKind.Relative));
        }
    }
}
