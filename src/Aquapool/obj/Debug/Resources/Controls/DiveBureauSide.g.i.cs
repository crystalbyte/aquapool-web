﻿#pragma checksum "C:\Users\Alexander\Documents\GitHub\aquapool-web\src\Aquapool\Resources\Controls\DiveBureauSide.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "253CB2D559F49DAB8CABC1ABEF84AB7F"
//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.18033
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

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
    
    
    public partial class DiveBureauSide : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.VisualStateGroup Mouse;
        
        internal System.Windows.VisualState MouseOver;
        
        internal System.Windows.VisualState MouseOut;
        
        internal System.Windows.VisualStateGroup Activity;
        
        internal System.Windows.VisualState Active;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Aquapool;component/Resources/Controls/DiveBureauSide.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.Mouse = ((System.Windows.VisualStateGroup)(this.FindName("Mouse")));
            this.MouseOver = ((System.Windows.VisualState)(this.FindName("MouseOver")));
            this.MouseOut = ((System.Windows.VisualState)(this.FindName("MouseOut")));
            this.Activity = ((System.Windows.VisualStateGroup)(this.FindName("Activity")));
            this.Active = ((System.Windows.VisualState)(this.FindName("Active")));
        }
    }
}
