using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

using Crystalbyte.Controls.Transition.Effects;

namespace Aquapool
{
	public partial class AbtiwaThumbnailPage : UserControl
	{
        private int currentPic = 0;
        private static readonly string Text1 = "Bild1";
        private static readonly Uri Uri1Full = new Uri("/Images/Abtiwa/1.jpg", UriKind.Relative);
        private static readonly Uri Uri1 = new Uri("../Images/Abtiwa/t1.jpg", UriKind.Relative);
        private static readonly string Text2 = "Bild2";
        private static readonly Uri Uri2Full = new Uri("/Images/Abtiwa/2.jpg", UriKind.Relative);
        private static readonly Uri Uri2 = new Uri("../Images/Abtiwa/t2.jpg", UriKind.Relative);
        private static readonly string Text3 = "Bild3";
        private static readonly Uri Uri3Full = new Uri("/Images/Abtiwa/3.jpg", UriKind.Relative);
        private static readonly Uri Uri3 = new Uri("../Images/Abtiwa/t3.jpg", UriKind.Relative);
        private static readonly string Text4 = "Bild4";
        private static readonly Uri Uri4Full = new Uri("/Images/Abtiwa/4.jpg", UriKind.Relative);
        private static readonly Uri Uri4 = new Uri("../Images/Abtiwa/t4.jpg", UriKind.Relative);
        private static readonly string Text5 = "Bild5";
        private static readonly Uri Uri5Full = new Uri("/Images/Abtiwa/5.jpg", UriKind.Relative);
        private static readonly Uri Uri5 = new Uri("../Images/Abtiwa/t5.jpg", UriKind.Relative);
        private static readonly string Text6 = "Bild6";
        private static readonly Uri Uri6Full = new Uri("/Images/Abtiwa/6.jpg", UriKind.Relative);
        private static readonly Uri Uri6 = new Uri("../Images/Abtiwa/t6.jpg", UriKind.Relative);
        private static readonly string Text7 = "Bild7";
        private static readonly Uri Uri7Full = new Uri("/Images/Abtiwa/7.jpg", UriKind.Relative);
        private static readonly Uri Uri7 = new Uri("../Images/Abtiwa/t7.jpg", UriKind.Relative);
        private static readonly string Text8 = "Bild8";
        private static readonly Uri Uri8Full = new Uri("/Images/Abtiwa/8.jpg", UriKind.Relative);
        private static readonly Uri Uri8 = new Uri("../Images/Abtiwa/t8.jpg", UriKind.Relative);

		public AbtiwaThumbnailPage()
		{
			// Required to initialize variables
			this.InitializeComponent();
            this.Loaded += new RoutedEventHandler(AbtiwaThumbnailPage_Loaded);
            Page.Instance.GalleryAbtiwa.Next += new EventHandler(GalleryAbtiwa_Next);
            Page.Instance.GalleryAbtiwa.Previous += new EventHandler(GalleryAbtiwa_Previous);
		}

        void AbtiwaThumbnailPage_Loaded(object sender, RoutedEventArgs e)
        {
            this.InitializeTransitions();
            this.LoadThumbs();
            this.ShowPicture(1);
        }

        void ShowPicture(int i)
        {
            switch (i)
            {
                case 1:
                    Page.Instance.GalleryAbtiwa.ShowPicture(1, 8, Uri1Full, Text1);
                    currentPic = 1;
                    break;
                case 2:
                    Page.Instance.GalleryAbtiwa.ShowPicture(2, 8, Uri2Full, Text2);
                    currentPic = 2;
                    break;
                case 3:
                    Page.Instance.GalleryAbtiwa.ShowPicture(3, 8, Uri3Full, Text3);
                    currentPic = 3;
                    break;
                case 4:
                    Page.Instance.GalleryAbtiwa.ShowPicture(4, 8, Uri4Full, Text4);
                    currentPic = 4;
                    break;
                case 5:
                    Page.Instance.GalleryAbtiwa.ShowPicture(5, 8, Uri5Full, Text5);
                    currentPic = 5;
                    break;
                case 6:
                    Page.Instance.GalleryAbtiwa.ShowPicture(6, 8, Uri6Full, Text6);
                    currentPic = 6;
                    break;
                case 7:
                    Page.Instance.GalleryAbtiwa.ShowPicture(7, 8, Uri7Full, Text7);
                    currentPic = 7;
                    break;
                case 8:
                    Page.Instance.GalleryAbtiwa.ShowPicture(8, 8, Uri8Full, Text8);
                    currentPic = 8;
                    break;
                default:
                    break;
            }
        }

