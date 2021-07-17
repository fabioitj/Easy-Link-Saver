using Android.Content;
using Android.Gms.Ads;
using App.Class;
using App.Droid.Class;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(AdBanner), typeof(AdBanner_Droid))]
namespace App.Droid.Class
{
    public class AdBanner_Droid : ViewRenderer
    {
        Context context;
        public AdBanner_Droid(Context _context) : base(_context)
        {
            context = _context;
        }
        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            int heightPixels = 0;

            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                var adView = new AdView(Context);
                switch ((Element as AdBanner).Size)
                {
                    case AdBanner.Sizes.Standardbanner:
                        adView.AdSize = AdSize.Banner;
                        heightPixels =  AdSize.Banner.GetHeightInPixels(Context);
                        break;
                    case AdBanner.Sizes.LargeBanner:
                        adView.AdSize = AdSize.LargeBanner;
                        heightPixels = AdSize.LargeBanner.GetHeightInPixels(Context);
                        break;
                    case AdBanner.Sizes.MediumRectangle:
                        adView.AdSize = AdSize.MediumRectangle;
                        heightPixels = AdSize.MediumRectangle.GetHeightInPixels(Context);
                        break;
                    case AdBanner.Sizes.FullBanner:
                        adView.AdSize = AdSize.FullBanner;
                        heightPixels = AdSize.FullBanner.GetHeightInPixels(Context);
                        break;
                    case AdBanner.Sizes.Leaderboard:
                        adView.AdSize = AdSize.Leaderboard;
                        heightPixels = AdSize.Leaderboard.GetHeightInPixels(Context);
                        break;
                    default:
                        adView.AdSize = AdSize.Banner;
                        heightPixels = AdSize.Banner.GetHeightInPixels(Context);
                        break;
                }
                // TODO: change this id to your admob id  
                adView.AdUnitId = "ca-app-pub-3940256099942544/6300978111";
                AdRequest.Builder requestbuilder = new AdRequest.Builder();
                adView.SetMinimumHeight(heightPixels);
                adView.LoadAd(requestbuilder.Build());
                SetNativeControl(adView);
            }
        }
    }
}