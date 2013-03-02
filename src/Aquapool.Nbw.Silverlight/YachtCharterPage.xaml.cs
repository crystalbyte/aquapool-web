using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace Aquapool.Nbw
{
    public partial class YachtCharterPage : UserControl
    {
        public YachtCharterPage()
        {
            // Required to initialize variables
            InitializeComponent();
            ContentGrid.Children.Add(new YachtCharterTextPage());
        }

        private YachtCharterGalleryPage EnsureGalleryPanelExistence()
        {
            if (!(ContentGrid.Children[0] is YachtCharterGalleryPage))
            {
                ContentGrid.Opacity = 0;
                ContentGrid.Children.Clear();
                ContentGrid.Children.Add(new YachtCharterGalleryPage());
                var panel = ContentGrid.Children[0] as YachtCharterGalleryPage;
                panel.Close += panel_Close;
                var sb = Resources["FadeInNbwContent"] as Storyboard;
                sb.Begin();
            }

            return ContentGrid.Children[0] as YachtCharterGalleryPage;
        }

        private void Reset()
        {
            ContentGrid.Children.Clear();
            ContentGrid.Children.Add(new YachtCharterTextPage());
            var sb = Resources["FadeInNbwContent"] as Storyboard;
            sb.Begin();
        }

        private void panel_Close(object sender, EventArgs e)
        {
            Reset();
        }

        private void ThumbnailButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            YachtCharterGalleryPage gallery = EnsureGalleryPanelExistence();
            gallery.ShowPicture(Pictures.PictureText1, 1, 6, Pictures.PicturePath1);
        }

        private void SwapContent(UserControl contentControl)
        {
            {
                ContentGrid.Opacity = 0;
                ContentGrid.Children.Clear();
                ContentGrid.Children.Add(contentControl);
                var sb = Resources["FadeInNbwContent"] as Storyboard;
                sb.Begin();
            }
        }

        private void ThumbnailButton2_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            YachtCharterGalleryPage gallery = EnsureGalleryPanelExistence();
            gallery.ShowPicture(Pictures.PictureText2, 2, 6, Pictures.PicturePath2);
        }

        private void ThumbnailButton3_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            YachtCharterGalleryPage gallery = EnsureGalleryPanelExistence();
            gallery.ShowPicture(Pictures.PictureText3, 3, 6, Pictures.PicturePath3);
        }

        private void ThumbnailButton4_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            YachtCharterGalleryPage gallery = EnsureGalleryPanelExistence();
            gallery.ShowPicture(Pictures.PictureText4, 4, 6, Pictures.PicturePath4);
        }

        private void ThumbnailButton5_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            YachtCharterGalleryPage gallery = EnsureGalleryPanelExistence();
            gallery.ShowPicture(Pictures.PictureText5, 5, 6, Pictures.PicturePath5);
        }

        private void ThumbnailButton6_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            YachtCharterGalleryPage gallery = EnsureGalleryPanelExistence();
            gallery.ShowPicture(Pictures.PictureText6, 6, 6, Pictures.PicturePath6);
        }
    }
}
