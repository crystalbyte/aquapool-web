using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Aquapool.Nbw {
    public partial class ContactPage {
        public ContactPage() {
            // Required to initialize variables
            InitializeComponent();
            DataContext = new Message();
        }
    }
}
