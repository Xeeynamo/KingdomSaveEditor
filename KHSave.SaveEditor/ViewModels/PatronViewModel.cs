using KHSave.SaveEditor.Models;
using System;
using System.Net.Cache;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace KHSave.SaveEditor.ViewModels
{
    public class PatronViewModel
    {
        public PatronViewModel(PatronModel patron)
        {
            Brush = GetColor(patron.Color);
            Name = patron.Name;
            //ImageUrl = patron.PhotoUrl;
            //BadgeUrl = patron.BadgeUrl;
            ProfileUrl = patron.ProfileUrl;

            if (!IsImageEmpty || !IsBadgeEmpty)
            {
                ImageSource = new BitmapImage();
                ImageSource.BeginInit();

                ImageSource.DecodePixelWidth = 64; // Arbitrary, does not respect DPI
                ImageSource.CacheOption = BitmapCacheOption.OnDemand;
                ImageSource.CreateOptions = BitmapCreateOptions.DelayCreation;
                ImageSource.UriCachePolicy = new RequestCachePolicy(RequestCacheLevel.CacheIfAvailable);
                ImageSource.UriSource = new Uri(IsImageEmpty ? BadgeUrl : ImageUrl);

                ImageSource.EndInit();
            }

            BorderColor = IsStandardBadge ? new SolidColorBrush(Colors.Black) : Brush;
        }

        public Brush Brush { get; }
        public Brush BorderColor { get; }
        public string Name { get; }
        public string ImageUrl { get; }
        public string BadgeUrl { get; }
        public string ProfileUrl { get; }
        public BitmapImage ImageSource { get; }

        public Visibility ImageVisibility => IsImageEmpty ? Visibility.Collapsed : Visibility.Visible;
        public Visibility BadgeVisibility => IsBadgeEmpty ? Visibility.Collapsed : Visibility.Visible;
        public Visibility BorderVisibility => IsBadgeEmpty ? Visibility.Visible : Visibility.Collapsed;
        public Visibility NormalLabelVisibility => IsProfileUrlEmpty ? Visibility.Visible : Visibility.Collapsed;
        public Visibility ProfileLinkVisibility => IsProfileUrlEmpty ? Visibility.Collapsed : Visibility.Visible;

        private bool IsStandardBadge => IsImageEmpty && IsBadgeEmpty;
        private bool IsImageEmpty => string.IsNullOrWhiteSpace(ImageUrl);
        private bool IsBadgeEmpty => string.IsNullOrWhiteSpace(BadgeUrl);
        private bool IsProfileUrlEmpty => string.IsNullOrWhiteSpace(ProfileUrl);

        private static SolidColorBrush GetColor(string color)
        {
            if (string.IsNullOrWhiteSpace(color) ||
                color[0] != '#')
                return new SolidColorBrush(Colors.Red);

            return new BrushConverter().ConvertFromString(color) as SolidColorBrush;
        }
    }
}
