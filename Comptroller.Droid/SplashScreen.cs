using Acr.UserDialogs;
using Android.App;
using Android.Content.PM;
using Android.OS;
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

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);


			UserDialogs.Init(this);
		}
	}
}
