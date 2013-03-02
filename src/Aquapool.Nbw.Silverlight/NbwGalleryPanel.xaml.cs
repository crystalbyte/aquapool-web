using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace Nbw
{
	public partial class NbwGalleryPanel : UserControl
	{
        private int current = 1;
        public event EventHandler Close;

		public NbwGalleryPanel()
		{
			// Required to initialize variables
			InitializeComponent();
            this.OnApplyTemplate();
        }

        public void ShowPicture(string text, int min, int max, string path)
        {
         
            var uri = new Uri(path, UriKind.Relative);
            this.Viewer.LoadPicture(uri);
            this.TextBlockImageTitle.Text = text;
            this.TextBlockPictureNumber.Text = "0" + min + " / " + "0" + max;
            current = min;
            this.CheckButtons();
        }

        private void CheckButtons()
        {
            var nextButton = this.ViewboxButtonNext.Child as Button;
            var isEnd = current < 6;
            if (isEnd)
            {
                 VisualStateManager.GoToState(this.ButtonNextImage, "MouseOut", true);
            }
            //nextButton.IsEnabled = isEnd;

            var previousButton = this.ViewboxButtonPrevious.Child as Button;
            var isBeginning = (current > 1);
            if (isBeginning)
            {
                VisualStateManager.GoToState(this.ButtonPreviousImage, "MouseOut", true);
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
                    this.ShowPicture(Pictures.PictureText1, 1, 6, Pictures.PicturePath1);
                    break;
                case 2:
                    this.ShowPicture(Pictures.PictureText2, 2, 6, Pictures.PicturePath2);
                    break;
                case 3:
                    this.ShowPicture(Pictures.PictureText3, 3, 6, Pictures.PicturePath3);
                    break;
                case 4:
                    this.ShowPicture(Pictures.PictureText4, 4, 6, Pictures.PicturePath4);
                    break;
                case 5:
                    this.ShowPicture(Pictures.PictureText5, 5, 6, Pictures.PicturePath5);
                    break;
                case 6:
                    this.ShowPicture(Pictures.PictureText6, 6, 6, Pictures.PicturePath6);
                    break;
                default:
                    break;
            }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this.ButtonPreviousImage = this.ViewboxButtonPrevious.Child as Button;
            this.ButtonNextImage = this.ViewboxButtonNext.Child as Button;
            this.ButtonClose = this.ViewboxClose.Child as Button;
            this.TextBlockPictureNumber = this.ViewboxPictureNumber.Child as TextBlock;
            this.TextBlockImageTitle = this.ViewboxImageTitleText.Child as TextBlock;
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
                    this.ShowPicture(Pictures.PictureText1, 1, 6, Pictures.PicturePath1);
                    break;
                case 2:
                    this.ShowPicture(Pictures.PictureText2, 2, 6, Pictures.PicturePath2);
                    break;
                case 3:
                    this.ShowPicture(Pictures.PictureText3, 3, 6, Pictures.PicturePath3);
                    break;
                case 4:
                    this.ShowPicture(Pictures.PictureText4, 4, 6, Pictures.PicturePath4);
                    break;
                case 5:
                    this.ShowPicture(Pictures.PictureText5, 5, 6, Pictures.PicturePath5);
                    break;
                case 6:
                    this.ShowPicture(Pictures.PictureText6, 6, 6, Pictures.PicturePath6);
                    break;
                default:
                    break;
            }
        }
    
        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            if (this.Close != null)
            {
                this.Close(this, EventArgs.Empty);
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
            VisualStateManager.GoToState(this.ButtonClose, "MouseOut", true);
        }

        private void ButtonNextImage_MouseLeave(object sender, MouseEventArgs e)
        {
            VisualStateManager.GoToState(this.ButtonNextImage, "MouseOut", true);
        }

        private void ButtonPreviousImage_MouseLeave(object sender, MouseEventArgs e)
        {
            VisualStateManager.GoToState(this.ButtonPreviousImage, "MouseOut", true);
        }
	}
}