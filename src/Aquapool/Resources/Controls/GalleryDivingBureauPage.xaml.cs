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
	public partial class GalleryDivingBureauPage : UserControl
	{
        public event EventHandler Next;
        public event EventHandler Previous;

		public GalleryDivingBureauPage()
		{
			// Required to initialize variables
			InitializeComponent();
		}
	}
}