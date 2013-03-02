using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace Aquapool.Nbw
{
    [ContentProperty("Content")]
    public sealed class MenuPanel : Control
    {
        public static readonly DependencyProperty IsActiveProperty =
            DependencyProperty.Register("IsActive", typeof (bool), typeof (MenuPanel),
                                        new PropertyMetadata(OnActiveStateChanged));

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof (string), typeof (MenuPanel), null);

        public static readonly DependencyProperty ContentProperty =
            DependencyProperty.Register("Content", typeof (Grid), typeof (MenuPanel), null);

        public MenuPanel()
        {
            IsLast = false;
            IsActive = false;
            DefaultStyleKey = GetType();
            MouseEnter += MenuPanel_MouseEnter;
            MouseLeave += MenuPanel_MouseLeave;
        }

        public bool IsActive
        {
            get { return (bool) GetValue(IsActiveProperty); }
            set { SetValue(IsActiveProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsActive.  This enables animation, styling, binding, etc...

        public string Title
        {
            get { return (string) GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...

        public bool IsLast { get; set; }

        public Grid Content
        {
            get { return (Grid) GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }

        private void MenuPanel_MouseLeave(object sender, MouseEventArgs e)
        {
            if (!IsActive)
            {
                VisualStateManager.GoToState(this, "MouseOut", true);
            }
        }

        private void MenuPanel_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!IsActive)
            {
                VisualStateManager.GoToState(this, "MouseOver", true);
            }
        }

        private static void OnActiveStateChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var menu = sender as MenuPanel;
            var active = (bool) e.NewValue;
            if (!active)
            {
                VisualStateManager.GoToState(menu, "MouseOut", true);
            }
        }

        // Using a DependencyProperty as the backing store for Content.  This enables animation, styling, binding, etc...
    }
}
