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
using System.Windows.Media.Imaging;

using Crystalbyte.Controls.Transition;
using Crystalbyte.Controls.Transition.Effects;

namespace Aquapool.Lobby
{
    public partial class Page : UserControl
    {
        private AquaCursor cc = new AquaCursor();

        public Page()
        {
            // Required to initialize variables
            this.InitializeComponent();
            this.InitializeTransitionControls();
            this.InitializeCursor();

            //Initialize sound
            this.MediaElementIntro.Source = new Uri("/Media/Intro_Wasser_07112008.mp3", UriKind.Relative);
            this.MediaElementIntro.Volume = .3;
            this.MediaElementIntro.Position = TimeSpan.Zero;

            // attaching resize handlers
            Application.Current.Host.Content.Resized += new EventHandler(Content_Resized);

            // attaching loading handlers
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);

            // attaching mouse handlers
            this.MouseLeave += new MouseEventHandler(Page_MouseLeave);
            this.MouseEnter += new MouseEventHandler(Page_MouseEnter);

            // initial resizing
            this.Resize();
        }

        void Page_MouseEnter(object sender, MouseEventArgs e)
        {
            this.cc.Visibility = Visibility.Visible;
        }

        void Page_MouseLeave(object sender, MouseEventArgs e)
        {
            this.cc.Visibility = Visibility.Collapsed;
        }

        private void InitializeTransitionControls()
        {
            this.TransitionAbtiwaButton.EntryEffects.Add(new FadeEffect());
            this.TransitionBackgroundGradient.EntryEffects.Add(new FadeEffect());
            this.TransitionBerlinText.EntryEffects.Add(new FadeEffect());
            this.TransitionBottomText.EntryEffects.Add(new FadeEffect());
            this.TransitionButtonContact.EntryEffects.Add(new FadeEffect());
            this.TransitionButtonHome.EntryEffects.Add(new FadeEffect());
            this.TransitionButtonImprint.EntryEffects.Add(new FadeEffect());
            this.TransitionButtonServices.EntryEffects.Add(new FadeEffect());
            this.TransitionDiveBureauButton.EntryEffects.Add(new FadeEffect());
            this.TransitionMap.EntryEffects.Add(new FadeEffect());
            this.TransitionRedDot.EntryEffects.Add(new FadeEffect());
            this.TransitionSeperator1.EntryEffects.Add(new FadeEffect());
            this.TransitionSeperator2.EntryEffects.Add(new FadeEffect());
            this.TransitionSeperator3.EntryEffects.Add(new FadeEffect());
            this.TransitionSideLine.EntryEffects.Add(new FadeEffect());
            this.TransitionTextBackground.EntryEffects.Add(new FadeEffect());
            this.TransitionTopText.EntryEffects.Add(new FadeEffect());
            this.TransitionWave.EntryEffects.Add(new FadeEffect());
            this.TransitionLogo.EntryEffects.Add(new FadeEffect());
            this.TransitionGradient.EntryEffects.Add(new FadeEffect());
        }

        private void InitializeCursor()
        {
            this.MouseMove += new MouseEventHandler(Page_MouseMove);
            cc.IsHitTestVisible = false;
            cc.SetValue(Canvas.ZIndexProperty, 100000);
            this.CursorLayer.Children.Add(cc);
            this.Cursor = Cursors.None;
        }

        private void Page_MouseMove(object sender, MouseEventArgs e)
        {
            cc.SetValue(Canvas.TopProperty, e.GetPosition(null).Y);
            cc.SetValue(Canvas.LeftProperty, e.GetPosition(null).X);
        }

        private void Content_Resized(object sender, EventArgs e)
        {
            if (Application.Current.Host.Content.ActualHeight <= 910)
            {
                //this.ResizeToMin();
                this.Resize();
            }
            else
            {
                this.Resize();
            }
        }
      
        private void Resize()
        {
            // 910 / 900
            this.LayoutRoot.Height = Application.Current.Host.Content.ActualHeight;
            this.LayoutRoot.Width = Application.Current.Host.Content.ActualHeight * 0.989010989;
            //this.CreateBackground();
            this.CreateBackground2();
        }
      
