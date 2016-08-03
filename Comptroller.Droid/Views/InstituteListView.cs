using Android.App;
using Android.OS;
using Comptroller.Droid.Resources;
using MvvmCross.Droid.Views;

namespace Comptroller.Droid.Views
{
    [Activity(Label = "Institutes")]
    public class InstituteListView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.InstituteListView);
        }
    }
}
