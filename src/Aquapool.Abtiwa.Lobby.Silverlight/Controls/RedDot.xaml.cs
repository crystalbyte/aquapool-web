﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Aquapool.Lobby
{
	public partial class RedDot : UserControl
	{
		public RedDot()
		{
			// Required to initialize variables
			InitializeComponent();
            this.Loaded += new RoutedEventHandler(RedDot_Loaded);
		}

        void RedDot_Loaded(object sender, RoutedEventArgs e)
        {
            this.StoryboardImpulse.BeginTime = TimeSpan.FromMilliseconds(500);
            this.StoryboardImpulse.Begin();
        }
	}
}