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
    public partial class ContactPage : UserControl
    {
        public ContactPage()
        {
            InitializeComponent();
        }

        private void TextBoxName_MouseEnter(object sender, MouseEventArgs e)
        {
            Page.Instance.CustomCursor.Visibility = Visibility.Collapsed;
        }

        private void TextBoxName_MouseLeave(object sender, MouseEventArgs e)
        {
            Page.Instance.CustomCursor.Visibility = Visibility.Visible;
        }

        private void TextBoxCompany_MouseEnter(object sender, MouseEventArgs e)
        {
            Page.Instance.CustomCursor.Visibility = Visibility.Collapsed;
        }

        private void TextBoxCompany_MouseLeave(object sender, MouseEventArgs e)
        {
            Page.Instance.CustomCursor.Visibility = Visibility.Visible;
        }

        private void TextBoxSubject_MouseEnter(object sender, MouseEventArgs e)
        {
            Page.Instance.CustomCursor.Visibility = Visibility.Collapsed;
        }

        private void TextBoxSubject_MouseLeave(object sender, MouseEventArgs e)
        {
            Page.Instance.CustomCursor.Visibility = Visibility.Visible;
        }

        private void TextBoxEmail_MouseEnter(object sender, MouseEventArgs e)
        {
            Page.Instance.CustomCursor.Visibility = Visibility.Collapsed;
        }

        private void TextBoxEmail_MouseLeave(object sender, MouseEventArgs e)
        {
            Page.Instance.CustomCursor.Visibility = Visibility.Visible;
        }

        private void TextBoxMessage_MouseEnter(object sender, MouseEventArgs e)
        {
            Page.Instance.CustomCursor.Visibility = Visibility.Collapsed;
        }

        private void TextBoxMessage_MouseLeave(object sender, MouseEventArgs e)
        {
            Page.Instance.CustomCursor.Visibility = Visibility.Visible;
        }
    }
}
