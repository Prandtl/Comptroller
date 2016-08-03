using Android.App;
using Android.Content.PM;
using Comptroller.Droid.Resources;
using MvvmCross.Droid.Views;

namespace Comptroller.Droid
{
    [Activity(
        Label = "Comptroller"
        , MainLauncher = true
        , Icon = "@drawable/icon"
        , Theme = "@style/Theme.Splash"
        , NoHistory = true
        , ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : MvxSplashScreenActivity
    {
        public SplashScreen()
            : base(Resource.Layout.SplashScreen)
        {
        }
    }
}
