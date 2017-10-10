using KulGen.ViewModels;
using MvvmCross.Binding.BindingContext;

namespace KulGen.Droid.Views
{
	public abstract class NavigationBarView<TView, TViewModel> : BaseView<TView, TViewModel>
        where TView : class, IMvxBindingContextOwner
        where TViewModel : NavigationBarViewModel
	{
		//Will eventually have links to other screens

        protected override void OnInitializeComponents()
		{
      	}

        protected override void SetupBindings(MvxFluentBindingDescriptionSet<TView, TViewModel> bindingSet)
		{
        }
    }
}
