using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Aquapool.Nbw {
    public partial class ContactPage : UserControl {
        public ContactPage() {
            // Required to initialize variables
            InitializeComponent();
            DataContext = new Message();
            SuccessOverlay.Visibility = Visibility.Collapsed;
        }

        private void OnButtonCommitMouseLeave(object sender, MouseEventArgs e) {
            VisualStateManager.GoToState(ButtonCommit, "MouseOut", true);
        }

        private void OnButtonCommitClick(object sender, RoutedEventArgs e) {
            SendMessage();
        }

        private void SendMessage() {
            var message = (Message)DataContext;
            var uri = System.Windows.Browser.HtmlPage.Document.DocumentUri.OriginalString.Replace("/Home/Nbw", "/Home/Submit");
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
                writer.Write("targetaddress={0}&", message.Text);
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

            SuccessOverlay.Visibility = Visibility.Visible;
        }
    }
}
