using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Aquapool.Nbw
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
            ButtonKopierService = ViewboxKopierServiceButton.Child as Button;
            ButtonYachtCharter = ViewBoxYachtCharterButton.Child as Button;
            ButtonNbw = ViewboxNbwButton.Child as Button;
        }

        private void ButtonNbw_Click(object sender, RoutedEventArgs e)
        {
            Root.Instance.Navigate(Root.MenuType.Wasserbau, true);
        }

        private void ButtonNbw_MouseEnter(object sender, MouseEventArgs e)
        {
            VisualStateManager.GoToState(ButtonNbw, "MouseOver", true);
        }

        private void ButtonYachtCharter_Click(object sender, RoutedEventArgs e)
        {
            Root.Instance.Navigate(Root.MenuType.YachtCharter, true);
        }

        private void ButtonYachtCharter_MouseEnter(object sender, MouseEventArgs e)
        {
            VisualStateManager.GoToState(ButtonYachtCharter, "MouseOver", true);
        }

        private void ButtonKopierService_Click(object sender, RoutedEventArgs e)
        {
            Root.Instance.Navigate(Root.MenuType.KopierService, true);
        }

        private void ButtonKopierService_MouseEnter(object sender, MouseEventArgs e)
        {
            VisualStateManager.GoToState(ButtonKopierService, "MouseOver", true);
        }

        private void ButtonNbw_MouseLeave(object sender, MouseEventArgs e)
        {
            VisualStateManager.GoToState(ButtonNbw, "MouseOut", true);
        }

        private void ButtonYachtCharter_MouseLeave(object sender, MouseEventArgs e)
        {
            VisualStateManager.GoToState(ButtonYachtCharter, "MouseOut", true);
        }

        private void ButtonKopierService_MouseLeave(object sender, MouseEventArgs e)
        {
            VisualStateManager.GoToState(ButtonKopierService, "MouseOut", true);
        }
    }
}