        private void CreateBackground2()
        {
            StackPanel ver = new StackPanel();
            int v = 0;
            while (v < this.ActualHeight)
            {
                StackPanel hor = new StackPanel();
                hor.VerticalAlignment = VerticalAlignment.Top;
                hor.Height = 35;
                hor.HorizontalAlignment = HorizontalAlignment.Stretch;
                hor.Orientation = Orientation.Horizontal;
                int h = 0;
                while (h < this.ActualWidth)
                {
                    Image image = new Image();
                    image.Stretch = Stretch.Uniform;
                    image.Source = new BitmapImage(new Uri("Media/Images/hg_welle_klein_transparent.png", UriKind.Relative));
                    hor.Children.Add(image);
                    h += 91;
                }
                this.BackGroundRepeatLayer2.Children.Clear();
                ver.Children.Add(hor);
                v += 35;
            }
            this.BackGroundRepeatLayer.Children.Add(ver);
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            this.MediaElementIntro.AutoPlay = true;
            TransitionTimer.Launch(TimeSpan.FromMilliseconds(100), this.TransitionBackgroundGradient.PerformTransition, new BackgroundGradient());
            TransitionTimer.Launch(TimeSpan.FromMilliseconds(200), this.TransitionGradient.PerformTransition, new LogoGradient());
            TransitionTimer.Launch(TimeSpan.FromMilliseconds(300), this.TransitionWave.PerformTransition, new Wave());
            TransitionTimer.Launch(TimeSpan.FromMilliseconds(500), this.TransitionMap.PerformTransition, new Map());
            TransitionTimer.Launch(TimeSpan.FromMilliseconds(700), this.TransitionBerlinText.PerformTransition, new BerlinText());
            TransitionTimer.Launch(TimeSpan.FromMilliseconds(900), this.TransitionSideLine.PerformTransition, new SideLine());
            TransitionTimer.Launch(TimeSpan.FromMilliseconds(1000), this.TransitionLogo.PerformTransition, new Logo());
            TransitionTimer.Launch(TimeSpan.FromMilliseconds(1100), this.TransitionTextBackground.PerformTransition, new TextLayer());
            TransitionTimer.Launch(TimeSpan.FromMilliseconds(1300), this.TransitionRedDot.PerformTransition, new RedDot());
            TransitionTimer.Launch(TimeSpan.FromMilliseconds(1500), this.TransitionTopText.PerformTransition, new TextTopLayer());
            TransitionTimer.Launch(TimeSpan.FromMilliseconds(1600), this.TransitionBottomText.PerformTransition, new TextBottomLayer());
            TransitionTimer.Launch(TimeSpan.FromMilliseconds(1700), this.TransitionAbtiwaButton.PerformTransition, new MenuButtonUpper());
            TransitionTimer.Launch(TimeSpan.FromMilliseconds(1800), this.TransitionDiveBureauButton.PerformTransition, new MenuButtonLower());
            TransitionTimer.Launch(TimeSpan.FromMilliseconds(1900), this.TransitionButtonHome.PerformTransition, new ButtonHomeControl());
            TransitionTimer.Launch(TimeSpan.FromMilliseconds(2000), this.TransitionSeperator1.PerformTransition, new Seperator());
            TransitionTimer.Launch(TimeSpan.FromMilliseconds(2100), this.TransitionButtonServices.PerformTransition, new ButtonServicesControl());
            TransitionTimer.Launch(TimeSpan.FromMilliseconds(2200), this.TransitionSeperator2.PerformTransition, new Seperator());
            TransitionTimer.Launch(TimeSpan.FromMilliseconds(2300), this.TransitionButtonContact.PerformTransition, new ButtonContactControl());
            TransitionTimer.Launch(TimeSpan.FromMilliseconds(2400), this.TransitionSeperator3.PerformTransition, new Seperator());
            TransitionTimer.Launch(TimeSpan.FromMilliseconds(2500), this.TransitionButtonImprint.PerformTransition, new ButtonImprintControl());
        }
    }
}
