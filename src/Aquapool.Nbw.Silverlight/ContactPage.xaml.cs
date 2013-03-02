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
	public partial class ContactPage : UserControl
	{
		public ContactPage()
		{
			// Required to initialize variables
			InitializeComponent();
		}

        private void ButtonCommit_MouseLeave(object sender, MouseEventArgs e)
        {
            VisualStateManager.GoToState(this.ButtonCommit, "MouseOut", true);
        }
	}
}