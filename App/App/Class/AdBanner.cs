using Xamarin.Forms;

namespace App.Class
{
    public class AdBanner: View
    {
        public enum Sizes { Standardbanner, LargeBanner, MediumRectangle, FullBanner, Leaderboard, SmartBannerPortrait }
        public Sizes Size { get; set; }
        public AdBanner()
        {
            //BackgroundColor = Color.Accent;
        }
    }
}