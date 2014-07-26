using System;
using System.Collections.Generic;
using System.Globalization;
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
    public partial class GalleryPageAbtiwa : UserControl
    {
        public event EventHandler Next = delegate { };
        public event EventHandler Previous = delegate { };

        public GalleryPageAbtiwa()
        {
            this.InitializeComponent();
            this.AttachHandlers();
        }

        private void AttachHandlers()
        {
            this.ButtonLeft.Click += new RoutedEventHandler(ButtonLeft_Click);
            this.ButtonRight.Click += new RoutedEventHandler(ButtonRight_Click);
        }

        void ButtonRight_Click(object sender, RoutedEventArgs e)
        {
            this.Next(this, EventArgs.Empty);
        }

        void ButtonLeft_Click(object sender, RoutedEventArgs e)
        {
            this.Previous(this, EventArgs.Empty);
        }

        public void ShowPicture(int current, int max, Uri uri, string text)
        {
            ButtonLeft.Content = current.ToString(CultureInfo.InvariantCulture);
            ButtonRight.Content = max.ToString(CultureInfo.InvariantCulture);
            TextBlockDescription.Text = text;
            SwapPicture(uri);
        }

        private void SwapPicture(Uri uri)
        {
            DoubleAnimation animation = new DoubleAnimation();
            animation.To = 1;
            
            Storyboard sb = new Storyboard();
            sb.Duration = TimeSpan.FromMilliseconds(800);
            sb.Children.Add(animation);

            Storyboard.SetTarget(animation, this.ImageCurrent);
            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));

            this.ImageCurrent.Opacity = 0;
            this.ImageCurrent.Source = new BitmapImage(uri);
            sb.Begin();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Page.Instance.Navigate(Page.PageType.Abtiwa);
        }
    }
}
