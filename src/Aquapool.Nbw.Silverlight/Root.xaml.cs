using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Aquapool.Nbw
{
    public partial class Root
    {
        private static readonly Root instance = new Root();

        public Root()
        {
            // Required to initialize variables
            InitializeComponent();
            InitializeControls();
            // HACK: Viewbox does not publish it's children
            InitializeNavigationButtons();
            Loaded += Root_Loaded;
            Application.Current.Host.Content.Resized += Content_Resized;
        }

        public static Root Instance
        {
            get { return instance; }
        }

        private Grid MainArea
        {
            get { return AnimatedContentGridIn; }
        }

        private void InitializeNavigationButtons()
        {
            var child = (StackPanel)NavigationViewbox.Child;
            ButtonHome = child.Children[0] as Button;
            ButtonServices = child.Children[2] as Button;
            ButtonContact = child.Children[4] as Button;
            ButtonImprint = child.Children[6] as Button;
        }

        private void Resize()
        {
            // height 910 / 900
            VisualBorder.Height = Application.Current.Host.Content.ActualHeight;
            VisualBorder.Width = Application.Current.Host.Content.ActualHeight*0.989010989;
        }

        private void Content_Resized(object sender, EventArgs e)
        {
            Resize();
        }

        private void InitializeControls()
        {
            HeaderGrid.Opacity = 0;
            LogoGrid.Opacity = 0;
        }

        private void Root_Loaded(object sender, RoutedEventArgs e)
        {
#if DEBUG
            Debug.WriteLine("Fading in controls");
#endif
            FirstTimeLoadStoryboard.Completed += delegate { Navigate(MenuType.Home); };
            Utility.Launch(TimeSpan.Zero, StoryboardLogoFadeIn);
            Utility.Launch(TimeSpan.FromMilliseconds(200), StoryboardHeaderFadeIn);
            Utility.Launch(TimeSpan.FromMilliseconds(1), FirstTimeLoadStoryboard);
        }

        private void SetPageTitle(string title)
        {
            ((TextBlock)PageTitleViewbox.Child).Text = title;
        }

        private void SwapPage(UserControl control)
        {
            MainArea.Opacity = 0;
            MainArea.Children.Clear();
            MainArea.Children.Add(control);
            StoryboardContentIn.Begin();
        }

        internal void Navigate(MenuType type)
        {
            Navigate(type, false);
        }

        internal void Navigate(MenuType type, bool gotoState)
        {
            switch (type)
            {
                case MenuType.Home:
                    SetPageTitle("Home");
                    SetActive(type);
                    SwapPage(new home());
                    break;
                case MenuType.Imprint:
                    SetPageTitle("Impressum");
                    SetActive(type);
                    SwapPage(new ImprintPage());
                    break;
                case MenuType.KopierService:
                    SetPageTitle("Kopierservice Werlsee");
                    if (gotoState)
                    {
                        VisualStateManager.GoToState(MenuKopierService, "MouseOver", true);
                    }
                    SetActive(type);
                    SwapPage(new KopierServicePage());
                    break;
                case MenuType.Wasserbau:
                    if (gotoState)
                    {
                        VisualStateManager.GoToState(MenuNbw, "MouseOver", true);
                    }
                    SetPageTitle("Niederbarnimer Wasserbau");
                    SetActive(type);
                    SwapPage(new WasserbauPage());
                    break;
                case MenuType.YachtCharter:
                    if (gotoState)
                    {
                        VisualStateManager.GoToState(MenuYachtCharter, "MouseOver", true);
                    }
                    SetPageTitle("Yachtcharter Süd/Ost");
                    SetActive(type);
                    SwapPage(new YachtCharterPage());
                    break;
                case MenuType.Contact:
                    SetPageTitle("Kontakt");
                    SetActive(type);
                    SwapPage(new ContactPage());
                    break;
                case MenuType.Services:
                    SetPageTitle("Übersicht");
                    SetActive(type);
                    SwapPage(new OverviewPage());
                    break;
                default:
                    break;
            }
        }

        private void Freeze()
        {
            IsHitTestVisible = false;
        }

        private void Unfreeze()
        {
            IsHitTestVisible = true;
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

        private void SetActive(MenuType type)
        {
            switch (type)
            {
                case MenuType.Home:
                    MenuKopierService.IsActive = false;
                    MenuYachtCharter.IsActive = false;
                    MenuNbw.IsActive = false;
                    break;
                case MenuType.Imprint:
                    MenuKopierService.IsActive = false;
                    MenuYachtCharter.IsActive = false;
                    MenuNbw.IsActive = false;
                    break;
                case MenuType.KopierService:
                    MenuKopierService.IsActive = true;
                    MenuYachtCharter.IsActive = false;
                    MenuNbw.IsActive = false;
                    break;
                case MenuType.Wasserbau:
                    MenuKopierService.IsActive = false;
                    MenuYachtCharter.IsActive = false;
                    MenuNbw.IsActive = true;
                    break;
                case MenuType.YachtCharter:
                    MenuKopierService.IsActive = false;
                    MenuYachtCharter.IsActive = true;
                    MenuNbw.IsActive = false;
                    break;
                case MenuType.Contact:
                    MenuKopierService.IsActive = false;
                    MenuYachtCharter.IsActive = false;
                    MenuNbw.IsActive = false;
                    break;
                case MenuType.Services:
                    MenuKopierService.IsActive = false;
                    MenuYachtCharter.IsActive = false;
                    MenuNbw.IsActive = false;
                    break;
                default:
                    break;
            }
            SetNavigationActive(type);
        }

        private void SetNavigationActive(MenuType type)
        {
            switch (type)
            {
                case MenuType.Home:
                    ButtonHome.IsHitTestVisible = false;
                    VisualStateManager.GoToState(ButtonHome, "MouseOver", true);
                    ButtonServices.IsHitTestVisible = true;
                    VisualStateManager.GoToState(ButtonServices, "Normal", true);
                    ButtonImprint.IsHitTestVisible = true;
                    VisualStateManager.GoToState(ButtonImprint, "Normal", true);
                    ButtonContact.IsHitTestVisible = true;
                    VisualStateManager.GoToState(ButtonContact, "Normal", true);
                    break;
                case MenuType.Imprint:
                    ButtonHome.IsHitTestVisible = true;
                    VisualStateManager.GoToState(ButtonHome, "Normal", true);
                    ButtonServices.IsHitTestVisible = true;
                    VisualStateManager.GoToState(ButtonServices, "Normal", true);
                    ButtonImprint.IsHitTestVisible = false;
                    VisualStateManager.GoToState(ButtonImprint, "MouseOver", true);
                    ButtonContact.IsHitTestVisible = true;
                    VisualStateManager.GoToState(ButtonContact, "Normal", true);
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
                    ButtonHome.IsHitTestVisible = true;
                    VisualStateManager.GoToState(ButtonHome, "Normal", true);
                    ButtonServices.IsHitTestVisible = true;
                    VisualStateManager.GoToState(ButtonServices, "Normal", true);
                    ButtonImprint.IsHitTestVisible = true;
                    VisualStateManager.GoToState(ButtonImprint, "Normal", true);
                    ButtonContact.IsHitTestVisible = false;
                    VisualStateManager.GoToState(ButtonContact, "MouseOver", true);
                    break;
                case MenuType.Services:
                    ButtonHome.IsHitTestVisible = true;
                    VisualStateManager.GoToState(ButtonHome, "Normal", true);
                    ButtonServices.IsHitTestVisible = false;
                    VisualStateManager.GoToState(ButtonServices, "MouseOver", true);
                    ButtonImprint.IsHitTestVisible = true;
                    VisualStateManager.GoToState(ButtonImprint, "Normal", true);
                    ButtonContact.IsHitTestVisible = true;
                    VisualStateManager.GoToState(ButtonContact, "Normal", true);
                    break;
                default:
                    ButtonHome.IsHitTestVisible = true;
                    VisualStateManager.GoToState(ButtonHome, "Normal", true);
                    ButtonServices.IsHitTestVisible = true;
                    VisualStateManager.GoToState(ButtonServices, "Normal", true);
                    ButtonImprint.IsHitTestVisible = true;
                    VisualStateManager.GoToState(ButtonImprint, "Normal", true);
                    ButtonContact.IsHitTestVisible = true;
                    VisualStateManager.GoToState(ButtonContact, "Normal", true);
                    break;
            }
        }

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
    }
}
