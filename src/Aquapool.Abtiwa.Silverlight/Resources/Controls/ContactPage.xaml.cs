using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Aquapool.Nbw;

namespace Aquapool
{
    public partial class ContactPage : UserControl
    {
        public ContactPage()
        {
            InitializeComponent();
            DataContext = new Message();

            ContactOverlay.Visibility = Visibility.Collapsed;
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

        private void OnButtonCommitClick(object sender, RoutedEventArgs e) {
            SendMessage();
        }

        private void SendMessage() {
            var message = (Message)DataContext;
            var uri = System.Windows.Browser.HtmlPage.Document.DocumentUri.OriginalString.Replace("/Home/Abtiwa", "/Home/Submit");
            var request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "post";
            request.ContentType = "application/x-www-form-urlencoded";
            request.BeginGetRequestStream(OnRequestReady, new object[] { request, message });
        }

        private void OnRequestReady(IAsyncResult result) {
            const string targetAddress = "bla@bla.net";
            var request = (HttpWebRequest)((object[])result.AsyncState)[0];
            var stream = request.EndGetRequestStream(result);
            var message = (Message)((object[])result.AsyncState)[1];
            using (var writer = new StreamWriter(stream)) {
                writer.Write("name={0}&", message.Name);
                writer.Write("company={0}&", message.Company);
                writer.Write("emailaddress={0}&", message.EmailAddress);
                writer.Write("subject={0}&", message.Subject);
                writer.Write("text={0}&", message.Text);
                writer.Write("targetaddress={0}", targetAddress);
                writer.Flush();
            }

            request.BeginGetResponse(OnResponseReady, request);
        }

        private void OnResponseReady(IAsyncResult ar) {
            NotifySuccess();
        }

        private void NotifySuccess() {
            if (!Dispatcher.CheckAccess()) {
                Dispatcher.BeginInvoke(NotifySuccess);
                return;
            }

            ContactOverlay.Visibility = Visibility.Visible;
        }
    }
}
