﻿#pragma checksum "C:\Users\Alexander\Documents\GitHub\aquapool-web\src\Aquapool.Abtiwa.Silverlight\Resources\Controls\AbtiwaSide.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "24EC48741F9D267E8E0CC4274A40761F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18033
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
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
    
    
    public partial class AbtiwaSide : System.Windows.Controls.UserControl {
        
        internal System.Windows.VisualStateGroup Mouse;
        
        internal System.Windows.VisualState MouseOver;
        
        internal System.Windows.VisualState MouseOut;
        
        internal System.Windows.VisualStateGroup Activity;
        
        internal System.Windows.VisualState Active;
        
        internal System.Windows.Controls.Button button;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Aquapool;component/Resources/Controls/AbtiwaSide.xaml", System.UriKind.Relative));
            this.Mouse = ((System.Windows.VisualStateGroup)(this.FindName("Mouse")));
            this.MouseOver = ((System.Windows.VisualState)(this.FindName("MouseOver")));
            this.MouseOut = ((System.Windows.VisualState)(this.FindName("MouseOut")));
            this.Activity = ((System.Windows.VisualStateGroup)(this.FindName("Activity")));
            this.Active = ((System.Windows.VisualState)(this.FindName("Active")));
            this.button = ((System.Windows.Controls.Button)(this.FindName("button")));
        }
    }
}

