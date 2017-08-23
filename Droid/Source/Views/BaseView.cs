using Android.Content;
using Android.OS;
using KulGen.Source.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Views;

namespace KulGen.Droid.Source.Views
{
    public abstract class BaseView : MvxActivity
    {
		protected abstract int LayoutResId { get; }

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate (bundle);

			if (!Setup.SetupComplete.Value){
				var intent = new Intent(this, typeof(SplashScreen));
				StartActivity(intent);
				Finish();
				return;
			}

			//Set the layout to the view
			if (LayoutResId > 0) SetContentView(LayoutResId);

			//This allows the smooth transition between screens
			//OverridePendingTransition(0, 0);

			SetupView();
		}

		protected virtual void SetupView() { }
	}

	public abstract class BaseView<TViewModel> : BaseView
		where TViewModel : class, IMvxViewModel
	{
		public new TViewModel ViewModel
		{
			get { return (TViewModel)base.ViewModel; }
			set
			{
				base.ViewModel = value;
			}
		}
	}

	public abstract class BaseView<TView, TViewModel> : BaseView<TViewModel>
		where TViewModel : class, IMvxViewModel
		where TView : class, IMvxBindingContextOwner
	{

		protected override void SetupView()
		{
			base.SetupView();

			OnInitializeComponents();

			var bindingSet = (this as TView).CreateBindingSet<TView, TViewModel>();
			SetupBindings(bindingSet);
			bindingSet.Apply();
		}

		// Used to initialize UI 
		protected virtual void OnInitializeComponents() { }

		//Set up the Mvvm Bindings
		protected abstract void SetupBindings(MvxFluentBindingDescriptionSet<TView, TViewModel> bindingSet);
	}
}
