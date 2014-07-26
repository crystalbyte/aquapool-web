using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Browser;
using Crystalbyte.Controls.Transition;
using Crystalbyte.Controls.Transition.Effects;
using System.Diagnostics;
using System.Windows.Media.Imaging;

namespace Aquapool
{
    public partial class Page : UserControl
    {
        private static readonly string MenuKey = "key";
        private static Page instance; 
        private bool running = false;
        private AquaCursor cc = new AquaCursor();
        private PageType currentPage = PageType.None;
        private GalleryPageAbtiwa abtiwaGallery = new GalleryPageAbtiwa();
        //private GalleryDivingBureauPage diveGallery = new GalleryDivingBureauPage();

        internal enum MenuTypes
        {
            Services,
            Contact,
            Imprint
        }

        private enum BodyType
        {
            Menu,
            Content
        }

        public enum PageType
        {
            None,
            Home,
            Services,
            Abtiwa,
            DiveBureau,
            AbtiwaGallery,
            DiveBureauGallery,
            Imprint,
            Contact
        }

        public enum GalleryType
        {
            Abtiwa,
            DivingBureau
        }


        public static Page Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Page();
                }
                return instance;
            }
        }

        /// <summary>
        /// Gets the gallery page for AbTiWa.
        /// </summary>
        public GalleryPageAbtiwa GalleryAbtiwa 
        {
            get { return this.abtiwaGallery; }
        }

        ///// <summary>
        ///// Gets the gallery pagg for the diving bureau.
        ///// </summary>
        //public GalleryDivingBureauPage GalleryDivingBureau
        //{
        //    get { return this.diveGallery; }
        //}

        internal AquaCursor CustomCursor
        {
            get { return this.cc; }
        }

        public PageType CurrentPageType
        {
            get { return this.currentPage; }
        }

        private Page()
        {
            // Required to initialize variables
            this.InitializeComponent();
            this.InitializeTransitionControls();
            this.InitializeCursor();

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

        private void InitializeCursor()
        {
            //this.MouseMove += new MouseEventHandler(Page_MouseMove);
            //cc.IsHitTestVisible = false;
            //cc.SetValue(Canvas.ZIndexProperty, 100000);
            //this.CursorLayer.Children.Add(cc);
            //this.Cursor = Cursors.None;
        }

        void Page_MouseMove(object sender, MouseEventArgs e)
        {
            cc.SetValue(Canvas.TopProperty, e.GetPosition(null).Y);
            cc.SetValue(Canvas.LeftProperty, e.GetPosition(null).X);
        }

        private void InitializeTransitionControls()
        {
            this.TransitionAbtiwaLogo.EntryEffects.Add(new FadeEffect());
            this.TransitionAbtiwaMain.EntryEffects.Add(new FadeEffect());
            this.TransitionAbtiwaMain.ExitEffects.Add(new Effects.ClearEffect());
            this.TransitionAbtiwaSide.EntryEffects.Add(new FadeEffect());
            this.TransitionBodyCanvas.EntryEffects.Add(new FadeEffect());
            this.TransitionBodyCanvas.TransitionLayerPosition = TransitionControl.TransitionLayer.Top;
            this.TransitionBodyCanvas.ExitEffects.Add(new Effects.ClearEffect());
            this.TransitionButtonContact.EntryEffects.Add(new FadeEffect());
            this.TransitionButtonHome.EntryEffects.Add(new FadeEffect());
            this.TransitionButtonImprint.EntryEffects.Add(new FadeEffect());
            this.TransitionButtonServices.EntryEffects.Add(new FadeEffect());
            this.TransitionCornerBox.EntryEffects.Add(new FadeEffect());
            this.TransitionCornerBoxContent.EntryEffects.Add(new FadeEffect());
            this.TransitionCornerBoxContent.ExitEffects.Add(new Effects.ClearEffect());
            this.TransitionCornerBoxContent.TransitionLayerPosition = TransitionControl.TransitionLayer.Top;
            this.TransitionHeader.EntryEffects.Add(new FadeEffect());
            this.TransitionIngLogo.EntryEffects.Add(new FadeEffect());
            this.TransitionIngMain.EntryEffects.Add(new FadeEffect());
            this.TransitionIngMain.ExitEffects.Add(new Effects.ClearEffect());
            this.TransitionIngSide.EntryEffects.Add(new FadeEffect());
            this.TransitionSeperator1.EntryEffects.Add(new FadeEffect());
            this.TransitionSeperator2.EntryEffects.Add(new FadeEffect());
            this.TransitionSeperator3.EntryEffects.Add(new FadeEffect());
            this.TransitionThumbnailPage.EntryEffects.Add(new FadeEffect());
            this.TransitionThumbnailPage.ExitEffects.Add(new Effects.FadeOutEffect());
            this.TransitionWave.EntryEffects.Add(new FadeEffect());
            this.TransitionLogo.EntryEffects.Add(new FadeEffect());
            this.TransitionGalleryButton.EntryEffects.Add(new FadeEffect());
            this.TransitionGalleryButton.ExitEffects.Add(new Effects.FadeOutEffect());
        }

        internal void ClearActiveStates()
        {
            var a = this.TransitionAbtiwaMain.CurrentPage as AbtiwaMain;
            if (a != null)
            {
                a.IsActive = false;
                VisualStateManager.GoToState(a, "MouseOut", true);
            }
            var b = this.TransitionAbtiwaLogo.CurrentPage as AbtiwaLogo;
            if (b != null)
            {
                b.IsActive = false;
                VisualStateManager.GoToState(this.TransitionAbtiwaSide.CurrentPage, "MouseOut", true);
            }
            var c = this.TransitionIngMain.CurrentPage as DiveBureauMain;
            if (c != null)
            {
                c.IsActive = false;
                VisualStateManager.GoToState(c, "MouseOut", true);
            }
            var d = this.TransitionIngLogo.CurrentPage as DiveBureauLogo;
            if (d != null)
            {
                d.IsActive = false;
                VisualStateManager.GoToState(this.TransitionIngSide.CurrentPage, "MouseOut", true);
            }
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (HtmlPage.Document.QueryString.ContainsKey(MenuKey))
            {
                switch (HtmlPage.Document.QueryString[MenuKey])
                {
                    case "abtiwa":
                        {
                            this.Navigate(PageType.Abtiwa);
                            break;
                        }
                    case "dive":
                        {
                            this.Navigate(PageType.DiveBureau);
                            break;
                        }
                    case "gallery":
                        {
                            this.Navigate(PageType.AbtiwaGallery);
                            break;
                        }
                    case "imprint":
                        {
                            this.Navigate(PageType.Imprint);
                            break;
                        }
                    case "contact":
                        {
                            this.Navigate(PageType.Contact);
                            break;
                        }
                    default:
                        {
                            this.Navigate(PageType.Services);
                            break;
                        }
                }
            }
            else
            {
                this.Navigate(PageType.Services);
            }
            running = true;
        }

        private void ShowUpperMenu()
        {
            TransitionProvider.Launch(TimeSpan.FromMilliseconds(500), this.TransitionButtonHome.PerformTransition, new ButtonHomeControl());
            TransitionProvider.Launch(TimeSpan.FromMilliseconds(600), this.TransitionSeperator1.PerformTransition, new Seperator());
            TransitionProvider.Launch(TimeSpan.FromMilliseconds(700), this.TransitionButtonServices.PerformTransition, new ButtonServicesControl());
            TransitionProvider.Launch(TimeSpan.FromMilliseconds(800), this.TransitionSeperator2.PerformTransition, new Seperator());
            TransitionProvider.Launch(TimeSpan.FromMilliseconds(900), this.TransitionButtonContact.PerformTransition, new ButtonContactControl());
            TransitionProvider.Launch(TimeSpan.FromMilliseconds(1000), this.TransitionSeperator3.PerformTransition, new Seperator());
            TransitionProvider.Launch(TimeSpan.FromMilliseconds(1100), this.TransitionButtonImprint.PerformTransition, new ButtonImprintControl());
        }

        private GalleryButton GetNewButton()
        {
            GalleryButton b = new GalleryButton();
            b.MouseLeftButtonUp += delegate
            {
                TransitionProvider.Launch(TimeSpan.FromMilliseconds(1), this.TransitionThumbnailPage.PerformTransition, new AbtiwaThumbnailPage());
            };
            return b;
        }
       
        internal void Navigate(PageType page)
        {
            switch (page)
            {
                case PageType.Home:
                    HtmlPage.Window.Navigate(new Uri("Abtiwa",UriKind.Relative));
                    break;
                case PageType.Services:
                    this.SetMenuActive(MenuTypes.Services);
                    this.ClearActiveStates();
                    if (running)
                    {
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(10), this.TransitionBodyCanvas.PerformTransition, new PlaceboControl());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(200), this.TransitionThumbnailPage.PerformTransition, new PlaceboControl());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(300), this.TransitionAbtiwaMain.PerformTransition, new AbtiwaMain());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(400), this.TransitionIngMain.PerformTransition, new DiveBureauMain());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(500), this.TransitionGalleryButton.PerformTransition, new PlaceboControl());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(600), this.TransitionCornerBoxContent.PerformTransition, new CornerBoxContentServices());
                    }
                    else
                    {
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(10), this.TransitionHeader.PerformTransition, new HeaderGradient());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(200), this.TransitionWave.PerformTransition, new Wave());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(400), this.TransitionLogo.PerformTransition, new Logo());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(600), this.TransitionAbtiwaSide.PerformTransition, new AbtiwaSide());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(800), this.TransitionAbtiwaLogo.PerformTransition, new AbtiwaLogo());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(1000), this.TransitionAbtiwaMain.PerformTransition, new AbtiwaMain());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(1200), this.TransitionIngSide.PerformTransition, new DiveBureauSide());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(1400), this.TransitionIngLogo.PerformTransition, new DiveBureauLogo());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(1600), this.TransitionIngMain.PerformTransition, new DiveBureauMain());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(1800), this.TransitionCornerBox.PerformTransition, new CornerBox());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(2000), this.TransitionCornerBoxContent.PerformTransition, new CornerBoxContentServices());   
                        this.ShowUpperMenu();
                    }
                    this.BringToFront(BodyType.Menu);
                    this.currentPage = PageType.Services;
                    break;
                case PageType.Abtiwa:
                    this.SetMenuActive(MenuTypes.Services);
                    if (running)
                    {
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(10), this.TransitionAbtiwaMain.PerformTransition, new PlaceboControl());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(200), this.TransitionIngMain.PerformTransition, new PlaceboControl());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(400), this.TransitionBodyCanvas.PerformTransition, new AbtiwaPage());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(600), this.TransitionGalleryButton.PerformTransition, this.GetNewButton());
                    }
                    else
                    {
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(10), this.TransitionHeader.PerformTransition, new HeaderGradient());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(200), this.TransitionWave.PerformTransition, new Wave());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(400), this.TransitionLogo.PerformTransition, new Logo());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(600), this.TransitionAbtiwaSide.PerformTransition, new AbtiwaSide());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(800), this.TransitionAbtiwaLogo.PerformTransition, new AbtiwaLogo());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(1000), this.TransitionIngSide.PerformTransition, new DiveBureauSide());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(1200), this.TransitionIngLogo.PerformTransition, new DiveBureauLogo());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(1400), this.TransitionCornerBox.PerformTransition, new CornerBox());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(1600), this.TransitionBodyCanvas.PerformTransition, new AbtiwaPage());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(1800), this.TransitionGalleryButton.PerformTransition, this.GetNewButton());
                        this.ShowUpperMenu();
                    }
                    this.BringToFront(BodyType.Content);
                    this.currentPage = PageType.Abtiwa;
                    break;
                case PageType.DiveBureau:
                    this.SetMenuActive(MenuTypes.Services);
                    if (running)
                    {
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(10), this.TransitionAbtiwaMain.PerformTransition, new PlaceboControl());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(200), this.TransitionIngMain.PerformTransition, new PlaceboControl());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(300), this.TransitionGalleryButton.PerformTransition, new PlaceboControl());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(400), this.TransitionBodyCanvas.PerformTransition, new DiveBureauPage());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(500), this.TransitionThumbnailPage.PerformTransition, new PlaceboControl());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(600), this.TransitionGalleryButton.PerformTransition, new PlaceboControl());
                        
                    }
                    else
                    {
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(10), this.TransitionHeader.PerformTransition, new HeaderGradient());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(200), this.TransitionWave.PerformTransition, new Wave());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(400), this.TransitionLogo.PerformTransition, new Logo());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(600), this.TransitionAbtiwaSide.PerformTransition, new AbtiwaSide());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(800), this.TransitionAbtiwaLogo.PerformTransition, new AbtiwaLogo());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(1000), this.TransitionIngSide.PerformTransition, new DiveBureauSide());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(1200), this.TransitionIngLogo.PerformTransition, new DiveBureauLogo());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(1400), this.TransitionCornerBox.PerformTransition, new CornerBox());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(1600), this.TransitionBodyCanvas.PerformTransition, new DiveBureauPage());
                        //TransitionTimer.Launch(TimeSpan.FromMilliseconds(1600), this.TransitionThumbnailPage.PerformTransition, new DiveBureauThumbnailPanel());
                        this.ShowUpperMenu();
                    }
                    this.BringToFront(BodyType.Content);
                    this.currentPage = PageType.DiveBureau;
                    break;
                case PageType.AbtiwaGallery:
                    this.SetMenuActive(MenuTypes.Services);
                    if (running)
                    {
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(10), this.TransitionAbtiwaMain.PerformTransition, new PlaceboControl());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(200), this.TransitionIngMain.PerformTransition, new PlaceboControl());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(400), this.TransitionBodyCanvas.PerformTransition, this.GalleryAbtiwa);
                    }
                    else
                    {
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(10), this.TransitionHeader.PerformTransition, new HeaderGradient());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(200), this.TransitionWave.PerformTransition, new Wave());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(400), this.TransitionLogo.PerformTransition, new Logo());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(600), this.TransitionAbtiwaSide.PerformTransition, new AbtiwaSide());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(800), this.TransitionAbtiwaLogo.PerformTransition, new AbtiwaLogo());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(1000), this.TransitionIngSide.PerformTransition, new DiveBureauSide());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(1200), this.TransitionIngLogo.PerformTransition, new DiveBureauLogo());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(1400), this.TransitionCornerBox.PerformTransition, new CornerBox());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(1600), this.TransitionBodyCanvas.PerformTransition, this.GalleryAbtiwa);
                        this.ShowUpperMenu();
                    }
                    this.BringToFront(BodyType.Content);
                    this.currentPage = PageType.AbtiwaGallery;
                    break;
                case PageType.DiveBureauGallery:
                    if (running)
                    {
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(10), this.TransitionAbtiwaMain.PerformTransition, new PlaceboControl());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(200), this.TransitionIngMain.PerformTransition, new PlaceboControl());
                        //TransitionTimer.Launch(TimeSpan.FromMilliseconds(400), this.TransitionBodyCanvas.PerformTransition, this.GalleryDivingBureau);
                    }
                    else
                    {
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(10), this.TransitionHeader.PerformTransition, new HeaderGradient());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(200), this.TransitionWave.PerformTransition, new Wave());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(400), this.TransitionLogo.PerformTransition, new Logo());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(600), this.TransitionAbtiwaSide.PerformTransition, new AbtiwaSide());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(800), this.TransitionAbtiwaLogo.PerformTransition, new AbtiwaLogo());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(1000), this.TransitionIngSide.PerformTransition, new DiveBureauSide());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(1200), this.TransitionIngLogo.PerformTransition, new DiveBureauLogo());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(1400), this.TransitionCornerBox.PerformTransition, new CornerBox());
                        //TransitionTimer.Launch(TimeSpan.FromMilliseconds(1600), this.TransitionBodyCanvas.PerformTransition, this.GalleryDivingBureau);
                        this.ShowUpperMenu();
                    }
                    this.BringToFront(BodyType.Content);
                    this.currentPage = PageType.DiveBureauGallery;
                    break;
                case PageType.Imprint:
                    this.ClearActiveStates();
                    this.SetMenuActive(MenuTypes.Imprint);
                    if (running)
                    {
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(10), this.TransitionAbtiwaMain.PerformTransition, new PlaceboControl());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(200), this.TransitionIngMain.PerformTransition, new PlaceboControl());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(400), this.TransitionBodyCanvas.PerformTransition, new ImprintPage());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(500), this.TransitionGalleryButton.PerformTransition, new PlaceboControl());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(700), this.TransitionCornerBoxContent.PerformTransition, new CornerBoxContentImprint());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(900), this.TransitionThumbnailPage.PerformTransition, new ImprintSideLineControl());

                    }
                    else
                    {
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(10), this.TransitionHeader.PerformTransition, new HeaderGradient());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(200), this.TransitionWave.PerformTransition, new Wave());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(400), this.TransitionLogo.PerformTransition, new Logo());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(600), this.TransitionAbtiwaSide.PerformTransition, new AbtiwaSide());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(800), this.TransitionAbtiwaLogo.PerformTransition, new AbtiwaLogo());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(1000), this.TransitionIngSide.PerformTransition, new DiveBureauSide());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(1200), this.TransitionIngLogo.PerformTransition, new DiveBureauLogo());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(1400), this.TransitionCornerBox.PerformTransition, new CornerBox());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(1600), this.TransitionBodyCanvas.PerformTransition, new ImprintPage());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(1800), this.TransitionCornerBoxContent.PerformTransition, new CornerBoxContentImprint());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(2000), this.TransitionThumbnailPage.PerformTransition, new ImprintSideLineControl());
                        this.ShowUpperMenu();
                    }
                    this.BringToFront(BodyType.Content);
                    this.currentPage = PageType.Imprint;
                    break;
                case PageType.Contact:
                    this.ClearActiveStates();
                    this.SetMenuActive(MenuTypes.Contact);
                    if (running)
                    {
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(10), this.TransitionAbtiwaMain.PerformTransition, new PlaceboControl());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(200), this.TransitionIngMain.PerformTransition, new PlaceboControl());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(400), this.TransitionBodyCanvas.PerformTransition, new ContactPage());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(300), this.TransitionThumbnailPage.PerformTransition, new PlaceboControl());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(500), this.TransitionGalleryButton.PerformTransition, new PlaceboControl());
                    }
                    else
                    {
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(10), this.TransitionHeader.PerformTransition, new HeaderGradient());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(200), this.TransitionWave.PerformTransition, new Wave());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(400), this.TransitionLogo.PerformTransition, new Logo());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(600), this.TransitionAbtiwaSide.PerformTransition, new AbtiwaSide());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(800), this.TransitionAbtiwaLogo.PerformTransition, new AbtiwaLogo());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(1000), this.TransitionIngSide.PerformTransition, new DiveBureauSide());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(1200), this.TransitionIngLogo.PerformTransition, new DiveBureauLogo());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(1400), this.TransitionCornerBox.PerformTransition, new CornerBox());
                        TransitionProvider.Launch(TimeSpan.FromMilliseconds(1600), this.TransitionBodyCanvas.PerformTransition, new ContactPage());
                        this.ShowUpperMenu();
                    }
                    this.BringToFront(BodyType.Content);
                    this.currentPage = PageType.Contact;
                    break;
                default:
                    break;
            }
        }

        internal void SetMenuActive(MenuTypes type)
        {
            switch (type)
            {
                case MenuTypes.Services:
                    ClearMenuStates();
                    if (this.TransitionButtonServices.CurrentPage as ButtonServicesControl != null)
                    {
                        (this.TransitionButtonServices.CurrentPage as ButtonServicesControl).IsActive = true;    
                    }
                    break;
                case MenuTypes.Contact:
                    ClearMenuStates();
                    if (this.TransitionButtonContact.CurrentPage as ButtonContactControl != null)
                    {
                        (this.TransitionButtonContact.CurrentPage as ButtonContactControl).IsActive = true;    
                    }
                    break;
                case MenuTypes.Imprint:
                    ClearMenuStates();
                    if (this.TransitionButtonImprint.CurrentPage as ButtonImprintControl != null)
                    {
                        (this.TransitionButtonImprint.CurrentPage as ButtonImprintControl).IsActive = true;    
                    }
                    break;
                default:
                    break;
            }
        }

        internal void ClearMenuStates()
        {
            var a = this.TransitionButtonContact.CurrentPage as ButtonContactControl;
            if (a != null)
            {
                a.IsActive = false;
                VisualStateManager.GoToState(a, "Inactive", true);    
            }

            var b = this.TransitionButtonHome.CurrentPage as ButtonHomeControl;
            if (b != null)
            {
                b.IsActive = false;
                VisualStateManager.GoToState(b, "Inactive", true);    
            }
            

            var c = this.TransitionButtonImprint.CurrentPage as ButtonImprintControl;
            if (c != null)
            {
                c.IsActive = false;
                VisualStateManager.GoToState(c, "Inactive", true);    
            }

            var d = this.TransitionButtonServices.CurrentPage as ButtonServicesControl;
            if (d != null)
            {
                d.IsActive = false;
                VisualStateManager.GoToState(d, "Inactive", true);    
            }
        }

        private void BringToFront(BodyType type)
        {
            switch (type)
            {
                case BodyType.Menu:
                    this.TransitionAbtiwaMain.IsHitTestVisible = true;
                    this.TransitionIngMain.IsHitTestVisible = true;
                    this.TransitionBodyCanvas.IsHitTestVisible = false;
                    break;
                case BodyType.Content:
                    this.TransitionAbtiwaMain.IsHitTestVisible = false;
                    this.TransitionIngMain.IsHitTestVisible = false;
                    this.TransitionBodyCanvas.IsHitTestVisible = true;
                    break;
            }
        }

        private void Content_Resized(object sender, EventArgs e)
        {
            //this.Resize();
        }

        private void Resize()
        {
            // height 910 / 900
            this.LayoutRoot.Height = Application.Current.Host.Content.ActualHeight;
            this.LayoutRoot.Width = Application.Current.Host.Content.ActualHeight * 0.989010989;
        }

        private void ButtonHome_Click(object sender, RoutedEventArgs e)
        {
            Page.Instance.Navigate(PageType.Home);
        }

        private void ButtonServices_Click(object sender, RoutedEventArgs e)
        {
            Page.Instance.Navigate(PageType.Services);
        }

        private void ButtonContact_Click(object sender, RoutedEventArgs e)
        {
            Page.Instance.Navigate(PageType.Contact);
        }

        private void ButtonImprint_Click(object sender, RoutedEventArgs e)
        {
            Page.Instance.Navigate(PageType.Imprint);
        }
    }
}