using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace MyTM
{
    public class BasePage: UserControl
    {
        private TranslateTransform CurTranslate;
        private DoubleAnimation XAnim;
        private DoubleAnimation OpacityAnim;
        private double OriginX = 50;

        public BasePage()
        {
            CurTranslate = new TranslateTransform();
            CurTranslate.X = OriginX;
            RenderTransform = CurTranslate;
            Opacity = 0;
            XAnim = new DoubleAnimation(0, TimeSpan.FromSeconds(0.3));
            XAnim.EasingFunction = new ExponentialEase() { EasingMode = EasingMode.EaseOut };
            OpacityAnim = new DoubleAnimation(1, TimeSpan.FromSeconds(0.2));

            Loaded += BasePageLoaded;
            Unloaded += BasePageUnloaded;
        }

        private void BasePageUnloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            CurTranslate.BeginAnimation(TranslateTransform.XProperty, null);
            BeginAnimation(UIElement.OpacityProperty, null);

            CurTranslate.X = OriginX;
            Opacity = 0;
        }

        private void BasePageLoaded(object sender, System.Windows.RoutedEventArgs e)
        {
            CurTranslate.BeginAnimation(TranslateTransform.XProperty, XAnim);
            BeginAnimation(UIElement.OpacityProperty, OpacityAnim);
        }
    }
}
