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
	public partial class ButtonContactControl : UserControl
	{
		public ButtonContactControl()
		{
			// Required to initialize variables
			InitializeComponent();
            this.IsActive = false;
		}

        private void ButtonContact_Click(object sender, RoutedEventArgs e)
        {
            Page.Instance.Navigate(Page.PageType.Contact);
            Page.Instance.SetMenuActive(Page.MenuTypes.Contact);
            VisualStateManager.GoToState(this, "Active", true);
        }

        public bool IsActive { get; set; }
	}
}