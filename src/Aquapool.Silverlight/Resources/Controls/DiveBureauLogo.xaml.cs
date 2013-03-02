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
	public partial class DiveBureauLogo : UserControl
	{
		public DiveBureauLogo()
		{
			// Required to initialize variables
			InitializeComponent();
            this.IsActive = false;
		}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Page.Instance.Navigate(Page.PageType.DiveBureau);
        }

        private void UserControl_MouseEnter(object sender, MouseEventArgs e)
        {
            VisualStateManager.GoToState(Page.Instance.TransitionIngSide.CurrentPage, "MouseOver", true);
            VisualStateManager.GoToState(Page.Instance.TransitionIngMain.CurrentPage, "MouseOver", true);
        }

        private void UserControl_MouseLeave(object sender, MouseEventArgs e)
        {
            if (IsActive)
            {
                return;
            }
            VisualStateManager.GoToState(Page.Instance.TransitionIngSide.CurrentPage, "MouseOut", true);
            VisualStateManager.GoToState(Page.Instance.TransitionIngMain.CurrentPage, "MouseOut", true);
        }

        private void UserControl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Page.Instance.ClearActiveStates();
            this.IsActive = true;
            VisualStateManager.GoToState(Page.Instance.TransitionIngSide.CurrentPage, "MouseOver", true);
            Page.Instance.Navigate(Page.PageType.DiveBureau);
        }

        public bool IsActive { get; set; }
	}
}