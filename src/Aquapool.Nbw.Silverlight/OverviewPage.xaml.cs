using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Nbw
{
	public partial class OverviewPage : UserControl
	{
		public OverviewPage()
		{
			// Required to initialize variables
			InitializeComponent();
            // HACK: Viewbox does not expose child element.
            InitializeButtons();
		}

        private void InitializeButtons()
        {
            this.ButtonKopierService = this.ViewboxKopierServiceButton.Child as Button;
            this.ButtonYachtCharter = this.ViewBoxYachtCharterButton.Child as Button;
            this.ButtonNbw = this.ViewboxNbwButton.Child as Button;
        }

        private void ButtonNbw_Click(object sender, RoutedEventArgs e)
        {
            Root.Instance.Navigate(Root.MenuType.Wasserbau, true);
        }

        private void ButtonNbw_MouseEnter(object sender, MouseEventArgs e)
        {
            VisualStateManager.GoToState(this.ButtonNbw, "MouseOver", true);
        }
      
        private void ButtonYachtCharter_Click(object sender, RoutedEventArgs e)
        {
            Root.Instance.Navigate(Root.MenuType.YachtCharter, true);
        }

        private void ButtonYachtCharter_MouseEnter(object sender, MouseEventArgs e)
        {
            VisualStateManager.GoToState(this.ButtonYachtCharter, "MouseOver", true);
        }

        private void ButtonKopierService_Click(object sender, RoutedEventArgs e)
        {
            Root.Instance.Navigate(Root.MenuType.KopierService, true);
        }

        private void ButtonKopierService_MouseEnter(object sender, MouseEventArgs e)
        {
            VisualStateManager.GoToState(this.ButtonKopierService, "MouseOver", true);
        }

        private void ButtonNbw_MouseLeave(object sender, MouseEventArgs e)
        {
            VisualStateManager.GoToState(this.ButtonNbw, "MouseOut", true);
        }

        private void ButtonYachtCharter_MouseLeave(object sender, MouseEventArgs e)
        {
            VisualStateManager.GoToState(this.ButtonYachtCharter, "MouseOut", true);
        }

        private void ButtonKopierService_MouseLeave(object sender, MouseEventArgs e)
        {
            VisualStateManager.GoToState(this.ButtonKopierService, "MouseOut", true);
        }
	}
}