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
    public partial class DiveBureauThumbnailPanel : UserControl
    {
       

        public DiveBureauThumbnailPanel()
        {
            InitializeComponent();
        }

        private void HeaderLayer_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (Page.Instance.CurrentPageType == Page.PageType.DiveBureauGallery) return;
            VisualStateManager.GoToState(this, "MouseLeftUp", true);
            Page.Instance.Navigate(Page.PageType.DiveBureauGallery);
        }

        private void rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            VisualStateManager.GoToState(this, "MouseLeftDown", true);
        }

        private void rectangle_MouseEnter(object sender, MouseEventArgs e)
        {
            VisualStateManager.GoToState(this, "MouseOver", true);
        }

        private void rectangle_MouseLeave(object sender, MouseEventArgs e)
        {
            VisualStateManager.GoToState(this, "MouseOut", true);
        }
    }
}
