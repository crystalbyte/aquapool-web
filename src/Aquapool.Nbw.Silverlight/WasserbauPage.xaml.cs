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
	public partial class WasserbauPage : UserControl
	{
		public WasserbauPage()
		{
			// Required to initialize variables
			InitializeComponent();
            this.ContentGrid.Children.Add(new NbwTextPanel());
		}

        private NbwGalleryPanel EnsureGalleryPanelExistence()
        {
            if (!(this.ContentGrid.Children[0] is NbwGalleryPanel))
            {
                this.ContentGrid.Opacity = 0;
                this.ContentGrid.Children.Clear();
                this.ContentGrid.Children.Add(new NbwGalleryPanel());
                var panel = this.ContentGrid.Children[0] as NbwGalleryPanel;
                panel.Close += new EventHandler(panel_Close);
                var sb = this.Resources["FadeInNbwContent"] as Storyboard;
                sb.Begin();
            }

            return this.ContentGrid.Children[0] as NbwGalleryPanel;
        }

        void Reset()
        {
            this.ContentGrid.Children.Clear();
            this.ContentGrid.Children.Add(new NbwTextPanel());
            var sb = this.Resources["FadeInNbwContent"] as Storyboard;
            sb.Begin();
        }

        void panel_Close(object sender, EventArgs e)
        {
            this.Reset();
        }

        private void ThumbnailButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var gallery = this.EnsureGalleryPanelExistence();
            gallery.ShowPicture(Pictures.PictureText1, 1, 6, Pictures.PicturePath1);
        }

        void SwapContent(UserControl contentControl)
        {
            {
                this.ContentGrid.Opacity = 0;
                this.ContentGrid.Children.Clear();
                this.ContentGrid.Children.Add(contentControl);
                var sb = this.Resources["FadeInNbwContent"] as Storyboard;
                sb.Begin();
            }
        }

        private void ThumbnailButton2_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var gallery = this.EnsureGalleryPanelExistence();
            gallery.ShowPicture(Pictures.PictureText2, 2, 6, Pictures.PicturePath2);
        }

        private void ThumbnailButton3_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var gallery = this.EnsureGalleryPanelExistence();
            gallery.ShowPicture(Pictures.PictureText3, 3, 6, Pictures.PicturePath3);
        }

        private void ThumbnailButton4_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var gallery = this.EnsureGalleryPanelExistence();
            gallery.ShowPicture(Pictures.PictureText4, 4, 6, Pictures.PicturePath4);
        }

        private void ThumbnailButton5_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var gallery = this.EnsureGalleryPanelExistence();
            gallery.ShowPicture(Pictures.PictureText5, 5, 6, Pictures.PicturePath5);
        }

        private void ThumbnailButton6_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var gallery = this.EnsureGalleryPanelExistence();
            gallery.ShowPicture(Pictures.PictureText6, 6, 6, Pictures.PicturePath6);
        }
	}
}