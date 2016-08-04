using Acr.UserDialogs;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;

namespace Comptroller.Core
{
	public class App : MvvmCross.Core.ViewModels.MvxApplication
	{
		public override void Initialize()
		{
			CreatableTypes()
				.EndingWith("Service")
				.AsInterfaces()
				.RegisterAsLazySingleton();

			CreatableTypes()
				.EndingWith("Repository")
				.AsInterfaces()
				.RegisterAsLazySingleton();

			CreatableTypes()
				.EndingWith("DataManager")
				.AsInterfaces()
				.RegisterAsLazySingleton();

			Mvx.RegisterSingleton<IUserDialogs>(() => UserDialogs.Instance);

			RegisterAppStart<ViewModels.InstituteListViewModel>();
		}
	}
}
