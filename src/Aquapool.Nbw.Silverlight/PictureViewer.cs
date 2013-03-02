using System;
using System.Net;
using System.Windows;
using System.Windows.Browser;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace Aquapool.Nbw
{
    [TemplatePart(Name = "SwitchImageStoryboard", Type = typeof (Storyboard))]
    [TemplatePart(Name = "LoadNewImageStoryboard", Type = typeof (Storyboard))]
    public class PictureViewer : Control
    {
        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register("ImageSource", typeof (ImageSource), typeof (PictureViewer),
                                        new PropertyMetadata(null));

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof (double), typeof (PictureViewer), new PropertyMetadata(0.0));

        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register("Maximum", typeof (double), typeof (PictureViewer), new PropertyMetadata(0.0));

        public static readonly DependencyProperty MinimumProperty =
            DependencyProperty.Register("Minimum", typeof (double), typeof (PictureViewer), new PropertyMetadata(0.0));

        private Storyboard FinishLoadingStoryboard;
        private Storyboard StartLoadingStoryboard;

        public PictureViewer()
        {
            DefaultStyleKey = GetType();
            Minimum = 0;
            Maximum = 100;
        }

        public ImageSource ImageSource
        {
            get { return (ImageSource) GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ImageSource.  This enables animation, styling, binding, etc...

        public double Value
        {
            get { return (double) GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentValue.  This enables animation, styling, binding, etc...

        public double Maximum
        {
            get { return (double) GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MaximumValue.  This enables animation, styling, binding, etc...

        public double Minimum
        {
            get { return (double) GetValue(MinimumProperty); }
            set { SetValue(MinimumProperty, value); }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            StartLoadingStoryboard = GetTemplateChild("LoadNewImageStoryboard") as Storyboard;
            FinishLoadingStoryboard = GetTemplateChild("SwitchImageStoryboard") as Storyboard;
        }

        // Using a DependencyProperty as the backing store for MinimumValue.  This enables animation, styling, binding, etc...

        public void LoadPicture(Uri pictureUri)
        {
            if (StartLoadingStoryboard != null)
            {
                StartLoadingStoryboard.Begin();
            }

            Value = Minimum;
            var wc = new WebClient();
            wc.DownloadProgressChanged += OnDownloadProgressChanged;
            wc.OpenReadCompleted += OnOpenReadCompleted;
            wc.OpenReadAsync(pictureUri, null);
        }

        private void OnOpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                HtmlPage.Window.Alert(e.Error.Message);
                return;
            }

            var image = new BitmapImage();
            image.SetSource(e.Result);
            ImageSource = image;
            FinishLoadingStoryboard.Begin();
        }

        private void OnDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Value = e.ProgressPercentage;
        }
    }
}
