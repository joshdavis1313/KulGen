using System;
using Android.OS;
using Android.Views;
using KulGen.Source.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.FullFragging.Fragments;

namespace KulGen.Droid.Source.Views.Dialogs
{
	public abstract class BaseDialogFragment : MvxDialogFragment
	{
		protected abstract int LayoutId { get; }
		protected BaseViewModel baseViewModel => ViewModel as BaseViewModel;

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			base.OnCreateView(inflater, container, savedInstanceState);
			Dialog.RequestWindowFeature((int)WindowFeatures.NoTitle);
			return this.BindingInflate(LayoutId, null);
		}
	}

	public abstract class BaseDialogFragment<TViewModel> : BaseDialogFragment where TViewModel : class, IMvxViewModel
	{
		public new TViewModel ViewModel
		{
			get { return (TViewModel)base.ViewModel; }
			set { base.ViewModel = value; }
		}
	}

	public abstract class BaseDialogFragment<TView, TViewModel> : BaseDialogFragment<TViewModel>
		where TView : class, IMvxBindingContextOwner
		where TViewModel : class, IMvxViewModel
	{
		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			var view = base.OnCreateView(inflater, container, savedInstanceState);
			OnInitializeComponents(view);
			return view;
		}

		public override void OnViewCreated(View view, Bundle savedInstanceState)
		{
			base.OnViewCreated(view, savedInstanceState);

			var bindingSet = (this as TView).CreateBindingSet<TView, TViewModel>();
			SetupBindings(bindingSet, view);
			bindingSet.Apply();
		}

		protected abstract void OnInitializeComponents(View view);

		protected abstract void SetupBindings(MvxFluentBindingDescriptionSet<TView, TViewModel> bindingSet, View view);
	}
}
