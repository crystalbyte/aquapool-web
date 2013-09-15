using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Aquapool.Nbw
{
    public partial class YachtCharterGalleryPage : UserControl
    {
        private int current = 1;

        public YachtCharterGalleryPage()
        {
            InitializeComponent();
            OnApplyTemplate();
        }

        public event EventHandler Close;

        public void ShowPicture(string text, int min, int max, string path)
        {
            var uri = new Uri(path, UriKind.Relative);
            Viewer.LoadPicture(uri);
            TextBlockImageTitle.Text = text;
            TextBlockPictureNumber.Text = min + " / " + max;
            current = min;
            CheckButtons();
        }

        private void CheckButtons()
        {
            var nextButton = ViewboxButtonNext.Child as Button;
            bool isEnd = current < 6;
            if (isEnd)
            {
                VisualStateManager.GoToState(ButtonNextImage, "MouseOut", true);
            }
            //nextButton.IsEnabled = isEnd;

            var previousButton = ViewboxButtonPrevious.Child as Button;
            bool isBeginning = (current > 1);
            if (isBeginning)
            {
                VisualStateManager.GoToState(ButtonPreviousImage, "MouseOut", true);
            }
            //previousButton.IsEnabled = isBeginning;
        }

        public void Next()
        {
            if (current == 6)
            {
                return;
            }
            current++;
            switch (current)
            {
                case 1:
                    ShowPicture(Pictures.PictureText1, 1, 5, Pictures.PicturePath1);
                    break;
                case 2:
                    ShowPicture(Pictures.PictureText2, 2, 5, Pictures.PicturePath2);
                    break;
                case 3:
                    ShowPicture(Pictures.PictureText3, 3, 5, Pictures.PicturePath3);
                    break;
                case 4:
                    ShowPicture(Pictures.PictureText4, 4, 5, Pictures.PicturePath4);
                    break;
                case 5:
                    ShowPicture(Pictures.PictureText5, 5, 5, Pictures.PicturePath5);
                    break;
                //case 6:
                //    ShowPicture(Pictures.PictureText6, 6, 6, Pictures.PicturePath6);
                    break;
                default:
                    break;
            }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            ButtonPreviousImage = ViewboxButtonPrevious.Child as Button;
            ButtonNextImage = ViewboxButtonNext.Child as Button;
            ButtonClose = ViewboxClose.Child as Button;
            TextBlockPictureNumber = ViewboxPictureNumber.Child as TextBlock;
            TextBlockImageTitle = TextBlockImageTitle as TextBlock;
        }

        public void Previous()
        {
            if (current == 1)
            {
                return;
            }
            current--;
            switch (current)
            {
                case 1:
                    ShowPicture(Pictures.PictureText1, 1, 5, Pictures.PicturePath1);
                    break;
                case 2:
                    ShowPicture(Pictures.PictureText2, 2, 5, Pictures.PicturePath2);
                    break;
                case 3:
                    ShowPicture(Pictures.PictureText3, 3, 5, Pictures.PicturePath3);
                    break;
                case 4:
                    ShowPicture(Pictures.PictureText4, 4, 5, Pictures.PicturePath4);
                    break;
                case 5:
                    ShowPicture(Pictures.PictureText5, 5, 5, Pictures.PicturePath5);
                    break;
                //case 6:
                //    ShowPicture(Pictures.PictureText6, 6, 6, Pictures.PicturePath6);
                    break;
                default:
                    break;
            }
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            if (Close != null)
            {
                Close(this, EventArgs.Empty);
            }
        }

        private void ButtonNextImage_Click(object sender, RoutedEventArgs e)
        {
            Next();
        }

        private void ButtonPreviousImage_Click(object sender, RoutedEventArgs e)
        {
            Previous();
        }

        private void ButtonClose_MouseLeave(object sender, MouseEventArgs e)
        {
            VisualStateManager.GoToState(ButtonClose, "MouseOut", true);
        }

        private void ButtonNextImage_MouseLeave(object sender, MouseEventArgs e)
        {
            VisualStateManager.GoToState(ButtonNextImage, "MouseOut", true);
        }

        private void ButtonPreviousImage_MouseLeave(object sender, MouseEventArgs e)
        {
            VisualStateManager.GoToState(ButtonPreviousImage, "MouseOut", true);
        }
    }
}
