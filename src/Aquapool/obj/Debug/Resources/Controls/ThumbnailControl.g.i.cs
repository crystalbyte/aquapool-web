﻿#pragma checksum "C:\Users\Alexander\Documents\GitHub\aquapool-web\src\Aquapool\Resources\Controls\ThumbnailControl.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "37BA95C474CB4A4C31572AE96AD84621"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18034
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Windows.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Aquapool {
    
    
    public partial class ThumbnailControl : System.Windows.Controls.UserControl {
        
        internal System.Windows.VisualStateGroup Mouse;
        
        internal System.Windows.VisualState MouseOver;
        
        internal System.Windows.VisualState MouseOut;
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Image MyImage;
        
        internal Microsoft.Windows.Controls.Viewbox MyViewbox;
        
        internal System.Windows.Controls.TextBlock MyText;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/Aquapool;component/Resources/Controls/ThumbnailControl.xaml", System.UriKind.Relative));
            this.Mouse = ((System.Windows.VisualStateGroup)(this.FindName("Mouse")));
            this.MouseOver = ((System.Windows.VisualState)(this.FindName("MouseOver")));
            this.MouseOut = ((System.Windows.VisualState)(this.FindName("MouseOut")));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.MyImage = ((System.Windows.Controls.Image)(this.FindName("MyImage")));
            this.MyViewbox = ((Microsoft.Windows.Controls.Viewbox)(this.FindName("MyViewbox")));
            this.MyText = ((System.Windows.Controls.TextBlock)(this.FindName("MyText")));
        }
    }
}

