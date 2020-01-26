using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Shapes;

namespace KHSave.SaveEditor.Views
{
    /// <summary>
    /// Interaction logic for PatronView.xaml
    /// </summary>
    public partial class PatronView : UserControl
    {
        private readonly double remainHiddenSeconds;
        private readonly bool glow;

        public PatronView() :
            this(0.0, false)
        { }

        public PatronView(double remainHiddenSeconds, bool glow)
        {
            InitializeComponent();
            this.remainHiddenSeconds = remainHiddenSeconds;
            this.glow = glow;
            Opacity = 0.0;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (glow)
            {
                glowEffect.BeginAnimation(DropShadowEffect.OpacityProperty, new DoubleAnimation
                {
                    From = 0.0,
                    To = 1.0,
                    EasingFunction = new CircleEase(),
                    Duration = new Duration(TimeSpan.FromSeconds(1)),
                    RepeatBehavior = RepeatBehavior.Forever,
                    AutoReverse = true
                });

                lightGlow.BeginAnimation(Ellipse.OpacityProperty, new DoubleAnimation
                {
                    From = 0.0,
                    To = 1.0,
                    EasingFunction = new CircleEase(),
                    Duration = new Duration(TimeSpan.FromSeconds(1)),
                    RepeatBehavior = RepeatBehavior.Forever,
                    AutoReverse = true
                });
            }

            BeginAnimation(OpacityProperty, new DoubleAnimation
            {
                From = 0.0,
                To = 1.0,
                EasingFunction = new CubicEase(),
                Duration = new Duration(TimeSpan.FromSeconds(0.5 + Math.Sqrt(remainHiddenSeconds / 2.0))),
                BeginTime = TimeSpan.FromSeconds(remainHiddenSeconds)
            });
        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}
