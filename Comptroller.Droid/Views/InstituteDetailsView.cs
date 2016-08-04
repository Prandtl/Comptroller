using Acr.UserDialogs;
using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;

namespace Comptroller.Droid.Views
{
	[Activity(Label = "Institutes")]
	public class InstituteDetailsView : MvxActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.InstituteDetailsView);


			UserDialogs.Init(this);
		}
	}
}
