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

namespace Aquapool
{
    public partial class GalleryButton : UserControl
    {
        public GalleryButton()
        {
            InitializeComponent();
            this.MouseEnter += new MouseEventHandler(ThumbnailControl_MouseEnter);
            this.MouseLeave += new MouseEventHandler(ThumbnailControl_MouseLeave);
            this.MouseLeftButtonUp += new MouseButtonEventHandler(GalleryButton_MouseLeftButtonUp);
        }

        void ThumbnailControl_MouseLeave(object sender, MouseEventArgs e)
        {
            VisualStateManager.GoToState(this, "MouseOut", true);
        }

        void ThumbnailControl_MouseEnter(object sender, MouseEventArgs e)
        {
            VisualStateManager.GoToState(this, "MouseOver", true);
        }
        private void GalleryButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (Page.Instance.CurrentPageType == Page.PageType.AbtiwaGallery) return;
            Page.Instance.Navigate(Page.PageType.AbtiwaGallery);
        }
    }
}
