using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Aquapool.Nbw
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
            VisualStateManager.GoToState(ButtonCommit, "MouseOut", true);
        }
    }
}