        void GalleryAbtiwa_Previous(object sender, EventArgs e)
        {
            if (this.currentPic == 1) return;
            this.ShowPicture(--currentPic);
        }

        void GalleryAbtiwa_Next(object sender, EventArgs e)
        {
            if (this.currentPic == 8) return;
            this.ShowPicture(++currentPic);
        }

        private void InitializeTransitions()
        {
            this.TransitionThumbnail1.EntryEffects.Add(new FadeEffect());
            this.TransitionThumbnail1.ExitEffects.Add(new Effects.FadeOutEffect());

            this.TransitionThumbnail2.EntryEffects.Add(new FadeEffect());
            this.TransitionThumbnail2.ExitEffects.Add(new Effects.FadeOutEffect());

            this.TransitionThumbnail3.EntryEffects.Add(new FadeEffect());
            this.TransitionThumbnail3.ExitEffects.Add(new Effects.FadeOutEffect());

            this.TransitionThumbnail4.EntryEffects.Add(new FadeEffect());
            this.TransitionThumbnail4.ExitEffects.Add(new Effects.FadeOutEffect());

            this.TransitionThumbnail5.EntryEffects.Add(new FadeEffect());
            this.TransitionThumbnail5.ExitEffects.Add(new Effects.FadeOutEffect());

            this.TransitionThumbnail6.EntryEffects.Add(new FadeEffect());
            this.TransitionThumbnail6.ExitEffects.Add(new Effects.FadeOutEffect());

            this.TransitionThumbnail7.EntryEffects.Add(new FadeEffect());
            this.TransitionThumbnail7.ExitEffects.Add(new Effects.FadeOutEffect());

            this.TransitionThumbnail8.EntryEffects.Add(new FadeEffect());
            this.TransitionThumbnail8.ExitEffects.Add(new Effects.FadeOutEffect());
        }

        private void LoadThumbs()
        {
            var a = new ThumbnailControl(Text1, Uri1);
            a.MouseLeftButtonUp += new MouseButtonEventHandler(a_MouseLeftButtonUp);
            TransitionTimer.Launch(TimeSpan.FromMilliseconds(5), this.TransitionThumbnail1.PerformTransition, a);

            var b = new ThumbnailControl(Text2, Uri2);
            b.MouseLeftButtonUp += new MouseButtonEventHandler(b_MouseLeftButtonUp);
            TransitionTimer.Launch(TimeSpan.FromMilliseconds(100), this.TransitionThumbnail2.PerformTransition, b);

            var c = new ThumbnailControl(Text3, Uri3);
            c.MouseLeftButtonUp += new MouseButtonEventHandler(c_MouseLeftButtonUp);
            TransitionTimer.Launch(TimeSpan.FromMilliseconds(200), this.TransitionThumbnail3.PerformTransition, c);

            var d = new ThumbnailControl(Text4, Uri4);
            d.MouseLeftButtonUp += new MouseButtonEventHandler(d_MouseLeftButtonUp);
            TransitionTimer.Launch(TimeSpan.FromMilliseconds(300), this.TransitionThumbnail4.PerformTransition, d);

            var e = new ThumbnailControl(Text5, Uri5);
            e.MouseLeftButtonUp += new MouseButtonEventHandler(e_MouseLeftButtonUp);
            TransitionTimer.Launch(TimeSpan.FromMilliseconds(400), this.TransitionThumbnail5.PerformTransition, e);

            var f = new ThumbnailControl(Text6, Uri6);
            f.MouseLeftButtonUp += new MouseButtonEventHandler(f_MouseLeftButtonUp);
            TransitionTimer.Launch(TimeSpan.FromMilliseconds(500), this.TransitionThumbnail6.PerformTransition, f);

            var g = new ThumbnailControl(Text7, Uri7);
            g.MouseLeftButtonUp += new MouseButtonEventHandler(g_MouseLeftButtonUp);
            TransitionTimer.Launch(TimeSpan.FromMilliseconds(600), this.TransitionThumbnail7.PerformTransition, g);

            var h = new ThumbnailControl(Text8, Uri8);
            h.MouseLeftButtonUp += new MouseButtonEventHandler(h_MouseLeftButtonUp);
            TransitionTimer.Launch(TimeSpan.FromMilliseconds(700), this.TransitionThumbnail8.PerformTransition, h);
        }

        void h_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.ShowPicture(8);
        }

        void g_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.ShowPicture(7);
        }

        void f_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.ShowPicture(6);
        }

        void e_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.ShowPicture(5);
        }

        void d_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.ShowPicture(4);
        }

        void c_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.ShowPicture(3);
        }

        void b_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.ShowPicture(2);
        }

        void a_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.ShowPicture(1);
        }
	}
}