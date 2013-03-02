using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace Nbw
{
	public partial class Root : UserControl
	{
        private static readonly Root instance = new Root();

        internal enum MenuType
        {
            Home,
            Imprint,
            KopierService,
            Wasserbau,
            YachtCharter,
            Contact,
            Services
        }

        public Root()
		{
			// Required to initialize variables
			this.InitializeComponent();
            this.InitializeControls();
            // HACK: Viewbox does not publish it's children
            this.InitializeNavigationButtons();
            this.Loaded += new RoutedEventHandler(Root_Loaded);
            Application.Current.Host.Content.Resized += new EventHandler(Content_Resized);
		}

        void InitializeNavigationButtons()
        {
            var child = this.NavigationViewbox.Child as StackPanel;
            this.ButtonHome = child.Children[0] as Button;
            this.ButtonServices = child.Children[2] as Button;
            this.ButtonContact = child.Children[4] as Button;
            this.ButtonImprint = child.Children[6] as Button;
        }

        void Resize()
        {
            // height 910 / 900
            this.VisualBorder.Height = Application.Current.Host.Content.ActualHeight;
            this.VisualBorder.Width = Application.Current.Host.Content.ActualHeight * 0.989010989;
        }

        void Content_Resized(object sender, EventArgs e)
        {
            this.Resize();
        }

        void InitializeControls()
        {
            this.HeaderGrid.Opacity = 0;
            this.LogoGrid.Opacity = 0;
        }

        void Root_Loaded(object sender, RoutedEventArgs e)
        {
#if DEBUG
            Debug.WriteLine("Fading in controls");
#endif
            this.FirstTimeLoadStoryboard.Completed += delegate { Navigate(MenuType.Home); };
            Utility.Launch(TimeSpan.Zero, this.StoryboardLogoFadeIn);
            Utility.Launch(TimeSpan.FromMilliseconds(200), this.StoryboardHeaderFadeIn);
            Utility.Launch(TimeSpan.FromMilliseconds(1), this.FirstTimeLoadStoryboard);
            
        }

        public static Root Instance
        {
            get { return instance; }
        }

        void SetPageTitle(string title)
        {
            (this.PageTitleViewbox.Child as TextBlock).Text = title;
        }

        void SwapPage(UserControl control)
        {
            this.MainArea.Opacity = 0;
            this.MainArea.Children.Clear();
            this.MainArea.Children.Add(control);
            this.StoryboardContentIn.Begin();
        }

        internal void Navigate(MenuType type)
        {
            this.Navigate(type, false);
        }

        internal void Navigate(MenuType type, bool gotoState)
        {
            switch (type)
            {
                case MenuType.Home:
                    this.SetPageTitle("Home");
                    this.SetActive(type);
                    this.SwapPage(new home());
                    break;
                case MenuType.Imprint:
                    this.SetPageTitle("Impressum");
                    this.SetActive(type);
                    this.SwapPage(new ImprintPage());
                    break;
                case MenuType.KopierService:
                    this.SetPageTitle("Kopierservice Werlsee");
                    if (gotoState)
                    {
                        VisualStateManager.GoToState(this.MenuKopierService, "MouseOver", true);
                    }
                    this.SetActive(type);
                    this.SwapPage(new KopierServicePage());
                    break;
                case MenuType.Wasserbau:
                    if (gotoState)
                    {
                        VisualStateManager.GoToState(this.MenuNbw, "MouseOver", true);
                    }
                    this.SetPageTitle("Niederbarnimer Wasserbau");
                    this.SetActive(type);
                    this.SwapPage(new WasserbauPage());
                    break;
                case MenuType.YachtCharter:
                    if (gotoState)
                    {
                        VisualStateManager.GoToState(this.MenuYachtCharter, "MouseOver", true);
                    }
                    this.SetPageTitle("Yachtcharter Süd/Ost");
                    this.SetActive(type);
                    this.SwapPage(new YachtCharterPage());
                    break;
                case MenuType.Contact:
                    this.SetPageTitle("Kontakt");
                    this.SetActive(type);
                    this.SwapPage(new ContactPage());
                    break;
                case MenuType.Services:
                    this.SetPageTitle("Übersicht");
                    this.SetActive(type);
                    this.SwapPage(new OverviewPage());
                    break;
                default:
                    break;
            }
        }

        void Freeze()
        {
            this.IsHitTestVisible = false;
        }

        void Unfreeze()
        {
            this.IsHitTestVisible = true;
        }

        private void ButtonHome_Click(object sender, RoutedEventArgs e)
        {
            Navigate(MenuType.Home);
        }

        private void ButtonServices_Click(object sender, RoutedEventArgs e)
        {
            Navigate(MenuType.Services);
        }

        private void ButtonContact_Click(object sender, RoutedEventArgs e)
        {
            Navigate(MenuType.Contact);
        }

        private void ButtonImprint_Click(object sender, RoutedEventArgs e)
        {
            Navigate(MenuType.Imprint);
        }

        Grid MainArea
        {
            get { return this.AnimatedContentGridIn; }
        }

        private void MenuNbw_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Navigate(MenuType.Wasserbau);
        }

        private void MenuYachtCharter_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Navigate(MenuType.YachtCharter);
        }

        private void MenuKopierService_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Navigate(MenuType.KopierService);
        }

        void SetActive(MenuType type)
        {
            switch (type)
            {
                case MenuType.Home:
                    this.MenuKopierService.IsActive = false;
                    this.MenuYachtCharter.IsActive = false;
                    this.MenuNbw.IsActive = false;
                    break;
                case MenuType.Imprint:
                    this.MenuKopierService.IsActive = false;
                    this.MenuYachtCharter.IsActive = false;
                    this.MenuNbw.IsActive = false;
                    break;
                case MenuType.KopierService:
                    this.MenuKopierService.IsActive = true;
                    this.MenuYachtCharter.IsActive = false;
                    this.MenuNbw.IsActive = false;
                    break;
                case MenuType.Wasserbau:
                    this.MenuKopierService.IsActive = false;
                    this.MenuYachtCharter.IsActive = false;
                    this.MenuNbw.IsActive = true;
                    break;
                case MenuType.YachtCharter:
                    this.MenuKopierService.IsActive = false;
                    this.MenuYachtCharter.IsActive = true;
                    this.MenuNbw.IsActive = false;
                    break;
                case MenuType.Contact:
                    this.MenuKopierService.IsActive = false;
                    this.MenuYachtCharter.IsActive = false;
                    this.MenuNbw.IsActive = false;
                    break;
                case MenuType.Services:
                    this.MenuKopierService.IsActive = false;
                    this.MenuYachtCharter.IsActive = false;
                    this.MenuNbw.IsActive = false;
                    break;
                default:
                    break;
            }
            this.SetNavigationActive(type);
        }

        void SetNavigationActive(MenuType type)
        {
            switch (type)
            {
                case MenuType.Home:
                    this.ButtonHome.IsHitTestVisible = false;
                    VisualStateManager.GoToState(this.ButtonHome, "MouseOver", true);
                    this.ButtonServices.IsHitTestVisible = true;
                    VisualStateManager.GoToState(this.ButtonServices, "Normal", true);
                    this.ButtonImprint.IsHitTestVisible = true;
                    VisualStateManager.GoToState(this.ButtonImprint, "Normal", true);
                    this.ButtonContact.IsHitTestVisible = true;
                    VisualStateManager.GoToState(this.ButtonContact, "Normal", true);
                    break;
                case MenuType.Imprint:
                    this.ButtonHome.IsHitTestVisible = true;
                    VisualStateManager.GoToState(this.ButtonHome, "Normal", true);
                    this.ButtonServices.IsHitTestVisible = true;
                    VisualStateManager.GoToState(this.ButtonServices, "Normal", true);
                    this.ButtonImprint.IsHitTestVisible = false;
                    VisualStateManager.GoToState(this.ButtonImprint, "MouseOver", true);
                    this.ButtonContact.IsHitTestVisible = true;
                    VisualStateManager.GoToState(this.ButtonContact, "Normal", true);
                    break;
                //case MenuType.KopierService:
                //    this.SetNavigationActive(MenuType.Services);
                //    break;
                //case MenuType.Wasserbau:
                //    this.SetNavigationActive(MenuType.Services);
                //    break;
                //case MenuType.YachtCharter:
                //    this.SetNavigationActive(MenuType.Services);
                //    break;
                case MenuType.Contact:
                    this.ButtonHome.IsHitTestVisible = true;
                    VisualStateManager.GoToState(this.ButtonHome, "Normal", true);
                    this.ButtonServices.IsHitTestVisible = true;
                    VisualStateManager.GoToState(this.ButtonServices, "Normal", true);
                    this.ButtonImprint.IsHitTestVisible = true;
                    VisualStateManager.GoToState(this.ButtonImprint, "Normal", true);
                    this.ButtonContact.IsHitTestVisible = false;
                    VisualStateManager.GoToState(this.ButtonContact, "MouseOver", true);
                    break;
                case MenuType.Services:
                    this.ButtonHome.IsHitTestVisible = true;
                    VisualStateManager.GoToState(this.ButtonHome, "Normal", true);
                    this.ButtonServices.IsHitTestVisible = false;
                    VisualStateManager.GoToState(this.ButtonServices, "MouseOver", true);
                    this.ButtonImprint.IsHitTestVisible = true;
                    VisualStateManager.GoToState(this.ButtonImprint, "Normal", true);
                    this.ButtonContact.IsHitTestVisible = true;
                    VisualStateManager.GoToState(this.ButtonContact, "Normal", true);
                    break;
                default:
                    this.ButtonHome.IsHitTestVisible = true;
                    VisualStateManager.GoToState(this.ButtonHome, "Normal", true);
                    this.ButtonServices.IsHitTestVisible = true;
                    VisualStateManager.GoToState(this.ButtonServices, "Normal", true);
                    this.ButtonImprint.IsHitTestVisible = true;
                    VisualStateManager.GoToState(this.ButtonImprint, "Normal", true);
                    this.ButtonContact.IsHitTestVisible = true;
                    VisualStateManager.GoToState(this.ButtonContact, "Normal", true);
                    break;
            }
        }
	}
}