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
using System.Windows.Media.Imaging;

namespace Aquapool
{
    public partial class ThumbnailControl : UserControl
    {
        public ThumbnailControl(string text, Uri uri)
        {
            // Required to initialize variables
            this.InitializeComponent();
            this.MyImage.Source = new BitmapImage(uri);
            (this.MyViewbox.Child as TextBlock).Text = text;
            this.MouseEnter += new MouseEventHandler(ThumbnailControl_MouseEnter);
            this.MouseLeave += new MouseEventHandler(ThumbnailControl_MouseLeave);
            this.IsActive = false;
        }

        void ThumbnailControl_MouseLeave(object sender, MouseEventArgs e)
        {
            if (IsActive) return;
            VisualStateManager.GoToState(this, "MouseOut", true);
        }

        void ThumbnailControl_MouseEnter(object sender, MouseEventArgs e)
        {
            VisualStateManager.GoToState(this, "MouseOver", true);
        }

        public bool IsActive { get; set; }
    }
}
