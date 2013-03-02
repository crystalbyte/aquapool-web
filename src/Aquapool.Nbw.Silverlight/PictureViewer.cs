using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;
using System.Windows.Interop;
using System.Windows.Browser;
using System.Diagnostics;

namespace Nbw
{
    [TemplatePart(Name = "SwitchImageStoryboard", Type = typeof(Storyboard))]
    [TemplatePart(Name = "LoadNewImageStoryboard", Type = typeof(Storyboard))]
    public class PictureViewer : Control
    {
        private Storyboard StartLoadingStoryboard;
        private Storyboard FinishLoadingStoryboard;
        
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            this.StartLoadingStoryboard = this.GetTemplateChild("LoadNewImageStoryboard") as Storyboard;
            this.FinishLoadingStoryboard = this.GetTemplateChild("SwitchImageStoryboard") as Storyboard;
        }

        public PictureViewer()
        {
            this.DefaultStyleKey = this.GetType();
            this.Minimum = 0;
            this.Maximum = 100;
        }

        public ImageSource ImageSource
        {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ImageSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(PictureViewer), new PropertyMetadata(null));

        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(double), typeof(PictureViewer), new PropertyMetadata(0.0));

        public double Maximum
        {
            get { return (double)GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MaximumValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register("Maximum", typeof(double), typeof(PictureViewer), new PropertyMetadata(0.0));

        public double Minimum
        {
            get { return (double)GetValue(MinimumProperty); }
            set { SetValue(MinimumProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MinimumValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinimumProperty =
            DependencyProperty.Register("Minimum", typeof(double), typeof(PictureViewer), new PropertyMetadata(0.0));

        public void LoadPicture(Uri pictureUri)
        {
            if (this.StartLoadingStoryboard != null)
            {
                this.StartLoadingStoryboard.Begin();    
            }

            this.Value = this.Minimum;
            var wc = new WebClient();
            wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(OnDownloadProgressChanged);
            wc.OpenReadCompleted += new OpenReadCompletedEventHandler(OnOpenReadCompleted);
            wc.OpenReadAsync(pictureUri,null);
        }

        void OnOpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                HtmlPage.Window.Alert(e.Error.Message);
                return;
            }

            var image = new BitmapImage();
            image.SetSource(e.Result);
            this.ImageSource = image;
            this.FinishLoadingStoryboard.Begin();
        }

        void OnDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.Value = e.ProgressPercentage;
        }
    }
}
