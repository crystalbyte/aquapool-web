using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Aquapool.Nbw
{
    public class ThumbnailButton : Control
    {
        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register("ImageSource", typeof (ImageSource), typeof (ThumbnailButton),
                                        new PropertyMetadata(null));

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof (string), typeof (ThumbnailButton),
                                        new PropertyMetadata(string.Empty));

        public ThumbnailButton()
        {
            DefaultStyleKey = GetType();
        }

        public ImageSource ImageSource
        {
            get { return (ImageSource) GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ImageSource.  This enables animation, styling, binding, etc...

        public string Text
        {
            get { return (string) GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
    }
}
