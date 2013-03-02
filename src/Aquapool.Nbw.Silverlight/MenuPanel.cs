using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Windows.Markup;
using System.ComponentModel;

namespace Nbw
{
    [ContentProperty("Content")]
    public sealed class MenuPanel : Control
    {
        public MenuPanel()
        {
            this.IsLast = false;
            this.IsActive = false;
            this.DefaultStyleKey = this.GetType();
            this.MouseEnter += new MouseEventHandler(MenuPanel_MouseEnter);
            this.MouseLeave += new MouseEventHandler(MenuPanel_MouseLeave);
        }

        void MenuPanel_MouseLeave(object sender, MouseEventArgs e)
        {
            if (!IsActive)
            {
                VisualStateManager.GoToState(this, "MouseOut", true);
            }
        }

        void MenuPanel_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!IsActive)
            {
                VisualStateManager.GoToState(this, "MouseOver", true);
            }
        }

        public bool IsActive
        {
            get { return (bool)GetValue(IsActiveProperty); }
            set { SetValue(IsActiveProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsActive.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsActiveProperty =
            DependencyProperty.Register("IsActive", typeof(bool), typeof(MenuPanel), new PropertyMetadata(new PropertyChangedCallback(OnActiveStateChanged)));

        static  void OnActiveStateChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var menu = sender as MenuPanel;
            var active = (bool)e.NewValue;
            if (!active)
            {
                VisualStateManager.GoToState(menu, "MouseOut", true);
            }
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(MenuPanel), null);

        [TypeConverter(typeof(StringToBoolConverter))]
        public bool IsLast { get; set; }

        public Grid Content
        {
            get { return (Grid)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Content.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContentProperty =
            DependencyProperty.Register("Content", typeof(Grid), typeof(MenuPanel), null);
    }
}
